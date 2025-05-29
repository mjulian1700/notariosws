using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.Models
{
	public class OutReferencia : Mensaje
	{
		//EL CAMPO 0: IDENTIFICADOR DE PROCESO ES estatusEjecucion
		public String referencia {  get; set; }
		public int secReferencia { get; set; }
		public int anioReferencia {  get; set; }
		public String fechaEmision {  get; set; }
		public String fechaVigencia { get; set; }
		public String fechaServicio { get; set; }
		public int idMateria { get; set; }
		public decimal totalReferencia { get; set; }
		public int idEstatusReferencia { get; set; }
		public int idEstatusServicio { get; set; }
		public int idOfiGenReferencia { get; set; }
		public int idOficPagoReferencia { get; set; }
		public int idFuenteGeneracion { get; set; }
		public int idDependencia { get; set; }
		public String tipoServicio { get; set; }
		public String descripCorta { get; set; }
		public String nombre {  get; set; }
		public int idPagoDiferido { get; set; }
		public int noRegistroReferencia { get; set; }
		public int idPromocion { get; set; }
		public int noServicio { get; set; }
		public String usuario {  get; set; }
		public int idEstatusPago { get; set; }
		public String descripSitReferencia { get; set; }
		public String mensajeReferencia { get; set; }
		public String OficinaBanco { get; set; }
		public String logTransaccion { get; set; }
		public int folioTramite { get; set; }
		public String fechaPago { get; set; }
		public String descripDependencia { get; set; }
		public String descripUnidadResp {  get; set; }

		public OutReferencia()
		{

		}

		public OutReferencia(Mensaje msg)
		{
			this.estatusEjecucion = msg.estatusEjecucion;
			this.mensajeCiudadano = msg.mensajeCiudadano;
			this.mensajeTecnico = msg.mensajeTecnico;
		}
	}
}