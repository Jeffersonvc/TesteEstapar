using Estapar.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Estapar.Web.Integration
{
    public class ValetParkingIntegration : BaseIntegration
    {
        public IEnumerable<ValetParkingViewModel> GetAll()
        {
            string address = "valet-parking/get";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<IEnumerable<ValetParkingViewModel>>(result);
            }
            return null;
        }

        public IEnumerable<ValetParkingViewModel> GetActives()
        {
            string address = "valet-parking/get-active";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<IEnumerable<ValetParkingViewModel>>(result);
            }
            return null;
        }

        public ValetParkingViewModel Get(int id)
        {
            string address = $"valet-parking/get/{id}";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<ValetParkingViewModel>(result);
            }
            return null;
        }

        public bool Delete(ValetParkingViewModel viewModel)
        {
            string address = "valet-parking/delete";
            string result = this.Post<ValetParkingViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool HasAssociation(ValetParkingViewModel viewModel)
        {
            string address = "valet-parking/has-association";
            string result = this.Post<ValetParkingViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool Insert(ValetParkingViewModel viewModel)
        {
            string address = "valet-parking/insert";
            string result = this.Post<ValetParkingViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool DocumentExists(string document)
        {
            string address = $"valet-parking/get-by-document/{document}";
            string result = this.Get(address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }

        public bool Update(ValetParkingViewModel viewModel)
        {
            string address = "valet-parking/update";
            string result = this.Post<ValetParkingViewModel>(viewModel, address);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<bool>(result);
            }
            return false;
        }
    }
}