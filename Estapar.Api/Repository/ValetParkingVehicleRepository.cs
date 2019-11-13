using Estapar.Api.Helper;
using Estapar.Api.Model;
using Estapar.Api.Repository.Interfaces;
using Estapar.Core.Repository.Base;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Estapar.Api.Repository
{
    public class ValetParkingVehicleRepository : BaseRepository<ValetParkingVehicle>, IValetParkingVehicleRepository
    {
        public ValetParkingVehicleRepository(IOptions<ConnectionStrings> options) : base(options.Value.DefaultConnection) { }

        public IEnumerable<ValetParkingVehicle> GetActives()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string query = _scriptGenerator.SelectWithFilter(new ValetParkingVehicle(), new { Active = 1 }, ref parameters);
            return ExecuteCommandList(query, parameters);
        }

    }
}
