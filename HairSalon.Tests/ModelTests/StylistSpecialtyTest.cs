using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistSpecialtyTests : IDisposable
  {
    public void Dispose()
    {
      StylistSpecialty.DeleteAll();
    }
    public StylistSpecialtyTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=lan_dam_test;";
    }
    [TestMethod]
    public void GetTest_ReturnDataField()
    {
      // Arrange
      int id = 1;
      int stylistId = 1;
      int specialtyId = 1;
      StylistSpecialty testStylistSpecialty = new StylistSpecialty(stylistId, specialtyId, id);

      // Act
      int resultId = testStylistSpecialty.GetId();
      int resultStylistId = testStylistSpecialty.GetStylistId();
      int resultSpecialtyId = testStylistSpecialty.GetSpecialtyId();

      // Assert
      Assert.AreEqual(id, resultId);
      Assert.AreEqual(stylistId, resultStylistId);
      Assert.AreEqual(specialtyId, resultSpecialtyId);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfIdAndNameAreTheSame_StylistSpecialty()
    {
      // Arrange, Act
      StylistSpecialty firstStylistSpecialty = new StylistSpecialty(1, 1, 1);
      StylistSpecialty secondStylistSpecialty = new StylistSpecialty(1, 1, 1);

      // Assert
      Assert.AreEqual(firstStylistSpecialty, secondStylistSpecialty);
    }
    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      StylistSpecialty testStylistSpecialty = new StylistSpecialty(1, 1);

      //Act
      testStylistSpecialty.Save();
      StylistSpecialty savedStylistSpecialty = StylistSpecialty.GetAll()[0];

      int result = savedStylistSpecialty.GetId();
      int testId = testStylistSpecialty.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }
    [TestMethod]
    public void SaveAndGetAll_SavesToDatabaseAndReturnAll_StylistSpecialty()
    {
      //Arrange
      StylistSpecialty testStylistSpecialty = new StylistSpecialty(1, 1);

      //Act
      testStylistSpecialty.Save();
      List<StylistSpecialty> result = StylistSpecialty.GetAll();
      List<StylistSpecialty> testList = new List<StylistSpecialty>{testStylistSpecialty};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
  }
}
