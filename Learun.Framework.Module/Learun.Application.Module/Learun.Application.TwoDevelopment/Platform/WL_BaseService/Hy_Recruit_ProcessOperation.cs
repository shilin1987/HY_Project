using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.Platform.WL_BaseService
{
    /// <summary>
    /// 流程操作表
    /// </summary>
  public  class Hy_Recruit_ProcessOperation
    {
        #region 实体成员

        /// <summary>
        /// id
        /// </summary>
        [Column("ID")]
        public string Id { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("SUBPROCESSID")]
        public string SubProcessId { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("OPERATIONSTATUS")]
        public string OperationStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("REMART")]
        public string Remart { get; set; }
        /// <summary>
        /// 编辑人ID
        /// </summary>
        [Column("OPERATIONCONTENT")]
        public string OperationContent { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>
        [Column("CANDIDATESID")]
        public string CandidatesId { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        [Column("OPERATIONTIME")]
        public DateTime OperationTime { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OperationTime = DateTime.Now;
          
        }
        #endregion
    }
}
