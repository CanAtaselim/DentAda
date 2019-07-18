using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DentAda.Web.Areas.Admin.ViewComponents.AboutUs
{
    public class EditViewComponent : ViewComponent
    {
        private AdministrationBLLocator _administrationBLLocator;
        public EditViewComponent(AdministrationBLLocator administrationBLLocator)
        {
            _administrationBLLocator = administrationBLLocator;
        }


        public Task<IViewComponentResult> InvokeAsync(int department)
        {
            AboutUsVM aboutUs = new AboutUsVM();
            if (department > 0)
            {
                aboutUs = _administrationBLLocator.AboutUsBL.GetVM(filter: m => m.Department == department && m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, orderBy: o => o.OrderBy(x => x.Department)).FirstOrDefault();
            }
            else
            {
                aboutUs = _administrationBLLocator.AboutUsBL.GetVM(filter: m => m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, orderBy: o => o.OrderBy(x => x.Department)).FirstOrDefault();
            }

            return Task.FromResult<IViewComponentResult>(View(aboutUs ?? new AboutUsVM()));
        }

    }
}
