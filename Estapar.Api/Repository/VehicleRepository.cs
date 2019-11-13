using Estapar.Api.Helper;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Core.Repository.Base;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Estapar.Api.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IOptions<ConnectionStrings> options) : base(options.Value.DefaultConnection) { }

        public IEnumerable<Vehicle> GetActives()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.SelectWithFilter(new Vehicle(), new { Active = 1 }, ref parameters);
            return ExecuteCommandList(query, parameters);
        }

        public Vehicle GetByPlate(string plate)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.SelectWithFilter(new Vehicle(), new { VehicleLicensePlate = plate }, ref parameters);
            return ExecuteCommandObject(query, parameters);
        }

        public bool HasAssociation(Vehicle model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "vehicleId", model.Id }
            };
            string query = @"select 1 from TB_ValetParkingVehicle where VehicleId = @vehicleId";
            return ExecuteCommandExists(query, parameters);
        }
    }
}
