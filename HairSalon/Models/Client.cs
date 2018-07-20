using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Client
  {
    private int id;
    private string name;
    private int stylistId;

    public Client(string newName, int newStylistId, int newId = 0)
    {
      name = newName;
      stylistId = newStylistId;
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

    public int GetStylistId()
    {
      return stylistId;
    }

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = this.GetName().Equals(newClient.GetName());
        bool stylistIdEquality = this.GetStylistId().Equals(newClient.GetStylistId());
        return (idEquality && nameEquality && stylistIdEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@ClientName, @StylistId);";
      MySqlParameter newName = new MySqlParameter();
      newName.ParameterName = "@ClientName";
      newName.Value = this.name;
      cmd.Parameters.Add(newName);
      MySqlParameter newStylistId = new MySqlParameter();
      newStylistId.ParameterName = "@StylistId";
      newStylistId.Value = this.stylistId;
      cmd.Parameters.Add(newStylistId);
      cmd.ExecuteNonQuery();
      id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Client newClient = new Client(name, stylistId, id);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public static Client Find(int inputId)
    {
      int id = 0;
      string name = "";
      int stylistId = 0;
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = @Id;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@Id";
      searchId.Value = inputId;
      cmd.Parameters.Add(searchId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        stylistId = rdr.GetInt32(2);
      }
      Client foundClient = new Client(name, stylistId, id);
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return foundClient;
    }

    // Find client by stylist Id
    public static List<Client> FindByStylistId(int searchId)
    {
      List<Client> foundClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @StylistId;";
      MySqlParameter searchStylistId = new MySqlParameter();
      searchStylistId.ParameterName = "@StylistId";
      searchStylistId.Value = searchId;
      cmd.Parameters.Add(searchStylistId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Client newClient = new Client(name, stylistId, id);
        foundClients.Add(newClient);
      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return foundClients;
    }

    public void ChangeName(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET name = @newName WHERE id = @searchId;";
      MySqlParameter editName = new MySqlParameter();
      editName.ParameterName = "@newName";
      editName.Value = newName;
      cmd.Parameters.Add(editName);
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this.id;
      cmd.Parameters.Add(searchId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void ChangeStylistId(int newStylistId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET stylist_id = @newStylistId WHERE id = @searchId;";
      MySqlParameter editStylistId = new MySqlParameter();
      editStylistId.ParameterName = "@newStylistId";
      editStylistId.Value = newStylistId;
      cmd.Parameters.Add(editStylistId);
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this.id;
      cmd.Parameters.Add(searchId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE id = @Id;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@Id";
      searchId.Value = this.id;
      cmd.Parameters.Add(searchId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
