using Estapar.Core.Repository.Database.Annotations;
using System;

namespace Estapar.Api.Model
{
    [Table(TableName = "TB_ValetParking")]
    public class ValetParking : BaseModel
    {
        [PrimaryKey(IsIdentity = true)]
        [Field(FieldName = "ValetParkingId")]
        public int Id { get; set; }
        [Field(FieldName = "Name")]
        public string Name { get; set; }
        [Field(FieldName = "Document")]
        public string Document { get; set; }
        [Field(FieldName = "BirthDate")]
        public DateTime BirthDate { get; set; }
        
    }
}
