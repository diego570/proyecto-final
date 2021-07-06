// BLUPOINT.Source.Numero_letras
using System;

public static class Numero_letras
{
	public static string NumeroLetras(this decimal numberAsString)
	{
		long num = Convert.ToInt64(Math.Truncate(numberAsString));
		int num2 = Convert.ToInt32(Math.Round((numberAsString - (decimal)num) * 100m, 2));
		return string.Concat(str1: (num2 <= 0) ? $" PESOS {num2:0,0} /100" : $" PESOS {num2:0,0} /100", str0: NumeroALetras(Convert.ToDouble(num)));
	}

	private static string NumeroALetras(double value)
	{
		value = Math.Truncate(value);
		string text;
		if (value == 0.0)
		{
			text = "CERO";
		}
		else if (value == 1.0)
		{
			text = "UNO";
		}
		else if (value == 2.0)
		{
			text = "DOS";
		}
		else if (value == 3.0)
		{
			text = "TRES";
		}
		else if (value == 4.0)
		{
			text = "CUATRO";
		}
		else if (value == 5.0)
		{
			text = "CINCO";
		}
		else if (value == 6.0)
		{
			text = "SEIS";
		}
		else if (value == 7.0)
		{
			text = "SIETE";
		}
		else if (value == 8.0)
		{
			text = "OCHO";
		}
		else if (value == 9.0)
		{
			text = "NUEVE";
		}
		else if (value == 10.0)
		{
			text = "DIEZ";
		}
		else if (value == 11.0)
		{
			text = "ONCE";
		}
		else if (value == 12.0)
		{
			text = "DOCE";
		}
		else if (value == 13.0)
		{
			text = "TRECE";
		}
		else if (value == 14.0)
		{
			text = "CATORCE";
		}
		else if (value == 15.0)
		{
			text = "QUINCE";
		}
		else if (value < 20.0)
		{
			text = "DIECI" + NumeroALetras(value - 10.0);
		}
		else if (value == 20.0)
		{
			text = "VEINTE";
		}
		else if (value < 30.0)
		{
			text = "VEINTI" + NumeroALetras(value - 20.0);
		}
		else if (value == 30.0)
		{
			text = "TREINTA";
		}
		else if (value == 40.0)
		{
			text = "CUARENTA";
		}
		else if (value == 50.0)
		{
			text = "CINCUENTA";
		}
		else if (value == 60.0)
		{
			text = "SESENTA";
		}
		else if (value == 70.0)
		{
			text = "SETENTA";
		}
		else if (value == 80.0)
		{
			text = "OCHENTA";
		}
		else if (value == 90.0)
		{
			text = "NOVENTA";
		}
		else if (value < 100.0)
		{
			text = NumeroALetras(Math.Truncate(value / 10.0) * 10.0) + " Y " + NumeroALetras(value % 10.0);
		}
		else if (value == 100.0)
		{
			text = "CIEN";
		}
		else if (value < 200.0)
		{
			text = "CIENTO " + NumeroALetras(value - 100.0);
		}
		else if (value == 200.0 || value == 300.0 || value == 400.0 || value == 600.0 || value == 800.0)
		{
			text = NumeroALetras(Math.Truncate(value / 100.0)) + "CIENTOS";
		}
		else if (value == 500.0)
		{
			text = "QUINIENTOS";
		}
		else if (value == 700.0)
		{
			text = "SETECIENTOS";
		}
		else if (value == 900.0)
		{
			text = "NOVECIENTOS";
		}
		else if (value < 1000.0)
		{
			text = NumeroALetras(Math.Truncate(value / 100.0) * 100.0) + " " + NumeroALetras(value % 100.0);
		}
		else if (value == 1000.0)
		{
			text = "MIL";
		}
		else if (value < 2000.0)
		{
			text = "MIL " + NumeroALetras(value % 1000.0);
		}
		else if (value < 1000000.0)
		{
			text = NumeroALetras(Math.Truncate(value / 1000.0)) + " MIL";
			if (value % 1000.0 > 0.0)
			{
				text = text + " " + NumeroALetras(value % 1000.0);
			}
		}
		else if (value == 1000000.0)
		{
			text = "UN MILLON";
		}
		else if (value < 2000000.0)
		{
			text = "UN MILLON " + NumeroALetras(value % 1000000.0);
		}
		else if (value < 1000000000000.0)
		{
			text = NumeroALetras(Math.Truncate(value / 1000000.0)) + " MILLONES ";
			if (value - Math.Truncate(value / 1000000.0) * 1000000.0 > 0.0)
			{
				text = text + " " + NumeroALetras(value - Math.Truncate(value / 1000000.0) * 1000000.0);
			}
		}
		else if (value == 1000000000000.0)
		{
			text = "UN BILLON";
		}
		else if (value < 2000000000000.0)
		{
			text = "UN BILLON " + NumeroALetras(value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0);
		}
		else
		{
			text = NumeroALetras(Math.Truncate(value / 1000000000000.0)) + " BILLONES";
			if (value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0 > 0.0)
			{
				text = text + " " + NumeroALetras(value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0);
			}
		}
		return text;
	}
}
