using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class StylistSpecialty
  {
    private int id;
    private int stylistId;
    private int specialtyId;

    public StylistSpecialty(int newStylistId, int newSpecialtyId, int newId = 0)
    {
      id = newId;
      stylistId = newStylistId;
      specialtyId = newSpecialtyId;
    }

    public int GetId()
    {
      return id;
    }

    public int GetStylistId()
    {
      return stylistId;
    }

    public int GetSpecialtyId()
    {
      return specialtyId;
    }

    public override bool Equals(System.Object otherStylistSpecialty)
    {
      if(!(otherStylistSpecialty is StylistSpecialty))
      {
        return false;
      }
      else
      {
        StylistSpecialty newStylistSpecialty = (StylistSpecialty) otherStylistSpecialty;
        bool idEquality = (this.GetId() == newStylistSpecialty.GetId());
        bool stylistIdEquality = this.GetStylistId().Equals(newStylistSpecialty.GetStylistId());
        bool specialtyIdEquality = this.GetSpecialtyId().Equals(newStylistSpecialty.GetSpecialtyId());
        return (idEquality && specialtyIdEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";
      MySqlParameter newStylistId = new MySqlParameter();
      newStylistId.ParameterName = "@StylistId";
      newStylistId.Value = this.stylistId;
      cmd.Parameters.Add(newStylistId);
      MySqlParameter newSpecialtyId = new MySqlParameter();
      newSpecialtyId.ParameterName = "@SpecialtyId";
      newSpecialtyId.Value = this.specialtyId;
      cmd.Parameters.Add(newSpecialtyId);
      cmd.ExecuteNonQuery();
      id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
    }

    public static List<StylistSpecialty> GetAll()
    {
      List<StylistSpecialty> allStylistSpecialties = new List<StylistSpecialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists_specialties;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        int stylistId = rdr.GetInt32(1);
        int specialtyId = rdr.GetInt32(2);
        StylistSpecialty newStylistSpecialty = new StylistSpecialty(stylistId, specialtyId, id);
        allStylistSpecialties.Add(newStylistSpecialty);
      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return allStylistSpecialties;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists_specialties;";
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
