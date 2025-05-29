using APINotarios.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace APINotarios.Utilerias
{
	public class Token
	{
		public static String CrearToken(String user, String pass, String amb)
		{
			String time = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
			String sep = " ";
			String ans = time + sep + user + sep + pass + sep + amb;
			Debug.WriteLine(ans);
			return Seguridad.Encriptar(ans);
		}

		public static UserConection validarAmbiente(String amb)
		{
			int ambiente = Convert.ToInt16(amb);
			ambiente = ambiente - 1;
			UserConection resultado = new UserConection(new Mensaje(1, ""));
			if (ambiente < 0)
			{
				return new UserConection(new Mensaje(-300, "Ambiente Invalido, error al poner tipo de Ambiente"));
			}
			if (ambiente > 1)
			{
				return new UserConection(new Mensaje(-300, "Ambiente Invalido, error al poner tipo de Ambiente"));
			}
			resultado.Ambiente = Convert.ToString(ambiente);
			return resultado;

		}

		public static UserConection Validar(String token)
		{
			UserConection ans = new UserConection(new Mensaje(1, ""));
			String cad = Seguridad.Desencriptar(token);
			String[] words = cad.Split(' ');
			for (int i = 0; i < words.Length; i++)
				Debug.WriteLine(i + "=" + words[i]);

			if (words.Length < 5)
			{
				//error

				return new UserConection(new Mensaje(-400, "Token Invalido, error al desencriptar "));
			}
			ans.ConfigUser(words[2], words[3], words[4]);
			if (SuperUser(words[2], words[3]))
			{
				Debug.WriteLine("Usuario de Pruebas");
				return ans;
			}

			if (Vigencia(words[0], words[1]))
			{
				Debug.WriteLine("Conexion Valida");
				return ans;
			}
			/// 
			return new UserConection(new Mensaje(-400, "Token expirado"));
		}
		public static Boolean Vigencia(String Day, String Time)
		{

			DateTime now = DateTime.Now;
			if (Day.CompareTo(now.ToString("dd/MM/yy")) != 0)
			{
				Debug.WriteLine("El Token es de otro dia");
				return false;
			}
			int hr = int.Parse(Time.Substring(0, 2));
			int mn = int.Parse(Time.Substring(3, 2));
			int ss = int.Parse(Time.Substring(6, 2));

			DateTime TokenTime = new DateTime(now.Year, now.Month, now.Day, hr, mn, ss);
			Debug.WriteLine("  now:" + now.ToString("dd/MM/yy HH:mm:ss"));
			Debug.WriteLine("Token:" + TokenTime.ToString("dd/MM/yy HH:mm:ss"));


			TimeSpan ts = now - TokenTime;
			Debug.WriteLine("Tiempo de vida del Token:" + ts);

			if (ts.TotalMinutes > 13)
				return false;

			return true;
		}

		public static Boolean SuperUser(String user, String pass)
		{

			String us = "QLiRTErzYPN5Y1Eh8VlDiBr7i2epgDRo";
			String ps = "DB3fmAiJuc9VbLS98x5f1Q==";
			return user.CompareTo(Seguridad.Desencriptar(us)) == 0 && pass.CompareTo(Seguridad.Desencriptar(ps)) == 0;
		}


		public static int GetId(String cad)
		{
			int prime = 7901;
			int mod = 250000;

			int ans = 0;
			for (int i = 0; i < cad.Length; i++)
			{
				ans += (int)cad[i] + ans * prime;
				ans %= mod;
			}
			return ans;
		}
	}
}