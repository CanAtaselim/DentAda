using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DentAda.Business.BusinessLogic.Locator;
using DentAda.Web.Attributes;
using DentAda.Web.WebCommon;
using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentAda.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = new string[] { "SYSTEM_ADMIN", "ADMIN" })]
    public class GalleryController : BaseController
    {
        private AdministrationBLLocator _administrationBLLocator;
        private IHostingEnvironment _env;


        public GalleryController(AdministrationBLLocator administrationBLLocator, IHostingEnvironment env) : base(env)
        {
            _administrationBLLocator = administrationBLLocator;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save()
        {
            AjaxMessage aMsg = new AjaxMessage();
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                var totalFileSize = 20 * 1024 * 1024;
                if (files.Sum(m => m.Length) > totalFileSize)
                {
                    return View();
                }


                string originalDirectory = Path.Combine(_env.WebRootPath, "images\\gallery\\cayyolu\\original");
                string thumbnailDirectory = Path.Combine(_env.WebRootPath, "images\\gallery\\cayyolu\\thumbnail");
                if (!Directory.Exists(originalDirectory))
                {
                    Directory.CreateDirectory(originalDirectory);
                }
                if (!Directory.Exists(thumbnailDirectory))
                {
                    Directory.CreateDirectory(thumbnailDirectory);
                }
                foreach (IFormFile image in files)
                {
                    int fileSizeLimit = 2 * 1024 * 1024;
                    if (image.Length < fileSizeLimit)
                    {
                        string imageName = Guid.NewGuid().ToString();
                        string imageExtension = Path.GetExtension(image.FileName);

                        try
                        {
                            using (FileStream fileStream = new FileStream(Path.Combine(originalDirectory, imageName + imageExtension), FileMode.Create))
                            {
                                await image.CopyToAsync(fileStream);
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            COnvertThumbnail(thumbnailDirectory, image, imageName, imageExtension);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                aMsg.Status = 1;
                aMsg.Message = "Fotoğraf ekleme işlemi başarılı";

            }
            return Json(aMsg);
        }

        private static void COnvertThumbnail(string thumbnailDirectory, IFormFile image, string imageName, string imageExtension)
        {

            using (MagickImage imageFile = new MagickImage(GetFormImageToByte(image)))
            {
                imageFile.Format = MagickFormat.Jpg;

                MagickGeometry reSize = new MagickGeometry(200);
                reSize.IgnoreAspectRatio = false;
                imageFile.Resize(reSize);
                imageFile.Quality = 100;
                imageFile.Write(Path.Combine(thumbnailDirectory, imageName + imageExtension));
                imageFile.Dispose();
            }
        }

        public static byte[] GetFormImageToByte(IFormFile image)
        {
            byte[] data = null;
            if (image != null && image.Length > 0)
            {
                using (Stream inputStream = image.OpenReadStream())
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                }

            }
            return data;
        }
    }
}