using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IdrugWeb.Controllers;
using Core.Service;
using IdrugWeb.Mappers;
using IdrugWeb.Models;

namespace IdrugWeb.Controllers.Tests
{
    [TestClass()]
	public class CategoriaMedicamentoControllerTests
	{
		private static CategoriaMedicamentoController controller;


		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<ICategoriaMedicamentoService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new CategoriaMedicamentoProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestCategoriaMedicamentos());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetAutor());
			mockService.Setup(service => service.Editar(It.IsAny<CategoriaMedicamento>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<CategoriaMedicamento>()))
				.Verifiable();
			controller = new CategoriaMedicamentoController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CategoriaMedicamentoModel>));
			List<CategoriaMedicamentoModel> lista = (List<CategoriaMedicamentoModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CategoriaMedicamentoModel));
			CategoriaMedicamentoModel autorModel = (CategoriaMedicamentoModel)viewResult.ViewData.Model;
			Assert.AreEqual("Machado de Assis", autorModel.Nome);
			Assert.AreEqual(DateTime.Parse("1839-06-21"), autorModel.AnoNascimento);
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
			var result = controller.Create(GetNewAutor());

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
			var result = controller.Create(GetNewAutor());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CategoriaMedicamentoModel));
			CategoriaMedicamentoModel autorModel = (CategoriaMedicamentoModel)viewResult.ViewData.Model;
			Assert.AreEqual("Machado de Assis", autorModel.Nome);
			Assert.AreEqual(DateTime.Parse("1839-06-21"), autorModel.AnoNascimento);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetCategoriaMedicamentoModel().IdCategoriaMedicamento, GetTargetCategoriaMedicamentoModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CategoriaMedicamentoModel));
			CategoriaMedicamentoModel autorModel = (CategoriaMedicamentoModel)viewResult.ViewData.Model;
			Assert.AreEqual("Machado de Assis", autorModel.Nome);
			Assert.AreEqual(DateTime.Parse("1839-06-21"), autorModel.AnoNascimento);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetCategoriaMedicamentoModel().IdCategoriaMedicamento, GetTargetCategoriaMedicamentoModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static CategoriaMedicamentoModel GetNewAutor()
		{
			return new CategoriaMedicamentoModel
			{
				IdCategoriaMedicamento = 4,
				Nome = "Ian Sommerville",
				AnoNascimento = DateTime.Parse("1951-02-23")
			};

		}
		private static CategoriaMedicamento GetTargetCategoriaMedicamento()
		{
			return new CategoriaMedicamento
			{
				IdAutor = 1,
				Nome = "Machado de Assis",
				AnoNascimento = DateTime.Parse("1839-06-21")
			};
		}

		private static CategoriaMedicamentoModel GetTargetCategoriaMedicamentoModel()
		{
			return new CategoriaMedicamentoModel
			{
				IdAutor = 2,
				Nome = "Machado de Assis",
				AnoNascimento = DateTime.Parse("1839-06-21")
			};
		}

		private static IEnumerable<CategoriaMedicamento> GetTestAutores()
		{
			return new List<CategoriaMedicamento>
			{
				new CategoriaMedicamento
				{
					IdAutor = 1,
					Nome = "Graciliano Ramos",
					AnoNascimento = DateTime.Parse("1892-10-27")
				},
				new CategoriaMedicamento
				{
					IdAutor = 2,
					Nome = "Machado de Assis",
					AnoNascimento = DateTime.Parse("1839-06-21")
				},
				new CategoriaMedicamento
				{
					IdAutor = 3,
					Nome = "Marcos Dósea",
					AnoNascimento = DateTime.Parse("1982-01-01")
				},
			};
		}
	}
}