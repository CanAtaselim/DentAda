using DentAda.Business.BusinessLogic.Base;
using DentAda.Business.ViewModel.Administration;
using DentAda.Data.Model;
using DentAda.Data.Repository;
using DentAda.Data.UnitOfWork.DentAda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DentAda.Business.BusinessLogic.Administration
{
    public class TalentBL : BaseBL<Talent, TalentVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<Talent> CRUD;

        public TalentBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.TalentRepository;
        }

        public override List<TalentVM> GetVM(Expression<Func<Talent, bool>> filter = null, Func<IQueryable<Talent>, IOrderedQueryable<Talent>> orderBy = null, int? take = null, int? skip = null, params Expression<Func<Talent, object>>[] includes)
        {
            return CRUD.Query(filter, orderBy, take, skip, includes).Select(x => new TalentVM
            {
                IdTalent = x.IdTalent,
                Description = x.Description,
                Title = x.Title
 

            }).ToList();
        }
        public override void Save()
        {
            _unitOfWork.Save();
        }
    }
}
