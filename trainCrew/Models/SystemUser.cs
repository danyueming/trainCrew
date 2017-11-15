using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trainCrew.Models
{
    public class SystemUser
    {
        
        public int ID { get; set; }
        [Required]
        [Display(Name = "用户名")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "密码")]
        public string Password { get; set; }

    }
}