﻿using DentAda.Business.BusinessLogic.Auth;


namespace DentAda.Business.BusinessLogic.Locator
{
    public class AuthBLLocator
    {
        private LoginBL _loginBL;

        public LoginBL LoginBL
        {
            get { return _loginBL == null ? _loginBL = new LoginBL() : _loginBL; }
        }
    }
}
