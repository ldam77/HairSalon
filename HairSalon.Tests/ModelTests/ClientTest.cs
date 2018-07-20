using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
    }
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=lan_dam_test;";
    }
    [TestMethod]
    public void GetTest_ReturnDataField()
    {
      // Arrange
      int id = 1;
      string name = "testName";
      int stylistId = 1;
      Client testClient = new Client(name, stylistId, id);

      // Act
      int resultId = testClient.GetId();
      string resultName = testClient.GetName();
      int resultStylistId = testClient.GetStylistId();

      // Assert
      Assert.AreEqual(id, resultId);
      Assert.AreEqual(name, resultName);
      Assert.AreEqual(stylistId, resultStylistId);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfIdAndNameAreTheSame_Client()
    {
      // Arrange, Act
      Client firstClient = new Client("testName", 1, 1);
      Client secondClient = new Client("testName", 1, 1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }
    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Client testClient = new Client("testName", 1);

      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }
    [TestMethod]
    public void SaveAndGetAll_SavesToDatabaseAndReturnAll_Client()
    {
      //Arrange
      Client testClient = new Client("testName", 1);

      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
    [TestMethod]
    public void Find_FindClientInDatabase_Client()
    {
      //Arrange
      List<Client> testList = new List<Client> {};
      Client testClient = new Client("testName", 1);
      testClient.Save();
      testList.Add(testClient);

      //Act
      Client resultClient = Client.Find(testClient.GetId());
      List<Client> resultList = Client.FindByStylistId(testClient.GetStylistId());

      //Assert
      Assert.AreEqual(testClient, resultClient);
      CollectionAssert.AreEqual(testList, resultList);
    }
  }
}
