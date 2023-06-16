namespace Core;

public partial class Medicamento
{
    public Medicamento()
    {
        Medicamentodisponivel = new HashSet<Medicamentodisponivel>();
    }

    public int IdMedicamento { get; set; }
    public int IdCategoriaMedicamento { get; set; }
    public string CodigoBarras { get; set; }
    public string Nome { get; set; }
    public string Fabricante { get; set; }

    public virtual Categoriamedicamento IdCategoriaMedicamentoNavigation { get; set; }
    public virtual ICollection<Medicamentodisponivel> Medicamentodisponivel { get; set; }
}
