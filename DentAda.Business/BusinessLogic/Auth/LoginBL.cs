﻿using DentAda.Business.BusinessLogic.Base;
using DentAda.Business.BusinessLogic.Locator;
using DentAda.Business.ViewModel.Administration;
using DentAda.Business.ViewModel.Login;
using System.Linq;

namespace DentAda.Business.BusinessLogic.Auth
{
    public class LoginBL : ServiceBaseBL
    {
        //public TbsUserValidation_Result Login(LoginVM login)
        //{
        //    return TBSUserValidationService.TbsUserValidation(Username: login.UserName, Password: login.Password, IpAddress: login.IpAddress);
        //}

        public SystemUserVM LoginCustom(LoginVM login)
        {
            AdministrationBLLocator loc = new AdministrationBLLocator();
            return loc.SystemUserBL.GetVM(x => x.Username == login.UserName && x.Password == login.Password).FirstOrDefault();
        }

        //public DOC_TbsUser GetTBSUserInfo(string idNo)
        //{
        //    Result_TbsUserSelect res = null;
        //    return TBSUserValidationService.TbsUserSelect(new Input_TbsUserSelect() { IdNo = idNo }, out res);
        //}
    }
}
