using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentAda.Data.DataCommon;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using DentAda.Web.WebCommon;

namespace DentAda.Web
{
    public class BaseController : Controller
    {
        private IHostingEnvironment _env;
        public BaseController(IHostingEnvironment env = null)
        {
            _env = env;
        }

        public HttpRequestInfo HttpRequestInfo
        {
            get { return HttpInfo.GetRequestInfo(HttpContext); }
        }

        public new RedirectToRouteResult RedirectToAction(string action, string controller)
        {
            return RedirectToAction(action, controller);
        }


        public static object GetPropValue(object src, string propName)
        {
            if (src.GetType().GetProperty(propName).GetValue(src, null) == null)
                return "";
            return src.GetType().GetProperty(propName).GetValue(src, null).ToString();
        }
    }
}