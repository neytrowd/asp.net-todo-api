using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Todo.Common.Utils
{
	public static class HashUtil
	{
		public static bool VerifyEquality(string hashedValue, string value)
		{
			var hash = Hash(value); 
			return hash == hashedValue;
		}

		public static string Hash(string value)
		{
			var data = Encoding.ASCII.GetBytes(value);
			var md5 = new MD5CryptoServiceProvider();
			var hashed = md5.ComputeHash(data);
			return Convert.ToBase64String(hashed);
		}
	}
}
