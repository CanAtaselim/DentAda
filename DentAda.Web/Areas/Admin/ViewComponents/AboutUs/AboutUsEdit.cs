using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Data.DataCommon;
using DentAda.Web.WebCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentAda.Web.Areas.Admin.ViewComponents.AboutUs
{
    public class AboutUsEdit : ViewComponent
    {
        private AdministrationBLLocator _administrationBLLocator;
        public AboutUsEdit(AdministrationBLLocator administrationBLLocator)
        {
            _administrationBLLocator = administrationBLLocator;
        }


        public Task<IViewComponentResult> InvokeAsync(int Department)
        {
            ViewBag.DepartmentList = HttpInfo.DepartmentList;

            AboutUsVM aboutUs = new AboutUsVM();
            if (Department > 0)
            {
                aboutUs = _administrationBLLocator.AboutUsBL.GetVM(filter: m => m.Department == Department && m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, orderBy: o => o.OrderBy(x => x.Department)).FirstOrDefault();
            }
            else
            {
                aboutUs = _administrationBLLocator.AboutUsBL.GetVM(filter: m => m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, orderBy: o => o.OrderBy(x => x.Department)).FirstOrDefault();
            }

            return Task.FromResult<IViewComponentResult>(View(aboutUs ?? new AboutUsVM()));
        }

    }
}
