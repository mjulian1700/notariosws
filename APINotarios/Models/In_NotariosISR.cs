using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class In_NotariosISR
	{
		public int pi_no_ticket { get; set; }
		public String pc_fol_ope_not { get; set; }
		public int pi_tipo_declaracion { get; set; }
		public int pi_tipo_calculo { get; set; }
		public int pi_causa_exencion { get; set; }
		public int pi_no_complementaria { get; set; }
		public String pd_fecha_anterior { get; set; }
		public double pm_ingreso_enajena { get; set; }
		public float pf_ingreso_udis { get; set; }
		public float pf_excedente_udis { get; set; }
		public double pm_ing_gravado { get; set; }
		public double pm_ing_exento { get; set; }
		public String pc_causa_no_pago { get; set; }
		public double pm_deducciones { get; set; }
		public double pm_pago_provisional { get; set; }
		public double pm_monto_anterior { get; set; }
		public double pd_fecha_operacion_not { get; set; }
		public int ambiente { get; set; }
	}
}