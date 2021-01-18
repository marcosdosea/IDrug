using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IUsuarioService
    {
        void Editar(Usuario usuario);

        IEnumerable<object> GetQuery();
        int Inserir(Usuario usuario);
       
        Usuario Obter(int idUsuario);
       
        void Remover(int idAutor);
     
    }
}
