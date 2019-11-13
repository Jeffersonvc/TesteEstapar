namespace Estapar.Api.DTO
{
    public class ValetParkingVehicleDTO : BaseDTO
    {
        public int VehicleId { get; set; }
        public int ValetParkingId { get; set; }
        public ValetParkingDTO ValetParkingDTO { get; set; }
        public VehicleDTO VehicleDTO { get; set; }
    }
}
