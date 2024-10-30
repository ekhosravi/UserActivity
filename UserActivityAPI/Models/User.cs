using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserActivityAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }


        public enum Roles { Admin, User, Moderator }
        public  Roles Role{ get; set; }


        [Required]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }


        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }

    }
}
