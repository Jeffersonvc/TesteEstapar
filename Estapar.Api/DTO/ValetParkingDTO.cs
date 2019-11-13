using System;

namespace Estapar.Api.DTO
{
    public class ValetParkingDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
