using System;
using System.ComponentModel.DataAnnotations;

namespace Estapar.Web.Models
{
    public class VehicleModelViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do modelo é obrigatório")]
        [MaxLength(length: 200, ErrorMessage = "Tamanho máximo de 200 caracteres")]
        public string Name { get; set; }
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "A marca é obrigatória")]
        public int VehicleBrandId { get; set; }
        [Display(Name = "Data de Inclusão")]
        public DateTime InclusionDate { get; set; }
        [Display(Name = "Ativo")]
        public bool Active { get; set; }
    }
}