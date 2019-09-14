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
    public class ServicesBL : BaseBL<Services, ServicesVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<Services> CRUD;

        public ServicesBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.ServicesRepository;
        }

        public override List<ServicesVM> GetVM(Expression<Func<Services, bool>> filter = null, Func<IQueryable<Services>, IOrderedQueryable<Services>> orderBy = null, int? take = null, int? skip = null, params Expression<Func<Services, object>>[] includes)
        {
            return CRUD.Query(filter, orderBy, take, skip, includes).Select(x => new ServicesVM
            {
                IdServices = x.IdServices,
                Title = x.Title,
                FullText = x.FullText,
                Summary = x.Summary,
                Icon = x.Icon
            }).ToList();
        }

        public override void Save()
        {
            _unitOfWork.Save();
        }
    }
}
