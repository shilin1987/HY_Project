using System.Web.Mvc;

namespace Learun.Application.Web.Areas.HY_Logistics
{
    public class HY_LogisticsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HY_Logistics";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HY_Logistics_default",
                "HY_Logistics/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}