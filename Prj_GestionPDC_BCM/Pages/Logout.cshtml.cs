using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prj_GestionPDC_BCM
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPost()
        {
            var authenticationManager = Request.HttpContext;
            await authenticationManager.SignOutAsync();
            return LocalRedirect("/Login");
            
        }
    }
}