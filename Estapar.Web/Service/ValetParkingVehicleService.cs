using Estapar.Web.Integration;
using Estapar.Web.Models;
using System;
using System.Collections.Generic;

namespace Estapar.Web.Service
{
    public class ValetParkingVehicleService
    {
        ValetParkingVehicleIntegration integration;
        public ValetParkingVehicleService()
        {
            integration = new ValetParkingVehicleIntegration();
        }

        public IEnumerable<ValetParkingVehicleDetailViewModel> GetAll()
        {
            return integration.GetAll();
        }

        public IEnumerable<ValetParkingVehicleDetailViewModel> GetActives()
        {
            return integration.GetActives();
        }
        public ValetParkingVehicleDetailViewModel GetDetail(int id)
        {
            return integration.GetDetail(id);
        }
        public ValetParkingVehicleViewModel Get(int id)
        {
            return integration.Get(id);
        }
        public Tuple<bool, string> Delete(ValetParkingVehicleViewModel viewModel)
        {
            bool result = integration.Delete(viewModel);

            return new Tuple<bool, string>(result, result ? "Registro excluído com sucesso" : "Erro ao excluir registro");
        }

        public Tuple<bool, string> Insert(ValetParkingVehicleViewModel viewModel)
        {
            bool result = integration.Insert(viewModel);

            return new Tuple<bool, string>(result, result ? "Manobrista vinculado a veículo com sucesso" : "Erro ao vincular manobrista ao veiculo");
        }

        public Tuple<bool, string> Update(ValetParkingVehicleViewModel viewModel)
        {
            bool result = integration.Update(viewModel);

            return new Tuple<bool, string>(result, result ? "Manobrista vinculado a veículo com sucesso" : "Erro ao vincular manobrista ao veiculo");
        }
    }
}