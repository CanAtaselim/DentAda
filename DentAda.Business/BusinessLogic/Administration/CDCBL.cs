using DentAda.Business.BusinessLogic.Base;
using DentAda.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DentAda.Data.Repository;
using DentAda.Business.ViewModel.Administration;
using DentAda.Data.UnitOfWork.DentAda;

namespace DentAda.Business.BusinessLogic.Administration
{
    public class CDCBL : BaseBL<CDC, CDCVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<CDC> CRUD;
        public CDCBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.CDCRepository;
        }
        public override List<CDCVM> GetVM(Expression<Func<CDC, bool>> filter = null, Func<IQueryable<CDC>, IOrderedQueryable<CDC>> orderBy = null, int? take = default(int?), int? skip = default(int?), params Expression<Func<CDC, object>>[] includes)
        {
            return null;
        }

        public override void Save()
        {
            _unitOfWork.Save();
        }
    }
}
