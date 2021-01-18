using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IFarmaciaService
    {
        public int Inserir(Farmacia farmacia);

        public Farmacia Obter(int nome);

        public void Editar(Farmacia farmacia);

        public int InserirUsuario(Usuario usuario);

        IEnumerable<Farmacia> ObterPorNome(string nome);

        IEnumerable<Farmacia> ObterTodos();

        IEnumerable<FarmaciaDTO> ObterPorNomeOrdenadoDescending(string nome);

    }
}
