using DentAda.Business.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentAda.Business.ViewModel.Administration
{
    public class ContactUsVM : BaseVM
    {
        public long IdContactUs { get; set; }
        [Required(ErrorMessage = "Lütfen Şube Seçiniz.")]
        public short Department { get; set; }

        [Required(ErrorMessage = "Lütfen Adres Giriniz.")]
        [MaxLength(500, ErrorMessage = "Adres 500 karakterden fazla olamaz")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Lütfen E-Posta Giriniz.")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(40, ErrorMessage = "E-Posta 40 karakterden fazla olamaz")]
        [EmailAddress(ErrorMessage = "Geçerli bir E-Posta giriniz. Örnek: info@dentada.com.tr")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Telefon Giriniz.")]
        [RegularExpression(@"^\(?([0-9]{4} )\)?[-. ]?([0-9]{3} )[-. ]?([0-9]{2} )[-. ]?([0-9]{2})$", ErrorMessage = "Geçerli bir telefon giriniz. Örnek: 0399 123 45 67")]
        public string Phone { get; set; }

        [RegularExpression(@"^\(?([0-9]{4} )\)?[-. ]?([0-9]{3} )[-. ]?([0-9]{2} )[-. ]?([0-9]{2})$", ErrorMessage = "Geçerli bir telefon giriniz. Örnek: 0500 123 45 67")]
        public string GSM { get; set; }

        [RegularExpression(@"^\(?([0-9]{4} )\)?[-. ]?([0-9]{3} )[-. ]?([0-9]{2} )[-. ]?([0-9]{2})$", ErrorMessage = "Geçerli bir telefon giriniz. Örnek: 0399 123 45 67")]
        public string Fax { get; set; }

        [MaxLength(70, ErrorMessage = "Facebook 70 karakterden fazla olamaz")]
        public string Facebook { get; set; }

        [MaxLength(30, ErrorMessage = "Twitter 30 karakterden fazla olamaz")]
        public string Twitter { get; set; }

        [MaxLength(30, ErrorMessage = "Instagram 30 karakterden fazla olamaz")]
        public string Instagram { get; set; }

        [MaxLength(70, ErrorMessage = "Youtube 70 karakterden fazla olamaz")]
        public string Youtube { get; set; }

        [MaxLength(70, ErrorMessage = "Linkedin 70 karakterden fazla olamaz")]
        public string Linkedin { get; set; }

        [MaxLength(70, ErrorMessage = "Google+ 70 karakterden fazla olamaz")]
        public string GooglePlus { get; set; }

    }
}
