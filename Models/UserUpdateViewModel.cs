using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Models
{
    public class UserUpdateViewModel
    {
        [Required(ErrorMessage = "Email  alanı boş geçilemez")] 
        [EmailAddress(ErrorMessage = "Geçerli bir format giriniz.")] 
        [Display(Name ="Email:")]
        public string Email { get; set; }

        [Display(Name ="Telefon Numarası:")]
        public string PhoneNumber { get; set; }

        public string PictureUrl { get; set; }

        public IFormFile Picture { get; set; }



        [Required(ErrorMessage = "Name  alanı boş geçilemez")]
        [Display(Name ="İsim:")]
        public string Name { get; set; }

        [Display(Name ="Soyisim:")]
        public string SurName { get; set; }

    }
}
