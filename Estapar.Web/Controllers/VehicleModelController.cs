using Estapar.Web.Models;
using Estapar.Web.Notification;
using Estapar.Web.Service;
using System;
using System.Web.Mvc;

namespace Estapar.Web.Controllers
{
    public class VehicleModelController : BaseController
    {
        protected VehicleModelService _service;
        public VehicleModelController()
        {
            _service = new VehicleModelService();
        }
        // GET: VehicleModel
        public ActionResult Index(string msg = null, string notificationType = NotificationType.SUCCESS)
        {
            if (!string.IsNullOrEmpty(msg))
                this.AddNotification(msg, notificationType);
            var list = _service.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            LoadBrandList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(VehicleModelViewModel viewModel)
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
            LoadBrandList();

            return View();
        }

        public ActionResult ConfirmDelete(int id)
        {
            var model = _service.Get(id);
            return PartialView("_Message", model);
        }

        public ActionResult Delete(int id)
        {
            VehicleModelViewModel viewModel = new VehicleModelViewModel();
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
            LoadBrandList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(VehicleModelViewModel viewModel)
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
            LoadBrandList();

            return View();
        }

        private void LoadBrandList()
        {
            VehicleBrandService brandService = new VehicleBrandService();

            var brandList = brandService.GetActives();

            SelectList selectList = new SelectList(brandList, "Id", "Name");
            ViewBag.BrandList = selectList;

        }
    }
}