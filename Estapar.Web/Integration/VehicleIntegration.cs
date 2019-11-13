using Estapar.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estapar.Web.Integration
{
    public class VehicleIntegration : BaseIntegration
    {
        public IEnumerable<VehicleViewModel> GetAll()
        {
            string address = "vehicle/get";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<IEnumerable<VehicleViewModel>>(result);
            }
            return null;
        }

        public IEnumerable<VehicleViewModel> GetActives()
        {
            string address = "vehicle/get-active";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<IEnumerable<VehicleViewModel>>(result);
            }
            return null;
        }

        public VehicleViewModel Get(int id)
        {
            string address = $"vehicle/get/{id}";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<VehicleViewModel>(result);
            }
            return null;
        }

        public bool Delete(VehicleViewModel viewModel)
        {
            string address = "vehicle/delete";
            string result = this.Post<VehicleViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool HasAssociation(VehicleViewModel viewModel)
        {
            string address = "vehicle/has-association";
            string result = this.Post<VehicleViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool Insert(VehicleViewModel viewModel)
        {
            string address = "vehicle/insert";
            string result = this.Post<VehicleViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool PlateExists(string plate)
        {
            string address = $"vehicle/get-by-plate/{plate}";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool Update(VehicleViewModel viewModel)
        {
            string address = "vehicle/update";
            string result = this.Post<VehicleViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }
    }
}