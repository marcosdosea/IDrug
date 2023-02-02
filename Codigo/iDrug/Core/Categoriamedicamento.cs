namespace Core
{
    public partial class Categoriamedicamento
    {
        public Categoriamedicamento()
        {
            Medicamento = new HashSet<Medicamento>();
        }

        public int IdCategoriaMedicamento { get; set; }
        public string NomeCategoria { get; set; }

        public virtual ICollection<Medicamento> Medicamento { get; set; }
    }
}
