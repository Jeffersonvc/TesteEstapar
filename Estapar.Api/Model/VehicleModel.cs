using Estapar.Core.Repository.Database.Annotations;

namespace Estapar.Api.Model
{
    [Table(TableName = "TB_VehicleModel")]
    public class VehicleModel : BaseModel
    {
        [PrimaryKey(IsIdentity = true)]
        [Field(FieldName = "VehicleModelId")]
        public int Id { get; set; }
        [Field(FieldName = "Name")]
        public string Name { get; set; }
        [Field(FieldName = "VehicleBrandId")]
        public int VehicleBrandId { get; set; }
        [RemoveMap]
        public VehicleBrand VehicleBrand { get; set; }
    }
}
