using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Web.WebCommon;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DentAda.Web.Areas.Admin.ViewComponents.Gallery
{
    public class GalleryList : ViewComponent
    {
        private IHostingEnvironment _env;


        public GalleryList(IHostingEnvironment env)
        {
            _env = env;
        }

        public Task<IViewComponentResult> InvokeAsync(int Department = (int)_Enumeration._Department.Cayyolu)
        {
            ViewBag.DepartmentList = HttpInfo.DepartmentList;

            string departmentName = Department == 1 ? "cayyolu" : "polatli";
            string thumbnailDirectory = Path.Combine(_env.WebRootPath, "images\\gallery\\" + departmentName + "\\thumbnail");
            DirectoryInfo di = new DirectoryInfo(thumbnailDirectory);
            GalleryVM galleryVM = new GalleryVM();
            galleryVM.GalleryList = new List<GalleryItem>();
            galleryVM.Department = 1;
            if (di.Exists)
            {
                FileInfo[] rgFiles = di.GetFiles("*.jpg");
                GalleryItem gallery = null;
                foreach (FileInfo item in rgFiles.OrderByDescending(x => x.LastWriteTime))
                {
                    gallery = new GalleryItem();
                    gallery.FileName = item.Name;
                    gallery.FilePath = Path.Combine(_env.WebRootPath, "images\\gallery\\" + departmentName);

                    galleryVM.GalleryList.Add(gallery);
                }

            }
            return Task.FromResult<IViewComponentResult>(View(galleryVM));
        }
    }
}
