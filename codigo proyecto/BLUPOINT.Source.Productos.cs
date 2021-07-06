// BLUPOINT.Source.Productos
using System;
using System.Data;
using BLUPOINT.Config;
using MySql.Data.MySqlClient;

internal class Productos
{
	public string Id { get; set; }

	public string Nombre_P { get; set; }

	public string Precio_U { get; set; }

	public string IVA { get; set; }

	public string Descuento { get; set; }

	public string Imagen { get; set; }

	public string Codigo { get; set; }

	public string Cantidad { get; set; }

	public string Cod_Alt { get; set; }

	public string proveedor { get; set; }

	public string Fecha_Reg { get; set; }

	public string Fecha_Cad { get; set; }

	public string Precio_Mayoreo { get; set; }

	public string Minimos { get; set; }

	public string Maximos { get; set; }

	public string ofer { get; set; }

	public Productos()
	{
	}

	public Productos(string nombre_p, string precio, string iva, string desc, string img, string cod, string cant, string coda, string fecha_c, string fecha_r, string proveedor, string pre_m, string id, string max, string min)
	{
		Nombre_P = nombre_p;
		Precio_U = precio;
		IVA = iva;
		Descuento = desc;
		Imagen = img;
		Codigo = cod;
		Cantidad = cant;
		Cod_Alt = coda;
		Fecha_Reg = fecha_r;
		Fecha_Cad = fecha_c;
		this.proveedor = proveedor;
		Precio_Mayoreo = pre_m;
		Id = id;
		Maximos = max;
		Minimos = min;
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
				mySqlCommand.CommandText = "INSERT INTO Producto(Nombre_P, Precio, IVA, Descuento, Imagen, Codigo, Cantidad, Codigo_Alterno,Fecha_reg, Fecha_Cad, Proveedor, Mayoreo, Maximos, Minimos) VALUES(@nombre,@precio,@iva,@descuento,@imagen,@codigo,@cantidad,@codigo_al,@fecha_r, @fecha_c,@prov,@mayoreo, @max,@min)";
				mySqlCommand.Parameters.AddWithValue("nombre", Nombre_P);
				mySqlCommand.Parameters.AddWithValue("precio", Precio_U);
				mySqlCommand.Parameters.AddWithValue("iva", IVA);
				mySqlCommand.Parameters.AddWithValue("descuento", Descuento);
				mySqlCommand.Parameters.AddWithValue("imagen", Imagen);
				mySqlCommand.Parameters.AddWithValue("codigo", Codigo);
				mySqlCommand.Parameters.AddWithValue("cantidad", Cantidad);
				mySqlCommand.Parameters.AddWithValue("codigo_al", Cod_Alt);
				mySqlCommand.Parameters.AddWithValue("fecha_r", Fecha_Reg);
				mySqlCommand.Parameters.AddWithValue("fecha_c", Fecha_Cad);
				mySqlCommand.Parameters.AddWithValue("prov", proveedor);
				mySqlCommand.Parameters.AddWithValue("mayoreo", Precio_Mayoreo);
				mySqlCommand.Parameters.AddWithValue("max", Maximos);
				mySqlCommand.Parameters.AddWithValue("min", Minimos);
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

	public DataTable GET()
	{
		DataTable result = new DataTable();
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Producto WHERE Codigo='" + Codigo + "' OR Codigo_Alterno='" + Codigo + "'";
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

	public string ProductosTotales()
	{
		DataTable dataTable = new DataTable();
		string result = "0";
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT COUNT(idProducto) AS totp FROM Producto";
			dataTable = dB.ExeReader(mySqlCommand);
			result = dataTable.Rows[0]["totp"].ToString();
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

	public DataTable ProdFaltantes()
	{
		DataTable result = new DataTable();
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Producto WHERE Cantidad='0'";
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

	public string ProductosTotalesFalt()
	{
		DataTable dataTable = new DataTable();
		string result = "0";
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT COUNT(idProducto) AS totp FROM producto WHERE cantidad='0'";
			dataTable = dB.ExeReader(mySqlCommand);
			result = dataTable.Rows[0]["totp"].ToString();
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

	public DataTable GETProd()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Producto";
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

	public int UPDATE()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "UPDATE Producto SET Nombre_P=(@nombre), Precio=(@precio), IVA=(@iva), Descuento=(@descuento),Imagen=(@imagen), Codigo=(@codigo), Cantidad=(@cantidad), Codigo_Alterno=(@cod_al), Fecha_reg=(@fecha_r), Fecha_Cad=(@fecha_c), Proveedor=(@proveedor), Mayoreo=(@mayoreo), Maximos=(@max), Minimos=(@min) WHERE idProducto='" + Id + "'";
			mySqlCommand.Parameters.AddWithValue("nombre", Nombre_P);
			mySqlCommand.Parameters.AddWithValue("precio", Precio_U);
			mySqlCommand.Parameters.AddWithValue("iva", IVA);
			mySqlCommand.Parameters.AddWithValue("descuento", Descuento);
			mySqlCommand.Parameters.AddWithValue("imagen", Imagen);
			mySqlCommand.Parameters.AddWithValue("codigo", Codigo);
			mySqlCommand.Parameters.AddWithValue("cantidad", Cantidad);
			mySqlCommand.Parameters.AddWithValue("cod_al", Cod_Alt);
			mySqlCommand.Parameters.AddWithValue("fecha_r", Fecha_Reg);
			mySqlCommand.Parameters.AddWithValue("fecha_c", Fecha_Cad);
			mySqlCommand.Parameters.AddWithValue("proveedor", proveedor);
			mySqlCommand.Parameters.AddWithValue("mayoreo", Precio_Mayoreo);
			mySqlCommand.Parameters.AddWithValue("max", Maximos);
			mySqlCommand.Parameters.AddWithValue("min", Minimos);
			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				return 1;
			}
			return 2;
		}
		catch
		{
			return 2;
		}
		finally
		{
			dB.Conexion().Close();
		}
	}

	private string RevisarExistencia(MySqlConnection con)
	{
		string result = "";
		string cmdText = "SELECT idProducto FROM Producto WHERE Codigo='" + Codigo + "'";
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

	public int DELETE()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "DELETE FROM Producto WHERE idProducto='" + Id + "'";
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

	public int AgregarOferta()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "INSERT INTO Oferta(Nombre_Offer)VALUES(@ofer)";
			mySqlCommand.Parameters.AddWithValue("ofer", ofer);
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

	public int AgregarDatosOfer()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "INSERT INTO Oferta_Detalle(Nombre_Ofer, Nombre_P, Cantidad, Precio, IVA, Imagen, Codigo, Codigo_Alterno, Proveedor)VALUES(@Nombre_of, @nombre,@cantidad,@precio,@iva,@img,@cod,@cod_al,@provee)";
			mySqlCommand.Parameters.AddWithValue("Nombre_of", Id);
			mySqlCommand.Parameters.AddWithValue("nombre", Nombre_P);
			mySqlCommand.Parameters.AddWithValue("cantidad", Cantidad);
			mySqlCommand.Parameters.AddWithValue("precio", Precio_U);
			mySqlCommand.Parameters.AddWithValue("iva", IVA);
			mySqlCommand.Parameters.AddWithValue("img", Imagen);
			mySqlCommand.Parameters.AddWithValue("cod", Codigo);
			mySqlCommand.Parameters.AddWithValue("cod_al", Cod_Alt);
			mySqlCommand.Parameters.AddWithValue("provee", proveedor);
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

	public DataTable GETOFER()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM Oferta_Detalle WHERE Nombre_Ofer='" + Codigo + "'";
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

	public int BorrarOferta()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			dB.Conexion().Open();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "DELETE fac, lin FROM Oferta AS fac JOIN Oferta_Detalle AS lin WHERE lin.Nombre_Ofer=fac.Nombre_Offer AND fac.Nombre_Offer='" + ofer + "'";
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

	public DataTable CargarOfertas2()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT Nombre_Ofer as OFERTAS FROM oferta_detalle o WHERE Codigo='" + Codigo + "'";
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

	public string BuscarOferta()
	{
		DB dB = new DB();
		DataTable dataTable = new DataTable();
		string result = "";
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT Nombre_Ofer as nombre FROM oferta_detalle o WHERE Nombre_P='" + ofer + "'";
			dataTable = dB.ExeReader(mySqlCommand);
			result = dataTable.Rows[0]["nombre"].ToString();
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

	public DataTable ObtenerOferta()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		string text = "";
		try
		{
			text = ofer;
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM oferta_detalle o WHERE Nombre_Ofer='" + text + "'";
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

	public int VerificarExistenciaProductosOferta(string codigo)
	{
		DB dB = new DB();
		DataTable dataTable = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT cantidad as cant FROM Producto WHERE Codigo_Alterno='" + codigo + "'";
			dataTable = dB.ExeReader(mySqlCommand);
			int num = Convert.ToInt32(dataTable.Rows[0]["cant"].ToString());
			if (num > 0)
			{
				return num;
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

	public DataTable GETOBJETODETALLEOFERTA()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		string text = "";
		try
		{
			text = Codigo;
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT * FROM oferta_detalle o WHERE Codigo='" + text + "'";
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

	public int ObtenerProductoOferta()
	{
		DB dB = new DB();
		DataTable dataTable = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.CommandText = "SELECT COUNT(Nombre_Ofer) AS contador FROM oferta_detalle o WHERE Nombre_Ofer='" + Codigo + "'";
			dataTable = dB.ExeReader(mySqlCommand);
			int num = Convert.ToInt32(dataTable.Rows[0]["contador"].ToString());
			if (num >= 1)
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
