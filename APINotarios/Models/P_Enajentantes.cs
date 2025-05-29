using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class P_Enajentantes
	{
		public int pi_opcion { get; set; }
		public int pi_noTicket { get; set; }
		public int pi_control { get; set; }
		public int pi_tipoPersonaEnajena { get; set; }
		public String pc_nombreEnajena { get; set; }
		public String pc_apellidoPaternoEnajena { get; set; }
		public String pc_apellidoMaternoEnajena { get; set; }
		public String pc_calleEnajena { get; set; }
		public String pc_noExtEnajena { get; set; }
		public String pc_noIntEnajena { get; set; }
		public String pc_coloniaEnajena { get; set; }
		public int pi_codigoEnajena { get; set; }
		public String pc_telefonoEnajena { get; set; }
		public String pc_localidadEnajena { get; set; }
		public String pc_municipioEnajena { get; set; }
		public String pc_entFedEnajena { get; set; }
		public String pc_rfc { get; set; }
		public String pc_curp { get; set; }
		public int pi_tipoFmto { get; set; }
		public int ambiente {  get; set; }	

	}
}