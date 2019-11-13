using System.Collections.Generic;
using Estapar.Api.Helper;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Core.Repository.Base;
using Microsoft.Extensions.Options;

namespace Estapar.Api.Repository
{
    public class VehicleBrandRepository : BaseRepository<VehicleBrand>, IVehicleBrandRepository
    {
        public VehicleBrandRepository(IOptions<ConnectionStrings> options) : base(options.Value.DefaultConnection) { }

        public VehicleBrand GetByName(VehicleBrand model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.SelectWithFilter(model, new { Name = model.Name }, ref parameters);
            return ExecuteCommandObject(query, parameters);
        }

        public IEnumerable<VehicleBrand> GetActives()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.SelectWithFilter(new VehicleBrand(), new { Active = 1 }, ref parameters);
            return ExecuteCommandList(query, parameters);
        }

        public bool HasAssociation(VehicleBrand model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "vehicleBrandId", model.Id }
            };
            string query = @"select 1 from TB_VehicleModel where VehicleBrandId = @vehicleBrandId";
            return ExecuteCommandExists(query, parameters);
        }
    }
}
