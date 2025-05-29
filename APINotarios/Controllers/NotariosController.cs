using APINotarios.BusinessLogic.Implementation;
using APINotarios.BusinessLogic.Interface;
using APINotarios.Log;
using APINotarios.Models;
using APINotarios.Utilerias;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APINotarios.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[System.Web.Http.RoutePrefix("api/v1")]
	public class NotariosController : ApiController
	{
		[System.Web.Http.Route("Enajentantes")]
		[System.Web.Http.HttpPost]
		public Enajenante Post([FromBody] P_Enajentantes datos)
		{
			Enajenante resultado = new Enajenante();
			
			ArchivoLog.CreateLog(Token.GetId(datos.ambiente.ToString()));
			ArchivoLog.EscribirLog(JsonConvert.SerializeObject(datos), TraceEventType.Resume);

			INotarios call = new NotariosImp();
			//int ambiente = 0;
			resultado = call.admEnajenante(datos.ambiente, datos);
			ArchivoLog.EscribirLog(JsonConvert.SerializeObject(resultado), TraceEventType.Resume);
			return resultado;
		}

		[System.Web.Http.Route("Adquirientes")]
		[System.Web.Http.HttpPost]
		public OutAdquiriente Post([FromBody] InAdquiriente datos)
		{
			OutAdquiriente resultado = new OutAdquiriente();

			ArchivoLog.CreateLog(Token.GetId(datos.ambiente.ToString()));
			ArchivoLog.EscribirLog(JsonConvert.SerializeObject(datos), TraceEventType.Resume);

			INotarios call = new NotariosImp();
			resultado = call.adquiriente(datos.ambiente, datos);
			ArchivoLog.EscribirLog(JsonConvert.SerializeObject(resultado), TraceEventType.Resume);
			return resultado;
		}

		[System.Web.Http.Route("Inmueble")]
		[System.Web.Http.HttpPost]
		public Out_Inmueble Post([FromBody] In_Inmueble datos) 
		{
			Out_Inmueble resultado = new Out_Inmueble();

			ArchivoLog.CreateLog(Token.GetId(datos.ambiente.ToString()));
			ArchivoLog.EscribirLog(JsonConvert.SerializeObject(datos), TraceEventType.Resume);

			INotarios call = new NotariosImp();
			resultado = call.admonInmueble(datos.ambiente, datos);
			ArchivoLog.EscribirLog(JsonConvert.SerializeObject(resultado), TraceEventType.Resume);
			return resultado;
		}

	}
}
