using Estapar.Web.Models;
using Estapar.Web.Notification;
using Estapar.Web.Service;
using System;
using System.Web.Mvc;

namespace Estapar.Web.Controllers
{
    public class ValetParkingVehicleController : BaseController
    {
        protected ValetParkingVehicleService _service;
        public ValetParkingVehicleController()
        {
            _service = new ValetParkingVehicleService();
        }

        public ActionResult Index(string msg = null, string notificationType = NotificationType.SUCCESS)
        {
            if (!string.IsNullOrEmpty(msg))
                this.AddNotification(msg, notificationType);
            var list = _service.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            LoadLists();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ValetParkingVehicleViewModel viewModel)
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
            LoadLists();
            return View();
        }

        public ActionResult ConfirmDelete(int id)
        {
            var model = _service.GetDetail(id);
            return PartialView("_Message", model);
        }

        public ActionResult Delete(int id)
        {
            ValetParkingVehicleViewModel viewModel = new ValetParkingVehicleViewModel();
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
            LoadLists();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ValetParkingVehicleViewModel viewModel)
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

        public void LoadLists()
        {
            VehicleService vehicleService = new VehicleService();

            var vehicleList = vehicleService.GetActives();

            SelectList selectVehicleList = new SelectList(vehicleList, "Id", "VehicleLicensePlate");
            ViewBag.VehiclelList = selectVehicleList;

            vehicleService = null;

            ValetParkingService valetParkingService = new ValetParkingService();

            var valetList = valetParkingService.GetActives();

            SelectList selectValetList = new SelectList(valetList, "Id", "Name");
            ViewBag.ValetParkingList = selectValetList;

            valetParkingService = null;
        }
    }
}