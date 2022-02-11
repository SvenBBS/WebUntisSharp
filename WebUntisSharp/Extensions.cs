using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace mrousavy.APIs.WebUntisSharp
{
    public static class Extensions
    {
        public static T[] Concat<T> (this T[] x, T[] y)
        {
            var z = new T[x.Length + y.Length];
            x.CopyTo(z, 0);
            y.CopyTo(z, x.Length);
            return z;
        }



    }

    public static class UnicodeNormalizer
    {

        private static Dictionary<char, string> charmap = new Dictionary<char, string>() {
            {'À', "A"}, {'Á', "A"}, {'Â', "A"}, {'Ã', "A"}, {'Ä', "Ae"}, {'Å', "A"}, {'Æ', "Ae"},
            {'Ç', "C"},
            {'È', "E"}, {'É', "E"}, {'Ê', "E"}, {'Ë', "E"},
            {'Ì', "I"}, {'Í', "I"}, {'Î', "I"}, {'Ï', "I"},
            {'Ð', "Dh"}, {'Þ', "Th"},
            {'Ñ', "N"},
            {'Ò', "O"}, {'Ó', "O"}, {'Ô', "O"}, {'Õ', "O"}, {'Ö', "Oe"}, {'Ø', "Oe"},
            {'Ù', "U"}, {'Ú', "U"}, {'Û', "U"}, {'Ü', "Ue"},
            {'Ý', "Y"},
            {'ß', "ss"},
            {'à', "a"}, {'á', "a"}, {'â', "a"}, {'ã', "a"}, {'ä', "ae"}, {'å', "a"}, {'æ', "ae"},
            {'ç', "c"},
            {'è', "e"}, {'é', "e"}, {'ê', "e"}, {'ë', "e"},
            {'ì', "i"}, {'í', "i"}, {'î', "i"}, {'ï', "i"},
            {'ð', "dh"}, {'þ', "th"},
            {'ñ', "n"},
            {'ò', "o"}, {'ó', "o"}, {'ô', "o"}, {'õ', "o"}, {'ö', "oe"}, {'ø', "oe"},
            {'ù', "u"}, {'ú', "u"}, {'û', "u"}, {'ü', "ue"},
            {'ý', "y"}, {'ÿ', "y"},
            {' ', "."}
        };

        private static Dictionary<char, string> charmapEMail = new Dictionary<char, string>() {
            {' ', "."}
        };

        public static string CleanString(this string text)
        {
            text = text.Trim(new char[] {' '});
            return text.Aggregate(
              new StringBuilder(),
              (sb, c) => {
                  string r;
                  if (charmap.TryGetValue(c, out r))
                  {
                      return sb.Append(r);
                  }
                  return sb.Append(c);
              }).ToString();
        }

        public static string ReplaceCharsForEmail(this string text)
        {
            return text.Aggregate(
              new StringBuilder(),
              (sb, c) => {
                  string r;
                  if (charmapEMail.TryGetValue(c, out r))
                  {
                      return sb.Append(r);
                  }
                  return sb.Append(c);
              }).ToString();
        }

    }
}
