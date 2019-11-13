using Estapar.Web.Models;
using Estapar.Web.Notification;
using Estapar.Web.Service;
using System;
using System.Web.Mvc;

namespace Estapar.Web.Controllers
{
    public class VehicleBrandController : BaseController
    {
        protected VehicleBrandService _service;
        public VehicleBrandController()
        {
            _service = new VehicleBrandService();
        }
        // GET: Brand
        public ActionResult Index(string msg = null, string notificationType = NotificationType.SUCCESS)
        {
            if (!string.IsNullOrEmpty(msg))
                this.AddNotification(msg, notificationType);
            var list = _service.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VehicleBrandViewModel viewModel)
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

            return View();
        }

        public ActionResult ConfirmDelete(int id)
        {
            var model = _service.Get(id);
            return PartialView("_Message", model);
        }

        public ActionResult Delete(int id)
        {
            VehicleBrandViewModel viewModel = new VehicleBrandViewModel();
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
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(VehicleBrandViewModel viewModel)
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

            return View();
        }
    }
}