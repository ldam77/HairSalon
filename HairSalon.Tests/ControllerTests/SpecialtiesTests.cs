using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtiesControllerTest
  {
    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      //Arrange
      SpecialtiesController controller = new SpecialtiesController();

      //Act
      ActionResult indexView = controller.Index();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
    [TestMethod]
    public void Index_HasCorrectModelType_SpecialtyList()
    {
      //Arrange
      ViewResult indexView = new SpecialtiesController().Index() as ViewResult;

      //Act
      var result = indexView.ViewData.Model;

      //Assert
      Assert.IsInstanceOfType(result, typeof(List<Specialty>));
    }
    [TestMethod]
    public void NewSpecialty_ReturnsCorrectView_True()
    {
      //Arrange
      SpecialtiesController controller = new SpecialtiesController();

      //Act
      ActionResult indexView = controller.NewSpecialty();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
    [TestMethod]
    public void Detail_ReturnsCorrectView_True()
    {
      //Arrange
      SpecialtiesController controller = new SpecialtiesController();

      //Act
      ActionResult indexView = controller.Detail(1);

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
    [TestMethod]
    public void Detail_HasCorrectModelType_SpecialtyList()
    {
      //Arrange
      ViewResult indexView = new SpecialtiesController().Detail(1) as ViewResult;

      //Act
      var result = indexView.ViewData.Model;

      //Assert
      Assert.IsInstanceOfType(result, typeof(Specialty));
    }
  }
}
