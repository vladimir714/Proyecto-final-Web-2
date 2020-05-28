using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Prj_GestionPDC_BCM.Data;
using Prj_GestionPDC_BCM.Entities;

namespace Prj_GestionPDC_BCM.Pages.ProductoPage
{
    public class IndexModel : PageModel
    {
        private readonly Prj_GestionPDC_BCM.Data.TiendaOnlineContext _context;

        public IndexModel(Prj_GestionPDC_BCM.Data.TiendaOnlineContext context)
        {
            _context = context;
        }

        public IList<Producto> Producto { get;set; }

        public async Task OnGetAsync()
        {
            Producto = await _context.Producto.ToListAsync();
        }
    }
}
