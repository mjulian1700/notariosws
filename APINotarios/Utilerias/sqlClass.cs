using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace APINotarios.Utilerias
{
	public class sqlClass
	{
		public static String IngressConnection(int ambiente)
		{
			String user = "intssi01";
			List<String> Passwords = new List<String>();
			Passwords.Add("clave123");
			Passwords.Add("Int551sub");
			Passwords.Add("arbol321");
			List<String> Cadenas = new List<String>();
			Cadenas.Add("IngresAmbD");
			Cadenas.Add("IngresAmbP");
			Cadenas.Add("IngresAmbC");

			String Connecion = ConfigurationManager.AppSettings[Cadenas[ambiente]].ToString();

			String cadCon = "";
			cadCon = ConfigurationManager.ConnectionStrings[Connecion].ConnectionString;
			cadCon = cadCon.Replace("xxxxxx", user);
			cadCon = cadCon.Replace("yyyyyy", Passwords[ambiente]);

			Debug.WriteLine("conexion de prueba ->" + cadCon);
			return cadCon;
		}

		public static string SqlConnection(int cnx)
		{
			String cadCon = "";
			String user = "lic_cons_pueblavehic";
			String Password = "1ngr3s0$LiC";
			List<String> Cadenas = new List<String>();
			Cadenas.Add("SqlAmbP1");
			Cadenas.Add("SqlAmbP2");
			String cnxn = ConfigurationManager.AppSettings[Cadenas[cnx]].ToString();
			cadCon = ConfigurationManager.ConnectionStrings[cnxn].ConnectionString;
			cadCon = cadCon.Replace("xxxxxx", user);
			cadCon = cadCon.Replace("yyyyyy", Password);
			Debug.WriteLine("conexion de prueba ->" + cadCon);
			return cadCon;
		}
	}
}