using APINotarios.Models;
using APINotarios.Utilerias;
using Ingres.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace APINotarios.DAO
{
	public class DAONotarios
	{
		public static OutReferencia consReferencia(int ambiente, InReferencia dtr)
		{
			OutReferencia resultado = new OutReferencia();
			String cadCon = sqlClass.IngressConnection(ambiente);
			using (IngresConnection conn = new IngresConnection(cadCon))
			{
				Debug.WriteLine("conection-------" + cadCon);
				resultado = Procedimientos.consReferencia(conn, dtr);
			}

			return resultado;
		}

		public static Enajenante admEnajenante(int ambiente, P_Enajentantes dtr)
		{
			Enajenante resultado = new Enajenante();
			String cadCon = sqlClass.IngressConnection(ambiente);
			using (IngresConnection conn = new IngresConnection(cadCon))
			{
				Debug.WriteLine("conection-------" + cadCon);
				resultado = Procedimientos.admonEnajenante(conn, dtr);
			}

			return resultado;
		}

		public static OutAdquiriente adquiriente(int ambiente, InAdquiriente dtr)
		{
			OutAdquiriente resultado = new OutAdquiriente();
			String cadCon = sqlClass.IngressConnection(ambiente);
			using (IngresConnection conn = new IngresConnection(cadCon))
			{
				Debug.WriteLine("conection-------" + cadCon);
				resultado = Procedimientos.admonAdquiriente(conn, dtr);
			}

			return resultado;
		}

		public static Out_Inmueble admonInmueble(int ambiente, In_Inmueble dtr)
		{
			Out_Inmueble resultado = new Out_Inmueble();
			String cadCon = sqlClass.IngressConnection(ambiente);
			using (IngresConnection conn = new IngresConnection(cadCon))
			{
				Debug.WriteLine("conection-------" + cadCon);
				resultado = Procedimientos.admonInmueble(conn, dtr);
			}

			return resultado;
		}

		public static Out_NotariosISR notarioISR(int ambiente, In_NotariosISR dtr)
		{
			Out_NotariosISR resultado = new Out_NotariosISR();
			String cadCon = sqlClass.IngressConnection(ambiente);
			using (IngresConnection conn = new IngresConnection(cadCon))
			{
				Debug.WriteLine("conection-------" + cadCon);
				resultado = Procedimientos.notarioISR(conn, dtr);
			}

			return resultado;
		}

		public static OutMaestro maestro_Notario(int ambiente, InMaestro dtr)
		{
			OutMaestro resultado = new OutMaestro();
			String cadCon = sqlClass.IngressConnection(ambiente);
			using (IngresConnection conn = new IngresConnection(cadCon))
			{
				Debug.WriteLine("conection-------" + cadCon);
				resultado = Procedimientos.maestroNotario(conn, dtr);
			}

			return resultado;
		}
	}
}