using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserActivityWeb.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
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
