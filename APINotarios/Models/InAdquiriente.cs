using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class InAdquiriente
	{
		public int pi_opcion { get; set; }
		public int pi_noTicket { get; set; }
		public int pi_control { get; set; }
		public int pi_tipoPersona_Adquiere { get; set; }
		public String pc_nombreAdquiere { get; set; }
		public String pc_apellidoPaterno_Adquiere { get; set; }
		public String pc_apellidoMaterno_Adquiere { get; set; }
		public String pc_calle_adquiere { get; set; }
		public String pc_no_ext_adquiere { get; set; }
		public String pc_no_int_adquiere { get; set; }
		public String pc_colonia_adquiere { get; set; }
		public int pi_codigo_adquiere { get; set; }
		public String pc_telefono_adquiere { get; set; }
		public String pc_localidad_adquiere { get; set; }
		public String pc_municipio_adquiere { get; set; }
		public String pc_ent_fed_adquiere { get; set; }
		public String pc_curp_adquiere { get; set; }
		public String pc_rfc { get; set; }
		public String pc_nom_comercial { get; set; }
		public String pi_tipo_fmto { get; set; }
		public int ambiente { get; set; }
	}
}