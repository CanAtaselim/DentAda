using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Web.WebCommon;
using Microsoft.AspNetCore.Mvc;
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


        public Task<IViewComponentResult> InvokeAsync(int Department = (int)_Enumeration._Department.Cayyolu)
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
