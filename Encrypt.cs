using System;

namespace ReCrypto
{
	public class Encrypt
	{
		static int difference = 'a' - 'A';
		//static int[] indices = new int[Char.MaxValue];

		public static void Initialize()
		{
			Reset ();
			//Console.WriteLine(indices.Length);
		}

		static void Reset()
		{
			//for (int i = 0; i < 26; ++i)
			//	indices [i] = -1;
		}

		public static bool EncryptMessage(String message, String garbage, int[] indices)
		{
			int i = 0, j = 0;
			while(i<message.Length && j<garbage.Length)
			{
				char m = message [i], g = garbage[j];
				if (m == g) {
					indices [i] = j;
					++i;
				} else if (m >= 'a' && m <= 'z') {
					if (g >= 'A' && g <= 'Z' && g + difference == m) {
						indices [i] = j;
						++i;
					}
				} else if (m >= 'A' && m <= 'Z') {
					if (g >= 'a' && g <= 'z' && g - difference == m) {
						indices [i] = j;
						++i;
					}
				}
				++j;
			}

			return i==message.Length;
		}
	}
}

