using Microsoft.Extensions.Options;
using System.Text;
using System.Text.RegularExpressions;
using WebApiPractice.Sorting;

namespace PracticeFromTechnology_WebApi_.Handler
{
    public class StringHandler
    {
        private readonly RandomizerApi _randomizerApi;
        private readonly List<string> _blacklistWords;
        public StringHandler(RandomizerApi randomizerApi, IOptions<BlacklistSettings> blacklistSettings)
        {
            if (blacklistSettings?.Value?.Words == null || !blacklistSettings.Value.Words.Any())
            {
                throw new ArgumentException("Blacklist settings are not configured properly.");
            }

            _randomizerApi = randomizerApi;
            _blacklistWords = blacklistSettings.Value?.Words ?? throw new ArgumentException("Blacklist settings are not configured properly.");
        }

        public string StringReverse(string text)
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

        public string GetInvalidCharacters(string text)
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

        public Dictionary<char, int> CharCounter(string text)
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

        public string SearchVowelsSubstring(string text)
        {
            string pattern = @"[aeiouy][a-z]*[aeiouy]";
            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            var longestSubstring = string.Empty;

            foreach (Match match in matches)
            {
                if (match.Length > longestSubstring.Length)
                {
                    longestSubstring = match.Value;
                }
            }

            return longestSubstring;
        }

        public string ChoseSort(string text, string sortSelection)
        {
            if(sortSelection == "quick")
            {
                var quickSortingString = QuickSort.QuickSortMethod(text.ToCharArray(), 0, text.Length - 1);
                return string.Join("", quickSortingString);
            }else if(sortSelection == "tree")
            {
                var treeSortingStrign = TreeNode.TreeSort(text.ToCharArray());
                return string.Join("", treeSortingStrign);
            }
            else
            {
                return "Choose 'quick' or 'tree', case sensitive"; 
            }
        }

        public async Task<string> RemoveRandomCharacter(string text)
        {
            var randomIndex = await _randomizerApi.GetRandomIndexAsync(text.Length - 1);
            var resultString = text.Remove(randomIndex, 1);
            return resultString;
        }

        public List<string> GetBlacklistedWords(string text)
        {
            var words = text.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            var foundBlacklistedWords = new List<string>();

            foreach(var word in words)
            {
                if (_blacklistWords.Contains(word))
                {
                    foundBlacklistedWords.Add(word);
                }
            }

            return foundBlacklistedWords;
        }

        public string InvalidWord(string text)
        {
            var blacklistWord = GetBlacklistedWords(text);
            if (!blacklistWord.Any())
            {
                return string.Join(",", blacklistWord);
            }
            return text;
        }
    } 
}
