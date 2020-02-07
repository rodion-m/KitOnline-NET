using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace KitOnline
{
	internal static class Extensions
	{
		/// <summary> Переводит рубли в копейки </summary>
		public static long Kopeek(this decimal rubs) => (long) Math.Round(rubs * 100, MidpointRounding.ToEven);
		
		/// <summary> Вычисляет md5 сумму и возвращает ее виде строки </summary>
		/// <param name="text">Кодируемый текст</param>
		/// <param name="lowerCase">Перевести результат в нижний регистр</param>
		public static string Md5(this string text, bool lowerCase = false)
		{
			using var md5 = MD5.Create();
			var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
			var result = BitConverter.ToString(bytes).Replace("-", "");
			if (lowerCase)
				result = result.ToLowerInvariant();
				
			return result;
		}
	}
}