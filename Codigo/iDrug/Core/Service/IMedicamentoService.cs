using Core.DTO;

namespace Core.Service
{
    public interface IMedicamentoService
    {
        void Editar(Medicamento medicamento);

        int Inserir(Medicamento medicamento);

        Medicamento Obter(int idMedicamento);

        IEnumerable<Medicamento> ObterPorNome(string nome);

        IEnumerable<Medicamento> ObterTodos();

        void Remover(int idAutor);

        IEnumerable<MedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
