﻿using DentAda.Data.DataCommon;
using DentAda.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DentAda.Web.WebCommon
{
    public static class HttpInfo
    {
        public static HttpRequestInfo GetRequestInfo(HttpContext context)
        {
            Task<AuthenticateInfo> authInfo = context.Authentication.GetAuthenticateInfoAsync("DentAda_CookieMiddlewareInstance");
            int userId = -1;
            long workingModuleId = -1;


            List<Role_List_Result> userAuth = new List<Role_List_Result>();
            if (authInfo.Result.Principal != null)
            {
                IEnumerable<Claim> claims = authInfo.Result.Principal.Claims;
                userId = int.Parse(claims.Where(x => x.Type.ToLower().EndsWith("nameidentifier")).FirstOrDefault().Value);
                userAuth = JsonConvert.DeserializeObject<List<Role_List_Result>>(context.Session.GetString("UserData"));


            }
            return new HttpRequestInfo()
            {
                UserID = userId,
                IpAddress = context.Connection.RemoteIpAddress.ToString(),
                Roles = userAuth.Select(x => x.RoleCode).ToList(),
                UserAuth = userAuth,
                WorkingModuleId = workingModuleId
            };
        }
        public static DateTime GetDateTimeFromString(string date)
        {
            DateTime dateOk;
            string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                    "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy","dd.MM.yyyy", "dd.M.yyyy", "d.M.yyyy", "d.MM.yyyy",
                    "dd.MM.yy", "dd.M.yy", "d.M.yy", "d.MM.yy","MM/dd/yyyy","MM.dd.yyyy"};
            DateTime.TryParseExact(date, formats, null, System.Globalization.DateTimeStyles.None, out dateOk);
            return dateOk;
        }
        public static string GetDateTimeParsed(DateTime date)
        {
            return string.Format("{0};{1};{2};{3};{4};{5}", date.Year.ToString(), date.Month.ToString(), date.Day.ToString(), date.Hour.ToString(), date.Minute.ToString(), date.Second.ToString());
        }
    }
    public class AjaxMessage
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class BatchOpsResult
    {
        public List<Guid> SuccessIds { get; set; }
        public List<Guid> ErrorIds { get; set; }
        public List<Guid> UpdateIds { get; set; }
    }

    public static class EventAppInfo
    {
        public static string Source { get { return "SinerjiSoftFramework"; } }
        public static string Log { get { return "Application"; } }
    }

    public class ViewBagStatics
    {
        public List<string> Params { get; set; }
    }
    public class UserInfo
    {
        public List<Role_List_Result> UserRoles { get; set; }
        public List<string> AreaList { get; set; }
    }

}
