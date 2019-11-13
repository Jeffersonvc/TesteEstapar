using Estapar.Core.Repository.Database.Annotations;

namespace Estapar.Api.Model
{
    [Table(TableName = "TB_VehicleBrand")]
    public class VehicleBrand : BaseModel
    {
        [PrimaryKey(IsIdentity = true)]
        [Field(FieldName = "VehicleBrandId")]
        public int Id { get; set; }
        [Field(FieldName = "Name")]
        public string Name { get; set; }
    }
}
