using DentAda.Data.Model;
using DentAda.Data.Repository;

namespace DentAda.Data.UnitOfWork.DentAda
{
    public interface IUnitOfWork
    {
        #region Administration Repos
        IGenericRepository<Role> RoleRepository { get; }
        IGenericRepository<RoleTopMenu> RoleTopMenuRepository { get; }
        IGenericRepository<RoleAuthorization> RoleAuthorizationRepository { get; }
        IGenericRepository<RoleSideMenu> RoleSideMenuRepository { get; }
        IGenericRepository<CDC> CDCRepository { get; }
        IGenericRepository<Country> CountryRepository { get; }
        IGenericRepository<City> CityRepository { get; }
        IGenericRepository<Town> TownRepository { get; }
        IGenericRepository<Village> VillageRepository { get; }
        IGenericRepository<TopMenu> TopMenuRepository { get; }
        IGenericRepository<SideMenu> SideMenuRepository { get; }
        IGenericRepository<SystemUser> SystemUserRepository { get; }
        IGenericRepository<SystemUserRole> SystemUserRoleRepository { get; }
        IGenericRepository<SystemUserRoleLocation> SystemUserRoleLocationRepository { get; }
        IGenericRepository<ANNOUNCEMENT> AnnouncementRepository { get; }
        IGenericRepository<ConnectionLog> ConnectionLogRepository { get; }
        IGenericRepository<SystemUserTicket> SystemUserTicketRepository { get; }
        IGenericRepository<ExceptionFeedBack> ExceptionFeedBackRepository { get; }
        IGenericRepository<AboutUs> AboutUsRepository { get; }
        IGenericRepository<Person> PersonRepository { get; }
        IGenericRepository<Universities> UniversitiesRepository { get; }
        IGenericRepository<UniversityDepartment> UniversityDepartmentRepository { get; }
        IGenericRepository<Faculties> FacultiesRepository { get; }
        IGenericRepository<ContactUs> ContactUsRepository { get; }
        IGenericRepository<Services> ServicesRepository { get; }

        #endregion 

        void Save();
        void SaveBulk();
    }
}
