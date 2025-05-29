using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class Mensaje
	{
		public int estatusEjecucion { get; set; }
		public String mensajeCiudadano { get; set; } = "";
		public String mensajeTecnico { get; set; } = "";

		public Mensaje() { }

		public Mensaje(int estatusEjecucion, String mensajeCiudadano)
		{
			this.estatusEjecucion = estatusEjecucion;
			this.mensajeCiudadano = mensajeCiudadano;
		}
		public Mensaje(int estatusEjecucion, String mensajeCiudadano, String mensajeTecnico)
		{
			this.estatusEjecucion = estatusEjecucion;
			this.mensajeCiudadano = mensajeCiudadano;
			this.mensajeTecnico = mensajeTecnico;
		}
	}
}