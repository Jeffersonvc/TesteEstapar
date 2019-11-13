using System;
using System.ComponentModel.DataAnnotations;

namespace Estapar.Web.Models
{
    public class ValetParkingVehicleDetailViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Data de Inclusão")]
        public DateTime InclusionDate { get; set; }
        [Display(Name = "Ativo")]
        public bool Active { get; set; }
        [Display(Name = "Manobrista")]
        public string ValetParkingName { get; set; }
        [Display(Name = "Marca")]
        public string VahicleBrandName { get; set; }
        [Display(Name = "Modelo")]
        public string VahicleModelName { get; set; }
        [Display(Name = "Placa")]
        public string VehicleLicensePlate { get; set; }
    }
}