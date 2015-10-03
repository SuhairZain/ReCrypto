using System;

namespace ReCrypto
{
	public class Decrypt
	{
		public static String DecryptMessage(String message, int[] indices)
		{
			String returnString = "";
			for(int i=0; i<indices.Length; ++i)
			{
				returnString += message [indices [i]];
			}
			return returnString;
		}
	}
}

