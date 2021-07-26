using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.CustromRequirements
{
    public class CustomRequirement : IAuthorizationRequirement
    {
        public int Age { get; set; }

        public CustomRequirement(int age)
        {
            Age = age;
        }
    }
}