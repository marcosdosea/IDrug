using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdrugWeb.Models
{
    public class MedicamentoModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código do medicamento é obrigatório")]
        public int IdMedicamento { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Nome do medicamento deve ter entre 1 e 60 caracteres")]
        public string Nome { get; set; }


        [Display(Name = "Código de Barras")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Código de barras deve ter entre 1 e 20 caracteres")]
        public string CodigoBarras { get; set; }


        [Display(Name = "Categoria Medicamento")]
        [Required(ErrorMessage = "Campo requerido")]
        public int IdCategoriaMedicamento { get; set; }



        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Nome do fabricante deve ter entre 1 e 40 caracteres")]
        public string Fabricante { get; set; }

     
    }
}
