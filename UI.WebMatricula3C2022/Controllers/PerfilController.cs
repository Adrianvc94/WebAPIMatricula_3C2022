﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.WebMatricula3C2022.Logica;

namespace UI.WebMatricula3C2022.Controllers
{
    public class PerfilController : Controller
    {
        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            return View(usuarioActual);
        }
    }
}
