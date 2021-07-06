// BLUPOINT.Config.DB
using System.Data;
using MySql.Data.MySqlClient;

internal class DB
{
	private MySqlConnection con = new MySqlConnection("server=localhost; password=blupoint01; user=root; database=blupoint; port= 3306;");

	public MySqlConnection Conexion()
	{
		return con;
	}

	public int ExeNonQuery(MySqlCommand cmd)
	{
		cmd.Connection = Conexion();
		int num = -1;
		num = cmd.ExecuteNonQuery();
		con.Close();
		return num;
	}

	public object ExeScalar(MySqlCommand com)
	{
		com.Connection = Conexion();
		object obj = -1;
		obj = com.ExecuteScalar();
		con.Close();
		return obj;
	}

	public DataTable ExeReader(MySqlCommand cmd)
	{
		con.Open();
		cmd.Connection = Conexion();
		DataTable dataTable = new DataTable();
		MySqlDataReader reader = cmd.ExecuteReader();
		dataTable.Load(reader);
		con.Close();
		return dataTable;
	}
}
