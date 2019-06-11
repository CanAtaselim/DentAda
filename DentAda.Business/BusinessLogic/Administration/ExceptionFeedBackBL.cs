﻿using DentAda.Business.BusinessLogic.Base;
using DentAda.Business.ViewModel.Administration;
using DentAda.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DentAda.Data.UnitOfWork.DentAda;
using DentAda.Data.Repository;

namespace DentAda.Business.BusinessLogic.Administration
{
    public class ExceptionFeedBackBL : BaseBL<ExceptionFeedBack, ExceptionFeedBackVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<ExceptionFeedBack> CRUD;
        public ExceptionFeedBackBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.ExceptionFeedBackRepository;
        }
        public override List<ExceptionFeedBackVM> GetVM(Expression<Func<ExceptionFeedBack, bool>> filter = null, Func<IQueryable<ExceptionFeedBack>, IOrderedQueryable<ExceptionFeedBack>> orderBy = null, int? take = default(int?), int? skip = default(int?), params Expression<Func<ExceptionFeedBack, object>>[] includes)
        {
            return null;
        }
        public override void Save()
        {
            _unitOfWork.Save();
        }
    }
}