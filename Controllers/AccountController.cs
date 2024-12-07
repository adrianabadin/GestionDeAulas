using GestionDeAulas.Models;
using GestionDeAulas.Models.ViewModels.Account;
using GestionDeAulas.Repository;
using GestionDeAulas.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GestionDeAulas.Controllers
{
    public class AccountController : Controller
    {
        UserManager<User> UserManager;
        private SignInManager<User> _SignInManager;
        private IPasswordHasher<User> _hasher;
        private RoleManager<IdentityRole> _role;
        private UsersService _usersService;
        private UnidadContenedora _Container;
        public AccountController
            (UserManager<User> _userManager,
            IPasswordHasher<User> hasher,
            RoleManager<IdentityRole> role,
            UsersService usersService,
            SignInManager<User> SignInManager,UnidadContenedora Container
            )


        {
            _Container= Container;
            this._SignInManager = SignInManager;
            this._usersService = usersService;
            this.UserManager = _userManager;
            this._hasher = hasher;
            _role = role;
        }
        public async Task<IActionResult> Activate(string? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));
            var user = await UserManager.FindByIdAsync(id);
            if (user == null) return RedirectToAction(nameof(Index));
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Activate(User user)
        {
            if (user == null) return RedirectToAction(nameof(Index));
            var response = await _usersService.Activate(user);
            if (!response) return View(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(User user) {
            var response = await _usersService.Delete(user);
            if (response) return RedirectToAction("Index");
            return View(user.Id);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string? id) {
           if (id == null) return RedirectToAction(nameof(Index));
            var user = await UserManager.FindByIdAsync(id);
            if (user == null) return RedirectToAction(nameof(Index));
            return View(user);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Credentials user)
        {
            var response = await UserManager.FindByEmailAsync(user.UserName);
            if (response == null) return View();
            var data= await _SignInManager.PasswordSignInAsync(response, user.Password,user.Persist,true);
            if (data.Succeeded) return RedirectToAction("Index","Home");
            return View(user);


        }
        public IActionResult Login() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM usuario) {
            if (ModelState.IsValid) {
                var newUser = new User() {
                    UserName=usuario.UserName,
                    LastName=usuario.LastName,
                    PhoneNumber=usuario.PhoneNumber, 
                    IsActive=true,
                    Dni=usuario.Dni,
                    Email=usuario.UserName,
                    FirstName=usuario.FirstName, 
                    EmployeeCode=usuario.EmployeeCode
                };
                newUser.PasswordHash = _hasher.HashPassword(newUser,usuario.Password ??"");
                var data = await UserManager.CreateAsync(newUser);
                
                foreach (var rol in usuario.Role)
                {
                   
                   await UserManager.AddToRoleAsync(newUser,rol);
                }
                return RedirectToAction("Index","Account");
            
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserUpdateVM user)
        {if (ModelState.IsValid)
            {
                var usuarioActual = await UserManager.FindByIdAsync(user.Id);
                if (usuarioActual == null) { return View(user); }
                usuarioActual.PhoneNumber = user.PhoneNumber;
                usuarioActual.UserName = user.UserName;
                usuarioActual.LastName = user.LastName;
                usuarioActual.FirstName=user.FirstName;
                usuarioActual.Dni=user.Dni;
                usuarioActual.Email = user.UserName;
                usuarioActual.EmployeeCode = user.EmployeeCode;
                foreach (var rol in user.Role)
                {
                    await UserManager.AddToRoleAsync(usuarioActual, rol);
                }
                
                if (user.Password != null && user.Password2 != null)
                {
                    usuarioActual.PasswordHash = _hasher.HashPassword(usuarioActual,user.Password);

                }             
                var response = await UserManager.UpdateAsync(usuarioActual);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
            
        }
        public async Task<IActionResult> Edit(string? Id) {
            if (Id == null) return View();
            var response = await UserManager.FindByIdAsync(Id);
            if (response != null) { 
            var newEditableUser = new UserUpdateVM
            {
                Id = Id,
                FirstName = response.FirstName,
                LastName = response.LastName,
                Dni = response.Dni,
                EmployeeCode = response.EmployeeCode,
                IsActive = response.IsActive,
                PhoneNumber = response.PhoneNumber,
                UserName = response.UserName,
                
            };
                newEditableUser.Role = (List<string>)(await UserManager.GetRolesAsync(response));
                return View(newEditableUser);
        }
            else return NotFound();
            
        }
        public async Task< IActionResult> Index() {

            //var response = await .List(null,null,"MyUserRole");
            var otra = await _Container._users.List(null,null,"MyUserRoles");
            var response = new List<UserUpdateVM>();
            foreach(var usuario in otra)
            {
                var temporal = new UserUpdateVM() {
                Dni=usuario.Dni,
                EmployeeCode=usuario.EmployeeCode,
                FirstName=usuario.FirstName,
                IsActive=usuario.IsActive,
                LastName = usuario.LastName,
                PhoneNumber=usuario.PhoneNumber,
                UserName=usuario.UserName,
                Id = usuario.Id,
                Role= (List<string>)await UserManager.GetRolesAsync(usuario)
                };
                //var respuesta = await UserManager.GetRolesAsync(usuario);
                response.Add(temporal);
                //usuario.Role = (List<string>)await UserManager.GetRolesAsync(usuario); //string.Join(",",respuesta);
            }
            return View(response); }
        [HttpGet]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(string role) {
            var response = await _role.CreateAsync(new IdentityRole(role)) ;
            return Ok();
        }
    }
}
