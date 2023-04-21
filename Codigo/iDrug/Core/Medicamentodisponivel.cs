namespace Core;

public partial class Medicamentodisponivel
{
    public Medicamentodisponivel()
    {
        Solicitacaomedicamento = new HashSet<Solicitacaomedicamento>();
    }

    public int IdDisponibilizacaoMedicamento { get; set; }
    public int IdMedicamento { get; set; }
    public int IdFarmacia { get; set; }
    public DateTime DataInicioDisponibilizacao { get; set; }
    public DateTime DataFimDisponibilizacao { get; set; }
    public int QuantidadeDisponibilizacao { get; set; }
    public string Lote { get; set; }
    public string Quantidade { get; set; }
    public string ValidadeMes { get; set; }
    public int ValidadeAno { get; set; }
    public string StatusMedicamento { get; set; }
    public DateTime DataVencimento { get; set; }
    public int QuantidadeReservada { get; set; }
    public int QuantidadeEntregue { get; set; }
    public int QuantidadeDisponivel { get; set; }
    public byte[]? Imagem { get; set; }

    public virtual Farmacia IdFarmaciaNavigation { get; set; }
    public virtual Medicamento IdMedicamentoNavigation { get; set; }
    public virtual ICollection<Solicitacaomedicamento> Solicitacaomedicamento { get; set; }
}
