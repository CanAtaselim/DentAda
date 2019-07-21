using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DentAda.Web.Areas.Admin.ViewComponents.Person
{
    public class PersonEdit : ViewComponent
    {
        private AdministrationBLLocator _administrationBLLocator;
        public PersonEdit(AdministrationBLLocator administrationBLLocator)
        {
            _administrationBLLocator = administrationBLLocator;
        }


        public Task<IViewComponentResult> InvokeAsync(int department)
        {
            PersonVM person = new PersonVM();

            person = _administrationBLLocator.PersonBL.GetVM(filter: m => m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, orderBy: o => o.OrderBy(x => x.Department)).FirstOrDefault();

            return Task.FromResult<IViewComponentResult>(View(person ?? new PersonVM()));
        }

    }
}
