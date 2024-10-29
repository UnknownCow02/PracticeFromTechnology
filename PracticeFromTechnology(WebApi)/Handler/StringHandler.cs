using System.Text;

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
    }
}
