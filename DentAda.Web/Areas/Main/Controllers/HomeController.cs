using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Web.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Linq;

namespace DentAda.Web.Areas.Main.Controllers
{
    [Area("Main")]
    public class HomeController : Controller
    {
        private IMemoryCache _memoryCache;
        private AdministrationBLLocator _adminlocator;
        public HomeController(AdministrationBLLocator adminLocator, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _adminlocator = adminLocator;
        }

        [ContactUsAttribute]
        public IActionResult Index()
        {

            ViewBag.ContactUs = JsonConvert.DeserializeObject<ContactUsVM>(HttpContext.Session.GetString("ContactUsData"));
            return View();
        }
    }
}