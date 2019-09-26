﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentAda.Data.Model
{
    public static class ConnectionStrings
    {
        public static string DentAda_Prod
        {
            get
            {
                if (System.Configuration.ConfigurationManager.AppSettings.Get("EnvMode") == "Prod")
                {
                    return @"metadata=res://*/Model.DentAda_Model.csdl|res://*/Model.DentAda_Model.ssdl|res://*/Model.DentAda_Model.msl;provider=System.Data.SqlClient; provider connection string=""data source=(LocalDB)\MSSQLLocalDB;initial catalog=DentAda;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework""";
                }
                return @"metadata=res://*/Model.DentAda_Model.csdl|res://*/Model.DentAda_Model.ssdl|res://*/Model.DentAda_Model.msl;provider=System.Data.SqlClient; provider connection string=""data source=94.73.170.2;initial catalog=u8990992_DentAda;persist security info=True;user id=u8990992_dentada;password=DentAdals_2019!;MultipleActiveResultSets=True;App=EntityFramework""";
            }
        }

    }
}
