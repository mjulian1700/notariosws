using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class OutMaestro
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
		public int Field10 { get; set; }
		public String Field11 { get; set; }
		public int Field12 { get; set; }
		public Double Field13 { get; set; }
		public int Field14 { get; set; }
		public int Field15 { get; set; }
		public int Field16 { get; set; }
		public int Field17 { get; set; }
		public int Field18 { get; set; }
		public Double Field19 { get; set; }
		public Double Field20 { get; set; }
		public int Field21 { get; set; }
		public String Field22 { get; set; }
		public int Field23 { get; set; }
		public String Field24 { get; set; }
		public String Field25 { get; set; }
		public int Field26 { get; set; }
		public Double Field27 { get; set; }
		public int Field28 { get; set; }
		public String Field29 { get; set; }
		public OutMaestro()
		{

		}

		public OutMaestro(Mensaje msg)
		{
			this.Field28 = msg.estatusEjecucion;
			this.Field29 = msg.mensajeCiudadano;
			this.Field29 = msg.mensajeTecnico;
		}
	}
}