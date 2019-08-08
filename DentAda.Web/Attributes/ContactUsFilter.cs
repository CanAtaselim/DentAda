using DentAda.Business.BusinessLogic.Locator;
using DentAda.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DentAda.Web.WebCommon;
using Microsoft.AspNetCore.Authentication.Cookies;
using DentAda.Common;
using DentAda.Business.ViewModel.Administration;

namespace DentAda.Web.Attributes
{
    public class ContactUsAttribute : Attribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                AdministrationBLLocator _locator = new AdministrationBLLocator();
                if (filterContext.HttpContext.Session.GetString("ContactUsData") == null)
                {
                    ContactUsVM contactUs = _locator.ContactUsBL.GetVM(filter: m => m.Department == (short)_Enumeration._Department.Cayyolu && m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active).FirstOrDefault();
                    filterContext.HttpContext.Session.SetString("ContactUsData", JsonConvert.SerializeObject(contactUs));
                }

            }
            catch (System.Exception ex)
            {

            }

        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}
