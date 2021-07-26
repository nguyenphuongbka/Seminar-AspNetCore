using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Policy = "custom")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateModel]
        public IActionResult Login(User user)
        {
            var nameClaim = new Claim("name", "bob");
            var emailClaim = new Claim("email", "bob");
            var mssvClaim = new Claim("mssv", "bob");

            var claimsIdentityBlx = new ClaimsIdentity("Bang lai xe");
            claimsIdentityBlx.AddClaim(nameClaim);
            claimsIdentityBlx.AddClaim(emailClaim);

            var claimsIdentityTotNgiep = new ClaimsIdentity("Bang Tot nghiep");
            claimsIdentityTotNgiep.AddClaim(nameClaim);
            claimsIdentityTotNgiep.AddClaim(emailClaim);
            claimsIdentityTotNgiep.AddClaim(mssvClaim);

            var claimPrincipal = new ClaimsPrincipal();
            claimPrincipal.AddIdentity(claimsIdentityBlx);
            claimPrincipal.AddIdentity(claimsIdentityTotNgiep);

            //dasdsadasdasdsad

            return Redirect("/home");
        }
    }
}