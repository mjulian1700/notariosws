using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace APINotarios.Models
{
	public class Cabeceras
	{
		private HttpRequestMessage request;


		public String Ambiente { get; set; }
		public String Token { get; set; }
		public String toString()
		{
			return "Token: " + Token;
		}
		public Cabeceras(String TokenC, String ambiente)
		{
			this.Token = TokenC;
			Ambiente = ambiente;
		}
		public Cabeceras(HttpRequestMessage request)
		{
			IEnumerable<string> valor;
			if (request.Headers.TryGetValues("token", out valor))
				Token = "" + valor.SingleOrDefault();
			else
				Token = "";
			if (request.Headers.TryGetValues("ambiente", out valor))
				Ambiente = "" + valor.SingleOrDefault();
			else
				Ambiente = "";
		}
		public Mensaje Validacion()
		{
			Mensaje resultado = new Mensaje();
			String tipoError = "";
			int estatus = 0;
			if (this.Token.CompareTo("") == 0)
			{
				tipoError = "--Token--";
				estatus = -200;
			}
			if (estatus != 0)
			{
				String errorc = "Error de cabeceras " + tipoError;
				return resultado = new Mensaje(estatus, "Error interno, favor de verificar con SISTEMAS", errorc);
			}
			return resultado;
		}
	}
}