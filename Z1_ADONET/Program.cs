
using System;
using System.Data.SqlClient;
namespace ADONET_1
{
	class Program
	{
		static void Main(string[] args)
		{
			var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			var sql = "SELECT * FROM Customers";

				
			using var connection = new SqlConnection(connectionString);
			var command = new SqlCommand(sql, connection);
			var db = new DB();
			connection.Open();
			db.Select(connection);
			Console.ReadLine();
			db.Insert(connection, 10, "Bielsko");
			Console.ReadLine();
			db.Delete(connection, 10);
			Console.ReadLine();
			db.Update(connection, 4, "Andrychow");
			Console.ReadLine();


			connection.Close();
		}
	}
}