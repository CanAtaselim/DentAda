using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentAda.Web.Areas.Admin.ViewComponents.Talent
{
    public class TalentList : ViewComponent
    {
        private AdministrationBLLocator _administrationBLLocator;
        public TalentList(AdministrationBLLocator administrationBLLocator)
        {
            _administrationBLLocator = administrationBLLocator;
        }


        public Task<IViewComponentResult> InvokeAsync()
        {
            List<TalentVM> talent = _administrationBLLocator.TalentBL.GetVM(filter: m => m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active);
            return Task.FromResult<IViewComponentResult>(View(talent ?? new List<TalentVM>()));
        }
    }
}
