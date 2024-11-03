using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace UserActivityWeb.Models.ViewModel
{
    public class UsersVM
    {
        public IEnumerable<SelectListItem> StatusList { get; set; }    
        public User User { get; set; }  
    }
}
