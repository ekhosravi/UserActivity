using System.ComponentModel.DataAnnotations;
using static UserActivityAPI.Models.User;

namespace UserActivityAPI.Models.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }

        public  Roles Role{ get; set; }


        [Required]
        public int StatusId { get; set; }


        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }

    }
}
