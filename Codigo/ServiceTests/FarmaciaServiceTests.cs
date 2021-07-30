using Core;
using Core.Service;
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
	public class FarmaciaServiceTests
	{
		private DBContext _context;
		private IFarmaciaService _farmaciaService;

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
			var farmacias = new List<Farmacia>
				{
					new Farmacia {
						// IdFarmacia = 1,
						IdFarmacia = 1
					},
					new Farmacia {
						//IdFarmacia = 2,
						IdFarmacia = 1

					},
					new Farmacia {
						//IdFarmaciao = 3,
						IdFarmacia = 1,

					},
				};

			_context.AddRange(farmacias);
			_context.SaveChanges();

			_farmaciaService = new FarmaciaService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_farmaciaService.Inserir(new Farmacia()
			{
				//IdFarmacia = 1,
				IdFarmacia = 1,
			});
			// Assert
			Assert.AreEqual(4, _farmaciaService.ObterTodos().Count());
			var farmacia = _farmaciaService.Obter(4);
			Assert.AreEqual(1, farmacia.IdFarmacia);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var farmacia = _farmaciaService.Obter(1);
			farmacia.IdFarmacia = 1;
			_farmaciaService.Editar(farmacia);
			farmacia = _farmaciaService.Obter(1);
			Assert.AreEqual(1, farmacia.IdFarmacia);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_farmaciaService.Remover(2);
			// Assert
			Assert.AreEqual(2, _farmaciaService.ObterTodos().Count());
			var autor = _farmaciaService.Obter(2);
			Assert.AreEqual(null, autor);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaFarmacia = _farmaciaService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaFarmacia, typeof(IEnumerable<Farmacia>));
			Assert.IsNotNull(listaFarmacia);
			Assert.AreEqual(3, listaFarmacia.Count());
			Assert.AreEqual(1, listaFarmacia.First().IdFarmacia);
		}


		[TestMethod()]
		public void ObterTest()
		{
			var farmacia = _farmaciaService.Obter(1);
			Assert.IsNotNull(farmacia);
			Assert.AreEqual(1, farmacia.IdFarmacia);
		}


	}
}