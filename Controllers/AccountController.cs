using GestionDeAulas.Models;
using GestionDeAulas.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeAulas.Controllers
{
    public class AccountController : Controller
    {
        UserManager<User> UserManager;
        private IPasswordHasher<User> _hasher;
        private RoleManager<IdentityRole> _role;
        private UsersService _usersService;
        public AccountController(UserManager<User> _userManager,IPasswordHasher<User> hasher, RoleManager<IdentityRole> role,UsersService usersService)


        {this._usersService = usersService;
            this.UserManager = _userManager;
            this._hasher = hasher;
            _role = role;
        }
        public IActionResult Delete(int? id) {
           // if (id == null) return NotFound();
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User usuario) {
            if (ModelState.IsValid) {
                usuario.UserName = usuario.Email;
                usuario.PasswordHash = _hasher.HashPassword(usuario,usuario.Password);
                var data = await UserManager.CreateAsync(usuario);
                return View("Index", "Home");
            
            }
            return View();
        }
        public IActionResult Edit() {
            return View();
        }
        public async Task< IActionResult> Index() {
            var response = await _usersService.List();
            foreach(var usuario in response)
            {
                var respuesta = await UserManager.GetRolesAsync(usuario);
                usuario.Role = string.Join(",",respuesta);
            }
            return View(response); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(string role) {
            var response = await _role.CreateAsync(new IdentityRole(role)) ;
            return Ok();
        }
    }
}
