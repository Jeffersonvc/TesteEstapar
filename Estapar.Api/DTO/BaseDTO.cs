using System;

namespace Estapar.Api.DTO
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime InclusionDate { get; set; }
        public bool Active { get; set; }
    }
}
