using System;
using System.Text;

namespace HexDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                DecodeAndOutput(arg);
            }
            while (true)
            {
                Console.Write("Input data to decode: ");
                string input = Console.ReadLine();
                DecodeAndOutput(input);
            }
        }

        private static void DecodeAndOutput(string input)
        {
            string decoded = DecodeHex(input);
            if (!string.IsNullOrEmpty(decoded))
                Console.WriteLine("Decoded: " + decoded);
        }
        public static string DecodeHex(string hex)
        {
            try
            {
                hex = hex.Replace("-", "");
                byte[] raw = new byte[hex.Length / 2];
                for (int i = 0; i < raw.Length; i++)
                {
                    raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
                }
                return Encoding.BigEndianUnicode.GetString(raw);
            }
            catch { return null; }
        }
    }
}
