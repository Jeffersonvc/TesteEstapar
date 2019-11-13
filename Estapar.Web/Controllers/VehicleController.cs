using Estapar.Web.Models;
using Estapar.Web.Notification;
using Estapar.Web.Service;
using System;
using System.Web.Mvc;

namespace Estapar.Web.Controllers
{
    public class VehicleController : BaseController
    {
        protected VehicleService _service;
        public VehicleController()
        {
            _service = new VehicleService();
        }
        // GET: Vehicle
        public ActionResult Index(string msg = null, string notificationType = NotificationType.SUCCESS)
        {
            if (!string.IsNullOrEmpty(msg))
                this.AddNotification(msg, notificationType);
            var list = _service.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            LoadModelList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(VehicleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                SetNotifications();
                return Create();
            }
            viewModel.InclusionDate = DateTime.Now;
            string msg = null;
            string notificationType = NotificationType.SUCCESS;
            var result = _service.Insert(viewModel);
            msg = result.Item2;
            if (!result.Item1)
                notificationType = NotificationType.ERROR;

            this.AddNotification(msg, notificationType);
            LoadModelList();

            return View();
        }

        public ActionResult ConfirmDelete(int id)
        {
            var model = _service.Get(id);
            return PartialView("_Message", model);
        }

        public ActionResult Delete(int id)
        {
            VehicleViewModel viewModel = new VehicleViewModel();
            viewModel.Id = id;
            string msg = null;
            string notificationType = NotificationType.SUCCESS;
            var result = _service.Delete(viewModel);
            msg = result.Item2;
            if (!result.Item1)
                notificationType = NotificationType.ERROR;

            return RedirectToAction("Index", new { msg = msg, notificationType = notificationType });

        }

        public ActionResult Edit(int id)
        {
            var model = _service.Get(id);
            LoadModelList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(VehicleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                SetNotifications();
                return Edit(viewModel.Id);
            }

            string msg = null;
            string notificationType = NotificationType.SUCCESS;
            var result = _service.Update(viewModel);
            msg = result.Item2;
            if (!result.Item1)
                notificationType = NotificationType.ERROR;

            this.AddNotification(msg, notificationType);
            LoadModelList();
            return View();
        }

        private void LoadModelList()
        {
            VehicleModelService modelService = new VehicleModelService();

            var modelList = modelService.GetActives();

            SelectList selectList = new SelectList(modelList, "Id", "Name");
            ViewBag.ModelList = selectList;

        }
    }
}