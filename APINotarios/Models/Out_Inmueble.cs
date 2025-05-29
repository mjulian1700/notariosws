using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class Out_Inmueble
	{
		public int Field1 { get; set; }
		public int Field2 { get; set; }
		public String Field3 { get; set; }
		public String Field4 { get; set; }
		public String Field5 { get; set; }
		public String Field6 { get; set; }
		public int Field7 { get; set; }
		public int Field8 { get; set; }
		public int Field9 { get; set; }
		public float Field10 { get; set; }
		public float Field11 { get; set; }
		public float Field12 { get; set; }
		public String Field13 { get; set; }
		public String Field14 { get; set; }
		public String Field15 { get; set; }
		public String Field16 { get; set; }
		public String Field17 { get; set; }
		public String Field18 { get; set; }
		public int Field19 { get; set; }
		public int Field20 { get; set; }
		public String Field21 { get; set; }

		public Out_Inmueble()
		{

		}

		public Out_Inmueble(Mensaje msg)
		{
			this.Field20 = msg.estatusEjecucion;
			this.Field21 = msg.mensajeCiudadano;
			this.Field21 = msg.mensajeTecnico;
		}

	}
}