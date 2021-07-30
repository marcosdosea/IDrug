using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdrugWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Service;
using Core;
using IdrugWeb.Models;
using Microsoft.AspNetCore.Mvc;
using IdrugWeb.Mappers;

namespace IdrugWeb.Controllers.Tests
{
	[TestClass()]
	public class FarmaciaControllerTests
	{
		private static FarmaciaController controller;


		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<FarmaciaService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new FarmaciaProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestFarmacias());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetFarmacia());
			mockService.Setup(service => service.Editar(It.IsAny<Farmacia>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Farmacia>()))
				.Verifiable();
			controller = new FarmaciaController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<FarmaciaModel>));
			List<FarmaciaModel> lista = (List<FarmaciaModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(FarmaciaModel));
			FarmaciaModel autorModel = (FarmaciaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Machado de Assis", autorModel.Nome);
			Assert.AreEqual(DateTime.Parse("18390621"), autorModel.Cnpj);
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
			var result = controller.Create(GetNewFarmacia());

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
			var result = controller.Create(GetNewFarmacia());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(FarmaciaModel));
			FarmaciaModel autorModel = (FarmaciaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Machado de Assis", autorModel.Nome);
			Assert.AreEqual(DateTime.Parse("18390621"), autorModel.Cnpj);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetFarmaciaModel().IdFarmacia, GetTargetFarmaciaModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static FarmaciaModel GetNewFarmacia()
		{
			return new FarmaciaModel
			{
				IdFarmacia = 4,
				Nome = "Ian Sommerville",
				Cnpj = "19510223"
			};

		}
		private static Farmacia GetTargetFarmacia()
		{
			return new Farmacia
			{
				IdFarmacia = 1,
				Nome = "Machado de Assis",
				Cnpj = "18390621"
			};
		}

		private static FarmaciaModel GetTargetFarmaciaModel()
		{
			return new FarmaciaModel
			{
				IdFarmacia = 2,
				Nome = "Machado de Assis",
				Cnpj = "18390621"
			};
		}

		private static IEnumerable<Farmacia> GetTestFarmacias()
		{
			return new List<Farmacia>
			{
				new Farmacia
				{
					IdFarmacia = 1,
					Nome = "Graciliano Ramos",
					Cnpj = "18921027"
				},
				new Farmacia
				{
					IdFarmacia = 2,
					Nome = "Machado de Assis",
					Cnpj = "18390621"
				},
				new Farmacia
				{
					IdFarmacia = 1,
					Nome = "Marcos Dósea",
					Cnpj = "19820101"
				},
			};
		}
	}
}