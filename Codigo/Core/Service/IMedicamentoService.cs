using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

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
