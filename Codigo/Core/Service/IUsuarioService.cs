using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IUsuarioService
    {
        public void Editar(Usuario usuario);

        public int Inserir(Usuario usuario);

        public Usuario Obter(int idUsuario);

        public void Remover(int idUsuario);

        IEnumerable<Usuario> ObterPorNome(string nome);

        IEnumerable<Usuario> ObterTodos();

        IEnumerable<object> GetQuery();

    }
}
