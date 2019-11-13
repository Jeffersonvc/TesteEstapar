using Estapar.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Estapar.Web.Integration
{
    public class VehicleModelIntegration : BaseIntegration
    {
        public IEnumerable<VehicleModelViewModel> GetAll()
        {
            string address = "vehicle-model/get";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<IEnumerable<VehicleModelViewModel>>(result);
            }
            return null;
        }

        public IEnumerable<VehicleModelViewModel> GetActives()
        {
            string address = "vehicle-model/get-active";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<IEnumerable<VehicleModelViewModel>>(result);
            }
            return null;
        }

        public VehicleModelViewModel Get(int id)
        {
            string address = $"vehicle-model/get/{id}";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<VehicleModelViewModel>(result);
            }
            return null;
        }

        public bool Delete(VehicleModelViewModel viewModel)
        {
            string address = "vehicle-model/delete";
            string result = this.Post<VehicleModelViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool HasAssociation(VehicleModelViewModel viewModel)
        {
            string address = "vehicle-model/has-association";
            string result = this.Post<VehicleModelViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool Insert(VehicleModelViewModel viewModel)
        {
            string address = "vehicle-model/insert";
            string result = this.Post<VehicleModelViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool NameExists(VehicleModelViewModel viewModel)
        {
            string address = "vehicle-model/get-by-name";
            string result = this.Post<VehicleModelViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool Update(VehicleModelViewModel viewModel)
        {
            string address = "vehicle-model/update";
            string result = this.Post<VehicleModelViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }
    }
}