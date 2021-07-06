// BLUPOINT.Source.Proveedores
using System.Data;
using BLUPOINT.Config;
using MySql.Data.MySqlClient;

internal class Proveedores
{
	public string id { get; set; }

	public string Nombre { get; set; }

	public string Telefono { get; set; }

	public string Mail { get; set; }

	public string Fecha { get; set; }

	public Proveedores()
	{
	}

	public Proveedores(string id, string nombre, string telefono, string mail, string fecha)
	{
		this.id = id;
		Nombre = nombre;
		Telefono = telefono;
		Mail = mail;
		Fecha = fecha;
	}

	public int POST()
	{
		DB dB = new DB();
		try
		{
			if (RevisarExistencia(dB.Conexion()) == "")
			{
				MySqlCommand mySqlCommand = new MySqlCommand();
				dB.Conexion().Open();
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandText = "INSERT INTO Proveedor(Nombre, Mail, Telefono, Fecha) VALUES(@nombre,@mail,@tel,fecha)";
				mySqlCommand.Parameters.AddWithValue("nombre", Nombre);
				mySqlCommand.Parameters.AddWithValue("mail", Mail);
				mySqlCommand.Parameters.AddWithValue("tel", Telefono);
				mySqlCommand.Parameters.AddWithValue("fecha", Fecha);
				if (mySqlCommand.ExecuteNonQuery() == 1)
				{
					return 1;
				}
				return 2;
			}
			return 3;
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

	public int UPDATE()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "UPDATE Proveedor SET Nombre=(@nombre), Mail=(@mail), Telefono=(@tel), Fecha=(@fecha) WHERE idProveedor='" + id + "'";
			mySqlCommand.Parameters.AddWithValue("nombre", Nombre);
			mySqlCommand.Parameters.AddWithValue("mail", Mail);
			mySqlCommand.Parameters.AddWithValue("tel", Telefono);
			mySqlCommand.Parameters.AddWithValue("fecha", Fecha);
			if (mySqlCommand.ExecuteNonQuery() == 1)
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

	private string RevisarExistencia(MySqlConnection con)
	{
		string result = "";
		string cmdText = "SELECT idProveedor FROM Proveedor WHERE Nombre='" + Nombre + "'";
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand(cmdText, con);
			con.Open();
			result = mySqlCommand.ExecuteScalar().ToString();
		}
		catch
		{
		}
		finally
		{
			con.Close();
		}
		return result;
	}

	public DataTable GETBYNAME()
	{
		DataTable result = new DataTable();
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Proveedor WHERE Nombre LIKE '%" + Nombre + "%'";
			result = dB.ExeReader(mySqlCommand);
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

	public DataTable GET()
	{
		DataTable result = new DataTable();
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Proveedor";
			result = dB.ExeReader(mySqlCommand);
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

	public DataTable GETPROV()
	{
		DataTable result = new DataTable();
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT Nombre FROM Proveedor";
			result = dB.ExeReader(mySqlCommand);
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

	public int DELETE()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "DELETE FROM Proveedor WHERE idProveedor='" + id + "'";
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
