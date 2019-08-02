using DentAda.Business.BusinessLogic.Locator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentAda.Web.Areas.Admin.ViewComponents.ContactUs
{
    public class ContactUsEdit : ViewComponent
    {
        private AdministrationBLLocator _administrationBLLocator;
        public ContactUsEdit(AdministrationBLLocator administrationBLLocator)
        {
            _administrationBLLocator = administrationBLLocator;
        }

        public Task<IViewComponentResult> InvokeAsync(int Department)
        {
            return Task.FromResult<IViewComponentResult>(View());
        }

    }
}
