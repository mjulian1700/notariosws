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

		public static Out_NotariosISR notarioISR(IngresConnection conn, In_NotariosISR dtr)
		{
			Out_NotariosISR ans = new Out_NotariosISR();
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
				return new Out_NotariosISR(error);
			}
			try
			{

				Debug.WriteLine("Conn TRY=" + conn.State);
				String Param = "(";
				Param += $"pi_no_ticket={dtr.pi_no_ticket},";
				Param += $"pc_fol_ope_not={dtr.pc_fol_ope_not},";
				Param += $"pi_tipo_declaracion='{dtr.pi_tipo_declaracion}',";
				Param += $"pi_tipo_calculo='{dtr.pi_tipo_calculo}',";
				Param += $"pi_causa_exencion='{dtr.pi_causa_exencion}',";
				Param += $"pi_no_complementaria='{dtr.pi_no_complementaria}',";
				Param += $"pd_fecha_anterior={dtr.pd_fecha_anterior},";
				Param += $"pm_ingreso_enajena={dtr.pm_ingreso_enajena},";
				Param += $"pf_ingreso_udis={dtr.pf_ingreso_udis},";
				Param += $"pf_excedente_udis={dtr.pf_excedente_udis},";
				Param += $"pm_ing_gravado={dtr.pm_ing_gravado},";
				Param += $"pm_ing_exento={dtr.pm_ing_exento},";
				Param += $"pc_causa_no_pago='{dtr.pc_causa_no_pago}' ,";
				Param += $"pm_deducciones='{dtr.pm_deducciones}' ,";
				Param += $"pm_pago_provisional='{dtr.pm_pago_provisional}' ,";
				Param += $"pm_monto_anterior='{dtr.pm_monto_anterior}' ,";
				Param += $"pd_fecha_operacion_not='{dtr.pd_fecha_operacion_not}'";
				Param += ")";
				String cdtxt = $"{{call n_notarios_isr_p{Param}}}";
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
					ans.Field1 = idr.GetDouble(0);
					ans.Field2 = idr.GetDouble(1);
					ans.Field3 = idr.GetDouble(2);
					ans.Field4 = idr.GetDouble(3);
					ans.Field5 = idr.GetDouble(4);
					ans.Field6 = idr.GetDouble(5);
					ans.Field7 = idr.GetDouble(6);
					ans.Field8 = idr.GetDouble(7);
					ans.Field9 = idr.GetInt32(8);
					ans.Field10 = idr.GetString(9) == null ? "" : idr.GetString(9).Trim();
				}
			}
			catch (IngresException inex)
			{
				Debug.WriteLine("Conn=" + conn.State + " " + inex.Message.ToString());
				System.Diagnostics.Trace.WriteLine("Error: \n" + inex.ToString());
				Mensaje error = new Mensaje(-99, "Error en la base de datos", inex.ToString().Trim());
				return new Out_NotariosISR(error);
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

		public static OutMaestro maestroNotario(IngresConnection conn, InMaestro dtr)
		{
			OutMaestro ans = new OutMaestro();
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
				return new OutMaestro(error);
			}
			try
			{

				Debug.WriteLine("Conn TRY=" + conn.State);
				String Param = "(";
				Param += $"pi_opcion={dtr.pi_no_ticket},";
				Param += $"pi_no_ticket={dtr.pi_no_ticket},";
				Param += $"pi_cve_notario='{dtr.pi_cve_notario}',";
				Param += $"pi_tipo_fmto='{dtr.pi_tipo_fmto}',";
				Param += $"pc_folio_operación_not='{dtr.pc_folio_operación_not}',";
				Param += $"pd_fecha_operación_not='{dtr.pd_fecha_operación_not}',";
				Param += $"pc_no_escritura={dtr.pc_no_escritura},";
				Param += $"pc_fojas={dtr.pc_fojas},";
				Param += $"pc_no_tomo={dtr.pc_no_tomo},";
				Param += $"pc_no_libro={dtr.pc_no_libro},";
				Param += $"pi_fol_avaluo_catastral={dtr.pi_fol_avaluo_catastral},";
				Param += $"pd_fec_avaluo_catastral={dtr.pd_fec_avaluo_catastral},";
				Param += $"pi_digito_verif_avaluo='{dtr.pi_digito_verif_avaluo}' ,";
				Param += $"pm_valor_catastral='{dtr.pm_valor_catastral}' ,";
				Param += $"pi_tipo_operacion='{dtr.pi_tipo_operacion}' ,";
				Param += $"pi_region='{dtr.pi_region}' ,";
				Param += $"pi_manzana='{dtr.pi_manzana}'";
				Param += $"pi_no_lote='{dtr.pi_no_lote}'";
				Param += $"pi_inscripcion='{dtr.pi_inscripcion}'";
				Param += $"pm_valor_operacion='{dtr.pm_valor_operacion}'";
				Param += $"pm_base_gravable='{dtr.pm_base_gravable}'";
				Param += $"pi_tasa='{dtr.pi_tasa}'";
				Param += $"pc_descrip_operacion='{dtr.pc_descrip_operacion}'";
				Param += $"pi_porce_dere_propi='{dtr.pi_porce_dere_propi}'";
				Param += $"pc_partida='{dtr.pc_partida}'";
				Param += $"pc_indice_predio='{dtr.pc_indice_predio}'";
				Param += ")";
				String cdtxt = $"{{call n_maestro_p{Param}}}";
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
					ans.Field3 = idr.GetInt32(2);
					ans.Field4 = idr.GetString(3);
					ans.Field5 = idr.GetDateTime(4).ToString("dd/MM/yyyy").Equals("31/12/9999") ? " " : idr.GetDateTime(4).ToString("dd/MM/yyyy");
					ans.Field6 = idr.GetString(5);
					ans.Field7 = idr.GetString(6);
					ans.Field8 = idr.GetString(7);
					ans.Field9 = idr.GetString(8);
					ans.Field10 = idr.GetInt32(9);
					ans.Field11 = idr.GetDateTime(10).ToString("dd/MM/yyyy").Equals("31/12/9999") ? " " : idr.GetDateTime(4).ToString("dd/MM/yyyy");
					ans.Field12 = idr.GetInt32(11);
					ans.Field13 = idr.GetDouble(12);
					ans.Field14 = idr.GetInt32(13);
					ans.Field15 = idr.GetInt32(14);
					ans.Field16 = idr.GetInt32(15);
					ans.Field17 = idr.GetInt32(16);
					ans.Field18 = idr.GetInt32(17);
					ans.Field19 = idr.GetDouble(18);
					ans.Field20 = idr.GetDouble(19);
					ans.Field21 = idr.GetInt32(20);
					ans.Field22 = idr.GetString(21) == null ? "" : idr.GetString(21).Trim();
					ans.Field23 = idr.GetInt32(22);
					ans.Field24 = idr.GetString(23) == null ? "" : idr.GetString(23).Trim();
					ans.Field25 = idr.GetString(24) == null ? "" : idr.GetString(24).Trim();
					ans.Field26 = idr.GetInt32(25);
					ans.Field27 = idr.GetDouble(26);
					ans.Field28 = idr.GetInt32(27);
					ans.Field29 = idr.GetString(28) == null ? "" : idr.GetString(28).Trim();
				}
			}
			catch (IngresException inex)
			{
				Debug.WriteLine("Conn=" + conn.State + " " + inex.Message.ToString());
				System.Diagnostics.Trace.WriteLine("Error: \n" + inex.ToString());
				Mensaje error = new Mensaje(-99, "Error en la base de datos", inex.ToString().Trim());
				return new OutMaestro(error);
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