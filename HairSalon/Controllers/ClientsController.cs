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
    [HttpGet("/clients/{id}")]
    public ActionResult Detail(int id)
    {
      // Dictionary<string, object> model = new Dictionary<string, object>();
      // Client selectedClient = Client.Find(id);
      // List<Stylist> allStylists = Stylist.GetAll();
      // model.Add("selectedClient", selectedClient);
      // model.Add("allStylists", allStylists);
      // return View(model);
      return View(Client.Find(id));
    }
    [HttpPost("/clients/{clientId}/changename")]
    public ActionResult EditClientName(int clientId, string newName)
    {
      Client.Find(clientId).ChangeName(newName);
      return RedirectToAction("Detail", new { id = clientId});
    }
    [HttpPost("/clients/{clientId}/changestylist")]
    public ActionResult ChangeStylist(int clientId, int stylistId)
    {
      Client.Find(clientId).ChangeStylistId(stylistId);
      return RedirectToAction("Detail", new { id = clientId});
    }
  }
}
