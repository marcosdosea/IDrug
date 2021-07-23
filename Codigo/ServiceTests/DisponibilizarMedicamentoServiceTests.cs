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
    public class DisponibilizarMedicamentoServiceTests
    {
		private DBContext _context;
		private IDisponibilizarMedicamentoService _disponibilizarMedicamentoService;

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			var builder = new DbContextOptionsBuilder<DBContext>();
			builder.UseInMemoryDatabase("Biblioteca");
			var options = builder.Options;

			_context = new DBContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var medicamentosDisponiveis = new List<Medicamentodisponivel>
				{
					new Medicamentodisponivel {
						// IdDisponibilizacaoMedicamento = 1,
						IdMedicamento = 1,
						IdFarmacia = 1,
						DataInicioDisponibilizacao = DateTime.Parse("2021-07-01"),
						DataFimDisponibilizacao = DateTime.Parse("2021-08-01"),
						QuantidadeDisponibilizacao = 10,
						Lote = "126",
						Quantidade = "10",
						ValidadeMes = "agosto",
						ValidadeAno = 2021,
						StatusMedicamento = "Disponível",
						DataVencimento = DateTime.Parse("2021-08-10"),
						QuantidadeReservada = 0,
						QuantidadeEntregue = 0,
						QuantidadeDisponivel = 0
					},
					new Medicamentodisponivel {
						//IdDisponibilizacaoMedicamento = 2,
						IdMedicamento = 1,
						IdFarmacia = 1,
						DataInicioDisponibilizacao = DateTime.Parse("2021-07-01"),
						DataFimDisponibilizacao = DateTime.Parse("2021-08-01"),
						QuantidadeDisponibilizacao = 10,
						Lote = "126",
						Quantidade = "10",
						ValidadeMes = "agosto",
						ValidadeAno = 2021,
						StatusMedicamento = "Disponível",
						DataVencimento = DateTime.Parse("2021-08-10"),
						QuantidadeReservada = 0,
						QuantidadeEntregue = 0,
						QuantidadeDisponivel = 0

					},
					new Medicamentodisponivel {
						//IdDisponibilizacaoMedicamento = 3,
						IdMedicamento = 1,
						IdFarmacia = 1,
						DataInicioDisponibilizacao = DateTime.Parse("2021-07-01"),
						DataFimDisponibilizacao = DateTime.Parse("2021-08-01"),
						QuantidadeDisponibilizacao = 10,
						Lote = "126",
						Quantidade = "10",
						ValidadeMes = "agosto",
						ValidadeAno = 2021,
						StatusMedicamento = "Disponível",
						DataVencimento = DateTime.Parse("2021-08-10"),
						QuantidadeReservada = 0,
						QuantidadeEntregue = 0,
						QuantidadeDisponivel = 0

					},
				};

			_context.AddRange(medicamentosDisponiveis);
			_context.SaveChanges();

			_disponibilizarMedicamentoService = new DisponibilizarMedicamentoService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_disponibilizarMedicamentoService.Inserir(new Medicamentodisponivel() {
				//IdDisponibilizacaoMedicamento = 1,
				IdMedicamento = 1,
				IdFarmacia = 1,
				DataInicioDisponibilizacao = DateTime.Parse("2021-07-01"),
				DataFimDisponibilizacao = DateTime.Parse("2021-08-01"),
				QuantidadeDisponibilizacao = 10,
				Lote = "126",
				Quantidade = "10",
				ValidadeMes = "agosto",
				ValidadeAno = 2021,
				StatusMedicamento = "Disponível",
				DataVencimento = DateTime.Parse("2021-08-10"),
				QuantidadeReservada = 0,
				QuantidadeEntregue = 0,
				QuantidadeDisponivel = 0
			});
			// Assert
			Assert.AreEqual(4, _disponibilizarMedicamentoService.ObterTodos().Count());
			var medicamentodisponivel = _disponibilizarMedicamentoService.Obter(4);
			Assert.AreEqual(1, medicamentodisponivel.IdDisponibilizacaoMedicamento);
			Assert.AreEqual("agosto", medicamentodisponivel.ValidadeMes);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var medicamentodisponivel = _disponibilizarMedicamentoService.Obter(1);
			medicamentodisponivel.IdMedicamento = 1;
			medicamentodisponivel.ValidadeMes = "agosto";
			_disponibilizarMedicamentoService.Editar(medicamentodisponivel);
			medicamentodisponivel = _disponibilizarMedicamentoService.Obter(1);
			Assert.AreEqual(1, medicamentodisponivel.IdDisponibilizacaoMedicamento);
			Assert.AreEqual("agosto", medicamentodisponivel.ValidadeMes);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_disponibilizarMedicamentoService.Remover(2);
			// Assert
			Assert.AreEqual(2, _disponibilizarMedicamentoService.ObterTodos().Count());
			var autor = _disponibilizarMedicamentoService.Obter(2);
			Assert.AreEqual(null, autor);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaMedicamentodisponivel = _disponibilizarMedicamentoService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaMedicamentodisponivel, typeof(IEnumerable<Medicamentodisponivel>));
			Assert.IsNotNull(listaMedicamentodisponivel);
			Assert.AreEqual(3, listaMedicamentodisponivel.Count());
			Assert.AreEqual(1, listaMedicamentodisponivel.First().IdDisponibilizacaoMedicamento);
			Assert.AreEqual("agosto", listaMedicamentodisponivel.First().ValidadeMes);
		}


		[TestMethod()]
		public void ObterTest()
		{
			var medicamentodisponivel = _disponibilizarMedicamentoService.Obter(1);
			Assert.IsNotNull(medicamentodisponivel);
			Assert.AreEqual(1, medicamentodisponivel.IdDisponibilizacaoMedicamento);
		}


	}
}