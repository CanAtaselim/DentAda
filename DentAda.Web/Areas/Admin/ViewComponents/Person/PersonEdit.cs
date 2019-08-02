using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Common;
using DentAda.Web.WebCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentAda.Web.Areas.Admin.ViewComponents.Person
{
    public class PersonEdit : ViewComponent
    {
        private AdministrationBLLocator _administrationBLLocator;
        public PersonEdit(AdministrationBLLocator administrationBLLocator)
        {
            _administrationBLLocator = administrationBLLocator;
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

            ViewBag.EmployeeType = EmployeeTypeList;
            ViewBag.DepartmentList = HttpInfo.DepartmentList;

            PersonVM person = new PersonVM();

            person = _administrationBLLocator.PersonBL.GetVM(filter: m => m.IdPerson == IdPerson && m.OperationIsDeleted == (short)_Enumeration.IsOperationDeleted.Active, orderBy: o => o.OrderBy(x => x.Department)).FirstOrDefault();

            return Task.FromResult<IViewComponentResult>(View(person ?? new PersonVM()));
        }

    }
}
