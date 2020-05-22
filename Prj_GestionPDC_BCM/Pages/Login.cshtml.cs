using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Prj_GestionPDC_BCM.Code;
using Prj_GestionPDC_BCM.Entities;



namespace Prj_GestionPDC_BCM
{
    public class LoginModel : PageModel
    {

        Login login_pg;       
        [BindProperty]
        public Login Login_pg { get => login_pg; set => login_pg = value; }

        private readonly Prj_GestionPDC_BCM.Data.TiendaOnlineContext _context;
        public LoginModel(Prj_GestionPDC_BCM.Data.TiendaOnlineContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var loginInfo = _context.RolUsuario
                    .Include(S => S.Rol)
                    .Include(S => S.Usuario)
                    .Where(s => s.Usuario.Usuario1.ToUpper() == Login_pg.Username.ToUpper().Trim() && s.Usuario.Password == Login_pg.Password).ToList();
                
                if (loginInfo != null && loginInfo.Count() > 0)
                {
                    var logindetails = loginInfo.First();
                    
                    int rolid = logindetails.Rol.Id;

                    var lstpermissions = _context.PermisosRol.Where(s => s.RolId == rolid).ToList();

                    string strpermissions = string.Empty;
                    foreach (var perm in lstpermissions)
                    {
                        if (perm.Active==1)
                        {
                            strpermissions += perm.CodigoFuncion+",";
                        }
                    }

                    await this.SignInUser(Login_pg.Username, false);
                    HttpContext.Session.SetString("UserName", logindetails.Usuario.Usuario1);
                    HttpContext.Session.SetString("RolName", logindetails.Rol.Nombre);
                    HttpContext.Session.SetString("Permissions", strpermissions);
                    //_session.SetString("Permissions", strpermissions);
                    return this.RedirectToPage("/IndexPage");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }

            return this.Page();
        }

        private async Task SignInUser(string username, bool isPersistent)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, username));
            var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(claimIdenties);
            var authenticationManager = Request.HttpContext;
            var AuthProp = new AuthenticationProperties { IsPersistent = isPersistent };
            await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, AuthProp);
            
        }
    }

 
}