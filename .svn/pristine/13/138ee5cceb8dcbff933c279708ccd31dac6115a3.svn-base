using System.Web.Mvc;

namespace Learun.Application.Web.Areas.WebServerUtil
{
    public class WebServerUtilAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WebServerUtil";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WebServerUtil_default",
                "WebServerUtil/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}