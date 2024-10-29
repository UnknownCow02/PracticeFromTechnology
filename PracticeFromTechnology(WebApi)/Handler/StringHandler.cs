using System.Text;
using System.Text.RegularExpressions;

namespace PracticeFromTechnology_WebApi_.Handler
{
    public class StringHandler
    {
        public static string StringReverse(string text)
        {
            var sb = new StringBuilder();
            var halfRange = text.Length / 2;

            if (text.Length % 2 == 0)
            {
                var firstSubstring = text.Substring(0, halfRange);
                var secondSubsting = text.Substring(halfRange);

                sb.Append(firstSubstring.Reverse().ToArray());
                sb.Append(secondSubsting.Reverse().ToArray());

                return sb.ToString();
            }
            else
            {
                sb.Append(text.Reverse().ToArray());
                return string.Concat(sb.ToString(), text);
            }
        }

        public static string GetInvalidCharacters(string text)
        {
            var invalidChars = new List<char>();

            foreach (char c in text)
            {
                if (!Regex.IsMatch(c.ToString(), "^[a-z]"))
                {
                    invalidChars.Add(c);
                }
            }

            return $"Недопустимые символы: {string.Join(",", invalidChars)}";
        }

        public static Dictionary<char, int> CharCounter(string text)
        {
            var numberOfCharacter = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (numberOfCharacter.ContainsKey(c))
                {
                    numberOfCharacter[c]++;
                }
                else
                {
                    numberOfCharacter[c] = 1;
                }
            }

            return numberOfCharacter;
        }
    }
}
