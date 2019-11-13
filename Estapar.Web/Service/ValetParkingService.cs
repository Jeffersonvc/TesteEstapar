using Estapar.Web.Integration;
using Estapar.Web.Models;
using System;
using System.Collections.Generic;

namespace Estapar.Web.Service
{
    public class ValetParkingService
    {
        ValetParkingIntegration integration;
        public ValetParkingService()
        {
            integration = new ValetParkingIntegration();
        }
        public IEnumerable<ValetParkingViewModel> GetAll()
        {
            return integration.GetAll();
        }

        public IEnumerable<ValetParkingViewModel> GetActives()
        {
            return integration.GetActives();
        }
        public ValetParkingViewModel Get(int id)
        {
            return integration.Get(id);
        }
        public Tuple<bool, string> Delete(ValetParkingViewModel viewModel)
        {
            bool hasAssociation = integration.HasAssociation(viewModel);

            if (hasAssociation)
            {
                return new Tuple<bool, string>(false, "Esse manobrista está vinculado a um veículo");
            }

            bool result = integration.Delete(viewModel);

            return new Tuple<bool, string>(result, result ? "Manobrista excluído com sucesso" : "Erro ao excluir manobrista");
        }

        public Tuple<bool, string> Insert(ValetParkingViewModel viewModel)
        {
            bool exists = this.DocumentExists(viewModel.Document);
            if (exists)
                return new Tuple<bool, string>(false, "Já existe um manobrista cadastrado com esse documento");

            bool result = integration.Insert(viewModel);

            return new Tuple<bool, string>(result, result ? "Manobrista cadastrado com sucesso" : "Erro ao cadastrar manobrista");
        }

        public bool DocumentExists(string document)
        {
            return integration.DocumentExists(document);
        }

        public Tuple<bool, string> Update(ValetParkingViewModel viewModel)
        {
            bool result = integration.Update(viewModel);

            return new Tuple<bool, string>(result, result ? "Manobrista atualizado com sucesso" : "Erro ao atualizar manobrista");
        }
    }
}