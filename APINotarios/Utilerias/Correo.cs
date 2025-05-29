using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace APINotarios.Utilerias
{
	public class Correo
	{
		public static String prepararCuerpo(String titulo, String aplicacion, String procedimiento, String[] parametros, String error)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<b>" + titulo + "</b><br>");
			sb.Append("Aplicación: <b>" + aplicacion + "</b><br>");
			sb.Append("Procedimiento / Método: <b>" + procedimiento + "</b><br>");
			sb.Append("Parámetros: <br>");
			foreach (String ind in parametros)
			{
				sb.Append("&nbsp;&nbsp;&nbsp;--><b>" + ind.ToString() + "</b> <br>");
			}
			sb.Append("Resultado: <b>" + error + "</b><br>");
			return sb.ToString();
		}

		public static bool EnviarCorreo(String aplicacion, String mensaje, String ruta)
		{
			String remitente = ConfigurationManager.AppSettings["correoRemitente"].ToString();
			String pwdRemitente = ConfigurationManager.AppSettings["pwdRemitente"].ToString();
			String hostRemitente = ConfigurationManager.AppSettings["hostRemitente"].ToString();
			String correoDestinatario = ConfigurationManager.AppSettings["correoDestinatario"].ToString();
			String correoDestinatarioC = ConfigurationManager.AppSettings["correoDestinatarioC"].ToString();
			/*-------------------------MENSAJE DE CORREO----------------------*/

			//Creamos un nuevo Objeto de mensaje
			MailMessage mmsg = new System.Net.Mail.MailMessage();
			String[] destinatarios = correoDestinatario.Split(';');
			foreach (String dest in destinatarios)
			{
				//Direccion de correo electronico a la que queremos enviar el mensaje
				//Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario
				mmsg.To.Add(dest);
			}
			if (!correoDestinatarioC.Trim().Equals(""))
			{
				String[] destinatariosCopias = correoDestinatarioC.Split(';');
				foreach (String destC in destinatariosCopias)
				{
					//Direccion de correo electronico que queremos que reciba una copia del mensaje
					mmsg.CC.Add(destC);
				}
			}
			Attachment log = new Attachment(ruta);

			mmsg.Attachments.Add(log);
			//Asunto
			mmsg.Subject = aplicacion;
			mmsg.SubjectEncoding = Encoding.UTF8;
			//Cuerpo del Mensaje
			mmsg.Body = mensaje;
			mmsg.BodyEncoding = Encoding.UTF8;
			mmsg.IsBodyHtml = true; //Si queremos que se envíe como HTML
									//Correo electronico desde la que enviamos el mensaje
			mmsg.From = new MailAddress(remitente);
			/*-------------------------CLIENTE DE CORREO----------------------*/
			//Creamos un objeto de cliente de correo
			SmtpClient cliente = new SmtpClient();
			//Hay que crear las credenciales del correo emisor
			cliente.Credentials = new System.Net.NetworkCredential(remitente, pwdRemitente);
			//Lo siguiente es obligatorio si enviamos el mensaje desde Gmail

			cliente.Port = 587;
			cliente.EnableSsl = true;
			cliente.Host = hostRemitente;
			/*-------------------------ENVIO DE CORREO----------------------*/
			try
			{
				cliente.Send(mmsg);
				System.Diagnostics.Debug.WriteLine("Correo enviado");
				return true;
			}
			catch (SmtpException ex)
			{
				System.Diagnostics.Trace.WriteLine("ERROR al enviar correo:" + ex.ToString());
				return false;
			}
			finally
			{
				log.Dispose();
				cliente.Dispose();
			}
		}
	}
}