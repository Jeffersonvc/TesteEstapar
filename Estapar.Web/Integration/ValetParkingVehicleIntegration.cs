using Estapar.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Estapar.Web.Integration
{
    public class ValetParkingVehicleIntegration : BaseIntegration
    {
        public IEnumerable<ValetParkingVehicleDetailViewModel> GetAll()
        {
            string address = "valet-parking-vehicle-detail/get";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<IEnumerable<ValetParkingVehicleDetailViewModel>>(result);
            }
            return null;
        }

        public IEnumerable<ValetParkingVehicleDetailViewModel> GetActives()
        {
            string address = "valet-parking-vehicle-detail/get";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<IEnumerable<ValetParkingVehicleDetailViewModel>>(result);
            }
            return null;
        }

        public ValetParkingVehicleViewModel Get(int id)
        {
            string address = $"valet-parking-vehicle/get/{id}";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<ValetParkingVehicleViewModel>(result);
            }
            return null;
        }

        public ValetParkingVehicleDetailViewModel GetDetail(int id)
        {
            string address = $"valet-parking-vehicle-detail/get/{id}";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<ValetParkingVehicleDetailViewModel>(result);
            }
            return null;
        }

        public bool Delete(ValetParkingVehicleViewModel viewModel)
        {
            string address = "valet-parking-vehicle/delete";
            string result = this.Post<ValetParkingVehicleViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool Insert(ValetParkingVehicleViewModel viewModel)
        {
            string address = "valet-parking-vehicle/insert";
            string result = this.Post<ValetParkingVehicleViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool Update(ValetParkingVehicleViewModel viewModel)
        {
            string address = "valet-parking-vehicle/update";
            string result = this.Post<ValetParkingVehicleViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }
    }
}