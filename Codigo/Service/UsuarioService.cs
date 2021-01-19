using Core;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DBContext _context;

        public UsuarioService(DBContext context)
        {
            _context = context;
        }

        public void Editar(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();
        }

        public int Inserir(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return usuario.IdUsuario;
        }

        public Usuario Obter(int idUsuario)
        {
            IEnumerable<Usuario> usuarios = (IEnumerable<Usuario>)GetQuery().Where(usuarioModel => 
            usuarioModel.Equals(idUsuario)
            );
            return usuarios.ElementAtOrDefault(0);
        }

        public IEnumerable<object> GetQuery()
        {
            IQueryable<Usuario> tb_usuario = _context.Usuario;
            var query = from usuario in tb_usuario
                        select usuario;
            return query;
        }

        public void Remover(int idUsuario)
        {
            var _usuario = _context.Usuario.Find(idUsuario);
            _context.Usuario.Remove(_usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> ObterPorNome(string nome)
        {
            //IEnumerable<Usuario> usuario = GetQuery().Where(UsuarioModel => UsuarioModel.Nome.StartsWith(nome));
            //return usuario;
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return (IEnumerable<Usuario>)GetQuery();
        }

    }
}
