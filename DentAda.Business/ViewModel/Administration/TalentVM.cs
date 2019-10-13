﻿

using DentAda.Business.ViewModel.Base;
using System.ComponentModel.DataAnnotations;

namespace DentAda.Business.ViewModel.Administration
{
    public class TalentVM : BaseVM
    {
        public long IdTalent { get; set; }
        [Required(ErrorMessage = "Başık Zorunlu")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama Zorunlu")]
        public string Description { get; set; }
    }
}
