namespace Core
{
    public partial class Solicitacaomedicamento
    {
        public int IdSolicitacaoMedicamento { get; set; }
        public int IdDisponibilizacaoMedicamento { get; set; }
        public int IdUsuario { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public string StatusSolicitacaoMedicamento { get; set; }
        public int QuantidadeEntregue { get; set; }
        public DateTime PrazoEntrega { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Cpf { get; set; }

        public virtual Medicamentodisponivel IdDisponibilizacaoMedicamentoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
