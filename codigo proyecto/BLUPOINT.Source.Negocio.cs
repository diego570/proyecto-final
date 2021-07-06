// BLUPOINT.Source.Negocio
using System;
using System.Data;
using BLUPOINT.Config;
using MySql.Data.MySqlClient;

internal class Negocio
{
	public string Nombre_N { get; set; }

	public string Calle { get; set; }

	public string Telefono { get; set; }

	public string Colonia { get; set; }

	public string No_Ext { get; set; }

	public string CP { get; set; }

	public string Correo { get; set; }

	public string Municipio { get; set; }

	public string Estado { get; set; }

	public string Nombre_Fiscal { get; set; }

	public int INSERT()
	{
		DB dB = new DB();
		try
		{
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "INSERT INTO Negocio(Nombre_N, Calle, Colonia, Numero_Ext, CP, Telefono, Correo, Municipio, Estado, Nombre_Fiscal)VALUES(@nombre, @calle,@col,@num,@cp,@tel,@mail,@mun,@est,@nombre_f)";
			mySqlCommand.Parameters.AddWithValue("nombre", Nombre_N);
			mySqlCommand.Parameters.AddWithValue("calle", Calle);
			mySqlCommand.Parameters.AddWithValue("col", Colonia);
			mySqlCommand.Parameters.AddWithValue("num", No_Ext);
			mySqlCommand.Parameters.AddWithValue("cp", CP);
			mySqlCommand.Parameters.AddWithValue("tel", Telefono);
			mySqlCommand.Parameters.AddWithValue("mail", Correo);
			mySqlCommand.Parameters.AddWithValue("mun", Municipio);
			mySqlCommand.Parameters.AddWithValue("est", Estado);
			mySqlCommand.Parameters.AddWithValue("nombre_f", Nombre_Fiscal);
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
			dB.Conexion().Open();
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "UPDATE Negocio SET Nombre_N=(@nombre), Calle=(@calle), Colonia=(@col), Numero_Ext=(@num), CP=(@cp), Telefono=(@tel), Correo=(@mail), Municipio=(@mun), Estado=(@est), Nombre_Fiscal=(@nombre_f)";
			mySqlCommand.Parameters.AddWithValue("nombre", Nombre_N);
			mySqlCommand.Parameters.AddWithValue("calle", Calle);
			mySqlCommand.Parameters.AddWithValue("col", Colonia);
			mySqlCommand.Parameters.AddWithValue("num", No_Ext);
			mySqlCommand.Parameters.AddWithValue("cp", CP);
			mySqlCommand.Parameters.AddWithValue("tel", Telefono);
			mySqlCommand.Parameters.AddWithValue("mail", Correo);
			mySqlCommand.Parameters.AddWithValue("mun", Municipio);
			mySqlCommand.Parameters.AddWithValue("est", Estado);
			mySqlCommand.Parameters.AddWithValue("nombre_f", Nombre_Fiscal);
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

	public int GetLogin()
	{
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			DataTable dataTable = new DataTable();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "SELECT * FROM blupoint.config_log c";
			dataTable = dB.ExeReader(mySqlCommand);
			return Convert.ToInt32(dataTable.Rows[0]["Tipo"].ToString());
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

	public DataTable GetBusinees()
	{
		DataTable result = new DataTable();
		DB dB = new DB();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "SELECT * FROM Negocio";
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

	public DataTable GetNegocio()
	{
		DB dB = new DB();
		DataTable result = new DataTable();
		try
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.CommandType = CommandType.Text;
			mySqlCommand.Connection = dB.Conexion();
			mySqlCommand.CommandText = "SELECT * FROM blupoint.Negocio";
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
