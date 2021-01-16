using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdrugWeb.Models
{
    public class CategoriaMedicamentoModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código da Categoria Medicamento é obrigatória")]
        public int IdCategoriaMedicamento { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome da categoria deve ter entre 5 e 45 caracteres")]
        public string NomeCategoria { get; set; }
    }
}
