using DentAda.Business.BusinessLogic.Base;
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
    public class CountryBL : BaseBL<Country, CountryVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<Country> CRUD;
        public CountryBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.CountryRepository;
        }
        public override List<CountryVM> GetVM(Expression<Func<Country, bool>> filter = null, Func<IQueryable<Country>, IOrderedQueryable<Country>> orderBy = null, int? take = default(int?), int? skip = default(int?), params Expression<Func<Country, object>>[] includes)
        {
            return CRUD.Query(filter, orderBy, take, skip, includes).Select(x => new CountryVM
            {
                CountryName = x.CountryName,
                CountryNameEng = x.CountryName_English,
                IdCountry = x.IdCountry,
                ISOCodeA2 = x.ISOCodeA2,
                CountryGroup = x.CountryGroup
            }).ToList();
        }
        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
