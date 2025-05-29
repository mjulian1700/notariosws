using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class OutAdquiriente
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
		public String Field18 { get; set; }
		public int Field19 { get; set; }
		public String Field20 { get; set; }

		public OutAdquiriente()
		{

		}

		public OutAdquiriente(Mensaje msg)
		{
			this.Field19 = msg.estatusEjecucion;
			this.Field20 = msg.mensajeCiudadano;
			this.Field20 = msg.mensajeTecnico;
		}
	}
}