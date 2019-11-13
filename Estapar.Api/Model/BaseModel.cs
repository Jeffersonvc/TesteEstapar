using Estapar.Core.Repository.Database.Annotations;
using System;

namespace Estapar.Api.Model
{
    public class BaseModel
    {
        [RemoveFromUpdate]
        [Field(FieldName = "InclusionDate")]
        public DateTime InclusionDate { get; set; }
        [Field(FieldName = "Active")]
        public bool Active { get; set; }
    }
}
