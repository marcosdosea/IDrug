﻿using Core.DTO;

namespace Core.Service
{
    public interface ICategoriaMedicamentoService
    {
        void Editar(Categoriamedicamento categoriaMedicamento);

        int Inserir(Categoriamedicamento categoriaMedicamento);

        Categoriamedicamento Obter(int idCategoriaMedicamento);

        IEnumerable<Categoriamedicamento> ObterPorNome(string nome);

        IEnumerable<Categoriamedicamento> ObterTodos();

        void Remover(int idCategoriaMedicamento);

        IEnumerable<CategoriaMedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
