﻿using terrain;
namespace aff
{
   public class Program
{
    public static void Main()
    {
        string connectionString = "Host=localhost;Username=postgres;Password=bloodseeker;Database=gestion";
        MyConnection myConnection = new MyConnection(connectionString);
        myConnection.OpenConnection();
        string query = "SELECT * FROM users;";
        myConnection.ExecuteQueryWithResult(query);
        myConnection.CloseConnection();
    }
}
}
