﻿using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Web.WebCommon;
using Microsoft.AspNetCore.Mvc;
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

        public Task<IViewComponentResult> InvokeAsync(int Department = (int)_Enumeration._Department.Cayyolu)
        {
            ViewBag.DepartmentList = HttpInfo.DepartmentList;

            ContactUsVM contactUs = new ContactUsVM();
            if (Department > 0)
            {
                contactUs = _administrationBLLocator.ContactUsBL.GetVM(filter: m => m.Department == Department && m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, orderBy: o => o.OrderBy(x => x.Department)).FirstOrDefault();
            }
            else
            {
                contactUs = _administrationBLLocator.ContactUsBL.GetVM(filter: m => m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, orderBy: o => o.OrderBy(x => x.Department)).FirstOrDefault();
            }

            return Task.FromResult<IViewComponentResult>(View(contactUs ?? new ContactUsVM()));
        }

    }
}