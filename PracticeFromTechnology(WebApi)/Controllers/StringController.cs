using Microsoft.AspNetCore.Mvc;
using PracticeFromTechnology_WebApi_.Handler;
using System.Text.RegularExpressions;

namespace TechnologyPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringController : Controller
    {
        [HttpGet]
        public ActionResult GetString(string text)
        {
            if (!string.IsNullOrEmpty(text) && Regex.IsMatch(text, "^[a-z]+$"))
            {
                var response = new
                {
                    reversedString = StringHandler.StringReverse(text.ToString())
                };
                return Ok(response);
            }
            else
            {
                return BadRequest(StringHandler.GetInvalidCharacters(text));
            }

        }
    }
}