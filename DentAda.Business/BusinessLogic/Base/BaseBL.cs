using DentAda.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DentAda.Business.BusinessLogic.Base
{
    public abstract class BaseBL<TEntity, TViewModel>
    {
        public abstract List<TViewModel> GetVM(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? take = null, int? skip = null, params Expression<Func<TEntity, object>>[] includes);

        public abstract void Save();

        private DentAdaEntities _entityForSP;

        protected DentAdaEntities EntityForSP
        {
            get { return _entityForSP == null ? _entityForSP = new DentAdaEntities(ConnectionStrings.DentAda_Prod) : _entityForSP; }
        }

    }
}
