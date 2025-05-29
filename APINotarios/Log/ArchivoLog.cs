using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace APINotarios.Log
{
	public class ArchivoLog
	{
		private static String sLogFormat;
		public static String ruta;
		private static TraceSource ts = new TraceSource("MyTraceSource");
		private static int id;
		public static void CreateLog(int aid)
		{

			ts.Listeners.Add(new TextWriterTraceListener("~/Log/LogNotarios.txt"));
			///ts.Listeners.Add(new TextWriterTraceListener("TracePVehicular.txt"));
			sLogFormat = DateTime.Now.ToString($"dd.MM.yyyy HH:mm:ss") + "|";
			ruta = HttpContext.Current.Request.MapPath(ConfigurationManager.AppSettings["ruta"].ToString());
			id = aid;
		}

		public static void EscribirLog(String sErrMsg, TraceEventType stuff)
		{
			ts.TraceEvent(stuff, id, sLogFormat + sErrMsg);
			//ts.TraceInformation(sLogFormat + sErrMsg);
			ts.Flush();
			ts.Close();
			using (StreamWriter sw = new StreamWriter(ruta, true, Encoding.UTF8))
			{
				sw.WriteLine(sLogFormat + sErrMsg);
				sw.Flush();
				sw.Close();
			}
		}
		public static void LimpiarLog()
		{
			StreamWriter sw = new StreamWriter(ruta, false);
			sw.WriteLine("");
			sw.Flush();
			sw.Close();
		}
	}
}