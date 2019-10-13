using DentAda.Business.BusinessLogic.Base;
using DentAda.Business.ViewModel.Administration;
using DentAda.Data.Model;
using DentAda.Data.Repository;
using DentAda.Data.UnitOfWork.DentAda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DentAda.Business.BusinessLogic.Administration
{
    public class PersonBL : BaseBL<Person, PersonVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<Person> CRUD;

        public PersonBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.PersonRepository;
        }

        public override List<PersonVM> GetVM(Expression<Func<Person, bool>> filter = null, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null, int? take = null, int? skip = null, params Expression<Func<Person, object>>[] includes)
        {
            return CRUD.Query(filter, orderBy, take, skip, includes).Select(x => new PersonVM
            {
                IdPerson = x.IdPerson,
                Department = x.Department,
                Name = x.Name,
                Surname = x.Surname,
                Title = x.Title,
                Profession = x.Profession,
                Phone = x.Phone,
                Gsm = x.Gsm,
                About = x.About,
                Picture = x.Picture,
                EmployeeType = x.EmployeeType,
                EmployeeTypeList = new List<string> { x.EmployeeTypeList },
                Employees = x.EmployeeTypeList,
                DepartmentList = new List<string> { x.DepartmentList },
                Departments = x.DepartmentList,
            }).ToList();
        }

        public override void Save()
        {
            _unitOfWork.Save();
        }
    }
}
