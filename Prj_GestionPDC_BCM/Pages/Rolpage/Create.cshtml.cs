using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prj_GestionPDC_BCM.Data;
using Prj_GestionPDC_BCM.Entities;

namespace Prj_GestionPDC_BCM.Pages.Rolpage
{
    public class CreateModel : PageModel
    {
        private readonly Prj_GestionPDC_BCM.Data.TiendaOnlineContext _context;

        public CreateModel(Prj_GestionPDC_BCM.Data.TiendaOnlineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RolId"] = new SelectList(_context.Rol, "Id", "Nombre");
        ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Apellido");
            return Page();
        }

        [BindProperty]
        public RolUsuario RolUsuario { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RolUsuario.Add(RolUsuario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
