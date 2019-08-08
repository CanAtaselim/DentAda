using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Web.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DentAda.Web.Areas.Main.Controllers
{
    [Area("Main")]
    public class GalleryController : BaseController
    {
        private IMemoryCache _memoryCache;
        private AdministrationBLLocator _adminlocator;
        private IHostingEnvironment _env;
        public GalleryController(AdministrationBLLocator adminLocator, IMemoryCache memoryCache, IHostingEnvironment env) : base(env)
        {
            _env = env;
            _memoryCache = memoryCache;
            _adminlocator = adminLocator;
        }
        [ContactUsAttribute]
        public IActionResult Index()
        {
            ViewBag.ContactUs = JsonConvert.DeserializeObject<ContactUsVM>(HttpContext.Session.GetString("ContactUsData"));

            GalleryVM galleryVM = new GalleryVM();
            galleryVM.GalleryList = new List<GalleryItem>();
            galleryVM.GalleryList.AddRange(GetImageList("cayyolu"));
            galleryVM.GalleryList.AddRange(GetImageList("polatli"));

            return View(galleryVM);
        }

        private List<GalleryItem> GetImageList(string departmentName)
        {
            string thumbnailDirectory = Path.Combine(_env.WebRootPath, "images\\gallery\\" + departmentName + "\\thumbnail");
            DirectoryInfo di = new DirectoryInfo(thumbnailDirectory);
            List<GalleryItem> galleryList = new List<GalleryItem>();
            if (di.Exists)
            {
                FileInfo[] rgFiles = di.GetFiles("*.jpg");
                GalleryItem gallery = null;
                foreach (FileInfo item in rgFiles.OrderByDescending(x => x.LastWriteTime))
                {
                    gallery = new GalleryItem();
                    gallery.FileName = item.Name;
                    gallery.FilePath = Path.Combine(_env.WebRootPath, "images\\gallery\\" + departmentName);
                    gallery.DepartmentName = departmentName;

                    galleryList.Add(gallery);
                }

            }
            return galleryList;
        }
    }
}