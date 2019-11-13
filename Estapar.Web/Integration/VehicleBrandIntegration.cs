using Estapar.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Estapar.Web.Integration
{
    public class VehicleBrandIntegration : BaseIntegration
    {
        public IEnumerable<VehicleBrandViewModel> GetAll()
        {
            string address = "vehicle-brand/get";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<IEnumerable<VehicleBrandViewModel>>(result);
            }
            return null;
        }

        public IEnumerable<VehicleBrandViewModel> GetActives()
        {
            string address = "vehicle-brands/get-active";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<IEnumerable<VehicleBrandViewModel>>(result);
            }
            return null;
        }

        public VehicleBrandViewModel Get(int id)
        {
            string address = $"vehicle-brand/get/{id}";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<VehicleBrandViewModel>(result);
            }
            return null;
        }

        public bool Delete(VehicleBrandViewModel viewModel)
        {
            string address = "vehicle-brand/delete";
            string result = this.Post<VehicleBrandViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool HasAssociation(VehicleBrandViewModel viewModel)
        {
            string address = "vehicle-brand/has-association";
            string result = this.Post<VehicleBrandViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool Insert(VehicleBrandViewModel viewModel)
        {
            string address = "vehicle-brand/insert";
            string result = this.Post<VehicleBrandViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool NameExists(VehicleBrandViewModel viewModel)
        {
            string address = "vehicle-brand/get-by-name";
            string result = this.Post<VehicleBrandViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool Update(VehicleBrandViewModel viewModel)
        {
            string address = "vehicle-brand/update";
            string result = this.Post<VehicleBrandViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }
    }
}