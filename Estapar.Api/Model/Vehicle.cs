using Estapar.Core.Repository.Database.Annotations;

namespace Estapar.Api.Model
{
    [Table(TableName = "TB_Vehicle")]
    public class Vehicle : BaseModel
    {
        [PrimaryKey(IsIdentity = true)]
        [Field(FieldName = "VehicleId")]
        public int Id { get; set; }
        [Field(FieldName = "VehicleModelId")]
        public int VehicleModelId { get; set; }
        [Field(FieldName = "VehicleYear")]
        public int? VehicleYear { get; set; }
        [Field(FieldName = "VehicleLicensePlate")]
        public string VehicleLicensePlate { get; set; }
        [RemoveMap]
        public VehicleModel VehicleModel { get; set; }
    }
}
