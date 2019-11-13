using Estapar.Api.Helper;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Core.Repository.Base;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Estapar.Api.Repository
{
    public class ValetParkingRepository : BaseRepository<ValetParking>, IValetParkingRepository
    {
        public ValetParkingRepository(IOptions<ConnectionStrings> options) : base(options.Value.DefaultConnection) { }

        public IEnumerable<ValetParking> GetActives()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.SelectWithFilter(new ValetParking(), new { Active = 1 }, ref parameters);
            return ExecuteCommandList(query, parameters);
        }

        public ValetParking GetByDocument(string document)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.SelectWithFilter(new ValetParking(), new { Document = document }, ref parameters);
            return ExecuteCommandObject(query, parameters);
        }

        public bool HasAssociation(ValetParking model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "valetParkingId", model.Id }
            };
            string query = @"select 1 from TB_ValetParkingVehicle where ValetParkingId = @valetParkingId";
            return ExecuteCommandExists(query, parameters);
        }
    }
}
