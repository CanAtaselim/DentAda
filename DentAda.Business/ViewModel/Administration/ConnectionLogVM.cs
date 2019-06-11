﻿using DentAda.Business.ViewModel.Base;
using System;


namespace DentAda.Business.ViewModel.Administration
{
    public class ConnectionLogVM : BaseVM
    {
        public string Username { get; set; }
        public long IdConnectionLog { get; set; }
        public DateTime LogDate { get; set; }
        public string IpAddress { get; set; }
        public Int16 ErrorCode { get; set; }
    }
}
