using System;
using System.Data.SqlClient;
namespace ADONET_1
{
	public class DB
	{
		public DB()
		{
		}

		public void Select(SqlConnection connection)
		{
			var Sql = "SELECT * FROM Customers";
			var command = new SqlCommand(Sql, connection);
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				Console.WriteLine(reader["CompanyName"]);
			}
			reader.Close();
		}

		public void Insert(SqlConnection connection, int id, string regionName)
		{
			var Sql = "INSERT INTO dbo.Region (RegionId, RegionDescription) VALUES (@id, @regionName)";
			var command = new SqlCommand(Sql, connection);
			command.Parameters.AddWithValue("@id", id);
			command.Parameters.AddWithValue("@regionName", regionName);
			int affected = command.ExecuteNonQuery();
			Console.WriteLine($"{affected} rows affected");
		}

		public void Delete(SqlConnection connection, int id)
		{
			var Sql = "DELETE FROM dbo.Region WHERE (RegionID = @id)";
			var command = new SqlCommand(Sql, connection);
			command.Parameters.AddWithValue("@id", id);
			command.ExecuteNonQuery();
		}

		public void Update(SqlConnection connection, int id, string regionName)
		{
			var Sql = "UPDATE Region SET RegionDescription = @regionName WHERE (RegionId = @id)";
			var command = new SqlCommand(Sql, connection);
			command.Parameters.AddWithValue("@regionName", regionName);
			command.Parameters.AddWithValue("@id", id);
			command.ExecuteNonQuery();
		}
	}
}