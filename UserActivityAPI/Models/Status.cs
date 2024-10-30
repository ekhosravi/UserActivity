using System.ComponentModel.DataAnnotations;

namespace UserActivityAPI.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        public string StatusName { get; set; }
    }
}
