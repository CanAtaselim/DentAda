﻿using DentAda.Business.ViewModel.Base;
using DentAda.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static DentAda.Common._Enumeration;

namespace DentAda.Business.ViewModel.Administration
{
    public class PersonVM : BaseVM
    {
        public long IdPerson { get; set; }
        [Required(ErrorMessage = "Çalışan tipi zorunlu.")]
        public short EmployeeType { get; set; }
        [Required(ErrorMessage = "Şube zorunlu.")]
        public short Department { get; set; }
        [Required(ErrorMessage = "Ad zorunlu.")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad zorunlu.")]
        [MaxLength(20)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Unvan zorunlu.")]
        [MaxLength(40)]
        public string Title { get; set; }
        [MaxLength(40)]
        public string Profession { get; set; }
        [RegularExpression(@"^\(?([0-9]{4} )\)?[-. ]?([0-9]{3} )[-. ]?([0-9]{2} )[-. ]?([0-9]{2})$", ErrorMessage = "Geçerli bir telefon giriniz. Örnek: 0399 123 45 67")]
        public string Phone { get; set; }
        [RegularExpression(@"^\(?([0-9]{4} )\)?[-. ]?([0-9]{3} )[-. ]?([0-9]{2} )[-. ]?([0-9]{2})$", ErrorMessage = "Geçerli bir telefon giriniz. Örnek: 0500 123 45 67")]
        public string Gsm { get; set; }
        public string About { get; set; }
        public byte[] Picture { get; set; }
        public List<string> EmployeeTypeList { get; set; }
        public string Employees { get; set; }
        public List<string> DepartmentList { get; set; }
        public string Departments { get; set; }

    }
}
