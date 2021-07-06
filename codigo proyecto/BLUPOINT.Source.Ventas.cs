// BLUPOINT.Source.Ventas
using System;
using System.Data;
using BLUPOINT.Config;
using MySql.Data.MySqlClient;

internal class Ventas
{
	public string idVenta { get; set; }

	public string Fecha { get; set; }

	public string Nombre_C { get; set; }

	public string Nombre_E { get; set; }

	public string Apellido_C { get; set; }

	public string Total { get; set; }

	public string SubTotal { get; set; }

	public string Efectivo { get; set; }

	public string Cambio { get; set; }

	public string Desc_Total { get; set; }

	public string Nombre_P { get; set; }

	public string Cantidad { get; set; }

	public string Iva { get; set; }

	public string Descuento { get; set; }

	public string Codigo { get; set; }

	public string Precio { get; set; }

	public string Importe { get; set; }

	public string Tipo_Pago { get; set; }

	public DataTable GETID()
	{
		DataTable result = new DataTable();
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT MAX(idVenta) AS idVenta FROM Venta";
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

	public DataTable GET(string filter)
	{
		DataTable result = new DataTable();
		DB dB = new DB();
		MySqlCommand mySqlCommand = new MySqlCommand();
		try
		{
			switch (filter)
			{
			case "Dia":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Venta WHERE Nombre_U='" + Nombre_E + "' AND Fecha LIKE '%" + Fecha + "%'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			case "Mes":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Venta WHERE Nombre_U='" + Nombre_E + "' AND Fecha LIKE '%" + Fecha + "%'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			case "Año":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Venta WHERE Nombre_U='" + Nombre_E + "' AND Fecha LIKE '%" + Fecha + "%'";
				result = dB.ExeReader(mySqlCommand);
				return result;
			case "Normal":
				mySqlCommand.Connection = dB.Conexion();
				mySqlCommand.CommandType = CommandType.Text;
				mySqlCommand.CommandText = "SELECT * FROM Venta WHERE Nombre_U='" + Nombre_E + "' AND Fecha='" + Fecha + "'";
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

	public int POST()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "INSERT INTO Venta(idVenta, Nombre_U, Fecha, Nombre_C, Apellido_C, Total, Subtotal, Efectivo,Cambio, Descuento_Total, Tipo_Pago) VALUES(@id,@No_E,@fecha,@N_C,@App_C,@total,@sub,@efe,@cambio, @desc, @tip)";
			mySqlCommand.Parameters.AddWithValue("id", idVenta);
			mySqlCommand.Parameters.AddWithValue("No_E", Nombre_E);
			mySqlCommand.Parameters.AddWithValue("fecha", Fecha);
			mySqlCommand.Parameters.AddWithValue("N_C", Nombre_C);
			mySqlCommand.Parameters.AddWithValue("App_C", Apellido_C);
			mySqlCommand.Parameters.AddWithValue("total", Total);
			mySqlCommand.Parameters.AddWithValue("sub", SubTotal);
			mySqlCommand.Parameters.AddWithValue("efe", Efectivo);
			mySqlCommand.Parameters.AddWithValue("cambio", Cambio);
			mySqlCommand.Parameters.AddWithValue("desc", Desc_Total);
			mySqlCommand.Parameters.AddWithValue("tip", Tipo_Pago);
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

	public int POST2()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "INSERT INTO Venta_detalle( id_venta, Nombre_Prod, Cantidad, Precio, Iva, Descuento, Codigo, Importe) VALUES(@id_ven,@N_P,@Cant,@Pre,@iva,@des,@cod,@imp)";
			mySqlCommand.Parameters.AddWithValue("id_ven", idVenta);
			mySqlCommand.Parameters.AddWithValue("N_P", Nombre_P);
			mySqlCommand.Parameters.AddWithValue("Cant", Cantidad);
			mySqlCommand.Parameters.AddWithValue("Pre", Precio);
			mySqlCommand.Parameters.AddWithValue("iva", Iva);
			mySqlCommand.Parameters.AddWithValue("des", Descuento);
			mySqlCommand.Parameters.AddWithValue("cod", Codigo);
			mySqlCommand.Parameters.AddWithValue("imp", Importe);
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

	public string VentasTotales()
	{
		DataTable dataTable = new DataTable();
		string result = "0";
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT COUNT(idVenta) AS totv FROM Venta";
			dataTable = dB.ExeReader(mySqlCommand);
			result = dataTable.Rows[0]["totv"].ToString();
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

	public string ProdMasVendido()
	{
		DataTable dataTable = new DataTable();
		string result = "0";
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT Nombre_Prod, COUNT( Nombre_Prod ) AS total, SUM(Cantidad) AS cant FROM  Venta_Detalle GROUP BY Nombre_Prod ORDER BY cant DESC";
			dataTable = dB.ExeReader(mySqlCommand);
			result = dataTable.Rows[0]["Nombre_Prod"].ToString();
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

	public int Disminium()
	{
		DataTable dataTable = new DataTable();
		DB dB = new DB();
		MySqlCommand mySqlCommand = new MySqlCommand();
		MySqlCommand mySqlCommand2 = new MySqlCommand();
		try
		{
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Producto WHERE Nombre_P='" + Nombre_P + "'";
			dataTable = dB.ExeReader(mySqlCommand);
			string value = dataTable.Rows[0]["Cantidad"].ToString();
			int num = Convert.ToInt32(value) - Convert.ToInt32(Cantidad);
			dB.Conexion().Open();
			mySqlCommand2.Connection = dB.Conexion();
			mySqlCommand2.CommandType = CommandType.Text;
			mySqlCommand2.CommandText = "UPDATE Producto SET Cantidad=(@res) WHERE Nombre_P='" + Nombre_P + "'";
			mySqlCommand2.Parameters.AddWithValue("res", num);
			if (mySqlCommand2.ExecuteNonQuery() == 1)
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
