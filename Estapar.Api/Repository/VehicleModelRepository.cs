using Estapar.Api.Helper;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Core.Repository.Base;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Estapar.Api.Repository
{
    public class VehicleModelRepository : BaseRepository<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(IOptions<ConnectionStrings> options) : base(options.Value.DefaultConnection) { }
        public VehicleModel GetByName(VehicleModel model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.SelectWithFilter(model, new { Name = model.Name }, ref parameters);
            return ExecuteCommandObject(query, parameters);
        }

        public IEnumerable<VehicleModel> GetActives()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.SelectWithFilter(new VehicleModel(), new { Active = 1 }, ref parameters);
            return ExecuteCommandList(query, parameters);
        }

        public bool HasAssociation(VehicleModel model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "vehicleModelId", model.Id }
            };
            string query = @"select 1 from TB_Vehicle where VehicleModelId = @vehicleModelId";
            return ExecuteCommandExists(query, parameters);
        }
    }
}
