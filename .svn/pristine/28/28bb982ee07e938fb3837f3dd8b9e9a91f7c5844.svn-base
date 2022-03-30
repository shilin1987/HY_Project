using System.Web.Mvc;

namespace Learun.Application.Web.Areas.HR_Code
{
    public class HR_CodeAreaRegistration: AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HR_Code";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HR_Code_default",
                "HR_Code/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}