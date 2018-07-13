using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int id;
    private string name;

    public Stylist(string newName, int newId = 0)
    {
      name = newName;
      id = newId;
    }

    public int GetId()
    {
      return id;
    }

    public string GetName()
    {
      return name;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool nameEquality = this.GetName().Equals(newStylist.GetName());
        return (idEquality && nameEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@stylistName);";
      MySqlParameter newName = new MySqlParameter();
      newName.ParameterName = "@stylistName";
      newName.Value = this.name;
      cmd.Parameters.Add(newName);
      cmd.ExecuteNonQuery();
      id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Stylist newStylist = new Stylist(name, id);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public static Stylist Find(int inputId)
    {
      int id = 0;
      string name = "";
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = @Id;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@Id";
      searchId.Value = inputId;
      cmd.Parameters.Add(searchId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
      }
      Stylist foundStylist = new Stylist(name, id);
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return foundStylist;
    }

    public static List<Stylist> Find(string inputName)
    {
      List<Stylist> foundStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE name LIKE @Name;";
      MySqlParameter searchName = new MySqlParameter();
      searchName.ParameterName = "@Name";
      searchName.Value = inputName + '%';
      cmd.Parameters.Add(searchName);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Stylist newStylist = new Stylist(name, id);
        foundStylists.Add(newStylist);
      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return foundStylists;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
