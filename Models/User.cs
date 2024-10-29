using Microsoft.AspNetCore.Identity;

namespace GestionDeAulas.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmployeeCode { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;

    }
}
