using System.Web.Mvc;

namespace Learun.Application.Web.Areas.SocialRecruitment
{
    public class SocialRecruitmentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SocialRecruitment";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SocialRecruitment_default",
                "SocialRecruitment/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}