using System.ComponentModel.DataAnnotations;

namespace BilgeShop.WebUI.Models
{
    public class RegisterViewModel
    {
        [Display(Name ="Ad")]
        [MaxLength(25, ErrorMessage ="isim maximum 25 karakter uzunlugunda olabilir")]
        [Required(ErrorMessage ="Ad alanı boş bırakılamaz")]
        public string FirstName { get; set; }


        [Display(Name = "Soyad")]
        [MaxLength(25, ErrorMessage = "soyisim  maximum 25 karakter uzunlugunda olabilir")]
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz")]
        public string LastName { get; set; }



        [Display(Name = "Eposta ")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz")]
        public string Email { get; set; }



        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Sifre alanı boş bırakılamaz")]
        public string Password { get; set; }


        [Display(Name = "Şifre Tekrarı")]
        [Required(ErrorMessage = "Sifre tekrar alanı boş bırakılamaz")]
        [Compare(nameof(Password),ErrorMessage ="Şifreler eşleşmiyor")]
        public string PasswordConfirm { get; set; }
    }
}
