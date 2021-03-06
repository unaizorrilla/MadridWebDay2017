﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
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
