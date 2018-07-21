using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/clients")]
    public ActionResult Index()
    {
      List<Client> allClients = Client.GetAll();
      return View(allClients);
    }
    [HttpGet("/clients/new")]
    public ActionResult NewClient()
    {
      return View(Stylist.GetAll());
    }
    [HttpPost("/clients/new")]
    public ActionResult AddClient(string clientName, int stylistId)
    {
      Client newClient = new Client(clientName, stylistId);
      newClient.Save();
      return RedirectToAction("Index");
    }
    [HttpPost("/clients/delete")]
    public ActionResult Delete(int clientId)
    {
      Client.Find(clientId).Delete();
      return RedirectToAction("Index");
    }
  }
}
