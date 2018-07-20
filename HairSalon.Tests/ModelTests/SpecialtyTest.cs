using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTests : IDisposable
  {
    public void Dispose()
    {
      Specialty.DeleteAll();
    }
    public SpecialtyTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=lan_dam_test;";
    }
    [TestMethod]
    public void GetTest_ReturnDataField()
    {
      // Arrange
      int id = 1;
      string name = "testName";
      Specialty testSpecialty = new Specialty(name, id);

      // Act
      int resultId = testSpecialty.GetId();
      string resultName = testSpecialty.GetName();

      // Assert
      Assert.AreEqual(id, resultId);
      Assert.AreEqual(name, resultName);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfIdAndNameAreTheSame_Specialty()
    {
      // Arrange, Act
      Specialty firstSpecialty = new Specialty("testName", 1);
      Specialty secondSpecialty = new Specialty("testName", 1);

      // Assert
      Assert.AreEqual(firstSpecialty, secondSpecialty);
    }
    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("testName");

      //Act
      testSpecialty.Save();
      Specialty savedSpecialty = Specialty.GetAll()[0];

      int result = savedSpecialty.GetId();
      int testId = testSpecialty.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }
    [TestMethod]
    public void SaveAndGetAll_SavesToDatabaseAndReturnAll_Specialty()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("testName");

      //Act
      testSpecialty.Save();
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{testSpecialty};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
    [TestMethod]
    public void Find_FindSpecialtyInDatabase_Specialty()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("testName");
      testSpecialty.Save();
      List<Specialty> testList = new List<Specialty> {testSpecialty};

      //Act
      Specialty resultById = Specialty.Find(testSpecialty.GetId());
      List<Specialty> resultByName = Specialty.Find(testSpecialty.GetName());

      //Assert
      Assert.AreEqual(testSpecialty, resultById);
      CollectionAssert.AreEqual(testList, resultByName);
    }

    [TestMethod]
    public void GetStylists_RetrievesAllStylistsWithSpecialtyId_StylistList()
    {
      // Arrange
      Specialty testSpecialty = new Specialty("testSpecialty");
      testSpecialty.Save();
      Stylist testStylist = new Stylist("testStylist");
      testStylist.Save();
      StylistSpecialty testStylistSpecialty = new StylistSpecialty(testStylist.GetId(), testSpecialty.GetId());
      testStylistSpecialty.Save();
      List<Stylist> testStylists = new List<Stylist> {testStylist};

      // Act
      List<Stylist> resultStylists = testSpecialty.GetStylists();

      // Assert
      CollectionAssert.AreEqual(testStylists, resultStylists);
    }
  }
}
