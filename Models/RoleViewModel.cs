using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Ad Alanı boş geçilemez")]
        [Display(Name = "Ad:")]
        public string Name { get; set; }
    }
}
