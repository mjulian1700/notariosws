using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class In_Inmueble
	{
		public int pi_opcion { get; set; }
		public int pi_no_ticket { get; set; }
		public int pi_control { get; set; }
		public String pc_calle_inmueble { get; set; }
		public String pc_no_ext_inmueble { get; set; }
		public String pc_no_int_inmueble { get; set; }
		public String pc_colonia_inmueble { get; set; }
		public int pi_codigo_inmueble { get; set; }
		public int pi_localidad_inmueble { get; set; }
		public int pi_municipio_inmueble { get; set; }
		public float pf_superficie_vendida { get; set; }
		public float pf_superficie_restante { get; set; }
		public float pf_superficie_construida { get; set; }
		public String pc_medida_colindancia_norte { get; set; }
		public String pc_medida_colindancia_sur { get; set; }
		public String pc_medida_colindancia_oriente { get; set; }
		public String pc_medida_colindancia_poniente { get; set; }
		public String pc_entre_calles { get; set; }
		public String pc_referencia { get; set; }
		public String pi_tipo_inmueble { get; set; }
		public int ambiente { get; set; }

	}
}