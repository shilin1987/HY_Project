using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Learun.Application.Organization
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.17
    /// 描 述：部门管理
    /// </summary>
    public class DepartmentService : RepositoryFactory
    {
        #region 构造函数和属性
        private string fieldSql;
        public DepartmentService()
        {
            fieldSql = @"
                    t.F_DepartmentId,
                    t.F_CompanyId,
                    t.F_ParentId,
                    t.F_EnCode,
                    t.F_FullName,
                    t.F_ShortName,
                    t.F_Nature,
                    t.F_Manager,
                    t.F_OuterPhone,
                    t.F_InnerPhone,
                    t.F_Email,
                    t.F_Fax,
                    t.F_SortCode,
                    t.F_DeleteMark,
                    t.F_EnabledMark,
                    t.F_Description,
                    t.F_CreateDate,
                    t.F_CreateUserId,
                    t.F_CreateUserName,
                    t.F_ModifyDate,
                    t.F_ModifyUserId,
                    t.F_ModifyUserName
                    ";
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取部门列表信息(根据公司Id)
        /// </summary>
        /// <param name="companyId">公司主键</param>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> GetList(string companyId)
        {
            try
            {
                var strSql = new StringBuilder();
                int count = this.BaseRepository().FindList<DepartmentEntity>(e => 
                 (e.F_EnabledMark == null || e.F_EnabledMark==1) && (e.F_DeleteMark == null || e.F_DeleteMark == 0) && e.F_CompanyId == companyId).Count();
                //如果查询为空 , 改查父节点数据
                if (count >0 )
                {
                    strSql.Append("SELECT ");
                    strSql.Append(fieldSql);
                    strSql.Append(" FROM LR_Base_Department t WHERE  (F_EnabledMark is null or F_EnabledMark=1) AND (F_DeleteMark is null or F_DeleteMark=0) AND F_CompanyId = @companyId ORDER BY t.F_EnCode");
                    return this.BaseRepository().FindList<DepartmentEntity>(strSql.ToString(), new { companyId = companyId });
                }
                else
                {
                    strSql.Append("SELECT ");
                    strSql.Append(fieldSql);
                    strSql.Append(" FROM LR_Base_Department t WHERE  (F_EnabledMark is null or F_EnabledMark=1) AND (F_DeleteMark is null or F_DeleteMark=0) AND F_ParentId = @companyId ORDER BY t.F_EnCode");
                    return this.BaseRepository().FindList<DepartmentEntity>(strSql.ToString(), new { companyId = companyId });
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        /// <summary>
        /// 获取部门列表信息(根据公司Id)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> GetAllList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM LR_Base_Department t WHERE t.F_EnabledMark = 1 AND t.F_DeleteMark = 0 ");
                return this.BaseRepository().FindList<DepartmentEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        /// <summary>
        /// 获取部门数据实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public DepartmentEntity GetEntity(string keyValue) {
            try
            {
                return this.BaseRepository().FindEntity<DepartmentEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 虚拟删除部门
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void VirtualDelete(string keyValue)
        {
            try
            {
                DepartmentEntity entity = new DepartmentEntity()
                {
                    F_DepartmentId = keyValue,
                    F_DeleteMark = 1
                };
                this.BaseRepository().Update(entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        /// <summary>
        /// 保存部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">部门实体</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DepartmentEntity departmentEntity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    departmentEntity.Modify(keyValue);
                    this.BaseRepository().Update(departmentEntity);
                }
                else
                {
                    departmentEntity.Create();
                    this.BaseRepository().Insert(departmentEntity);
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }

        }
        /// <summary>
        /// 修改部门状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动；0-禁用</param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                DepartmentEntity DepartmentEntity = new DepartmentEntity();
                DepartmentEntity.Modify(keyValue);
                DepartmentEntity.F_EnabledMark = state;
                this.BaseRepository().Update(DepartmentEntity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        #endregion
    }
}
