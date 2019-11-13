using Estapar.Web.Integration;
using Estapar.Web.Models;
using System;
using System.Collections.Generic;

namespace Estapar.Web.Service
{
    public class VehicleModelService
    {
        VehicleModelIntegration integration;
        public VehicleModelService()
        {
            integration = new VehicleModelIntegration();
        }

        public IEnumerable<VehicleModelViewModel> GetAll()
        {
            return integration.GetAll();
        }

        public IEnumerable<VehicleModelViewModel> GetActives()
        {
            return integration.GetActives();
        }
        public VehicleModelViewModel Get(int id)
        {
            return integration.Get(id);
        }
        public Tuple<bool, string> Delete(VehicleModelViewModel viewModel)
        {
            bool hasAssociation = integration.HasAssociation(viewModel);

            if (hasAssociation)
            {
                return new Tuple<bool, string>(false, "Esse modelo está associado a um veículo");
            }

            bool result = integration.Delete(viewModel);

            return new Tuple<bool, string>(result, result ? "Modelo excluído com sucesso" : "Erro ao excluir modelo");
        }

        public Tuple<bool, string> Insert(VehicleModelViewModel viewModel)
        {
            bool exists = this.NameExists(viewModel);
            if (exists)
                return new Tuple<bool, string>(false, "Já existe um modelo cadastrado com esse nome");

            bool result = integration.Insert(viewModel);

            return new Tuple<bool, string>(result, result ? "Modelo cadastrado com sucesso" : "Erro ao cadastrar novo modelo");
        }

        public bool NameExists(VehicleModelViewModel viewModel)
        {
            return integration.NameExists(viewModel);
        }

        public Tuple<bool, string> Update(VehicleModelViewModel viewModel)
        {
            bool result = integration.Update(viewModel);

            return new Tuple<bool, string>(result, result ? "Modelo atualizado com sucesso" : "Erro ao atualizar novo modelo");
        }
    }
}