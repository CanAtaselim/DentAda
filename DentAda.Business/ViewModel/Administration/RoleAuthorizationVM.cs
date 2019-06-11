using DentAda.Business.ViewModel.Base;


namespace DentAda.Business.ViewModel
{
    public class RoleAuthorizationVM : BaseVM
    {
        public long IdRoleAuthorization { get; set; }
        public long IdRoleRef { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public bool IsForbidden { get; set; }
    }

}
