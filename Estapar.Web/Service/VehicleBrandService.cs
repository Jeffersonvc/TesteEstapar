using Estapar.Web.Integration;
using Estapar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estapar.Web.Service
{
    public class VehicleBrandService
    {
        VehicleBrandIntegration integration;
        public VehicleBrandService()
        {
            integration = new VehicleBrandIntegration();
        }
        public IEnumerable<VehicleBrandViewModel> GetAll()
        {
            return integration.GetAll();
        }

        public IEnumerable<VehicleBrandViewModel> GetActives()
        {
            return integration.GetActives();
        }
        public VehicleBrandViewModel Get(int id)
        {
            return integration.Get(id);
        }
        public Tuple<bool, string> Delete(VehicleBrandViewModel viewModel)
        {
            bool hasAssociation = integration.HasAssociation(viewModel);

            if(hasAssociation)
            {
                return new Tuple<bool, string>(false, "Essa marca está associada a um modelo");
            }

            bool result = integration.Delete(viewModel);

            return new Tuple<bool, string>(result, result ? "Marca excluída com sucesso" : "Erro ao excluir marca");
        }

        public Tuple<bool, string> Insert(VehicleBrandViewModel viewModel)
        {
            bool exists = this.NameExists(viewModel);
            if (exists)
                return new Tuple<bool, string>(false, "Já existe uma marca cadastrado com esse nome");

            bool result = integration.Insert(viewModel);

            return new Tuple<bool, string>(result, result ? "Marca cadastrado com sucesso" : "Erro ao cadastrar nova Marca");
        }

        public bool NameExists(VehicleBrandViewModel viewModel)
        {
            return integration.NameExists(viewModel);
        }

        public Tuple<bool, string> Update(VehicleBrandViewModel viewModel)
        {
            bool result = integration.Update(viewModel);

            return new Tuple<bool, string>(result, result ? "Marca atualizado com sucesso" : "Erro ao atualizar nova marca");
        }
    }
}