﻿using DentAda.Business.BusinessLogic.Locator;
using DentAda.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DentAda.Web.WebCommon;

namespace DentAda.Web.Attributes
{
    public class AuthorizeAttribute : Attribute, IActionFilter
    {
        public string[] Roles { get; set; }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = (BaseController)filterContext.Controller;
            try
            {
                Task<AuthenticateInfo> authInfo = filterContext.HttpContext.Authentication.GetAuthenticateInfoAsync("DentAda_CookieMiddlewareInstance");
                if (authInfo.Result.Principal != null && authInfo.Result.Principal.Identity.IsAuthenticated == true)
                {
                    AdministrationBLLocator _locator = new AdministrationBLLocator();
                    if (filterContext.HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
                    {
                        string areaName = (string)filterContext.RouteData.Values["area"];
                        //List<SystemUserTopMenu_List_Result> topMenu = JsonConvert.DeserializeObject<List<SystemUserTopMenu_List_Result>>(filterContext.HttpContext.Session.GetString("TopMenu"));
                        //var selectedMenu = topMenu.Where(x => x.AREA.ToLower() == areaName.ToLower()).FirstOrDefault();
                        //if (selectedMenu != null)
                        //    controller.ViewBag.SideMenu = _locator.SideMenuBL.GetSideMenuWithPermission(selectedMenu.IDTOPMENU, controller.HttpRequestInfo.UserID);
                    }
                    if (Roles != null && Roles.Length > 0)
                    {
                        IEnumerable<Claim> claims = authInfo.Result.Principal.Claims;
                        string identity = claims.Where(x => x.Type.ToLower().EndsWith("name")).FirstOrDefault().Value;
                        string userId = claims.Where(x => x.Type.ToLower().EndsWith("nameidentifier")).FirstOrDefault().Value;
                        List<Role_List_Result> userAuth = JsonConvert.DeserializeObject<List<Role_List_Result>>(filterContext.HttpContext.Session.GetString("UserData"));
                        var validRoles = Roles.Where(x => userAuth.Any(a => a.RoleCode == x));
                        if (validRoles.Count() == 0)
                        {
                            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                            {
                                var ajaxMessage = new AjaxMessage()
                                {
                                    Message = "Bu İşlemi Yapmaya Yetkiniz Yok!",
                                    Status = 3,
                                };
                                filterContext.Result = new ObjectResult(ajaxMessage)
                                {
                                    StatusCode = 500,
                                    DeclaredType = typeof(AjaxMessage)
                                };
                                return;
                            }
                            filterContext.Result = controller.RedirectToAction("Forbidden", "Login", new { area = "Auth" });
                        }

                        else
                        {
                            //if (locationAdminRoles.Count() > 0)
                            //{
                            //    controller.ViewBag.cities = _locator.CityBL.GetVMWithPermission(orderBy: o => o.OrderBy(x => x.CITYNAME), roleCode: locationAdminRoles.First());
                            //}
                            //else
                            //{
                            //    List<long?> cityIds = userAuth.Where(x => x.ROLECODE == validRoles.First() && x.IDCITY != null).Select(s => s.IDCITY).ToList();
                            //    if (cityIds.Count() > 0)
                            //    {
                            //        controller.ViewBag.cities = _locator.CityBL.GetVMWithPermission(
                            //            filter: x => cityIds.Any(a => a == x.IDCITY), orderBy: o => o.OrderBy(x => x.CITYNAME),
                            //            roleCode: validRoles.First()
                            //          );
                            //    }
                            //}
                        }
                    }
                    return;

                }
                else
                {

                    if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        var ajaxMessage = new AjaxMessage()
                        {
                            Message = "Oturumunuz Sona Erdi!",
                            Status = 2,
                        };
                        filterContext.Result = new ObjectResult(ajaxMessage)
                        {
                            StatusCode = 500,
                            DeclaredType = typeof(AjaxMessage)
                        };
                    }

                    else
                    {
                        filterContext.Result = controller.RedirectToAction("SignOut", "Login", new { area = "Auth" });

                    }
                }


            }
            catch (System.Exception ex)
            {
                if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    var ajaxMessage = new AjaxMessage()
                    {
                        Message = "Oturumunuz Sona Erdi!",
                        Status = 2,
                    };
                    filterContext.Result = new ObjectResult(ajaxMessage)
                    {
                        StatusCode = 500,
                        DeclaredType = typeof(AjaxMessage)
                    };
                    return;
                }
                filterContext.Result = controller.RedirectToAction("SignOut", "Login", new { area = "Auth" });
            }

        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}
