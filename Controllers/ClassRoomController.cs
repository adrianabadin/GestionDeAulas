﻿using Microsoft.AspNetCore.Mvc;

namespace GestionDeAulas.Controllers
{
    public class ClassRoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() { return View(); }
        public IActionResult Edit() {  return View(); }
        public IActionResult Delete() { return View(); }
    }
}
