// BLUPOINT.Source.Clientes
using System.Data;
using BLUPOINT.Config;
using MySql.Data.MySqlClient;

internal class Clientes
{
	public string id { get; set; }

	public string Nombre { get; set; }

	public string Apellido { get; set; }

	public string Calle { get; set; }

	public string Colonia { get; set; }

	public string No_Ex { get; set; }

	public string Clave_U { get; set; }

	public string Mayorista { get; set; }

	public string Credito { get; set; }

	public string Fecha_Nac { get; set; }

	public string Telefono { get; set; }

	public string Correo { get; set; }

	public Clientes()
	{
	}

	public Clientes(string id, string Nombre, string apellido, string calle, string colonia, string no, string clave, string may, string cred, string fech, string telefono, string correo)
	{
		this.id = id;
		this.Nombre = Nombre;
		Apellido = apellido;
		Calle = calle;
		Colonia = colonia;
		No_Ex = no;
		Clave_U = clave;
		Mayorista = may;
		Credito = cred;
		Fecha_Nac = fech;
		Telefono = telefono;
	}

	public int INSERT()
	{
		DB dB = new DB();
		try
		{
			if (RevisarExistencia(dB.Conexion()) == "")
			{
				MySqlCommand mySqlCommand = new MySqlCommand();
				dB.Conexion().Open();
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandText = "INSERT INTO Cliente(Nombre, Apellidos, Calle, Colonia, No_Ex, Clave_U,Mayorista, Credito, Fecha_Nac, Telefono, Correo)VALUES(@nombre,@apellido,@calle,@colonia,@No,@clave,@may, @cred, @fecha, @telefono, @correo)";
				mySqlCommand.Parameters.AddWithValue("nombre", Nombre);
				mySqlCommand.Parameters.AddWithValue("apellido", Apellido);
				mySqlCommand.Parameters.AddWithValue("calle", Calle);
				mySqlCommand.Parameters.AddWithValue("colonia", Colonia);
				mySqlCommand.Parameters.AddWithValue("No", No_Ex);
				mySqlCommand.Parameters.AddWithValue("clave", Clave_U);
				mySqlCommand.Parameters.AddWithValue("may", Mayorista);
				mySqlCommand.Parameters.AddWithValue("cred", Credito);
				mySqlCommand.Parameters.AddWithValue("fecha", Fecha_Nac);
				mySqlCommand.Parameters.AddWithValue("telefono", Telefono);
				mySqlCommand.Parameters.AddWithValue("correo", Correo);
				if (dB.ExeNonQuery(mySqlCommand) == 1)
				{
					return 1;
				}
				return 0;
			}
			return 2;
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
		string cmdText = "SELECT idCliente FROM Cliente WHERE clave_u='" + Clave_U + "'";
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

	public string RevisarExistencia(int clave)
	{
		DB dB = new DB();
		string result = "";
		string cmdText = "SELECT idCliente FROM Cliente WHERE clave_u='" + clave + "'";
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand(cmdText, dB.Conexion());
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			result = mySqlCommand.ExecuteScalar().ToString();
		}
		catch
		{
			return result;
		}
		finally
		{
			dB.Conexion().Close();
		}
		return result;
	}

	public int DELETE()
	{
		DB dB = new DB();
		try
		{
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "DELETE FROM cliente WHERE idCliente='" + id + "'";
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

	public DataTable GETCli()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Cliente";
			result = dB.ExeReader(mySqlCommand);
			dB.Conexion().Close();
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

	public DataTable GETBYID()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Cliente WHERE Nombre LIKE '%" + Nombre + "%'";
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

	public int UPDATE()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "UPDATE Cliente SET Nombre=(@nombre),Apellidos=(@apellido),Calle=(@calle),Colonia=(@colonia),No_Ex=(@no),Clave_U=(@clave),Mayorista=(@may), Credito=(@cred), Fecha_Nac=(@fecha), Telefono=(@telefono), Correo=(@correo) WHERE idCliente='" + id + "'";
			mySqlCommand.Parameters.AddWithValue("nombre", Nombre);
			mySqlCommand.Parameters.AddWithValue("apellido", Apellido);
			mySqlCommand.Parameters.AddWithValue("calle", Calle);
			mySqlCommand.Parameters.AddWithValue("colonia", Colonia);
			mySqlCommand.Parameters.AddWithValue("No", No_Ex);
			mySqlCommand.Parameters.AddWithValue("clave", Clave_U);
			mySqlCommand.Parameters.AddWithValue("may", Mayorista);
			mySqlCommand.Parameters.AddWithValue("cred", Credito);
			mySqlCommand.Parameters.AddWithValue("fecha", Fecha_Nac);
			mySqlCommand.Parameters.AddWithValue("telefono", Telefono);
			mySqlCommand.Parameters.AddWithValue("correo", Correo);
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
