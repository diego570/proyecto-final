// BLUPOINT.Program
using System;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Config;
using BLUPOINT.Source;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		DB dB = new DB();
		Negocio negocio = new Negocio();
		try
		{
			dB.Conexion().Open();
			if (negocio.GetLogin() == 1)
			{
				Application.Run(new Login());
			}
			else if (negocio.GetLogin() == 2)
			{
				Application.Run(new Login_2());
			}
		}
		catch
		{
			Application.Run(new Star_Install());
		}
	}
}
