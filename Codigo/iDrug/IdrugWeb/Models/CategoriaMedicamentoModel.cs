using System.ComponentModel.DataAnnotations;

namespace IdrugWeb.Models
{
    public class CategoriaMedicamentoModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código da Categoria Medicamento é obrigatório")]
        public int IdCategoriaMedicamento { get; set; }

        [Display(Name = "Nome Categoria")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Nome da categoria deve ter entre 1 e 60 caracteres")]
        public string NomeCategoria { get; set; }
    }
}
