using DentAda.Business.ViewModel.Base;


namespace DentAda.Business.ViewModel
{
    public class RoleSideMenuVM : BaseVM
    {
        //Her iki alan DropDownListten seçildiğinden boş geçilme imkanı yok. 
        public long IdRoleSideMenu { get; set; }
        public long IdRoleRef { get; set; }
        public long IdSideMenuRef { get; set; }
        public string RoleName { get; set; }
        public string SideMenuName { get; set; }

    }

}
