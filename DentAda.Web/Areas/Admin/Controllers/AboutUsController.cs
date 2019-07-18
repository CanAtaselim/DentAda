namespace DentAda.Web.Areas.Admin.Controllers
{
    using DentAda.Business.BusinessLogic.Locator;
    using DentAda.Business.ViewModel.Administration;
    using DentAda.Common;
    using DentAda.Data.Model;
    using DentAda.Web.Attributes;
    using DentAda.Web.WebCommon;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.IO;

    /// <summary>
    /// Defines the <see cref="AboutUsController" />
    /// </summary>
    [Area("Admin")]
    [Authorize(Roles = new string[] { "SYSTEM_ADMIN", "ADMIN" })]
    public class AboutUsController : BaseController
    {
        /// <summary>
        /// Defines the _administrationBLLocator
        /// </summary>
        private AdministrationBLLocator _administrationBLLocator;

        /// <summary>
        /// Defines the _env
        /// </summary>
        private IHostingEnvironment _env;

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutUsController"/> class.
        /// </summary>
        /// <param name="administrationBLLocator">The administrationBLLocator<see cref="AdministrationBLLocator"/></param>
        /// <param name="env">The env<see cref="IHostingEnvironment"/></param>
        public AboutUsController(AdministrationBLLocator administrationBLLocator, IHostingEnvironment env) : base(env)
        {
            _administrationBLLocator = administrationBLLocator;
            _env = env;
        }

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The FileUpload
        /// </summary>
        /// <param name="model">The model<see cref="AboutUsVM"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpPost]

        public IActionResult Save(AboutUsVM model)
        {
            AjaxMessage aMsg = new AjaxMessage();

            var files = Request.Form.Files;
            byte[] imageData = null;
            if (files.Count > 0)
            {
                imageData = GetFormImageToByte(files[0]);
            }




            AboutUs aboutUs = new AboutUs();
            aboutUs.Department = model.Department;
            aboutUs.Description = model.Description;
            aboutUs.Picture = imageData != null ? imageData : model.Picture;
            aboutUs.OperationDate = DateTime.Now;
            aboutUs.OperationIdUserRef = HttpRequestInfo.UserID;
            aboutUs.OperationIP = HttpRequestInfo.IpAddress;
            aboutUs.OperationIsDeleted = 1;



            if (model.IdAboutUs == 0)
            {
                _administrationBLLocator.AboutUsBL.CRUD.Insert(aboutUs);
                _administrationBLLocator.AboutUsBL.Save();
                aMsg.Status = 1;
                aMsg.Message = "Kayıt Başarıyla Eklendi.";

            }
            else
            {
                aboutUs.IdAboutUs = model.IdAboutUs;
                _administrationBLLocator.AboutUsBL.CRUD.Update(aboutUs, HttpRequestInfo);
                _administrationBLLocator.AboutUsBL.Save();
                aMsg.Status = 1;
                aMsg.Message = "Güncelleme Başarılı.";

            }
            return Json(aMsg);
        }

        public IActionResult Delete(int? idAboutUs)
        {

            AjaxMessage aMsg = new AjaxMessage();

            if (idAboutUs != null)
            {
                var dropItem = _administrationBLLocator.AboutUsBL.CRUD.GetById(idAboutUs);
                if (dropItem != null)
                {
                    dropItem.OperationIsDeleted = (short)_Enumeration.IsOperationDeleted.Deleted;
                    _administrationBLLocator.AboutUsBL.Save();
                    aMsg.Status = 1;
                    aMsg.Message = "Kayıt Başarıyla Silinmiştir.";
                }
                else
                {
                    aMsg.Status = 0;
                    aMsg.Message = "Kayıt Bulunamadı!";
                }
            }
            else
            {
                aMsg.Status = 0;
                aMsg.Message = "Lütfen departman seçin!";
            }
            return Json(aMsg);
        }
        /// <summary>
        /// The ReInvokeEditComponent
        /// </summary>
        /// <param name="Department">The Department<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult ReInvokeEditComponent(int Department)
        {
            return ViewComponent("Edit", new { department = Department });
        }

        /// <summary>
        /// The GetFormImageToByte
        /// </summary>
        /// <param name="image">The image<see cref="IFormFile"/></param>
        /// <returns>The <see cref="byte[]"/></returns>
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
