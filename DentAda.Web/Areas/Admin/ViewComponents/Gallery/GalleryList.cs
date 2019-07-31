using DentAda.Business.BusinessLogic.Locator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentAda.Web.Areas.Admin.ViewComponents.Gallery
{
    public class GalleryList : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View());
        }
    }
}
