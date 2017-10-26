using Microsoft.AspNetCore.Mvc;

namespace HelloWebApi.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult  Get(string name)
        {
            return Ok($"Hello {name}, hope you are fine!");
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return Ok($"Posted");
        }
    }
}
