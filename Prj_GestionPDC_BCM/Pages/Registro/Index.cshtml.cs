using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Prj_GestionPDC_BCM.Data;
using Prj_GestionPDC_BCM.Entities;

namespace Prj_GestionPDC_BCM.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Prj_GestionPDC_BCM.Data.TiendaOnlineContext _context;

        public IndexModel(Prj_GestionPDC_BCM.Data.TiendaOnlineContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuario { get;set; }

        public async Task OnGetAsync()
        {
            Usuario = await _context.Usuario.ToListAsync();
        }
    }
}
