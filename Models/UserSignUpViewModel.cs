using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Kullanıcı Adı:")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }

        [Display(Name ="Parola Adı:")]
        [Required(ErrorMessage = "Parola alanı boş geçilemez")]
        public string Password { get; set; }

        [Display(Name ="Parola tekrar Adı:")]
        [Compare("Password", ErrorMessage ="Parolalar eşleşmiyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Ad:")]
        [Required(ErrorMessage = "Ad  alanı boş geçilemez")]
        public string Name { get; set; }

        [Display(Name ="Soyad Adı:")]
        [Required(ErrorMessage = "Soyad  alanı boş geçilemez")]
        public string SurName { get; set; }

        [Display(Name ="Email:")]
        [Required(ErrorMessage = "Email  alanı boş geçilemez")]
        public string Email { get; set; }
    }
}
