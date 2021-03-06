using Learun.Application.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class UserViewModele
    {
        public string token { get; set; }
        public string loginMark { get; set; }
        public UserEntity data { get; set; }
    }
    public class UserInitModele
    {
        public string token { get; set; }
        public string loginMark { get; set; }
        public string userId { get; set; }
    }

    /// <summary>
    /// 登录信息
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 账号/手机号
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 密码/验证码
        /// </summary>
        public string password { get; set; }

        public string loginMark { get; set; }
    }
    /// <summary>
    /// 修改密码
    /// </summary>
    public class ModifyModel
    {
        /// <summary>
        /// 新密码
        /// </summary>
        public string newpassword { get; set; }
        /// <summary>
        /// 旧密码
        /// </summary>
        public string oldpassword { get; set; }
    }

}