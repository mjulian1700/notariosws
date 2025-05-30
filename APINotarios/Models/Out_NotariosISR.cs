using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class Out_NotariosISR
	{
		public double Field1 { get; set; }
		public double Field2 { get; set; }
		public double Field3 { get; set; }
		public double Field4 { get; set; }
		public double Field5 { get; set; }
		public double Field6 { get; set; }
		public double Field7 { get; set; }
		public double Field8 { get; set; }
		public int Field9 { get; set; }
		public String Field10 { get; set; }
		public Out_NotariosISR()
		{

		}

		public Out_NotariosISR(Mensaje msg)
		{
			this.Field9 = msg.estatusEjecucion;
			this.Field10 = msg.mensajeCiudadano;
			this.Field10 = msg.mensajeTecnico;
		}
	}
}