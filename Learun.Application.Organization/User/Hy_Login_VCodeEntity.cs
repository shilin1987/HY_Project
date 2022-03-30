using Learun.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.Organization.User
{
   public class Hy_Login_VCodeEntity
    {
        #region 实体成员
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime F_CreateDate { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Column("F_Phone")]
        public int F_Phone { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Column("F_VCode")]
        public int F_VCode { get; set; }

        /// <summary>
        /// 主键ID
        /// </summary>
        [Column("F_ID")]
        public string F_Id { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_Id = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}
