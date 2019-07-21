using DentAda.Business.ViewModel.Base;
using DentAda.Data.Model;
using System;

namespace DentAda.Business.ViewModel.Administration
{
    public class PersonVM : BaseVM
    {
        public long IdPerson { get; set; }
        public Nullable<long> IdUniversity { get; set; }
        public Nullable<long> IdFaculty { get; set; }
        public Nullable<long> IdUniversityDepartment { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Profession { get; set; }
        public string Phone { get; set; }
        public string Gsm { get; set; }
        public string About { get; set; }
        public byte[] Picture { get; set; }
        public short Department { get; set; }

    }
}
