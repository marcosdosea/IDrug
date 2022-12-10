using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdrugWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using IdrugWeb.Mappers;
using Service;
using IdrugWeb.Models;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace IdrugWeb.Controllers.Tests
{
    [TestClass()]
    public class DisponibilizarMedicamentoControllerTests
    {
        private static DisponibilizarMedicamentoController controller;
		[TestInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<DisponibilizarMedicamentoService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new DisponibilizarMedicamentoProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestDisponibilizarMedicamento());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetDisponibilizarMedicamento());
			mockService.Setup(service => service.Editar(It.IsAny<Medicamentodisponivel>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Medicamentodisponivel>()))
				.Verifiable();

			//Faltam dois argumentos que dependem de outros dois Services por que contém chave estrangeira(medicamento e farmácia)
			//controller = new DisponibilizarMedicamentoController(mockService.Object, mapper);
		}

        private static IEnumerable<Farmacia> GetTestFarmacia()
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Medicamento> GetTestMedicamento()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<DisponibilizarMedicamentoModel>));
			List<DisponibilizarMedicamentoModel> lista = (List<DisponibilizarMedicamentoModel>)viewResult.ViewData.Model;
			Assert.AreEqual(3, lista.Count);
		}

		[TestMethod()]
		public void DetailsTest()
		{
			// Act
			var result = controller.Details(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisponibilizarMedicamentoModel));
			DisponibilizarMedicamentoModel disponibilizarMedicamentoModel = (DisponibilizarMedicamentoModel)viewResult.ViewData.Model;
			Assert.AreEqual(1, disponibilizarMedicamentoModel.IdDisponibilizacaoMedicamento);
			Assert.AreEqual("agosto", disponibilizarMedicamentoModel.ValidadeMes);
		}

		[TestMethod()]
		public void CreateTest()
		{
			// Act
			var result = controller.Create();
			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod()]
		public void CreateTest_Valid()
		{
			// Act
			var result = controller.Create(GetNewDisponibilizarMedicamento());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void CreateTest_InValid()
		{
			// Arrange
			controller.ModelState.AddModelError("Nome", "Campo requerido");

			// Act
			var result = controller.Create(GetNewDisponibilizarMedicamento());

			// Assert
			Assert.AreEqual(1, controller.ModelState.ErrorCount);
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void EditTest_Post()
		{
			// Act
			var result = controller.Edit(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisponibilizarMedicamentoModel));
			DisponibilizarMedicamentoModel disponibilizarMedicamentoModel = (DisponibilizarMedicamentoModel)viewResult.ViewData.Model;
			Assert.AreEqual(1, disponibilizarMedicamentoModel.IdDisponibilizacaoMedicamento);
			Assert.AreEqual("agosto", disponibilizarMedicamentoModel.ValidadeMes);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetDisponibilizarMedicamentoModel().IdDisponibilizacaoMedicamento, GetTargetDisponibilizarMedicamentoModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void DeleteTest_Post()
		{
			// Act
			var result = controller.Delete(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisponibilizarMedicamentoModel));
			DisponibilizarMedicamentoModel disponibilizarMedicamentoModel = (DisponibilizarMedicamentoModel)viewResult.ViewData.Model;
			Assert.AreEqual(1, disponibilizarMedicamentoModel.IdDisponibilizacaoMedicamento);
			Assert.AreEqual("agosto", disponibilizarMedicamentoModel.ValidadeMes);
		}


		private static DisponibilizarMedicamentoModel GetNewDisponibilizarMedicamento()
		{
			return new DisponibilizarMedicamentoModel
			{
				IdDisponibilizacaoMedicamento = 4,
				IdMedicamento = 1,
				IdFarmacia = 1,
				DataInicioDisponibilizacao = DateTime.Parse("2021-07-01"),
				DataFimDisponibilizacao = DateTime.Parse("2021-08-01"),
				Lote = "126",
				Quantidade = "10",
				ValidadeMes = "agosto",
				ValidadeAno = 2021,
				StatusMedicamento = "Disponível",
				DataVencimento = DateTime.Parse("2021-08-10"),
				QuantidadeReservada = 0,
				QuantidadeEntregue = 0,
				QuantidadeDisponivel = 0
			};

		}
		private static Medicamentodisponivel GetTargetDisponibilizarMedicamento()
		{
			return new Medicamentodisponivel
			{
				IdDisponibilizacaoMedicamento = 1,
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
			};
		}

		private static DisponibilizarMedicamentoModel GetTargetDisponibilizarMedicamentoModel()
		{
			return new DisponibilizarMedicamentoModel
			{
				IdDisponibilizacaoMedicamento = 1,
				IdMedicamento = 1,
				IdFarmacia = 1,
				DataInicioDisponibilizacao = DateTime.Parse("2021-07-01"),
				DataFimDisponibilizacao = DateTime.Parse("2021-08-01"),
				Lote = "126",
				Quantidade = "10",
				ValidadeMes = "agosto",
				ValidadeAno = 2021,
				StatusMedicamento = "Disponível",
				DataVencimento = DateTime.Parse("2021-08-10"),
				QuantidadeReservada = 0,
				QuantidadeEntregue = 0,
				QuantidadeDisponivel = 0
		};
		}

		private static IEnumerable<Medicamentodisponivel> GetTestDisponibilizarMedicamento()
		{
			return new List<Medicamentodisponivel>
			{
				new Medicamentodisponivel
				{
					IdDisponibilizacaoMedicamento = 1,
					IdMedicamento = 1,
					IdFarmacia =1,
					DataInicioDisponibilizacao = DateTime.Parse("2021-07-01"),
					DataFimDisponibilizacao = DateTime.Parse("2021-08-01"),
					QuantidadeDisponibilizacao = 10,
					Lote = "126",
					Quantidade = "10",
					ValidadeMes = "agosto",
					ValidadeAno = 2021,
					StatusMedicamento = "Disponível",
					DataVencimento =  DateTime.Parse("2021-08-10"),
					QuantidadeReservada = 0,
					QuantidadeEntregue = 0,
					QuantidadeDisponivel = 0

				},
				new Medicamentodisponivel
				{
					IdDisponibilizacaoMedicamento = 2,
					IdMedicamento = 1,
					IdFarmacia =1,
					DataInicioDisponibilizacao = DateTime.Parse("2021-07-01"),
					DataFimDisponibilizacao = DateTime.Parse("2021-08-01"),
					QuantidadeDisponibilizacao = 10,
					Lote = "126",
					Quantidade = "10",
					ValidadeMes = "agosto",
					ValidadeAno = 2021,
					StatusMedicamento = "Disponível",
					DataVencimento =  DateTime.Parse("2021-08-10"),
					QuantidadeReservada = 0,
					QuantidadeEntregue = 0,
					QuantidadeDisponivel = 0
		},
				new Medicamentodisponivel
				{
					IdDisponibilizacaoMedicamento = 3,
					IdMedicamento = 1,
					IdFarmacia =1,
					DataInicioDisponibilizacao = DateTime.Parse("2021-07-01"),
					DataFimDisponibilizacao = DateTime.Parse("2021-08-01"),
					QuantidadeDisponibilizacao = 10,
					Lote = "126",
					Quantidade = "10",
					ValidadeMes = "agosto",
					ValidadeAno = 2021,
					StatusMedicamento = "Disponível",
					DataVencimento =  DateTime.Parse("2021-08-10"),
					QuantidadeReservada = 0,
					QuantidadeEntregue = 0,
					QuantidadeDisponivel = 0
				},
			};
		}
	}
}
