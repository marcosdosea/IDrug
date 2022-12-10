using Core.DTO;

namespace Core.Service
{
    public interface IFarmaciaService
    {
        public int Inserir(Farmacia farmacia);

        public Farmacia Obter(int nome);

        public void Editar(Farmacia farmacia);

        public void Remover(int idFarmacia);

        public int InserirUsuario(Usuario usuario);

        IEnumerable<Farmacia> ObterPorNome(string nome);

        IEnumerable<Farmacia> ObterTodos();

        IEnumerable<FarmaciaDTO> ObterPorNomeOrdenadoDescending(string nome);

    }
}
