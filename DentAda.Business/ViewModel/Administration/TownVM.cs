﻿using DentAda.Business.ViewModel.Base;

namespace DentAda.Business.ViewModel.Administration
{
    public class TownVM : BaseVM
    {
        public long IdTown { get; set; }
        public int? TownCode { get; set; }
        public string TownName { get; set; }
        public string RoleCode { get; set; }
    }
}
