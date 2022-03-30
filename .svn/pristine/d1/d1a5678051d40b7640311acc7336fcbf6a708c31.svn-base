using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.Platform.RecruitSubProcessEntity
{
    public class Hy_Recruit_SubProcessEntity
    {
        #region 实体成员 
        /// <summary> 
        /// 主键ID 
        /// </summary> 
        /// <returns></returns> 
        [Column("ID")]
        public string ID { get; set; }
        /// <summary> 
        /// 主流程外键 
        /// </summary> 
        /// <returns></returns> 
        [Column("MAINPROCESSID")]
        public string MainProcessId { get; set; }
        /// <summary> 
        /// 子流程名称 
        /// </summary> 
        /// <returns></returns> 
        [Column("NAME")]
        public string Name { get; set; }
        /// <summary> 
        /// 子流程序号 
        /// </summary> 
        /// <returns></returns> 
        [Column("SORT")]
        public int? Sort { get; set; }
        /// <summary> 
        /// 备注 
        /// </summary> 
        /// <returns></returns> 
        [Column("REMARK")]
        public string Remark { get; set; }
        /// <summary> 
        /// 直接上级ID（多层级无限扩展） 
        /// </summary> 
        /// <returns></returns> 
        [Column("PARENTID")]
        public string ParentId { get; set; }
        #endregion

        #region 扩展操作 
        /// <summary> 
        /// 新增调用 
        /// </summary> 
        public void Create()
        {
            this.ID = Guid.NewGuid().ToString();
        }
        /// <summary> 
        /// 编辑调用 
        /// </summary> 
        /// <param name="keyValue"></param> 
        public void Modify(string keyValue)
        {
            this.ID = keyValue;
        }
        #endregion
    }
}
