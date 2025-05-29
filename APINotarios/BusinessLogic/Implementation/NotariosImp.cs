using APINotarios.BusinessLogic.Interface;
using APINotarios.DAO;
using APINotarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINotarios.BusinessLogic.Implementation
{
	public class NotariosImp : INotarios
	{
		public OutReferencia consReferencia(int ambiente, InReferencia dtr)
		{
			return DAONotarios.consReferencia(ambiente, dtr);
		}

		public Enajenante admEnajenante(int ambiente, P_Enajentantes dtr)
		{
			return DAONotarios.admEnajenante(ambiente, dtr);
		}

		public OutAdquiriente adquiriente(int ambiente, InAdquiriente dtr)
		{
			return DAONotarios.adquiriente(ambiente, dtr);
		}

		public Out_Inmueble admonInmueble(int ambiente, In_Inmueble dtr)
		{
			return DAONotarios.admonInmueble(ambiente, dtr);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}