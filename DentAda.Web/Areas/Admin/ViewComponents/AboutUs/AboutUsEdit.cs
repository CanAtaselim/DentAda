﻿using DentAda.Business.BusinessLogic.Locator;
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


        public Task<IViewComponentResult> InvokeAsync()
        {

            AboutUsVM aboutUs = new AboutUsVM();

            aboutUs = _administrationBLLocator.AboutUsBL.GetVM(filter: m => m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active).FirstOrDefault();


            return Task.FromResult<IViewComponentResult>(View(aboutUs ?? new AboutUsVM()));
        }

    }
}
