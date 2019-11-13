using System;
using System.ComponentModel.DataAnnotations;

namespace Estapar.Web.Models
{
    public class ValetParkingViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Data de Inclusão")]
        public DateTime InclusionDate { get; set; }
        [Display(Name = "Ativo")]
        public bool Active { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome deve ser informado")]
        public string Name { get; set; }
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF deve ser informado")]
        public string Document { get; set; }
        [Display(Name = "Data de Nasc.")]
        [Required(ErrorMessage = "A data de nascimento deve ser informada")]
        public DateTime BirthDate { get; set; }
    }
}