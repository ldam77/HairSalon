using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=lan_dam_test;";
    }
    [TestMethod]
    public void GetTest_ReturnDataField()
    {
      // Arrange
      int id = 1;
      string name = "testName";
      Stylist testStylist = new Stylist(name, id);

      // Act
      int resultId = testStylist.GetId();
      string resultName = testStylist.GetName();

      // Assert
      Assert.AreEqual(id, resultId);
      Assert.AreEqual(name, resultName);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfIdAndNameAreTheSame_Stylist()
    {
      // Arrange, Act
      Stylist firstStylist = new Stylist("testName", 1);
      Stylist secondStylist = new Stylist("testName", 1);

      // Assert
      Assert.AreEqual(firstStylist, secondStylist);
    }
    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Stylist testStylist = new Stylist("testName");

      //Act
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }
    [TestMethod]
    public void SaveAndGetAll_SavesToDatabaseAndReturnAll_Stylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("testName");

      //Act
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
    [TestMethod]
    public void Find_FindStylistInDatabase_Stylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("testName");
      testStylist.Save();

      //Act
      Stylist resultById = Stylist.Find(testStylist.GetId());
      Stylist resultByName = Stylist.Find(testStylist.GetName());

      //Assert
      Assert.AreEqual(testStylist, resultById);
      Assert.AreEqual(testStylist, resultByName);
    }

    [TestMethod]
    public void GetClients_RetrievesAllClientsWithStylistName_ClientList()
    {
      // Arrange
      Stylist testStylist = new Stylist("testStylist");
      testStylist.Save();
      Client firstClient = new Client("testName1", testStylist.GetId());
      firstClient.Save();
      Client secondClient = new Client("testName2", testStylist.GetId());
      secondClient.Save();

      // Act
      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClients();

      // Assert
      CollectionAssert.AreEqual(testClientList, resultClientList);
    }
  }
}
