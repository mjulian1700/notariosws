using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class UserConection : Mensaje
	{
		public String User { set; get; } = "";
		public String Password { set; get; } = "";
		public String Ambiente { set; get; } = "";
		public UserConection() { }
		public UserConection(Mensaje msg)
		{
			estatusEjecucion = msg.estatusEjecucion;
			mensajeCiudadano = msg.mensajeCiudadano;
			mensajeTecnico = msg.mensajeTecnico;
		}
		public void ConfigUser(String user, String pass, String amb)
		{
			User = user;
			Password = pass;
			Ambiente = amb;
		}
	}
}