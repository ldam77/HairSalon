using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }
    [HttpGet("/specialties/new")]
    public ActionResult NewSpecialty()
    {
      return View();
    }
    [HttpPost("/specialties/new")]
    public ActionResult AddSpecialty(string specialtyName)
    {
      Specialty newSpecialty = new Specialty(specialtyName);
      newSpecialty.Save();
      return RedirectToAction("Index");
    }
    [HttpGet("/specialties/{id}")]
    public ActionResult Detail(int id)
    {
      return View(Specialty.Find(id));
    }
    [HttpPost("/specialties/{specialtyId}/addstylist")]
    public ActionResult AddStylist(int specialtyId, int stylistId)
    {
      StylistSpecialty newPair = new StylistSpecialty(stylistId, specialtyId);
      newPair.Save();
      return RedirectToAction("Detail", new { id = specialtyId});
    }
  }
}
