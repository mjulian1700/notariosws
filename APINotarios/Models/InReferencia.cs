using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class InReferencia
	{
		public String referencia { get; set; }
		public int secuenciaReferencia { get; set; }
		public int control { get; set; }
		public int tipoServicio { get; set; }
		public int materia { get; set; }
		public int anio { get; set; }
		public int cveDependencia { get; set; }
		public int cveUnidad { get; set; }
		public int folioControl { get; set; }
		public int noServicio { get; set; }
		public int opcion { get; set; }

	}
}