using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class Enajenante
	{
		public int Field1 { get; set; }
		public int Field2 { get; set; }
		public int Field3 { get; set; }
		public String Field4 { get; set; }
		public String Field5 { get; set; }
		public String Field6 { get; set; } 
		public String Field7 { get; set; }
		public String Field8 { get; set; }
		public String Field9 { get; set; }
		public String Field10 { get; set; }
		public int Field11 { get; set; }
		public String Field12 { get; set; }
		public String Field13 { get; set; }
		public String Field14 { get; set; }
		public String Field15 { get; set; }
		public String Field16 { get; set; }
		public String Field17 { get; set; }
		public int Field18 { get; set; }
		public String Field19 { get; set; }

		public Enajenante()
		{

		}

		public Enajenante(Mensaje msg)
		{
			this.Field18 = msg.estatusEjecucion;
			this.Field19 = msg.mensajeCiudadano;
			this.Field19 = msg.mensajeTecnico;
		}
	}
}