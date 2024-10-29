using Microsoft.AspNetCore.Mvc;
using PracticeFromTechnology_WebApi_.Handler;

namespace TechnologyPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringController : Controller
    {
        [HttpGet]
        public ActionResult GetString(string text)
        {
            var response = new
            {
                reversedString = StringHandler.StringReverse(text.ToString())
            };
            return Ok(response);
        }
    }
}