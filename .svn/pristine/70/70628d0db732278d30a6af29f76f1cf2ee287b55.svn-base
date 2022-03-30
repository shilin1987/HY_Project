using System.Web.Mvc;

namespace Learun.Application.Web.Areas.HR_SocialRecruitment
{
    public class HR_SocialRecruitmentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HR_SocialRecruitment";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HR_SocialRecruitment_default",
                "HR_SocialRecruitment/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}