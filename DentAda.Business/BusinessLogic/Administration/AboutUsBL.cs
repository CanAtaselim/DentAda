using DentAda.Business.BusinessLogic.Base;
using DentAda.Business.ViewModel.Administration;
using DentAda.Data.Model;
using DentAda.Data.Repository;
using DentAda.Data.UnitOfWork.DentAda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DentAda.Business.BusinessLogic.Administration
{
    public class AboutUsBL : BaseBL<AboutUs, AboutUsVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<AboutUs> CRUD;

        public AboutUsBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.AboutUsRepository;
        }

        public override List<AboutUsVM> GetVM(Expression<Func<AboutUs, bool>> filter = null, Func<IQueryable<AboutUs>, IOrderedQueryable<AboutUs>> orderBy = null, int? take = null, int? skip = null, params Expression<Func<AboutUs, object>>[] includes)
        {
            return CRUD.Query(filter, orderBy, take, skip, includes).Select(x => new AboutUsVM
            {
                IdAboutUs = x.IdAboutUs,
                Description = x.Description,
                Department = x.Department,
                Picture = x.Picture

            }).ToList();
        }

        public override void Save()
        {
            _unitOfWork.Save();
        }
    }
}
