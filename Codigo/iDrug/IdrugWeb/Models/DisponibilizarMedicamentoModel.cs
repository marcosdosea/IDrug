using System.ComponentModel.DataAnnotations;

namespace IdrugWeb.Models
{
    public class DisponibilizarMedicamentoModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código da disponibilização é obrigatório")]
        public int IdDisponibilizacaoMedicamento { get; set; }

        [Display(Name = "Medicamento")]
        public int IdMedicamento { get; set; }

        [Display(Name = "Farmácia: ")]
        public int IdFarmacia { get; set; }

        [Display(Name = "Data Início")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicioDisponibilizacao { get; set; }

        [Display(Name = "Data Fim ")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFimDisponibilizacao { get; set; }

        [Display(Name = "Lote")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Lote deve conter entre 5 e 45 caracteres")]
        public string Lote { get; set; }

        [Display(Name = "Quantidade")]
        public string Quantidade { get; set; }

        [Display(Name = "Status")]
        public string StatusMedicamento { get; set; }

        [Display(Name = "Data Vencimento")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Quantidade Reservada")]
        public int QuantidadeReservada { get; set; }

        [Display(Name = "Quantidade Entregue")]
        public int QuantidadeEntregue { get; set; }

        [Display(Name = "Quantidade Disponível")]
        public int QuantidadeDisponivel { get; set; }

        //imagem
    }
}
