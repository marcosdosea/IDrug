using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
	[TestClass()]
	public class UsuarioServiceTests
	{
		private DBContext _context;
		private IUsuarioService _usuarioService;

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			var builder = new DbContextOptionsBuilder<DBContext>();
			builder.UseInMemoryDatabase("Idrug");
			var options = builder.Options;

			_context = new DBContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var usuarios = new List<Usuario>
				{
					new Usuario {
						// IdUsuario = 1,
						IdUsuario = 1
					},
					new Usuario {
						//IdUsuario = 2,
						IdUsuario = 1

					},
					new Usuario {
						//IdUsuario = 3,
						IdUsuario = 1,

					},
				};

			_context.AddRange(usuarios);
			_context.SaveChanges();

			_usuarioService = new UsuarioService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_usuarioService.Inserir(new Usuario()
			{
				//IdUsuario = 1,
				IdUsuario = 1,
			});
			// Assert
			Assert.AreEqual(4, _usuarioService.ObterTodos().Count());
			var usuario = _usuarioService.Obter(4);
			Assert.AreEqual(1, usuario.IdUsuario);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var usuario = _usuarioService.Obter(1);
			usuario.IdUsuario = 1;
			_usuarioService.Editar(usuario);
			usuario = _usuarioService.Obter(1);
			Assert.AreEqual(1, usuario.IdUsuario);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_usuarioService.Remover(2);
			// Assert
			Assert.AreEqual(2, _usuarioService.ObterTodos().Count());
			var autor = _usuarioService.Obter(2);
			Assert.AreEqual(null, autor);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaUsuario = _usuarioService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaUsuario, typeof(IEnumerable<Usuario>));
			Assert.IsNotNull(listaUsuario);
			Assert.AreEqual(3, listaUsuario.Count());
			Assert.AreEqual(1, listaUsuario.First().IdUsuario);
		}


		[TestMethod()]
		public void ObterTest()
		{
			var usuario = _usuarioService.Obter(1);
			Assert.IsNotNull(usuario);
			Assert.AreEqual(1, usuario.IdUsuario);
		}


	}
}