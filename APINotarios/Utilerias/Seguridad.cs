using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace APINotarios.Utilerias
{
	public class Seguridad
	{

		private static string key { get; set; } = "f1n4nz4$Pu#bl@";
		public static String Encriptar(String value)
		{

			using (var md5 = new MD5CryptoServiceProvider())
			{
				using (var tdes = new TripleDESCryptoServiceProvider())
				{
					tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
					tdes.Mode = CipherMode.ECB;
					tdes.Padding = PaddingMode.PKCS7;

					using (var transform = tdes.CreateEncryptor())
					{
						byte[] textBytes = UTF8Encoding.UTF8.GetBytes(value);
						byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
						return Convert.ToBase64String(bytes, 0, bytes.Length);
					}
				}
			}
		}
		public static String Desencriptar(String value)
		{
			/// validar espacios
			/// l1c3nc1@D1G
			using (var md5 = new MD5CryptoServiceProvider())
			{
				using (var tdes = new TripleDESCryptoServiceProvider())
				{
					tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
					tdes.Mode = CipherMode.ECB;
					tdes.Padding = PaddingMode.PKCS7;

					byte[] bytes = new byte[0];
					byte[] cipherBytes = new byte[0];

					using (var transform = tdes.CreateDecryptor())
					{
						try
						{
							cipherBytes = Convert.FromBase64String(value);
						}
						catch (Exception ex)
						{
							System.Diagnostics.Debug.WriteLine("ERROR Exception: => " + ex.ToString());
						}
						try
						{
							bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
						}
						catch (CryptographicException cex)
						{
							System.Diagnostics.Debug.WriteLine("ERROR Crypt: => " + cex.ToString());
						}
						catch (ArgumentNullException anex)
						{
							System.Diagnostics.Debug.WriteLine("ERROR ArgumentNull: => " + anex.ToString());
						}
						catch (ArgumentException aex)
						{
							System.Diagnostics.Debug.WriteLine("ERROR Argument: => " + aex.ToString());
						}
						return UTF8Encoding.UTF8.GetString(bytes);
					}
				}
			}
		}
	}
}