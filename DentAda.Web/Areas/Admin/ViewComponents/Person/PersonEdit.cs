using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Web.WebCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentAda.Web.Areas.Admin.ViewComponents.Person
{
    public class PersonEdit : ViewComponent
    {
        private AdministrationBLLocator _administrationBLLocator;
        private IMemoryCache _memoryCache;
        public PersonEdit(AdministrationBLLocator administrationBLLocator, IMemoryCache memoryCache)
        {
            _administrationBLLocator = administrationBLLocator;
            _memoryCache = memoryCache;
        }
        public static List<SelectListItem> EmployeeTypeList
        {
            get
            {
                return new List<SelectListItem>() {
                    new SelectListItem()
                    {
                        Text = _Enumeration.GetEnumDescription(_Enumeration._EmployeeType.MedicalStaff).ToString(),
                        Value = ((int)_Enumeration._EmployeeType.MedicalStaff).ToString()
                    },
                    new SelectListItem()
                    {
                        Text = _Enumeration.GetEnumDescription(_Enumeration._EmployeeType.OurTeam).ToString(),
                        Value = ((int)_Enumeration._EmployeeType.OurTeam).ToString()
                    },
                };
            }
        }

        public Task<IViewComponentResult> InvokeAsync(long IdPerson)
        {
            PersonVM person = new PersonVM();


            ViewBag.EmployeeType = EmployeeTypeList;
            ViewBag.DepartmentList = HttpInfo.DepartmentList;

            //string key = "person" + IdPerson;
            //if (IdPerson > 0)
            //{
            //    if (_memoryCache.TryGetValue(key, out person))
            //    {
            //        return Task.FromResult<IViewComponentResult>(View(person ?? new PersonVM()));
            //    }
            //}

            person = _administrationBLLocator.PersonBL.GetVM(filter: m => m.IdPerson == IdPerson && m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, orderBy: o => o.OrderBy(x => x.Department)).FirstOrDefault();
            
            //if (IdPerson > 0)
            //{
            //    _memoryCache.Set(key, person, new MemoryCacheEntryOptions
            //    {
            //        AbsoluteExpiration = DateTime.Now.AddMinutes(5),
            //        Priority = CacheItemPriority.Normal
            //    });
            //}

            return Task.FromResult<IViewComponentResult>(View(person ?? new PersonVM()));
        }

    }
}
