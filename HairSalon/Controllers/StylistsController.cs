using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylist = Stylist.GetAll();
      return View(allStylist);
    }
    [HttpGet("/stylists/new")]
    public ActionResult NewStylist()
    {
      return View();
    }
    [HttpPost("/stylists/new")]
    public ActionResult AddStylist(string name)
    {
      Stylist newStylist = new Stylist(name);
      newStylist.Save();
      return RedirectToAction("Index");
    }
    [HttpGet("/stylists/{id}")]
    public ActionResult StylistDetail(int id)
    {
      return View(Stylist.Find(id));
    }
    [HttpPost("/stylists/{stylistId}/addclient")]
    public ActionResult AddClient(int stylistId, string clientName)
    {
      Client newClient = new Client(clientName, stylistId);
      newClient.Save();
      return RedirectToAction("StylistDetail", new { id = stylistId});
    }
  }
}
