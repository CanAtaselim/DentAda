using DentAda.Data.Model;
using DentAda.Business.BusinessLogic.Administration;
using DentAda.Data.UnitOfWork.DentAda;

namespace DentAda.Business.BusinessLogic.Locator
{
    public class AdministrationBLLocator
    {
        private static class SingletonHolder
        {
            internal static readonly UnitOfWork _unitOfWork = new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod));
            static SingletonHolder() { }
        }
        private ConnectionLogBL _connectionLogBL;

        public ConnectionLogBL ConnectionLogBL
        {
            get { return _connectionLogBL == null ? _connectionLogBL = new ConnectionLogBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _connectionLogBL; }
        }
        private SystemUserRoleBL _systemUserRoleBL;

        public SystemUserRoleBL SystemUserRoleBL
        {
            get { return _systemUserRoleBL == null ? _systemUserRoleBL = new SystemUserRoleBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _systemUserRoleBL; }
        }
        private SystemUserRoleLocationBL _systemUserRoleLocationBL;

        public SystemUserRoleLocationBL SystemUserRoleLocationBL
        {
            get { return _systemUserRoleLocationBL == null ? _systemUserRoleLocationBL = new SystemUserRoleLocationBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _systemUserRoleLocationBL; }
        }
        private AnnouncementBL _announcementBL;

        public AnnouncementBL AnnouncementBL
        {
            get { return _announcementBL == null ? _announcementBL = new AnnouncementBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _announcementBL; }
        }

        private RoleBL _roleBL;

        public RoleBL RoleBL
        {
            get { return _roleBL == null ? _roleBL = new RoleBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _roleBL; }
        }

        private RoleAuthorizationBL _roleAuthorizationBL;

        public RoleAuthorizationBL RoleAuthorizationBL
        {
            get { return _roleAuthorizationBL == null ? _roleAuthorizationBL = new RoleAuthorizationBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _roleAuthorizationBL; }
        }

        private RoleTopMenuBL _roleTopMenuBL;

        public RoleTopMenuBL RoleTopMenuBL
        {
            get { return _roleTopMenuBL == null ? _roleTopMenuBL = new RoleTopMenuBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _roleTopMenuBL; }
        }

        private RoleSideMenuBL _roleSideMenuBL;

        public RoleSideMenuBL RoleSideMenuBL
        {
            get { return _roleSideMenuBL == null ? _roleSideMenuBL = new RoleSideMenuBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _roleSideMenuBL; }
        }

        private CityBL _cityBL;

        public CityBL CityBL
        {
            get { return _cityBL == null ? _cityBL = new CityBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _cityBL; }
        }

        private SystemUserBL _systemUserBL;

        public SystemUserBL SystemUserBL
        {
            get { return _systemUserBL == null ? _systemUserBL = new SystemUserBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _systemUserBL; }
        }
        private SystemUserTicketBL _systemUserTicketBL;

        public SystemUserTicketBL SystemUserTicketBL
        {
            get { return _systemUserTicketBL == null ? _systemUserTicketBL = new SystemUserTicketBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _systemUserTicketBL; }
        }
        private CountryBL _countryBL;

        public CountryBL CountryBL
        {
            get { return _countryBL == null ? _countryBL = new CountryBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _countryBL; }
        }

        private TownBL _townBL;

        public TownBL TownBL
        {
            get { return _townBL == null ? _townBL = new TownBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _townBL; }
        }

        private TopMenuBL _topMenuBL;

        public TopMenuBL TopMenuBL
        {
            get { return _topMenuBL == null ? _topMenuBL = new TopMenuBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _topMenuBL; }
        }

        private SideMenuBL _sideMenuBL;

        public SideMenuBL SideMenuBL
        {
            get { return _sideMenuBL == null ? _sideMenuBL = new SideMenuBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _sideMenuBL; }
        }
        private ExceptionFeedBackBL _exceptionFeedBackBL;

        public ExceptionFeedBackBL ExceptionFeedBackBL
        {
            get { return _exceptionFeedBackBL == null ? _exceptionFeedBackBL = new ExceptionFeedBackBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _exceptionFeedBackBL; }
        }
        private VillageBL _villageBL;

        public VillageBL VillageBL
        {
            get { return _villageBL == null ? _villageBL = new VillageBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _villageBL; }
        }

        private CDCBL _CDCBL;

        public CDCBL CDCBL
        {
            get { return _CDCBL == null ? _CDCBL = new CDCBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _CDCBL; }
        }

        private AboutUsBL _AboutUsBL;

        public AboutUsBL AboutUsBL
        {
            get { return _AboutUsBL == null ? _AboutUsBL = new AboutUsBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _AboutUsBL; }
        }


        private UniversitiesBL _UniversitiesBL;

        public UniversitiesBL UniversitiesBL
        {
            get { return _UniversitiesBL == null ? _UniversitiesBL = new UniversitiesBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _UniversitiesBL; }
        }
        private FacultyBL _FacultyBL;

        public FacultyBL FacultyBL
        {
            get { return _FacultyBL == null ? _FacultyBL = new FacultyBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _FacultyBL; }
        }
        private UniversityDepartmentBL _UniversityDepartmentBL;

        public UniversityDepartmentBL UniversityDepartmentBL
        {
            get { return _UniversityDepartmentBL == null ? _UniversityDepartmentBL = new UniversityDepartmentBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _UniversityDepartmentBL; }
        }
        private PersonBL _PersonBL;

        public PersonBL PersonBL
        {
            get { return _PersonBL == null ? _PersonBL = new PersonBL(new UnitOfWork(new DentAdaEntities(ConnectionStrings.DentAda_Prod))) : _PersonBL; }
        }
    }
}
