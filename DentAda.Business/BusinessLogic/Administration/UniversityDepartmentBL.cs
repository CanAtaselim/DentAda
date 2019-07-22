using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DentAda.Business.BusinessLogic.Base;
using DentAda.Business.ViewModel.Administration;
using DentAda.Data.Model;
using DentAda.Data.Repository;
using DentAda.Data.UnitOfWork.DentAda;

namespace DentAda.Business.BusinessLogic.Administration
{
    public class UniversityDepartmentBL : BaseBL<UniversityDepartment, UniversityDepartmentVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<UniversityDepartment> CRUD;

        public UniversityDepartmentBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.UniversityDepartmentRepository;
        }

        public override List<UniversityDepartmentVM> GetVM(Expression<Func<UniversityDepartment, bool>> filter = null, Func<IQueryable<UniversityDepartment>, IOrderedQueryable<UniversityDepartment>> orderBy = null, int? take = null, int? skip = null, params Expression<Func<UniversityDepartment, object>>[] includes)
        {

            return CRUD.Query(filter, orderBy, take, skip, includes).Select(x => new UniversityDepartmentVM
            {
                IdUniversityDepartment = x.IdUniversityDepartment,
                Name = x.Name

            }).ToList();
        }
        public override void Save()
        {
            _unitOfWork.Save();
        }

     
    }
}
