using APINotarios.Log;
using APINotarios.Models;
using Ingres.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace APINotarios.DAO
{
	public class Procedimientos
	{
		public static OutReferencia consReferencia(IngresConnection conn, InReferencia dtr)
		{
			OutReferencia ans = new OutReferencia(new Mensaje());
			IngresDataReader idr = null;
			IngresCommand cmd = null;
			try
			{
				conn.Open();
			}
			catch (IngresException inex)
			{
				Debug.WriteLine("Conn=" + conn.State + " " + inex.Message.ToString());
				System.Diagnostics.Trace.WriteLine("Error: \n" + inex.ToString());
				Mensaje error = new Mensaje(-99, "Error En la conexion ", inex.ToString().Trim());
				return new OutReferencia(error);
			}

			try
			{

				Debug.WriteLine("Conn TRY=" + conn.State);
				String Param = "(";
				Param += $"pc_refer='{dtr.referencia}',";
				Param += $"pi_sec_ref={dtr.secuenciaReferencia},";
				Param += $"pi_ctrl={dtr.control},";
				Param += $"pi_tpo_serv={dtr.tipoServicio},";
				Param += $"pi_materia={dtr.materia},";
				Param += $"pi_anio={dtr.anio},";
				Param += $"pi_cve_dep={dtr.cveDependencia},";
				Param += $"pi_cve_uni={dtr.cveUnidad} ,";
				Param += $"pi_fol_ctrl={dtr.folioControl} ,";
				Param += $"pi_no_serv={dtr.noServicio} ,";
				Param += $"pi_opcion={dtr.opcion}";
				Param += ")";
				String cdtxt = $"{{call g_referencia_cons_p{Param}}}";
				cmd = new IngresCommand(cdtxt, conn);
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 15;
				Debug.WriteLine(cdtxt);
				ArchivoLog.EscribirLog(cdtxt, TraceEventType.Information);
				Debug.WriteLine("Abrir conexion");
				idr = cmd.ExecuteReader();
				Debug.WriteLine("Idr Ejecutado");
				while (idr.Read())
				{
					ans.estatusEjecucion = idr.GetInt32(0);
					ans.referencia = idr.GetString(1).Trim();
					ans.secReferencia = idr.GetInt32(2);
					ans.anioReferencia = idr.GetInt16(3);
					ans.fechaEmision = idr.GetDateTime(4).ToString("dd/MM/yyyy");
					ans.fechaVigencia = idr.GetDateTime(5).ToString("dd/MM/yyyy");
					ans.fechaServicio = idr.GetDateTime(6).ToString("dd/MM/yyyy");
					ans.idMateria = idr.GetInt32(7);
					ans.totalReferencia = idr.GetDecimal(8);
					ans.idEstatusReferencia = idr.GetInt32(9);
					ans.idEstatusServicio = idr.GetInt32(10);
					ans.idOfiGenReferencia = idr.GetInt32(11);
					ans.idOficPagoReferencia = idr.GetInt32(12);
					ans.idFuenteGeneracion = idr.GetInt32(13);
					ans.idDependencia = idr.GetInt32(14);
					ans.tipoServicio = idr.GetString(15).Trim();
					ans.descripCorta = idr.GetString(16).Trim();
					ans.nombre = idr.GetString(17).Trim();
					ans.idPagoDiferido = idr.GetInt32(18);
					ans.noRegistroReferencia = idr.GetInt16(19);
					ans.idPromocion = idr.GetInt32(20);
					ans.noServicio = idr.GetInt16(21);
					ans.usuario = idr.GetString(22).Trim();
					ans.idEstatusPago = idr.GetInt32(23);
					ans.descripSitReferencia = idr.GetString(24).Trim();
					ans.mensajeReferencia = idr.GetString(25).Trim();
					ans.OficinaBanco = idr.GetString(26).Trim();
					ans.logTransaccion = idr.GetString(27).Trim();
					ans.folioTramite = idr.GetInt32(28);
					ans.fechaPago = idr.GetDateTime(29).ToString("dd/MM/yyyy");
					ans.descripDependencia = idr.GetString(30).Trim();
					ans.descripUnidadResp = idr.GetString(31).Trim();
				}
			}
			catch (IngresException inex)
			{
				Debug.WriteLine("Conn=" + conn.State + " " + inex.Message.ToString());
				System.Diagnostics.Trace.WriteLine("Error: \n" + inex.ToString());
				Mensaje error = new Mensaje(-99, "Error en la base de datos", inex.ToString().Trim());
				return new OutReferencia(error);
			}
			finally
			{
				if (cmd != null)
					cmd.Dispose();
				if (idr != null)
				{
					if (idr.IsClosed != true)
						idr.Close();
					idr.Dispose();
				}
				if (conn != null)
				{
					Debug.WriteLine("Conexion Cerrada");
					if (conn.State != ConnectionState.Closed)
						conn.Close();
					conn.Dispose();
				}
			}
			return ans;
		}


		public static Enajenante admonEnajenante(IngresConnection conn, P_Enajentantes dtr)
		{
			Enajenante ans = new Enajenante();

			IngresDataReader idr = null;
			IngresCommand cmd = null;
			try
			{
				conn.Open();
			}
			catch (IngresException inex)
			{
				Debug.WriteLine("Conn=" + conn.State + " " + inex.Message.ToString());
				System.Diagnostics.Trace.WriteLine("Error: \n" + inex.ToString());
				Mensaje error = new Mensaje(-99, "Error En la conexion ", inex.ToString().Trim());
				return new Enajenante(error);
			}
			try
			{

				Debug.WriteLine("Conn TRY=" + conn.State);
				String Param = "(";
				Param += $"pi_opcion='{dtr.pi_opcion}',";
				Param += $"pi_no_ticket={dtr.pi_noTicket},";
				Param += $"pi_control={dtr.pi_control},";
				Param += $"pi_tipo_persona_enajena={dtr.pi_tipoPersonaEnajena},";
				Param += $"pc_nombre_enajena='{dtr.pc_nombreEnajena}',";
				Param += $"pc_apellido_paterno_enajena='{dtr.pc_apellidoPaternoEnajena}',";
				Param += $"pc_apellido_materno_enajena='{dtr.pc_apellidoMaternoEnajena}',";
				Param += $"pc_calle_enajena='{dtr.pc_calleEnajena}',";
				Param += $"pc_no_ext_enajena='{dtr.pc_noExtEnajena}' ,";
				Param += $"pc_no_int_enajena='{dtr.pc_noIntEnajena}' ,";
				Param += $"pc_colonia_enajena='{dtr.pc_coloniaEnajena}' ,";
				Param += $"pi_codigo_enajena={dtr.pi_codigoEnajena} ,";
				Param += $"pc_telefono_enajena='{dtr.pc_telefonoEnajena}' ,";
				Param += $"pc_localidad_enajena='{dtr.pc_localidadEnajena}' ,";
				Param += $"pc_municipio_enajena='{dtr.pc_municipioEnajena}' ,";
				Param += $"pc_ent_fed_enajena='{dtr.pc_entFedEnajena}' ,";
				Param += $"pc_rfc='{dtr.pc_rfc}' ,";
				Param += $"pc_curp='{dtr.pc_curp}' ,";
				Param += $"pi_tipo_fmto={dtr.pi_tipoFmto}";
				Param += ")";
				String cdtxt = $"{{call n_enajenante_p{Param}}}";
				cmd = new IngresCommand(cdtxt, conn);
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 15;
				Debug.WriteLine(cdtxt);
				ArchivoLog.EscribirLog(cdtxt, TraceEventType.Information);
				Debug.WriteLine("Abrir conexion");
				idr = cmd.ExecuteReader();
				Debug.WriteLine("Idr Ejecutado");
				while (idr.Read())
				{
					ans.Field1 = idr.GetInt32(0);
					ans.Field2 = idr.GetInt32(1);
					ans.Field3 = idr.GetInt16(2);
					ans.Field4 = idr.GetString(3) == null ? "" : idr.GetString(3).Trim();
					ans.Field5 = idr.GetString(4) == null ? "" : idr.GetString(4).Trim();
					ans.Field6 = idr.GetString(5) == null ? "" : idr.GetString(5).Trim();
					ans.Field7 = idr.GetString(6) == null ? "" : idr.GetString(6).Trim();
					ans.Field8 = idr.GetString(7) == null ? "" : idr.GetString(7).Trim();
					ans.Field9 = idr.GetString(8) == null ? "" : idr.GetString(8).Trim();
					ans.Field10 = idr.GetString(9) == null ? "" : idr.GetString(9).Trim();
					ans.Field11 = idr.GetInt32(10);
					ans.Field12 = idr.GetString(11) == null ? "" : idr.GetString(11).Trim(); 
					ans.Field13 = idr.GetString(12) == null ? "" : idr.GetString(12).Trim();
					ans.Field14 = idr.GetString(13) == null ? "" : idr.GetString(13).Trim();
					ans.Field15 = idr.GetString(14) == null ? "" : idr.GetString(14).Trim();
					ans.Field16 = idr.GetString(15) == null ? "" : idr.GetString(15).Trim();
					ans.Field17 = idr.GetString(16) == null ? "" : idr.GetString(16).Trim();
					ans.Field18 = idr.GetInt16(17);
					ans.Field19 = idr.GetString(18) == null ? "" : idr.GetString(18).Trim();
				}
			}
			catch (IngresException inex)
			{
				Debug.WriteLine("Conn=" + conn.State + " " + inex.Message.ToString());
				System.Diagnostics.Trace.WriteLine("Error: \n" + inex.ToString());
				Mensaje error = new Mensaje(-99, "Error en la base de datos", inex.ToString().Trim());
				return new Enajenante(error);
			}
			finally
			{
				if (cmd != null)
					cmd.Dispose();
				if (idr != null)
				{
					if (idr.IsClosed != true)
						idr.Close();
					idr.Dispose();
				}
				if (conn != null)
				{
					Debug.WriteLine("Conexion Cerrada");
					if (conn.State != ConnectionState.Closed)
						conn.Close();
					conn.Dispose();
				}
			}

			return ans;
		}

		public static OutAdquiriente admonAdquiriente(IngresConnection conn, InAdquiriente dtr)
		{
			OutAdquiriente ans = new OutAdquiriente();

			IngresDataReader idr = null;
			IngresCommand cmd = null;
			try
			{
				conn.Open();
			}
			catch (IngresException inex)
			{
				Debug.WriteLine("Conn=" + conn.State + " " + inex.Message.ToString());
				System.Diagnostics.Trace.WriteLine("Error: \n" + inex.ToString());
				Mensaje error = new Mensaje(-99, "Error En la conexion ", inex.ToString().Trim());
				return new OutAdquiriente(error);
			}
			try
			{

				Debug.WriteLine("Conn TRY=" + conn.State);
				String Param = "(";
				Param += $"pi_opcion={dtr.pi_opcion},";
				Param += $"pi_no_ticket={dtr.pi_noTicket},";
				Param += $"pi_control={dtr.pi_control},";
				Param += $"pi_tipo_persona_adquiere='{dtr.pi_tipoPersona_Adquiere}',";
				Param += $"pc_nombre_adquiere='{dtr.pc_nombreAdquiere}',";
				Param += $"pc_apellido_paterno_adquiere='{dtr.pc_apellidoPaterno_Adquiere}',";
				Param += $"pc_apellido_materno_adquiere='{dtr.pc_apellidoMaterno_Adquiere}',";
				Param += $"pc_calle_adquiere='{dtr.pc_calle_adquiere}',";
				Param += $"pc_no_ext_adquiere='{dtr.pc_no_ext_adquiere}' ,";
				Param += $"pc_no_int_adquiere='{dtr.pc_no_int_adquiere}' ,";
				Param += $"pc_colonia_adquiere='{dtr.pc_colonia_adquiere}' ,";
				Param += $"pi_codigo_adquiere={dtr.pi_codigo_adquiere}' ,";
				Param += $"pc_telefono_adquiere='{dtr.pc_telefono_adquiere}' ,";
				Param += $"pc_localidad_adquiere='{dtr.pc_localidad_adquiere}' ,";
				Param += $"pc_municipio_adquiere='{dtr.pc_municipio_adquiere}' ,";
				Param += $"pc_ent_fed_adquiere='{dtr.pc_ent_fed_adquiere}' ,";
				Param += $"pc_curp_adquiere='{dtr.pc_curp_adquiere}' ,";
				Param += $"pc_rfc='{dtr.pc_rfc}' ,";
				Param += $"pc_nom_comercial='{dtr.pc_nom_comercial}' ,";
				Param += $"pi_tipo_fmto={dtr.pi_tipo_fmto}";
				Param += ")";
				String cdtxt = $"{{call n_adquiriente_p{Param}}}";
				cmd = new IngresCommand(cdtxt, conn);
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 15;
				Debug.WriteLine(cdtxt);
				ArchivoLog.EscribirLog(cdtxt, TraceEventType.Information);
				Debug.WriteLine("Abrir conexion");
				idr = cmd.ExecuteReader();
				Debug.WriteLine("Idr Ejecutado");
				while (idr.Read())
				{
					ans.Field1 = idr.GetInt32(0);
					ans.Field2 = idr.GetInt32(1);
					ans.Field3 = idr.GetInt16(2);
					ans.Field4 = idr.GetString(3) == null ? "" : idr.GetString(3).Trim();
					ans.Field5 = idr.GetString(4) == null ? "" : idr.GetString(4).Trim();
					ans.Field6 = idr.GetString(5) == null ? "" : idr.GetString(5).Trim();
					ans.Field7 = idr.GetString(6) == null ? "" : idr.GetString(6).Trim();
					ans.Field8 = idr.GetString(7) == null ? "" : idr.GetString(7).Trim();
					ans.Field9 = idr.GetString(8) == null ? "" : idr.GetString(8).Trim();
					ans.Field10 = idr.GetString(9) == null ? "" : idr.GetString(9).Trim();
					ans.Field11 = idr.GetInt32(10);
					ans.Field12 = idr.GetString(11) == null ? "" : idr.GetString(11).Trim();
					ans.Field13 = idr.GetString(12) == null ? "" : idr.GetString(12).Trim();
					ans.Field14 = idr.GetString(13) == null ? "" : idr.GetString(13).Trim();
					ans.Field15 = idr.GetString(14) == null ? "" : idr.GetString(14).Trim();
					ans.Field16 = idr.GetString(15) == null ? "" : idr.GetString(15).Trim();
					ans.Field17 = idr.GetString(16) == null ? "" : idr.GetString(16).Trim();
					ans.Field18 = idr.GetString(17) == null ? "" : idr.GetString(17).Trim();
					ans.Field19 = idr.GetInt32(18);
					ans.Field20 = idr.GetString(19) == null ? "" : idr.GetString(19).Trim();
				}
			}
			catch (IngresException inex)
			{
				Debug.WriteLine("Conn=" + conn.State + " " + inex.Message.ToString());
				System.Diagnostics.Trace.WriteLine("Error: \n" + inex.ToString());
				Mensaje error = new Mensaje(-99, "Error en la base de datos", inex.ToString().Trim());
				return new OutAdquiriente(error);
			}
			finally
			{
				if (cmd != null)
					cmd.Dispose();
				if (idr != null)
				{
					if (idr.IsClosed != true)
						idr.Close();
					idr.Dispose();
				}
				if (conn != null)
				{
					Debug.WriteLine("Conexion Cerrada");
					if (conn.State != ConnectionState.Closed)
						conn.Close();
					conn.Dispose();
				}
			}

			return ans;
		}

		public static Out_Inmueble admonInmueble(IngresConnection conn, In_Inmueble dtr)

		{
			Out_Inmueble ans = new Out_Inmueble();
			IngresDataReader idr = null;
			IngresCommand cmd = null;
			try
			{
				conn.Open();
			}
			catch (IngresException inex)
			{
				Debug.WriteLine("Conn=" + conn.State + " " + inex.Message.ToString());
				System.Diagnostics.Trace.WriteLine("Error: \n" + inex.ToString());
				Mensaje error = new Mensaje(-99, "Error En la conexion ", inex.ToString().Trim());
				return new Out_Inmueble(error);
			}
			try
			{

				Debug.WriteLine("Conn TRY=" + conn.State);
				String Param = "(";
				Param += $"pi_opcion={dtr.pi_opcion},";
				Param += $"pi_no_ticket={dtr.pi_no_ticket},";
				Param += $"pi_control={dtr.pi_control},";
				Param += $"pc_calle_inmueble='{dtr.pc_calle_inmueble}',";
				Param += $"pc_no_ext_inmueble='{dtr.pc_no_ext_inmueble}',";
				Param += $"pc_no_int_inmueble='{dtr.pc_no_int_inmueble}',";
				Param += $"pc_colonia_inmueble='{dtr.pc_colonia_inmueble}',";
				Param += $"pi_codigo_inmueble={dtr.pi_codigo_inmueble},";
				Param += $"pi_localidad_inmueble={dtr.pi_localidad_inmueble},";
				Param += $"pi_municipio_inmueble={dtr.pi_municipio_inmueble},";
				Param += $"pf_superficie_vendida={dtr.pf_superficie_vendida},";
				Param += $"pf_superficie_restante={dtr.pf_superficie_restante},";
				Param += $"pf_superficie_construida={dtr.pf_superficie_construida},";
				Param += $"pc_medida_colindancia_norte='{dtr.pc_medida_colindancia_norte}' ,";
				Param += $"pc_medida_colindancia_sur='{dtr.pc_medida_colindancia_sur}' ,";
				Param += $"pc_medida_colindancia_oriente='{dtr.pc_medida_colindancia_oriente}' ,";
				Param += $"pc_medida_colindancia_poniente='{dtr.pc_medida_colindancia_poniente}' ,";
				Param += $"pc_entre_calles='{dtr.pc_entre_calles}' ,";
				Param += $"pc_referencia='{dtr.pc_referencia}' ,";
				Param += $"pi_tipo_inmueble={dtr.pi_tipo_inmueble}";
				Param += ")";
				String cdtxt = $"{{call n_adquiriente_p{Param}}}";
				cmd = new IngresCommand(cdtxt, conn);
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 15;
				Debug.WriteLine(cdtxt);
				ArchivoLog.EscribirLog(cdtxt, TraceEventType.Information);
				Debug.WriteLine("Abrir conexion");
				idr = cmd.ExecuteReader();
				Debug.WriteLine("Idr Ejecutado");
				while (idr.Read())
				{
					ans.Field1 = idr.GetInt32(0);
					ans.Field2 = idr.GetInt32(1);
					ans.Field3 = idr.GetString(2) == null ? "" : idr.GetString(2).Trim();
					ans.Field4 = idr.GetString(3) == null ? "" : idr.GetString(3).Trim();
					ans.Field5 = idr.GetString(4) == null ? "" : idr.GetString(4).Trim();
					ans.Field6 = idr.GetString(5) == null ? "" : idr.GetString(5).Trim();
					ans.Field7 = idr.GetInt32(6);
					ans.Field8 = idr.GetInt32(7);
					ans.Field9 = idr.GetInt32(8);
					ans.Field10 = idr.GetFloat(9);
					ans.Field11 = idr.GetFloat(10);
					ans.Field12 = idr.GetFloat(11);
					ans.Field13 = idr.GetString(12) == null ? "" : idr.GetString(12).Trim();
					ans.Field14 = idr.GetString(13) == null ? "" : idr.GetString(13).Trim();
					ans.Field15 = idr.GetString(14) == null ? "" : idr.GetString(14).Trim();
					ans.Field16 = idr.GetString(15) == null ? "" : idr.GetString(15).Trim();
					ans.Field17 = idr.GetString(16) == null ? "" : idr.GetString(16).Trim();
					ans.Field18 = idr.GetString(17) == null ? "" : idr.GetString(17).Trim();
					ans.Field19 = idr.GetInt32(18);
					ans.Field20 = idr.GetInt32(19);
					ans.Field21 = idr.GetString(20) == null ? "" : idr.GetString(20).Trim();
				}
			}
			catch (IngresException inex)
			{
				Debug.WriteLine("Conn=" + conn.State + " " + inex.Message.ToString());
				System.Diagnostics.Trace.WriteLine("Error: \n" + inex.ToString());
				Mensaje error = new Mensaje(-99, "Error en la base de datos", inex.ToString().Trim());
				return new Out_Inmueble(error);
			}
			finally
			{
				if (cmd != null)
					cmd.Dispose();
				if (idr != null)
				{
					if (idr.IsClosed != true)
						idr.Close();
					idr.Dispose();
				}
				if (conn != null)
				{
					Debug.WriteLine("Conexion Cerrada");
					if (conn.State != ConnectionState.Closed)
						conn.Close();
					conn.Dispose();
				}
			}

			return ans;
		}

	}
}