﻿using System;
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
    public class BannerBL : BaseBL<Banner, BannerVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<Banner> CRUD;
        public BannerBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.BannerRepository;
        }
        public override List<BannerVM> GetVM(Expression<Func<Banner, bool>> filter = null, Func<IQueryable<Banner>, IOrderedQueryable<Banner>> orderBy = null, int? take = null, int? skip = null, params Expression<Func<Banner, object>>[] includes)
        {
            return CRUD.Query(filter, orderBy, take, skip, includes).Select(x => new BannerVM
            {
                IdBanner = x.IdBanner,
                FileName = x.FileName,
                FilePath = x.FilePath,
                Description = x.Description

            }).ToList();
        }

        public override void Save()
        {
            _unitOfWork.Save();
        }
    }
}