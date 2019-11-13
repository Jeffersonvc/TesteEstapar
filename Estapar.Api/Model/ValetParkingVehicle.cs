using Estapar.Core.Repository.Database.Annotations;

namespace Estapar.Api.Model
{
    [Table(TableName = "TB_ValetParkingVehicle")]
    public class ValetParkingVehicle : BaseModel
    {
        [PrimaryKey(IsIdentity = true)]
        [Field(FieldName = "ValetParkingVehicleId")]
        public int Id { get; set; }
        [Field(FieldName = "VehicleId")]
        public int VehicleId { get; set; }
        [Field(FieldName = "ValetParkingId")]
        public int ValetParkingId { get; set; }
        [RemoveMap]
        public ValetParking ValetParking { get; set; }
        [RemoveMap]
        public Vehicle Vehicle { get; set; }

    }
}
