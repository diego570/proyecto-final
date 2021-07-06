// BLUPOINT.Source.Credito
using System.Data;
using BLUPOINT.Config;
using MySql.Data.MySqlClient;

internal class Credito
{
	public string Nombre_U { get; set; }

	public string Total_P { get; set; }

	public string fecha_P { get; set; }

	public string id_Cred { get; set; }

	public string abono { get; set; }

	public int INSERT()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "INSERT INTO Credito(Nombre_U, Total_Pago, Fecha_Pago) VALUES(@nombre, @total, @fecha)";
			mySqlCommand.Parameters.AddWithValue("nombre", Nombre_U);
			mySqlCommand.Parameters.AddWithValue("total", Total_P);
			mySqlCommand.Parameters.AddWithValue("fecha", fecha_P);
			if (dB.ExeNonQuery(mySqlCommand) == 1)
			{
				return 1;
			}
			return 0;
		}
		catch
		{
			return 0;
		}
		finally
		{
			dB.Conexion().Close();
		}
	}

	public DataTable GetUser(string filtro)
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			if (filtro == "Adeudos")
			{
				MySqlCommand mySqlCommand = new MySqlCommand();
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Credito WHERE Nombre_U LIKE '%" + Nombre_U + "%'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			}
			DataTable dataTable = new DataTable();
			MySqlCommand mySqlCommand2 = new MySqlCommand();
			mySqlCommand2.Connection = dB.Conexion();
			mySqlCommand2.CommandType = CommandType.Text;
			mySqlCommand2.CommandText = "SELECT * FROM Credito WHERE Nombre_U='" + Nombre_U + "'";
			dataTable = dB.ExeReader(mySqlCommand2);
			MySqlCommand mySqlCommand3 = new MySqlCommand();
			mySqlCommand3.Connection = dB.Conexion();
			mySqlCommand3.CommandType = CommandType.Text;
			mySqlCommand3.CommandText = "SELECT Abono, Fecha FROM Abono WHERE id_credito='" + dataTable.Rows[0]["idCredito"].ToString() + "'";
			result = dB.ExeReader(mySqlCommand3);
			return result;
		}
		catch
		{
			return result;
		}
		finally
		{
			dB.Conexion().Close();
		}
	}

	public int Eliminar()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "DELETE FROM Credito WHERE idCredito='" + id_Cred + "'";
			if (dB.ExeNonQuery(mySqlCommand) == 1)
			{
				return 1;
			}
			return 0;
		}
		catch
		{
			return 0;
		}
		finally
		{
			dB.Conexion().Close();
		}
	}

	public int Actualizar()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "UPDATE Credito SET Total_Pago = (@ab) WHERE idCredito='" + id_Cred + "'";
			mySqlCommand.Parameters.AddWithValue("ab", Total_P);
			if (dB.ExeNonQuery(mySqlCommand) == 1)
			{
				return 1;
			}
			return 0;
		}
		catch
		{
			return 0;
		}
		finally
		{
			dB.Conexion().Close();
		}
	}

	public int Abono()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "INSERT INTO Abono(id_credito, Abono, Fecha) VALUES(@id, @ab, @fecha)";
			mySqlCommand.Parameters.AddWithValue("id", id_Cred);
			mySqlCommand.Parameters.AddWithValue("ab", abono);
			mySqlCommand.Parameters.AddWithValue("fecha", fecha_P);
			if (dB.ExeNonQuery(mySqlCommand) == 1)
			{
				return 1;
			}
			return 0;
		}
		catch
		{
			return 0;
		}
		finally
		{
			dB.Conexion().Close();
		}
	}
}
