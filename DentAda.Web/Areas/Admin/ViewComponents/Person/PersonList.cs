using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentAda.Web.Areas.Admin.ViewComponents.Person
{
    public class PersonList : ViewComponent
    {
        private AdministrationBLLocator _administrationBLLocator;
        public PersonList(AdministrationBLLocator administrationBLLocator)
        {
            _administrationBLLocator = administrationBLLocator;
        }


        public Task<IViewComponentResult> InvokeAsync()
        {
            List<PersonVM> person = _administrationBLLocator.PersonBL.GetVM(filter: m => m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active);
            return Task.FromResult<IViewComponentResult>(View(person ?? new List<PersonVM>()));
        }
    }
}
