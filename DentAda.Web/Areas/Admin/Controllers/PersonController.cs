using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Data.Model;
using DentAda.Web.Attributes;
using DentAda.Web.WebCommon;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DentAda.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = new string[] { "SYSTEM_ADMIN", "ADMIN" })]

    public class PersonController : BaseController
    {
        private AdministrationBLLocator _administrationBLLocator;


        private IHostingEnvironment _env;

        public PersonController(AdministrationBLLocator administrationBLLocator, IHostingEnvironment env) : base(env)
        {
            _administrationBLLocator = administrationBLLocator;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(long idPerson)
        {
            return ViewComponent("PersonEdit", new { IdPerson = idPerson });
        }

        [HttpPost]
        public IActionResult List()
        {
            return ViewComponent("PersonList");
        }
        [HttpPost]
        public JsonResult GetUniversity(string search)
        {
            List<UniversitiesVM> universities = _administrationBLLocator.UniversitiesBL.GetVM(filter: m => m.Name.Contains(search) && m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, take: 10);

            var newJson = JsonConvert.SerializeObject(universities);
            return Json(newJson);
        }
        [HttpPost]
        public JsonResult GetFaculty(string search, long idUniversity)
        {
            List<FacultyVM> faculties = _administrationBLLocator.FacultyBL.GetVM(filter: m => m.Name.Contains(search) && m.IdUniversity == idUniversity && m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, take: 10);
            var newJson = JsonConvert.SerializeObject(faculties);
            return Json(newJson);
        }

        [HttpPost]
        public JsonResult GetUniversityDepartment(string search, long idFaculty)
        {
            List<UniversityDepartmentVM> universityDepartment = _administrationBLLocator.UniversityDepartmentBL.GetVM(filter: m => m.Name.Contains(search) && m.IdFaculty == idFaculty && m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, take: 10);
            var newJson = JsonConvert.SerializeObject(universityDepartment);
            return Json(newJson);
        }

        [HttpPost]
        public IActionResult Save(PersonVM model)
        {
            AjaxMessage aMsg = new AjaxMessage();
            if (model != null)
            {
                if (ModelState.IsValid)
                {

                    var files = Request.Form.Files;
                    byte[] imageData = null;
                    if (files.Count > 0)
                    {
                        imageData = GetFormImageToByte(files[0]);
                    }




                    Person person = new Person();
                    person.IdUniversity = model.IdUniversity;
                    person.IdFaculty = model.IdFaculty;
                    person.IdUniversityDepartment = model.IdUniversityDepartment;
                    person.EmployeeType = model.EmployeeType;
                    person.Department = model.Department;
                    person.Name = model.Name;
                    person.Surname = model.Surname;
                    person.Title = model.Title;
                    person.Profession = model.Profession;
                    person.Phone = model.Phone;
                    person.Gsm = model.Gsm;
                    person.About = model.About;
                    person.Picture = imageData != null ? imageData : model.Picture;
                    person.OperationDate = DateTime.Now;
                    person.OperationIdUserRef = HttpRequestInfo.UserID;
                    person.OperationIP = HttpRequestInfo.IpAddress;
                    person.OperationIsDeleted = 1;



                    if (model.IdPerson == 0)
                    {
                        _administrationBLLocator.PersonBL.CRUD.Insert(person);
                        _administrationBLLocator.PersonBL.Save();
                        aMsg.Status = 1;
                        aMsg.Message = "Kayıt Başarıyla Eklendi.";

                    }
                    else
                    {
                        person.IdPerson = model.IdPerson;
                        _administrationBLLocator.PersonBL.CRUD.Update(person, HttpRequestInfo);
                        _administrationBLLocator.PersonBL.Save();
                        aMsg.Status = 1;
                        aMsg.Message = "Güncelleme Başarılı.";

                    }
                }
                else
                {
                    aMsg.Status = 0;
                    aMsg.Message = "Bir Hata oluştu";

                }
            }
            return Json(aMsg);
        }
        [HttpPost]
        public IActionResult Delete(int? idPerson)
        {

            AjaxMessage aMsg = new AjaxMessage();

            if (idPerson != null)
            {
                var dropItem = _administrationBLLocator.PersonBL.CRUD.GetById(idPerson);
                if (dropItem != null)
                {
                    dropItem.OperationIsDeleted = (short)_Enumeration.IsOperationDeleted.Deleted;
                    _administrationBLLocator.PersonBL.Save();
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