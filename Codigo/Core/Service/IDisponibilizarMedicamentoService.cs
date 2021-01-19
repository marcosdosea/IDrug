using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IDisponibilizarMedicamentoService
    {
        void Editar(Medicamentodisponivel medicamentoDisponivel);

        int Inserir(Medicamentodisponivel medicamentodisponivel);

        Medicamentodisponivel Obter(int idDisponibilizacaoMedicamento);

       // IEnumerable<Medicamentodisponivel> ObterPorNome(string nome);

        IEnumerable<Medicamentodisponivel> ObterTodos();

        void Remover(int idDisponibilizacaoMedicamento);

       // IEnumerable<DisponibilizarMedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
