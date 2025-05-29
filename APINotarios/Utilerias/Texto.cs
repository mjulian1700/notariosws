using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace APINotarios.Utilerias
{
	public class Texto
	{
		public String armaCadena(params string[] parametros)
		{
			StringBuilder cadenaTemp = new StringBuilder();
			for (int i = 0; i < parametros.Length; i++)
				cadenaTemp.Append(parametros[i].Trim() + "|");
			return cadenaTemp.ToString();
		}
		public static String GetTime(string str)
		{
			int years = int.Parse(str.Substring(6, 4));
			int months = int.Parse(str.Substring(3, 2));
			int days = int.Parse(str.Substring(0, 2));
			return $"{years}-{months}-{days}";
		}

		public static bool GetVigencia(string vnc)
		{
			int years = int.Parse(vnc.Substring(6, 4));
			int months = int.Parse(vnc.Substring(3, 2));
			int days = int.Parse(vnc.Substring(0, 2));
			DateTime lic = new DateTime(years, months, days);
			DateTime now = DateTime.Now;
			Debug.WriteLine("lic=" + lic.ToString("dd/MM/yyyy"));
			Debug.WriteLine("now=" + now.ToString("dd/MM/yyyy"));
			return DateTime.Compare(lic, now) > 0 ? true : false;
		}
		public static String GetPeriodo(int month, int year)
		{
			String ans = "";
			List<string> LMonths = new List<string>(new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", });
			if (month == 0 && year == 0)
			{
				return ans;
			}
			else
			{
				ans = LMonths[month - 1] + "/" + year;
				return ans;
			}
		}

		//public static string GetFullDireccion(Vehiculoinp dt)
		//{
		//	return dt.vchCalle + " " + dt.vchNumeroInterior + " " + dt.vchNumeroExterior + " " + dt.vchColonia + " " + dt.iCodigoPostal;
		//}

		public static string ConvertDate(string Fecha)
		{
			String ans = "";
			DateTime dt = Convert.ToDateTime(Fecha);
			ans = dt.ToString("dd/MM/yyyy");
			return ans;
		}

		public static string CatchByte(byte b)
		{
			if (b == 1)
				return "SI";
			return "NO";
		}

		public static string CatchRestricciones(byte b)
		{
			if (b == 0)
				return "CON RESTRICCIONES";
			return "SIN RESTRICCIONES";
		}
	}
}