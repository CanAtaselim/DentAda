using DentAda.Business.BusinessLogic.Locator;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DentAda.Web.Areas.Admin.ViewComponents.AboutUs
{
    public class EditViewComponent : ViewComponent
    {
        private AdministrationBLLocator _administrationBLLocator;
        public EditViewComponent(AdministrationBLLocator administrationBLLocator)
        {
            _administrationBLLocator = administrationBLLocator;
        }

        public IViewComponentResult Invoke()
        {          
            return View();
        }

    }
}
