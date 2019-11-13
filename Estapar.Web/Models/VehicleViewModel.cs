using System;
using System.ComponentModel.DataAnnotations;

namespace Estapar.Web.Models
{
    public class VehicleViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Data de Inclusão")]
        public DateTime InclusionDate { get; set; }
        [Display(Name = "Ativo")]
        public bool Active { get; set; }
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Modelo deve ser informado")]
        public int VehicleModelId { get; set; }
        [Display(Name = "Ano")]
        public int? VehicleYear { get; set; }
        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Placa deve ser informada")]
        public string VehicleLicensePlate { get; set; }
    }
}