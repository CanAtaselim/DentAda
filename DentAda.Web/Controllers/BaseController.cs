using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using DentAda.Data.Repository;
using DentAda.Web.WebCommon;
using DentAda.Data.DataCommon;

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