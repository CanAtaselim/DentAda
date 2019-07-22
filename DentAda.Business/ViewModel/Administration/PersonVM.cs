using DentAda.Business.ViewModel.Base;
using DentAda.Data.Model;
using System;
using System.ComponentModel.DataAnnotations;
using static DentAda.Common._Enumeration;

namespace DentAda.Business.ViewModel.Administration
{
    public class PersonVM : BaseVM
    {
        public long IdPerson { get; set; }
        public Nullable<long> IdUniversity { get; set; }
        public Nullable<long> IdFaculty { get; set; }
        public Nullable<long> IdUniversityDepartment { get; set; }
        [Required(ErrorMessage = "Çalışan tipi zorunlu.")]
        public short EmployeeType { get; set; }
        [Required(ErrorMessage = "Şube zorunlu.")]
        public short Department { get; set; }
        [Required(ErrorMessage = "Ad zorunlu.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad zorunlu.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Unvan zorunlu.")]
        public string Title { get; set; }
        public string Profession { get; set; }
        public string Phone { get; set; }
        public string Gsm { get; set; }
        public string About { get; set; }
        public byte[] Picture { get; set; }
        public string UniversityName { get; set; }
        public string FacultyName { get; set; }
        public string UniversityDepartmentName { get; set; }

    }
}
