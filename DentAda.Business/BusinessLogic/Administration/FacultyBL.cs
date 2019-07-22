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
    public class FacultyBL : BaseBL<Faculties, FacultyVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<Faculties> CRUD;

        public FacultyBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.FacultiesRepository;
        }
        public override List<FacultyVM> GetVM(Expression<Func<Faculties, bool>> filter = null, Func<IQueryable<Faculties>, IOrderedQueryable<Faculties>> orderBy = null, int? take = null, int? skip = null, params Expression<Func<Faculties, object>>[] includes)
        {
            return CRUD.Query(filter, orderBy, take, skip, includes).Select(x => new FacultyVM
            {
                IdFaculty = x.IdFaculty,
                Name = x.Name

            }).ToList();
        }

        public override void Save()
        {
            _unitOfWork.Save();
        }



    }
}
