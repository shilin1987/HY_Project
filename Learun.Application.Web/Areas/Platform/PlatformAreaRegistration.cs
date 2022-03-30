﻿using System.Web.Mvc;

namespace Learun.Application.Web.Areas.Platform
{
    public class PlatformAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Platform";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Platform_default",
                "Platform/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}