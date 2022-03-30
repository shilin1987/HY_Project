using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemporaryPro_Web.Models;

namespace TemporaryPro_Web.Areas
{
    public class QrCodeInfoController : Controller
    {
        UntilDB db = new UntilDB();

        // GET: QrCodeInfo
        public ActionResult QrFormInfo()
        {
            return Redirect("Html/pages/all-admin-register.html");//注意：把你的html文件放在Views文件夹外的任何文件夹中，就可以直接访问了，
            //return View();
        }

        [HttpPost]
        public ActionResult Save(UserDTO user)
        {
            ReturnCommon rc = new ReturnCommon();
            rc =  db.insert();
            if (rc.Falg)
            {
                return Redirect("../Html/pages/success.html");
            }
            else
            {
                return Redirect("../Html/pages/faile.html");
            }

        }

    }
}