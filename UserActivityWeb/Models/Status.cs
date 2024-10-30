using System.ComponentModel.DataAnnotations;

namespace UserActivityWeb.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        [Required]
        public string StatusName { get; set; }
    }
}
