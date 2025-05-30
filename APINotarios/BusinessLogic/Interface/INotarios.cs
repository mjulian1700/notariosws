using APINotarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.BusinessLogic.Interface
{
	public interface INotarios : IDisposable
	{
		OutReferencia consReferencia(int ambiente, InReferencia dtr);
		Enajenante admEnajenante(int ambiente, P_Enajentantes dtr);
		OutAdquiriente adquiriente(int ambiente, InAdquiriente dtr);
		Out_Inmueble admonInmueble(int ambiente, In_Inmueble dtr);
		Out_NotariosISR notarioISR(int ambiente, In_NotariosISR dtr);
	}	
}