using System;
using System.ComponentModel.DataAnnotations;

namespace Estapar.Web.Models
{
    public class VehicleBrandViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [MaxLength(length:200, ErrorMessage = "Tamanho máximo de 200 caracteres")]
        [Required(ErrorMessage = "O nome da marca é obrigatório")]
        public string Name { get; set; }
        [Display(Name = "Data de Inclusão")]
        public DateTime InclusionDate { get; set; }
        [Display(Name = "Ativo")]
        public bool Active { get; set; }

    }
}