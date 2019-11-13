using Estapar.Core.Repository.Database.Annotations;

namespace Estapar.Api.Model
{
    public class ValetParkingVehicleDetail : BaseModel
    {
        [Field(FieldName = "ValetParkingVehicleId")]
        public int Id { get; set; }
        [Field(FieldName = "ValetParkingName")]
        public string ValetParkingName { get; set; }
        [Field(FieldName = "VahicleBrandName")]
        public string VahicleBrandName { get; set; }
        [Field(FieldName = "VahicleModelName")]
        public string VahicleModelName { get; set; }
        [Field(FieldName = "VehicleLicensePlate")]
        public string VehicleLicensePlate { get; set; }

    }
}
