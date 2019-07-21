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
    public class UniversitiesBL : BaseBL<Universities, UniversitiesVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<Universities> CRUD;

        public UniversitiesBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.UniversitiesRepository;
        }

        public override List<UniversitiesVM> GetVM(Expression<Func<Universities, bool>> filter = null, Func<IQueryable<Universities>, IOrderedQueryable<Universities>> orderBy = null, int? take = null, int? skip = null, params Expression<Func<Universities, object>>[] includes)
        {
            return CRUD.Query(filter, orderBy, take, skip, includes).Select(x => new UniversitiesVM
            {
                IdUniversity = x.IdUniversity,
                Name = x.Name

            }).ToList();
        }

        public override void Save()
        {
            _unitOfWork.Save();
        }
    }
}
