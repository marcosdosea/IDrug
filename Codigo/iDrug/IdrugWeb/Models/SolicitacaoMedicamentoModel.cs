using System.ComponentModel.DataAnnotations;

namespace IdrugWeb.Models
{
    public class SolicitacaoMedicamentoModel
    {
        public int idSolicitacaoMedicamento { get; set; }

        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código da disponibilização é obrigatório")]
        public int idDisponibilizacaoMedicamento { get; set; }

        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código do usuario é obrigatório")]
        public int idUsuario { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo requerido")]
        public int quantidadeSolicitada { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo requerido")]
        public string statusSolicitacaoMedicamento { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo requerido")]
        public int quantidadeEntregue { get; set; }

        [Display(Name = "Prazo de Entrega")]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime prazoEntrega { get; set; }

        [Display(Name = "Data Solicitacao")]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime dataSolicitacao { get; set; }

        [Display(Name = "Data Entrega")]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime dataEntrega { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo requerido")]
        public string cpf { get; set; }
    }
}
