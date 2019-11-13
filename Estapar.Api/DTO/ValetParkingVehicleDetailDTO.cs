using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estapar.Api.DTO
{
    public class ValetParkingVehicleDetailDTO : BaseDTO
    {
        public string ValetParkingName { get; set; }
        public string VahicleBrandName { get; set; }
        public string VahicleModelName { get; set; }
        public string VehicleLicensePlate { get; set; }
    }
}
