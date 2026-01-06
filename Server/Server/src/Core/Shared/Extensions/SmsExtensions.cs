using System;
using System.Text;

namespace Server.Shared.Extensions
{
    public static class StringExtensions
    {
        private static readonly Encoding TurkishEncoding = Encoding.GetEncoding("iso-8859-9");

        private static readonly Random random = new Random();
        private const string chars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";


        public static string TurkishUrlEncode(this string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if (IsTurkishCharacter(c))
                {
                    byte[] bytes = TurkishEncoding.GetBytes(c.ToString());
                    foreach (byte b in bytes)
                    {
                        sb.AppendFormat("%{0:X2}", b);
                    }
                }
                else
                {
                    sb.Append(Uri.EscapeDataString(c.ToString()));
                }
            }
            return sb.ToString();
        }

        private static bool IsTurkishCharacter(char c)
        {
            return c == 'ı' || c == 'İ' || c == 'ğ' || c == 'Ğ' || c == 'ş' || c == 'Ş' || c == 'ç' || c == 'Ç' || c == 'ü' || c == 'Ü' || c == 'ö' || c == 'Ö';
        }


        public static string CheckPhoneNumber(this string numara)
        {
            // Numaranın uzunluğunu kontrol etme
            if (numara.Length == 11) // 0 ile başlayan numaralar
            {
                // 0 ön ekini kaldır ve kalan kısmı geri döndür
                return numara.Substring(1);
            }
            else if (numara.Length == 12) // 90 alan kodu ile başlayan numaralar
            {
                // 90 alan kodunu ve ardından 0 ön ekini kaldır, kalan kısmı geri döndür
                return numara.Substring(2);
            }
            else if (numara.Length == 13) // +90 alan kodu ile başlayan numaralar
            {
                // +90 alan kodunu ve ardından 0 ön ekini kaldır, kalan kısmı geri döndür
                return numara.Substring(3);
            }
            else if (numara.Length < 10 || numara.Equals("0000000000"))
            {
                // Uygun olmayan bir numara uzunluğu durumunda hata mesajı döndür
                return "Geçersiz telefon numarası!";
            }
            else
            {
                return numara;
            }
        }

        public static string GenerateRandomString(int length = 6)
        {
            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
    }
}
