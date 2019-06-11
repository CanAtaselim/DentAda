using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DentAda.Data.UnitOfWork.DentAda;
using DentAda.Data.Repository;
using DentAda.Common;
using DentAda.Data.Model;
using DentAda.Business.BusinessLogic.Base;
using DentAda.Business.ViewModel.Administration;

namespace DentAda.Business.BusinessLogic.Administration
{
    public class AnnouncementBL : BaseBL<ANNOUNCEMENT, AnnouncementVM>
    {
        private IUnitOfWork _unitOfWork;
        public IGenericRepository<ANNOUNCEMENT> CRUD;
        public IGenericRepository<SystemUser> CRUD_SystemUser;

        public AnnouncementBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CRUD = _unitOfWork.AnnouncementRepository;
            CRUD_SystemUser = _unitOfWork.SystemUserRepository;
        }
        public override List<AnnouncementVM> GetVM(Expression<Func<ANNOUNCEMENT, bool>> filter = null, Func<IQueryable<ANNOUNCEMENT>, IOrderedQueryable<ANNOUNCEMENT>> orderBy = null, int? take = default(int?), int? skip = default(int?), params Expression<Func<ANNOUNCEMENT, object>>[] includes)
        {
            Expression<Func<ANNOUNCEMENT, object>>[] elem = new Expression<Func<ANNOUNCEMENT, object>>[] {
                    i=>i.SystemUser
            };

            return CRUD.Get(filter, orderBy, take, skip, includes: elem).Select(x => new AnnouncementVM
            {
                IdAnnouncement = x.IdAnnouncement,
                MessageSubject = x.MessageSubject,
                MessageContent = x.MessageContent,
                MessageDate = x.MessageDate,
                MessageIcon = x.MessageIcon,
                Email = x.SystemUser.Email,
                FirstName = x.SystemUser.FirstName,
                LastName = x.SystemUser.LastName,
                IsVisibleToMain = x.IsVisibleToMain,
                Priority = (_Enumeration._AnnouncementPriority)Enum.ToObject(typeof(_Enumeration._AnnouncementPriority), x.Priority)
            }).ToList();
        }
        public List<AnnouncementVM> GetVMExtended(Expression<Func<ANNOUNCEMENT, bool>> filter = null, Func<IQueryable<ANNOUNCEMENT>, IOrderedQueryable<ANNOUNCEMENT>> orderBy = null, int? take = default(int?), int? skip = default(int?), string orderByS = null, short? orderByDirection = null, params Expression<Func<ANNOUNCEMENT, object>>[] includes)
        {
            Expression<Func<ANNOUNCEMENT, object>>[] elem = new Expression<Func<ANNOUNCEMENT, object>>[] {
                    i=>i.SystemUser
            };

            return CRUD.GetExtended(filter, orderBy, take, skip,orderByS,orderByDirection, includes: elem).Select(x => new AnnouncementVM
            {
                IdAnnouncement = x.IdAnnouncement,
                MessageSubject = x.MessageSubject,
                MessageContent = x.MessageContent,
                MessageDate = x.MessageDate,
                MessageIcon = x.MessageIcon,
                Email = x.SystemUser.Email,
                FirstName = x.SystemUser.FirstName,
                LastName = x.SystemUser.LastName,
                Priority = (_Enumeration._AnnouncementPriority)Enum.ToObject(typeof(_Enumeration._AnnouncementPriority), x.Priority),
                Area=x.Area,
                IsVisibleToMain=x.IsVisibleToMain
            }).ToList();
        }
        public override void Save()
        {
            _unitOfWork.Save();
        }
    }
}
