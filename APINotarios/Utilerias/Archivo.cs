using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace APINotarios.Utilerias
{
	public class Archivo
	{
		public static async Task<String> GetFileFromHttp(HttpResponseMessage ans, String SubPath)
		{

			byte[] fileData = await ans.Content.ReadAsByteArrayAsync();/// lectura de archivo a bytes 
			String arch = Archivo.DownloadFile(fileData, ans.Content.Headers.ContentDisposition.FileName, SubPath);
			Debug.WriteLine("Archivo copiado");
			return arch;
		}

		public static String DownloadFile(byte[] fileData, String FileName, String SubPath)
		{
			String Carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SubPath);
			Debug.WriteLine("Carpeta=" + Carpeta);
			Debug.WriteLine("Archivo=" + FileName);
			String arch = Path.Combine(Carpeta, FileName);
			File.WriteAllBytes(arch, fileData);
			Debug.WriteLine("carpeta=" + arch);
			return arch;
		}

		public static String DownloadImage(string Cad, string FileName, string SubPath)
		{
			byte[] ans = Convert.FromBase64String(Cad);
			String Carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SubPath);
			Debug.WriteLine("Carpeta=" + Carpeta);
			Debug.WriteLine("Archivo=" + FileName);
			String arch = Path.Combine(Carpeta, FileName);
			MemoryStream ms = new MemoryStream(ans);
			//Image jpg = Image.FromStream(ms);
			//jpg.Save(arch, ImageFormat.Jpeg);
			File.WriteAllBytes(arch, ans);
			return arch;
		}
	}
}