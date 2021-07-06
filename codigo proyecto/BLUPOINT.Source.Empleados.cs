// BLUPOINT.Source.Empleados
using System.Data;
using BLUPOINT.Config;
using MySql.Data.MySqlClient;

internal class Empleados
{
	public string Nombre_E { get; set; }

	public string Apellido_E { get; set; }

	public string Fecha_N { get; set; }

	public string Tipo_Emp { get; set; }

	public string Clave { get; set; }

	public string Imagen { get; set; }

	public string id { get; set; }

	public string Cliente { get; set; }

	public string Producto { get; set; }

	public string usuario { get; set; }

	public string Caja { get; set; }

	public string Pass { get; set; }

	public Empleados()
	{
	}

	public Empleados(string id, string nombre, string apellido, string fecha, string tipo, string clave, string img, string cliente, string producto, string usuario, string caja, string pass)
	{
		this.id = id;
		Nombre_E = nombre;
		Apellido_E = apellido;
		Fecha_N = fecha;
		Tipo_Emp = tipo;
		Clave = clave;
		Imagen = img;
		Producto = producto;
		Cliente = cliente;
		this.usuario = usuario;
		Caja = caja;
		Pass = pass;
	}

	public string verificarEntrada()
	{
		DB dB = new DB();
		DataTable dataTable = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "Select count(idAsistencia) as cuenta from Asistencia WHERE id_Us='" + id + "' AND Fecha='" + Fecha_N + "' AND Hora_fin=''";
			dataTable = dB.ExeReader(mySqlCommand);
			return dataTable.Rows[0]["cuenta"].ToString();
		}
		catch
		{
			return "0";
		}
		finally
		{
			dB.Conexion().Close();
		}
	}

	public int Registrar()
	{
		DB dB = new DB();
		try
		{
			if (RevisarExistencia(dB.Conexion()) == "")
			{
				MySqlCommand mySqlCommand = new MySqlCommand();
				dB.Conexion().Open();
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandText = "INSERT INTO Empleado(Nombre, Apellidos, Fecha_N, Tipo_Emp, Clave,Pass, Imagen,Cliente, Producto, Usuario, Caja)VALUES(@nombre,@apellido,@fecha,@tipo,@clave,@pass,@imagen,@cliente, @producto, @usuario,@caja)";
				mySqlCommand.Parameters.AddWithValue("nombre", Nombre_E);
				mySqlCommand.Parameters.AddWithValue("apellido", Apellido_E);
				mySqlCommand.Parameters.AddWithValue("fecha", Fecha_N);
				mySqlCommand.Parameters.AddWithValue("tipo", Tipo_Emp);
				mySqlCommand.Parameters.AddWithValue("clave", Clave);
				mySqlCommand.Parameters.AddWithValue("imagen", Imagen);
				mySqlCommand.Parameters.AddWithValue("cliente", Cliente);
				mySqlCommand.Parameters.AddWithValue("producto", Producto);
				mySqlCommand.Parameters.AddWithValue("usuario", usuario);
				mySqlCommand.Parameters.AddWithValue("pass", Pass);
				mySqlCommand.Parameters.AddWithValue("caja", Caja);
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

	public string EmpleadosTotales()
	{
		DataTable dataTable = new DataTable();
		string result = "0";
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT COUNT(idEmpleado) AS tote FROM Empleado";
			dataTable = dB.ExeReader(mySqlCommand);
			result = dataTable.Rows[0]["tote"].ToString();
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

	public string VerificarTurno(string fecha)
	{
		DB dB = new DB();
		string result = "";
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			DataTable dataTable = new DataTable();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "SELECT COUNT(id_Us) AS conta FROM asistencia WHERE Id_Us='" + id + "' AND Fecha='" + fecha + "'";
			dataTable = dB.ExeReader(mySqlCommand);
			result = dataTable.Rows[0]["conta"].ToString();
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

	public int Salida(string fecha)
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			DataTable dataTable = new DataTable();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "SELECT COUNT(id_Us) AS conta FROM asistencia WHERE Id_Us='" + id + "' AND Fecha='" + fecha + "'";
			dataTable = dB.ExeReader(mySqlCommand);
			string text = dataTable.Rows[0]["conta"].ToString();
			if (text == "1")
			{
				text = "1";
			}
			else if (text == "2")
			{
				text = "2";
			}
			if (text == "2")
			{
				MySqlCommand mySqlCommand2 = new MySqlCommand();
				dB.Conexion().Open();
				mySqlCommand2.Connection = dB.Conexion();
				mySqlCommand2.CommandText = "UPDATE Asistencia SET Hora_fin=(@hora) WHERE Id_Us='" + id + "' AND Fecha='" + fecha + "' AND Turno='2'";
				mySqlCommand2.Parameters.AddWithValue("hora", Fecha_N);
				if (dB.ExeNonQuery(mySqlCommand2) == 1)
				{
					return 1;
				}
				return 0;
			}
			MySqlCommand mySqlCommand3 = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand3.Connection = dB.Conexion();
			mySqlCommand3.CommandText = "UPDATE Asistencia SET Hora_fin=(@hora) WHERE Id_Us='" + id + "' AND Fecha='" + fecha + "' AND Turno='1'";
			mySqlCommand3.Parameters.AddWithValue("hora", Fecha_N);
			if (dB.ExeNonQuery(mySqlCommand3) == 1)
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
		string cmdText = "SELECT idEmpleado FROM Empleado WHERE Clave='" + Clave + "'";
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

	public DataTable Login()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Empleado WHERE Clave='" + Clave + "'";
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

	public DataTable Login2()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Empleado WHERE Nombre='" + Nombre_E + "' AND Pass='" + Pass + "'";
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
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "DELETE FROM Empleado WHERE idEmpleado='" + id + "'";
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

	public int UPDATE()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "UPDATE Empleado SET Nombre=(@nombre),Apellidos=(@apellido),Fecha_N=(@fecha),Tipo_Emp=(@tipo),Clave=(@clave),Imagen=(@imagen),Cliente=(@cliente), Producto=(@producto), Usuario=(@usuario), Pass=(@pass), Caja=(@caja) WHERE idEmpleado='" + id + "'";
			mySqlCommand.Parameters.AddWithValue("nombre", Nombre_E);
			mySqlCommand.Parameters.AddWithValue("apellido", Apellido_E);
			mySqlCommand.Parameters.AddWithValue("fecha", Fecha_N);
			mySqlCommand.Parameters.AddWithValue("tipo", Tipo_Emp);
			mySqlCommand.Parameters.AddWithValue("clave", Clave);
			mySqlCommand.Parameters.AddWithValue("imagen", Imagen);
			mySqlCommand.Parameters.AddWithValue("cliente", Cliente);
			mySqlCommand.Parameters.AddWithValue("producto", Producto);
			mySqlCommand.Parameters.AddWithValue("usuario", usuario);
			mySqlCommand.Parameters.AddWithValue("pass", Pass);
			mySqlCommand.Parameters.AddWithValue("caja", Caja);
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

	public DataTable GETEmp()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Empleado";
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

	public int InsertHour(string Hora_in, string hora_fin)
	{
		DB dB = new DB();
		try
		{
			DataTable dataTable = new DataTable();
			MySqlCommand mySqlCommand = new MySqlCommand();
			MySqlCommand mySqlCommand2 = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "SELECT COUNT(id_Us) AS conta FROM asistencia WHERE Id_Us='" + id + "' AND Fecha='" + Fecha_N + "'";
			dataTable = dB.ExeReader(mySqlCommand);
			string text = "1";
			if (dataTable.Rows[0]["conta"].ToString() == "1")
			{
				text = "2";
			}
			else
			{
				if (!(dataTable.Rows[0]["conta"].ToString() == "0"))
				{
					return 0;
				}
				text = "1";
			}
			dB.Conexion().Open();
			mySqlCommand2.Connection = dB.Conexion();
			mySqlCommand2.CommandText = "INSERT INTO asistencia(Id_Us, Hora_In, Hora_fin, Fecha, Turno)VALUES(@id_u, @hr_in,@hr_fin,@fecha, @turno)";
			mySqlCommand2.Parameters.AddWithValue("id_u", id);
			mySqlCommand2.Parameters.AddWithValue("hr_in", Hora_in);
			mySqlCommand2.Parameters.AddWithValue("hr_fin", hora_fin);
			mySqlCommand2.Parameters.AddWithValue("fecha", Fecha_N);
			mySqlCommand2.Parameters.AddWithValue("turno", text);
			if (dB.ExeNonQuery(mySqlCommand2) == 1)
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

	public DataTable GETASIS(string filter)
	{
		DataTable result = new DataTable();
		MySqlCommand mySqlCommand = new MySqlCommand();
		DB dB = new DB();
		try
		{
			switch (filter)
			{
			case "Dia":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Asistencia WHERE Id_Us='" + id + "' AND Fecha LIKE '%" + Fecha_N + "%'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			case "Mes":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Asistencia WHERE Id_Us='" + id + "' AND Fecha LIKE '%" + Fecha_N + "%'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			case "Anio":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Asistencia WHERE Id_Us='" + id + "' AND Fecha LIKE '%" + Fecha_N + "%'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			case "Normal":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Asistencia WHERE Id_Us='" + id + "'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			default:
				return result;
			}
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

	public DataTable GETBOX(string filter)
	{
		DataTable result = new DataTable();
		MySqlCommand mySqlCommand = new MySqlCommand();
		DB dB = new DB();
		try
		{
			switch (filter)
			{
			case "Dia":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Caja_Open WHERE Nombre_Us='" + Nombre_E + "' AND Fecha LIKE '%" + Fecha_N + "%' AND Id_Caja='" + id + "'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			case "Mes":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Caja_Open WHERE Nombre_Us='" + Nombre_E + "' AND Fecha LIKE '%" + Fecha_N + "%' AND Id_Caja='" + id + "'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			case "Anio":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Caja_Open WHERE Nombre_Us='" + Nombre_E + "' AND Fecha LIKE '%" + Fecha_N + "%' AND Id_Caja='" + id + "'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			case "Normal":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Caja_Open WHERE Nombre_Us='" + Nombre_E + "' AND Fecha LIKE '%" + Fecha_N + "%'  AND Id_Caja='" + id + "'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			default:
				return result;
			}
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
			mySqlCommand.CommandText = "SELECT * FROM Empleado WHERE Clave='" + Clave + "' OR Nombre ='" + Clave + "'";
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
}
