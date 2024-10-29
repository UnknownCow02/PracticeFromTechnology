using Microsoft.AspNetCore.Mvc;
using PracticeFromTechnology_WebApi_;
using PracticeFromTechnology_WebApi_.Handler;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace TechnologyPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringController : Controller
    {

        private readonly StringHandler _stringHandler;
        public StringController(StringHandler stringHandler)
        {
            _stringHandler = stringHandler;
        }

        /// <param name="text">string for handler</param>
        /// <param name="sortSelection">Choose "quick" or "tree</param>
        
        [HttpGet]
        public ActionResult GetString(string text, string sortSelection)
        {

            if (!string.IsNullOrEmpty(text) && Regex.IsMatch(text, "^[a-z]+$"))
            {
                var reversedString = _stringHandler.StringReverse(text.ToString());
                var invalidWord = _stringHandler.InvalidWord(text);

                if (text == invalidWord)
                {
                    return BadRequest($"Данная строка находится в черном списке: {invalidWord}");
                }

                var response = new
                {
                    reversedString,
                    numberOfRepetitions = _stringHandler.CharCounter(reversedString),
                    longestVowelSubstring = _stringHandler.SearchVowelsSubstring(reversedString),
                    sortedString = _stringHandler.ChooseSort(reversedString, sortSelection),
                    stringWithDeletedRandomCharacter = _stringHandler.RemoveRandomCharacter(reversedString).Result
                };
                
                return Ok(response);
            }
            else
            {
                return BadRequest(_stringHandler.GetInvalidCharacters(text));
            }

        }
    }
}