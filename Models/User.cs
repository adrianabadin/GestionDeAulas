using GestionDeAulas.Models.IModel;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace GestionDeAulas.Models
{
  
    public class User : IdentityUser, IActivable
    {
        
        public virtual ICollection<IdentityUserRole<string>>? MyUserRoles {get;set;} 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmployeeCode { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        override public string? PhoneNumber { get; set; }
        public bool? IsActive { get; set; } = true;
    }
}

