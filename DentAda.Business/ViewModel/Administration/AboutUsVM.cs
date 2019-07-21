using DentAda.Business.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentAda.Business.ViewModel.Administration
{
    public class AboutUsVM : BaseVM
    {
        public long IdAboutUs { get; set; }
        public short Department { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

    }
}
