﻿

using DentAda.Business.ViewModel.Base;

namespace DentAda.Business.ViewModel.Administration
{
    public class CityVM : BaseVM
    {
        public long IdCity { get; set; }
        public int? CityCode { get; set; }
        public string CityName { get; set; }
        public string RoleCode { get; set; }
    }
}
