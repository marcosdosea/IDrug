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
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome do medicamento deve ter entre 5 e 45 caracteres")]
        public string Nome { get; set; }


        public string CodigoBarras { get; set; }

        public string Fabricante { get; set; }

     
    }
}
