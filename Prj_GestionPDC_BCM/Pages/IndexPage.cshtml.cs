﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Prj_GestionPDC_BCM.Code;

 namespace Prj_GestionPDC_BCM
{
    public class IndexPageModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        [BindProperty]
        public bool V_pais { get => v_pais; set => v_pais = value; }
        [BindProperty]
        public bool V_depto { get => v_depto; set => v_depto = value; }
        [BindProperty]
        public bool V_ciudad { get => v_ciudad; set => v_ciudad = value; }

        private bool v_pais;
        private bool v_depto;
        private bool v_ciudad;


        public IndexPageModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            V_pais = Utilidades.TienePermisos(_session.GetString("Permissions"), "V_PAIS");
            V_depto = Utilidades.TienePermisos(_session.GetString("Permissions"), "V_DEPTO");
            V_ciudad = Utilidades.TienePermisos(_session.GetString("Permissions"), "V_CIUDAD");
        }

        
    }
}
