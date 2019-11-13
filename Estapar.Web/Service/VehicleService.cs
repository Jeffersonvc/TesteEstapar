using Estapar.Web.Integration;
using Estapar.Web.Models;
using System;
using System.Collections.Generic;

namespace Estapar.Web.Service
{
    public class VehicleService : BaseIntegration
    {
        VehicleIntegration integration;
        public VehicleService()
        {
            integration = new VehicleIntegration();
        }
        public IEnumerable<VehicleViewModel> GetAll()
        {
            return integration.GetAll();
        }

        public IEnumerable<VehicleViewModel> GetActives()
        {
            return integration.GetActives();
        }
        public VehicleViewModel Get(int id)
        {
            return integration.Get(id);
        }
        public Tuple<bool, string> Delete(VehicleViewModel viewModel)
        {
            bool hasAssociation = integration.HasAssociation(viewModel);

            if (hasAssociation)
            {
                return new Tuple<bool, string>(false, "Esse veículo está vinculado a um manobrista");
            }

            bool result = integration.Delete(viewModel);

            return new Tuple<bool, string>(result, result ? "Veículo excluído com sucesso" : "Erro ao excluir veículo");
        }

        public Tuple<bool, string> Insert(VehicleViewModel viewModel)
        {
            bool exists = this.PlateExists(viewModel.VehicleLicensePlate);
            if (exists)
                return new Tuple<bool, string>(false, "Já existe uma placa cadastrada para um veículo");

            bool result = integration.Insert(viewModel);

            return new Tuple<bool, string>(result, result ? "Veículo cadastrado com sucesso" : "Erro ao cadastrar novo veículo");
        }

        public bool PlateExists(string plate)
        {
            return integration.PlateExists(plate);
        }

        public Tuple<bool, string> Update(VehicleViewModel viewModel)
        {
            bool result = integration.Update(viewModel);

            return new Tuple<bool, string>(result, result ? "Veículo atualizado com sucesso" : "Erro ao atualizar veículo");
        }
    }
}