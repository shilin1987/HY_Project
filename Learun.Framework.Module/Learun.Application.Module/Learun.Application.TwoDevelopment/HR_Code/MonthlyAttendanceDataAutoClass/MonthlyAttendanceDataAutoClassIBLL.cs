using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.HR_Code.MonthlyAttendanceDataAutoClass;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-07 19:52
    /// 描 述：菜价补贴考勤数据明细
    /// </summary>
    public interface MonthlyAttendanceDataAutoClassIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hr_user_attendanceEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<AttendanceUserDTO> GetInitPageList(string year,string month);
        /// <summary>
        /// 获取Hr_user_attendance表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hr_user_attendanceEntity GetHr_user_attendanceEntity(string keyValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        IEnumerable<QkAndShiftDTO> GetQkAndShiftPageList(string year, string month, string userid);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        IEnumerable<QkAndShiftDTO> GetQkAndShiftPageListDetil(string year, string month);
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SaveEntity(string keyValue, Hr_user_attendanceEntity entity);
        #endregion

    }
}
