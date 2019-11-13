namespace Estapar.Api.DTO
{
    public class VehicleModelDTO : BaseDTO
    {
        public string Name { get; set; }
        public int VehicleBrandId { get; set; }
        public VehicleBrandDTO VehicleBrandDTO { get; set; }
    }
}
