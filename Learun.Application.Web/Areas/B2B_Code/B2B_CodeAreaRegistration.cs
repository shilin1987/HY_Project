using System.Web.Mvc;

namespace Learun.Application.Web.Areas.B2B_Code
{
    public class B2B_CodeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "B2B_Code";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "B2B_Code_default",
                "B2B_Code/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}