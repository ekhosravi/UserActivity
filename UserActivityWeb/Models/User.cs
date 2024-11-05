using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UserActivityWeb.Models
{
    public class User : IdentityUser
    {
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }


        public enum Roles { Admin, User, Moderator }
        public Roles Role { get; set; }


        public int StatusId { get; set; }
        public Status Status { get; set; }


        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
