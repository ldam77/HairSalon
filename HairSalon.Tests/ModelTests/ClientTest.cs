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
      Client testClient = new Client("testName", 1);
      testClient.Save();

      //Act
      Client resultClient = Client.Find(testClient.GetId());

      //Assert
      Assert.AreEqual(testClient, resultClient);
    }
    [TestMethod]
    public void FindStylist_FindThisClientStylist_ReturnStylist()
    {
      // Arrange
      Stylist testStylist = new Stylist("testStylist");
      testStylist.Save();
      Client testClient = new Client("testClient", testStylist.GetId());
      testClient.Save();

      // Act
      Stylist resultStylist = testClient.GetStylist();

      // Assert
      Assert.AreEqual(testStylist, resultStylist);
    }
    [TestMethod]
    public void ChangeName_ChangeClientNameInDatabase_Client()
    {
      // Arrange
      Client testClient = new Client("testName1", 1);
      testClient.Save();
      string testName = "testname2";

      // Act
      testClient.ChangeName(testName);

      // Assert
      Assert.AreEqual(testName, Client.Find(testClient.GetId()).GetName());
    }
    [TestMethod]
    public void ChangeStylistId_ChangeClientStylistIdInDatabase_Client()
    {
      // Arrange
      Client testClient = new Client("testName1", 1);
      testClient.Save();
      int testStylistId = 2;

      // Act
      testClient.ChangeStylistId(testStylistId);

      // Assert
      Assert.AreEqual(testStylistId, Client.Find(testClient.GetId()).GetStylistId());
    }
    [TestMethod]
    public void Delete_DeleteClientFromDatabase_Client()
    {
      // Arrange
      Client testClient = new Client("testName", 1);
      testClient.Save();

      // Act
      testClient.Delete();

      // Assert
      Assert.AreEqual(0, Client.Find(testClient.GetId()).GetId());
    }
  }
}
