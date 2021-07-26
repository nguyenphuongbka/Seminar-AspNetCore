using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class HomeController
    {
        [HttpGet("index")]
        public string Index()
        {
            return "123";
        }
    }
}