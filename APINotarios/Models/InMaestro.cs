using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class InMaestro
	{
		public int pi_opcion { get; set; }
		public int pi_no_ticket { get; set; }
		public int pi_cve_notario { get; set; }
		public int pi_tipo_fmto { get; set; }
		public String pc_folio_operación_not { get; set; }
		public String pd_fecha_operación_not { get; set;}
		public String pc_no_escritura { get; set; }	
		public String pc_fojas { get; set; }
		public String pc_no_tomo { get; set; }
		public String pc_no_libro { get; set; }
		public String pi_fol_avaluo_catastral { get; set; }
		public String pd_fec_avaluo_catastral { get; set;}
		public int pi_digito_verif_avaluo { get; set; }
		public double pm_valor_catastral { get; set;}
		public int pi_tipo_operacion { get; set; }
		public int pi_region { get; set; }
		public int pi_manzana { get; set; }
		public int pi_no_lote { get; set; }
		public int pi_inscripcion { get; set; }
		public double pm_valor_operacion { get; set; }
		public double pm_base_gravable { get; set; }
		public int pi_tasa { get; set; }
		public String pc_descrip_operacion { get; set;}
		public int pi_porce_dere_propi { get; set; }
		public String pc_partida { get; set; }
		public String pc_indice_predio { get; set; }
		public int ambiente { get; set; }

	}
}	