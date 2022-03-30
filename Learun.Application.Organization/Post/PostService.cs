﻿using Learun.DataBase.Repository;
using Learun.Util;
using Learun.Util.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learun.Application.Organization
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.03.04
    /// 描 述：岗位管理
    /// </summary>
    public class PostService : RepositoryFactory
    {
        #region 构造函数和属性
        private string fieldSql;
        public PostService()
        {
            fieldSql = @"
                    t.F_PostId,
                    t.F_ParentId,
                    t.F_Name,
                    t.F_EnCode,
                    t.F_CompanyId,
                    t.F_DepartmentId,
                    t.F_DeleteMark,
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
        /// 获取岗位数据列表（岗位下拉框）
        /// </summary>
        /// <param name="companyId">公司主键</param>
        /// <returns></returns>
        public IEnumerable<APPDropDownListModel> GetPostList()
        {
            try
            {
                var sql = "select  F_PostId [value],F_Name text from lr_base_post";
                return this.BaseRepository().FindList<APPDropDownListModel>(sql);
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
        /// 获取岗位数据列表（根据公司列表）
        /// </summary>
        /// <param name="companyId">公司主键</param>
        /// <returns></returns>
        public IEnumerable<PostEntity> GetList(string companyId)
        {
            try
            {
                var sql = "select F_DepartmentId from  lr_base_department where F_ParentId='"+companyId+"'";
                var list=this.BaseRepository().FindList<DepartmentEntity>(sql);
                List<String> listid = new List<string>();
                List<String> alllist = new List<string>();
                foreach (var item in list) 
                {
                    listid.Add(item.F_DepartmentId);
                }
                foreach (var i in listid) {
                    var alist = this.BaseRepository().FindList<DepartmentEntity>(t => i.ToString().Contains(t.F_ParentId));
                    foreach (var l in alist) {
                        alllist.Add(l.F_DepartmentId);
                    }
                }
                listid.AddRange(alllist);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                if (listid.Count <=1) { 
                strSql.Append(" FROM LR_Base_Post t WHERE (t.F_DeleteMark = 0 or t.F_DeleteMark is null) AND (t.F_DepartmentId =@companyId or t.F_CompanyId=@companyId) ");
                }
                else {
                    int i = 1;
                    strSql.Append(" FROM LR_Base_Post t WHERE (t.F_DeleteMark = 0 or t.F_DeleteMark is null) AND ");
                    foreach (var item in listid)
                   {
                    strSql.Append(" t.F_DepartmentId ='" + item.ToString()+ "'");
                        if (i < listid.Count) 
                        {
                            strSql.Append(" or ");
                        }
                        i++;
                   }
                }
                strSql.Append(" ORDER BY t.F_DepartmentId,t.F_ParentId,t.F_EnCode");
                return this.BaseRepository().FindList<PostEntity>(strSql.ToString(), new { companyId = companyId });
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
        /// 获取岗位数据列表(根据主键串)
        /// </summary>
        /// <param name="postIds">根据主键串</param>
        /// <returns></returns>
        public IEnumerable<PostEntity> GetListByPostIds(string postIds)
        {
            try
            {
                return this.BaseRepository().FindList<PostEntity>(t => postIds.Contains(t.F_PostId));
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
        /// 获取岗位的实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public PostEntity GetEntity(string keyValue) {
            try
            {
                return this.BaseRepository().FindEntity<PostEntity>(keyValue);
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
        /// 根据部门ID获取岗位信息
        /// </summary>
        /// <param name="DepId">部门ID</param>
        /// <returns></returns>
        public IEnumerable<PostEntity> GetPostListByDepId(string DepId)
        {
            try
            {
                return this.BaseRepository().FindList<PostEntity>(t => t.F_DepartmentId == DepId);
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
        /// 获取下级岗位id集合
        /// </summary>
        /// <param name="parentIds">父级Id集合</param>
        /// <returns></returns>
        public List<string> GetIdList(List<string> parentIds)
        {
            try
            {
                List<string> res = new List<string>();
                var list = this.BaseRepository().FindList<PostEntity>(t => parentIds.Contains(t.F_ParentId));
                foreach (var item in list) {
                    res.Add(item.F_PostId);
                }
                return res;
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
        /// 虚拟删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void VirtualDelete(string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                PostEntity entity = new PostEntity()
                {
                    F_PostId = keyValue,
                    F_DeleteMark = 1
                };
                db.Update(entity);
                db.ExecuteBySql(" Delete  From LR_BASE_USERRELATION where F_OBJECTID = @keyValue  ", new { keyValue = keyValue });

                //db.Delete<UserRelationEntity>(t=>t.F_ObjectId == keyValue);

                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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
        /// 保存岗位（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="postEntity">岗位实体</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, PostEntity postEntity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    postEntity.Modify(keyValue);
                    this.BaseRepository().Update(postEntity);
                }
                else
                {
                    postEntity.Create();
                    this.BaseRepository().Insert(postEntity);
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
        #endregion
    }
}
