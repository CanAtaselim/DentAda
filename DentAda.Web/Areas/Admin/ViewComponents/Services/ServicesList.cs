using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentAda.Web.Areas.Admin.ViewComponents.Services
{
    public class ServicesList : ViewComponent
    {
        private AdministrationBLLocator _administrationBLLocator;
        public ServicesList(AdministrationBLLocator administrationBLLocator)
        {
            _administrationBLLocator = administrationBLLocator;
        }


        public Task<IViewComponentResult> InvokeAsync()
        {
            List<ServicesVM> services = _administrationBLLocator.ServicesBL.GetVM(filter: m => m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active);
            return Task.FromResult<IViewComponentResult>(View(services ?? new List<ServicesVM>()));
        }
    }
}
