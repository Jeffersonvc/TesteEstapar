using System;
using System.ComponentModel.DataAnnotations;

namespace Estapar.Web.Models
{
    public class ValetParkingVehicleViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Data de Inclusão")]
        public DateTime InclusionDate { get; set; }
        [Display(Name = "Ativo")]
        public bool Active { get; set; }
        [Display(Name = "Veículo")]
        [Required(ErrorMessage = "Veículo deve ser informado")]
        public int VehicleId { get; set; }
        [Display(Name = "Manobrista")]
        [Required(ErrorMessage = "Manobrista deve ser informado")]
        public int ValetParkingId { get; set; }
    }
}