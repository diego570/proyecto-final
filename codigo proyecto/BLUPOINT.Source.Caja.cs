// BLUPOINT.Source.Caja
using System;
using System.Data;
using BLUPOINT.Config;
using MySql.Data.MySqlClient;

internal class Caja
{
	public string Nombre_C { get; set; }

	public string Default { get; set; }

	public string Cantidad { get; set; }

	public string id_caja { get; set; }

	public string Usuario { get; set; }

	public string Calculado { get; set; }

	public string Contado { get; set; }

	public string Diferencia { get; set; }

	public string Retirado { get; set; }

	public string concepto { get; set; }

	public string Fecha { get; set; }

	public string Tipo_Pago { get; set; }

	public string Hora { get; set; }

	public string Tipo_E { get; set; }

	public string Nombre_U { get; set; }

	public string tipo_consumo { get; set; }

	public string VerificarDato()
	{
		DB dB = new DB();
		DataTable dataTable = new DataTable();
		string result = "";
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT COUNT(idCorte_Caja) AS canti FROM corte_caja WHERE Fecha='" + Fecha + "' AND id_caja='" + id_caja + "' AND Usuario='" + Usuario + "'";
			dataTable = dB.ExeReader(mySqlCommand);
			result = dataTable.Rows[0]["canti"].ToString();
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

	public int UPDATEBOX()
	{
		DB dB = new DB();
		try
		{
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "UPDATE caja SET Nombre_Caja=(@nombre),Cantidad=(@cantidad) WHERE idCaja='" + id_caja + "'";
			mySqlCommand.Parameters.AddWithValue("nombre", Nombre_C);
			mySqlCommand.Parameters.AddWithValue("cantidad", Cantidad);
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

	public int Box()
	{
		DB dB = new DB();
		try
		{
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "INSERT INTO Caja(Nombre_Caja, Cantidad, Defaults)VALUES(@nombre,@cantidad,@def)";
			mySqlCommand.Parameters.AddWithValue("nombre", Nombre_C);
			mySqlCommand.Parameters.AddWithValue("cantidad", Cantidad);
			mySqlCommand.Parameters.AddWithValue("def", Default);
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

	public int OpenBox()
	{
		DB dB = new DB();
		try
		{
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "INSERT INTO Caja_Open(id_Caja, open, Fecha, Nombre_Us, Tipo_E, Tipo_Consumo)VALUES(@id,@hr,@fecha,@nombre,@tipo,@tipo_c)";
			mySqlCommand.Parameters.AddWithValue("id", id_caja);
			mySqlCommand.Parameters.AddWithValue("hr", Hora);
			mySqlCommand.Parameters.AddWithValue("fecha", Fecha);
			mySqlCommand.Parameters.AddWithValue("nombre", Nombre_U);
			mySqlCommand.Parameters.AddWithValue("tipo", Tipo_E);
			mySqlCommand.Parameters.AddWithValue("tipo_c", tipo_consumo);
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

	public DataTable GetOpenBox()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM corte_caja WHERE id_Caja='" + id_caja + "';";
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

	public DataTable GETFilterOpenBox()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM corte_caja WHERE Fecha='" + Fecha + "' AND id_Caja='" + id_caja + "'";
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

	public int INSERTBOX(string Empleado, string tipo)
	{
		DB dB = new DB();
		try
		{
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			DataTable dataTable = new DataTable();
			dataTable = GETMONEY();
			id_caja = dataTable.Rows[0]["idCaja"].ToString();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "INSERT INTO Entradas(Cantidad, Fecha, Nombre_E, Tipo_E, id_caja, Concepto, Tipo_Pago)VALUES(@cantidad,@fecha,@nombre,@tipo,@id, @concept, @tipo_p)";
			mySqlCommand.Parameters.AddWithValue("cantidad", Cantidad);
			mySqlCommand.Parameters.AddWithValue("Fecha", Fecha);
			mySqlCommand.Parameters.AddWithValue("nombre", Empleado);
			mySqlCommand.Parameters.AddWithValue("tipo", tipo);
			mySqlCommand.Parameters.AddWithValue("id", id_caja);
			mySqlCommand.Parameters.AddWithValue("concept", concepto);
			mySqlCommand.Parameters.AddWithValue("tipo_p", Tipo_Pago);
			if (dB.ExeNonQuery(mySqlCommand) == 1)
			{
				Cantidad = (Convert.ToDouble(dataTable.Rows[0]["Cantidad"].ToString()) + Convert.ToDouble(Cantidad)).ToString();
				ActualizarCaja();
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

	public int INSERTEXIT(string Empleado, string tipo)
	{
		DB dB = new DB();
		try
		{
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			DataTable dataTable = new DataTable();
			dataTable = GETMONEY();
			id_caja = dataTable.Rows[0]["idCaja"].ToString();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "INSERT INTO Salidas(Cantidad, Fecha, Usuario, Tipo_E, id_caja, Concepto)VALUES(@cantidad,@fecha,@nombre,@tipo,@id, @concept)";
			mySqlCommand.Parameters.AddWithValue("cantidad", Cantidad);
			mySqlCommand.Parameters.AddWithValue("Fecha", Fecha);
			mySqlCommand.Parameters.AddWithValue("nombre", Empleado);
			mySqlCommand.Parameters.AddWithValue("tipo", tipo);
			mySqlCommand.Parameters.AddWithValue("id", id_caja);
			mySqlCommand.Parameters.AddWithValue("concept", concepto);
			if (dB.ExeNonQuery(mySqlCommand) == 1)
			{
				Cantidad = (Convert.ToDouble(dataTable.Rows[0]["Cantidad"].ToString()) - Convert.ToDouble(Cantidad)).ToString();
				ActualizarCaja();
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

	public string GETType(string tipos)
	{
		DB dB = new DB();
		DataTable dataTable = new DataTable();
		string text = "0.0";
		try
		{
			if (tipos == "Tarjeta")
			{
				MySqlCommand mySqlCommand = new MySqlCommand();
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT SUM(Cantidad) as cantidad FROM entradas c WHERE Tipo_Pago LIKE'%" + tipos + "%' AND Fecha='" + Fecha + "' AND id_caja='" + id_caja + "'";
				dataTable = dB.ExeReader(mySqlCommand);
				return dataTable.Rows[0]["Cantidad"].ToString();
			}
			MySqlCommand mySqlCommand2 = new MySqlCommand();
			mySqlCommand2.Connection = dB.Conexion();
			mySqlCommand2.CommandType = CommandType.Text;
			mySqlCommand2.CommandText = "SELECT SUM(Cantidad) as cantidad FROM entradas c WHERE Tipo_Pago ='" + tipos + "' AND Fecha='" + Fecha + "' AND id_caja='" + id_caja + "'";
			dataTable = dB.ExeReader(mySqlCommand2);
			return dataTable.Rows[0]["Cantidad"].ToString();
		}
		catch
		{
			return "0.0";
		}
		finally
		{
			dB.Conexion().Close();
		}
	}

	public DataTable GETMONEY()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT idCaja, Cantidad, Nombre_Caja FROM Caja WHERE Defaults='1'";
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

	public DataTable FILTERENTER()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Entradas WHERE id_caja='" + id_caja + "' AND Nombre_E='" + Nombre_U + "' AND Fecha LIKE'%" + Fecha + "%'";
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

	public DataTable FILTERSalida()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Salidas WHERE id_caja='" + id_caja + "' AND Nombre_E='" + Nombre_U + "' AND Fecha LIKE'%" + Fecha + "%'";
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

	public DataTable GETENTER()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT Cantidad, Concepto, Nombre_E, Tipo_E,Tipo_Pago, Fecha FROM Entradas WHERE Fecha='" + Fecha + "' AND id_caja='" + id_caja + "'";
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

	public DataTable GETSAL()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT Cantidad, Concepto, Usuario, Tipo_E, Fecha FROM Salidas WHERE Fecha='" + Fecha + "' AND id_caja='" + id_caja + "'";
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

	public DataTable GETSALID()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT Cantidad, Concepto, Usuario, Tipo_E, Fecha FROM Salidas WHERE Fecha='" + Fecha + "' AND id_caja='" + id_caja + "' AND Usuario='" + Usuario + "'";
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

	public int ActualizarCaja()
	{
		DB dB = new DB();
		try
		{
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "UPDATE Caja SET Cantidad=(@cantidad) WHERE idCaja='" + id_caja + "'";
			mySqlCommand.Parameters.AddWithValue("cantidad", Cantidad);
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

	public int Asignar()
	{
		DB dB = new DB();
		try
		{
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "UPDATE Caja SET Defaults=(@def) WHERE idCaja='" + id_caja + "'";
			mySqlCommand.Parameters.AddWithValue("def", Default);
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

	public string GETBoxid()
	{
		DataTable dataTable = new DataTable();
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT  MAX(id_Caja) AS id_Caja, Fecha FROM Corte_Caja";
			dataTable = dB.ExeReader(mySqlCommand);
			return dataTable.Rows[0]["Fecha"].ToString();
		}
		catch
		{
			return "No hay Registros Aun";
		}
		finally
		{
			dB.Conexion().Close();
		}
	}

	public int RealizarCorte()
	{
		DB dB = new DB();
		try
		{
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "INSERT INTO corte_caja(id_Caja, Usuario, Contado, Calculado, Diferencia, Retirado, Fecha)VALUES(@id,@us,@con,@cal,@dif,@ret,@fecha)";
			mySqlCommand.Parameters.AddWithValue("id", id_caja);
			mySqlCommand.Parameters.AddWithValue("us", Usuario);
			mySqlCommand.Parameters.AddWithValue("con", Contado);
			mySqlCommand.Parameters.AddWithValue("cal", Calculado);
			mySqlCommand.Parameters.AddWithValue("dif", Diferencia);
			mySqlCommand.Parameters.AddWithValue("ret", Retirado);
			mySqlCommand.Parameters.AddWithValue("fecha", Fecha);
			return dB.ExeNonQuery(mySqlCommand);
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

	public int DELETE()
	{
		DB dB = new DB();
		try
		{
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "DELETE FROM Caja WHERE idCaja='" + id_caja + "'";
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

	public DataTable GET()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Caja";
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
