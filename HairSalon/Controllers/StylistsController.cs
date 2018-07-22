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
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
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
    [HttpPost("/stylists/delete")]
    public ActionResult Delete(int stylistId)
    {
      Stylist.Find(stylistId).Delete();
      return RedirectToAction("Index");
    }
    [HttpGet("/stylists/{id}")]
    public ActionResult Detail(int id)
    {
      return View(Stylist.Find(id));
    }
    [HttpPost("/stylists/{stylistId}/changename")]
    public ActionResult EditName(int stylistId, string newName)
    {
      Stylist.Find(stylistId).ChangeName(newName);
      return RedirectToAction("Detail", new { id = stylistId});
    }
    [HttpPost("/stylists/{stylistId}/addclient")]
    public ActionResult AddClient(int stylistId, string clientName)
    {
      Client newClient = new Client(clientName, stylistId);
      newClient.Save();
      return RedirectToAction("Detail", new { id = stylistId});
    }
    [HttpPost("/stylists/{stylistId}/addspecialty")]
    public ActionResult AddSpecialty(int stylistId, int specialtyId)
    {
      StylistSpecialty newPair = new StylistSpecialty(stylistId, specialtyId);
      newPair.Save();
      return RedirectToAction("Detail", new { id = stylistId});
    }
    [HttpPost("/stylists/{stylistId}/removespecialty")]
    public ActionResult RemoveSpecialty(int stylistId, int specialtyId)
    {
      Stylist.Find(stylistId).RemoveSpecialty(specialtyId);
      return RedirectToAction("Detail", new { id = stylistId});
    }
  }
}
