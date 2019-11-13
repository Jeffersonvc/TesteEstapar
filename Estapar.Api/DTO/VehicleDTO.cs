namespace Estapar.Api.DTO
{
    public class VehicleDTO : BaseDTO
    {
        public int VehicleModelId { get; set; }
        public int? VehicleYear { get; set; }
        public string VehicleLicensePlate { get; set; }
        public VehicleModelDTO VehicleModelDTO { get; set; }
    }
}
