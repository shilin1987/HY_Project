﻿using Dapper;
using Learun.Application.Base.SystemModule;
using Learun.Application.TwoDevelopment.HR_Code;
using Learun.Application.TwoDevelopment.Platform;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Learun.Application.Excel
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.01
    /// 描 述：Excel数据导入设置
    /// </summary>
    public class ExcelImportBLL :ExcelImportIBLL
    {
        private ExcelImportService excelImportService = new ExcelImportService();
        private DatabaseTableIBLL databaseTableIBLL = new DatabaseTableBLL();
        private DatabaseLinkIBLL databaseLinkIBLL = new DatabaseLinkBLL();
        private IndividualStandardItemIBLL insit = new IndividualStandardItemBLL();
        private DataItemIBLL dataItemIBLL = new DataItemBLL();
        private DataSourceIBLL dataSourceIBLL = new DataSourceBLL();

        #region 缓存定义
        private ICache cache = CacheFactory.CaChe();
        private string cacheKey = "learun_adms_excelError_";       // +公司主键
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件参数</param>
        /// <returns></returns>
        public IEnumerable<ExcelImportEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return excelImportService.GetPageList(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取导入配置列表根据模块ID
        /// </summary>
        /// <param name="moduleId">功能模块主键</param>
        /// <returns></returns>
        public IEnumerable<ExcelImportEntity> GetList(string moduleId)
        {
            try
            {
                return excelImportService.GetList(moduleId);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取配置信息实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public ExcelImportEntity GetEntity(string keyValue)
        {
            try
            {
                return excelImportService.GetEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取配置字段列表
        /// </summary>
        /// <param name="importId">配置信息主键</param>
        /// <returns></returns>
        public IEnumerable<ExcelImportFieldEntity> GetFieldList(string importId)
        {
            try
            {
                return excelImportService.GetFieldList(importId);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                excelImportService.DeleteEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体数据</param>
        /// <param name="filedList">字段列表</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, ExcelImportEntity entity, List<ExcelImportFieldEntity> filedList)
        {
            try
            {
                excelImportService.SaveEntity(keyValue, entity, filedList);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 更新配置主表
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        public void UpdateEntity(string keyValue, ExcelImportEntity entity)
        {
            try
            {
                excelImportService.UpdateEntity(keyValue, entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        #endregion

        #region 扩展方法
        /// <summary>
        /// excel 数据导入（未导入数据写入缓存）
        /// </summary>
        /// <param name="templateId">导入模板主键</param>
        /// <param name="fileId">文件ID</param>
        /// <param name="dt">导入数据</param>
        /// <returns></returns>
        public string ImportTable(string templateId, string fileId, DataTable dt)
        {
            int snum = 0;
            int fnum = 0;
            
            try
            {
                if (dt.Rows.Count > 0)
                {
                    ExcelImportEntity entity = GetEntity(templateId);
         
                    List<ExcelImportFieldEntity> list = (List<ExcelImportFieldEntity>)GetFieldList(templateId);
                    if (entity != null && list.Count > 0)
                    {
                        UserInfo userInfo = LoginUserInfo.Get();
                        // 获取当前表的所有字段
                        IEnumerable<DatabaseTableFieldModel> fieldList = databaseTableIBLL.GetTableFiledList(entity.F_DbId, entity.F_DbTable);
                        Dictionary<string, string> fieldMap = new Dictionary<string, string>();
                        foreach (var field in fieldList)// 遍历字段设置每个字段的数据类型
                        {
                            fieldMap.Add(field.f_column, field.f_datatype);
                        }
                        // 拼接导入sql语句
                        string sql = " INSERT INTO " + entity.F_DbTable + " (";
                        string sqlValue = "(";
                        bool isfirt = true;

                        foreach (var field in list)
                        {
                            if (!isfirt)
                            {
                                sql += ",";
                                sqlValue += ",";
                            }

                            sql += field.F_Name;
                            sqlValue += "@" + field.F_Name;
                            isfirt = false;
                        }

                        sql += " ) VALUES " + sqlValue + ")";
                        string sqlonly = " select * from " + entity.F_DbTable + " where ";

                        // 创建一个datatable容器用于保存导入失败的数据
                        DataTable failDt = new DataTable();
                        dt.Columns.Add("导入错误", typeof(string));
                        foreach (DataColumn dc in dt.Columns)
                        {
                            failDt.Columns.Add(dc.ColumnName, dc.DataType);
                        }

                        // 数据字典数据
                        Dictionary<string, List<DataItemDetailEntity>> dataItemMap = new Dictionary<string, List<DataItemDetailEntity>>();
                        // 循环遍历导入

                        foreach (DataRow dr in dt.Rows)
                        {
                            try
                            {
                                if (entity.F_DbTable.ToString() == "Hr_personalStandards_file")
                                {

                                    // databaseLinkIBLL.ExecuteBySql(entity.F_DbId, sql);
                                    insit.GetHrStandardList(dr[1].ToString(), decimal.Parse(dr[0].ToString()), decimal.Parse(dr[2].ToString()), decimal.Parse(dr[3].ToString()));

                                }
                                DataTable d = new DataTable();
                                DataTable isBlacke = new DataTable();
                                var dp = new DynamicParameters(new { });
                                string selectsql;
                                //考勤
                                if (entity.F_DbTable.ToString() == "Hy_hr_AttendanceSheet") {
                                    selectsql = "select * from " + entity.F_DbTable + " where  F_UserId=(select F_UserId from  dbo.lr_base_user where F_EnCode='" + dr[0] + "') and F_AttendanceMonth='" + dr[1] + "'";
                                    d = databaseLinkIBLL.FindTable(entity.F_DbId, selectsql, dp);
                                }
                                //五险一金
                                else if (entity.F_DbTable.ToString() == "Hy_hr_FiveInsurancesOneFund")
                                {
                                    selectsql = "select * from  " + entity.F_DbTable + " where  F_UserId=(select F_UserId from  dbo.lr_base_user where F_EnCode='" + dr[0] + "') and F_SettlementYearMonth='" + dr[1] + "'";
                                    d = databaseLinkIBLL.FindTable(entity.F_DbId, selectsql, dp);
                                }
                                //个税
                                else if (entity.F_DbTable.ToString() == "Hy_hr_PersonalIncomeTax")
                                {
                                    selectsql = "select * from  " + entity.F_DbTable + " where  F_UserId=(select F_UserId from  dbo.lr_base_user where F_EnCode='" + dr[0] + "') and F_PersonnalYearMonth='" + dr[1] + "'";
                                    d = databaseLinkIBLL.FindTable(entity.F_DbId, selectsql, dp);
                                }
                                //奖惩
                                else if (entity.F_DbTable.ToString() == "Hy_hr_RewardPunishment")
                                {
                                    int i;
                                    if (dr[5].ToString() == "收入（或奖励）") { i = 1; } else { i = 0; }
                                    selectsql = "select * from  " + entity.F_DbTable + " where  F_UserId=(select F_UserId from  dbo.lr_base_user where F_EnCode='" + dr[4] + "') and F_ItemId=(select  F_ItemId from  Hy_hr_OperationItems  where F_Item='" + dr[2] + "') and F_DateRewardPunishment ='" + dr[6] + "' and F_RewardorPunishment='" + i + "'";
                                    d = databaseLinkIBLL.FindTable(entity.F_DbId, selectsql, dp);
                                } else if (entity.F_DbTable.ToString() == "lr_base_user")
                                {
                                    selectsql = "select * from  " + entity.F_DbTable + "  where F_EnCode='" + dr[0] + "' and F_IDCard='" + dr[20] + "'";
                                    d = databaseLinkIBLL.FindTable(entity.F_DbId, selectsql, dp);
                                } else if (entity.F_DbTable.ToString() == "Hy_Recruit_Candidates")
                                {
                                    selectsql = "select * from  " + entity.F_DbTable + "  where  F_IDCard='" + dr[1] + "'";
                                    d = databaseLinkIBLL.FindTable(entity.F_DbId, selectsql, dp);
                                    selectsql = "select * from  Hy_Recruit_Blacklist  where  F_IDCard='" + dr[1] + "'";
                                    isBlacke = databaseLinkIBLL.FindTable(entity.F_DbId, selectsql, dp);
                                }
                                if (isBlacke.Rows.Count == 0)
                                {
                                    if (d.Rows.Count == 0)
                                    {
                                        foreach (var col in list)
                                        {
                                            string paramName = "@" + col.F_Name;
                                            DbType dbType = FieldTypeHepler.ToDbType(fieldMap[col.F_Name]);
                                            //var cellValue = dr[col.F_ColName];
                                            //判断是否为数据字典
                                            if (col.F_RelationType != 2)
                                            {
                                                if (string.IsNullOrEmpty(col.F_Value) && col.F_RelationType != 2) //导入没有设置默认值
                                                {
                                                    //判断是数字类型，并且模板里面该列是空的，那么赋一个默认值
                                                    if ((dbType.Equals(DbType.Int32) || dbType == DbType.Decimal || dbType == DbType.Double) && (dr[col.F_ColName] == null || dr[col.F_ColName].ToString() == ""))
                                                    {
                                                        dr[col.F_ColName] = 0.00;
                                                    }
                                                }
                                            }
                                            switch (col.F_RelationType)
                                            {
                                                case 0://无关联
                                                    dp.Add(col.F_Name, dr[col.F_ColName], dbType);
                                                    IsOnlyOne(col, sqlonly, dr[col.F_ColName].ToString(), entity.F_DbId, dbType);
                                                    break;
                                                case 1://GUID
                                                    dp.Add(col.F_Name, Guid.NewGuid().ToString(), dbType);
                                                    break;
                                                case 2://数据字典
                                                    string dataItemName = "";
                                                    if (!dataItemMap.ContainsKey(col.F_DataItemCode))
                                                    {
                                                        List<DataItemDetailEntity> dataItemList = dataItemIBLL.GetDetailList(col.F_DataItemCode);
                                                        dataItemMap.Add(col.F_DataItemCode, dataItemList);
                                                    }
                                                    dataItemName = FindDataItemValue(dataItemMap[col.F_DataItemCode], dr[col.F_ColName].ToString(), col.F_ColName);
                                                    dp.Add(col.F_Name, dataItemName, dbType);
                                                    IsOnlyOne(col, sqlonly, dataItemName, entity.F_DbId, dbType);
                                                    break;
                                                case 3://数据表
                                                    string v = "";
                                                    try
                                                    {
                                                        string[] dataSources = col.F_DataSourceId.Split(',');
                                                        string strWhere = " " + dataSources[1] + " =@" + dataSources[1];
                                                        string queryJson = "{" + dataSources[1] + ":\"" + dr[col.F_ColName].ToString() + "\"}";
                                                        DataTable sourceDt = dataSourceIBLL.GetDataTable(dataSources[0], strWhere, queryJson);
                                                        if (sourceDt.Rows.Count > 0)
                                                        {
                                                            v = sourceDt.Rows[0][0].ToString();
                                                        }
                                                        else { v = "无"; }

                                                        dp.Add(col.F_Name, v, dbType);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        throw (new Exception("【" + col.F_ColName + "】 找不到对应的数据"));
                                                    }
                                                    IsOnlyOne(col, sqlonly, v, entity.F_DbId, dbType);
                                                    break;
                                                case 4://固定值
                                                    dp.Add(col.F_Name, col.F_Value, dbType);
                                                    break;
                                                case 5://操作人ID
                                                    dp.Add(col.F_Name, userInfo.userId, dbType);
                                                    break;
                                                case 6://操作人名字
                                                    dp.Add(col.F_Name, userInfo.realName, dbType);
                                                    break;
                                                case 7://操作时间
                                                    dp.Add(col.F_Name, DateTime.Now, dbType);
                                                    break;
                                            }
                                        }

                                        //个人标准工资项
                                        if (entity.F_DbTable.ToString() == "Hr_personalStandards_file")
                                        {
                                            // databaseLinkIBLL.ExecuteBySql(entity.F_DbId, sql);
                                        }
                                        else
                                        {
                                            databaseLinkIBLL.ExecuteBySql(entity.F_DbId, sql, dp);
                                        }

                                        snum++;
                                    }
                                }
                                else
                                {
                                    dr["导入错误"] = "身份证号:" + dr[1] + "存在于黑名单中，无法导入！";
                                    failDt.Rows.Add(dr.ItemArray);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                fnum++;
                                if (entity.F_ErrorType == 0)// 如果错误机制是终止
                                {
                                    dr["导入错误"] = ex.Message + "【之后数据未被导入】";
                                    failDt.Rows.Add(dr.ItemArray);
                                    break;
                                }
                                else
                                {
                                    dr["导入错误"] = ex.Message;
                                    failDt.Rows.Add(dr.ItemArray);
                                }
                            }
                        }

                        // 写入缓存如果有未导入的数据
                        if (failDt.Rows.Count > 0)
                        {
                            string errordt = failDt.ToJson();

                            cache.Write<string>(cacheKey + fileId, errordt, CacheId.excel);
                        }
                    }
                }


                return snum + "|" + fnum;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取excel导入的错误数据
        /// </summary>
        /// <param name="fileId">文件主键</param>
        /// <returns></returns>
        public DataTable GetImportError(string fileId)
        {
            try
            {
                string strdt = cache.Read<string>(cacheKey + fileId, CacheId.excel);
                DataTable dt = strdt.ToObject<DataTable>();
                cache.Remove(cacheKey + fileId, CacheId.excel);
                return dt;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }


        /// <summary>
        /// 数据字典查找Value
        /// </summary>
        /// <param name="dataItemList">数据字典数据</param>
        /// <param name="itemName">项目名</param>
        /// <param name="colName">列名</param>
        /// <returns></returns>
        private string FindDataItemValue(List<DataItemDetailEntity> dataItemList, string itemName, string colName)
        {
            DataItemDetailEntity dataItem = dataItemList.Find(t => t.F_ItemName == itemName);
            if (dataItem != null)
            {
                return dataItem.F_ItemValue;
            }
            else
            {
                throw (new Exception("【" + colName + "】数据字典找不到对应值"));
            }
        }

        /// <summary>
        /// 判断是否数据有重复
        /// </summary>
        /// <param name="col"></param>
        /// <param name="sqlonly"></param>
        /// <param name="value"></param>
        /// <param name="dbId"></param>
        private void IsOnlyOne(ExcelImportFieldEntity col, string sqlonly, string value, string dbId, DbType dbType)
        {
            if (col.F_OnlyOne == 1)
            {
                var dp = new DynamicParameters(new { });
                sqlonly += col.F_Name + " = @" + col.F_Name;
                dp.Add(col.F_Name, value, dbType);
                var d = databaseLinkIBLL.FindTable(dbId, sqlonly, dp);
                if (d.Rows.Count > 0)
                {
                    throw new Exception("【" + col.F_ColName + "】此项数据不能重复");
                }
            }
        }
        /// <summary>
        /// 根据实际获取字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filedArray"></param>
        /// <returns></returns>
        public IEnumerable<ExcelImportFieldEntity> GetModelFieldList(string id, string[] filedArray)
        {
            try
            {
                var dataArray = excelImportService.GetFiledsList(filedArray);
                return excelImportService.GetModelFieldList(id, filedArray).Where(e => dataArray.Contains(e.F_Name));
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        public string ImportUserTable(string templateId, string fileId, DataTable dt, string[] filedArray)
        {
            int snum = 0;
            int fnum = 0;

            try
            {
                if (dt.Rows.Count > 0)
                {
                    ExcelImportEntity entity = GetEntity(templateId);
                    var dataArray = excelImportService.GetFiledsList(filedArray);
                    List<ExcelImportFieldEntity> list = new List<ExcelImportFieldEntity>();
                    var datas = GetFieldList(templateId).ToList();
                    foreach (var data in datas){
                        list.Add(data);
                    }
                    list = list.Where(e => dataArray.Contains(e.F_Name)).ToList(); ;

                    if (entity != null && list.Count() > 0)
                    {
                        UserInfo userInfo = LoginUserInfo.Get();
                        // 获取当前表的所有字段
                        IEnumerable<DatabaseTableFieldModel> fieldList = databaseTableIBLL.GetTableFiledList(entity.F_DbId, entity.F_DbTable);
                        Dictionary<string, string> fieldMap = new Dictionary<string, string>();
                        foreach (var field in fieldList)// 遍历字段设置每个字段的数据类型
                        {
                            fieldMap.Add(field.f_column, field.f_datatype);
                        }
                        // 拼接导入sql语句
                        string sql = " UPDATE " + entity.F_DbTable + " SET ";
                        bool isfirt = true;

                        foreach (var field in list)
                        {
                            if (!isfirt)
                            {
                                sql += ",";
                            }

                            sql += field.F_Name.Replace("@", "") + "= @" + field.F_Name;
                            isfirt = false;
                        }
                        sql += " WHERE F_EnCode=@F_EnCode ";
                        string sqlonly = " select * from " + entity.F_DbTable + " where ";

                        // 创建一个datatable容器用于保存导入失败的数据
                        DataTable failDt = new DataTable();
                        dt.Columns.Add("导入错误", typeof(string));
                        foreach (DataColumn dc in dt.Columns)
                        {
                            failDt.Columns.Add(dc.ColumnName, dc.DataType);
                        }

                        // 数据字典数据
                        Dictionary<string, List<DataItemDetailEntity>> dataItemMap = new Dictionary<string, List<DataItemDetailEntity>>();
                        // 循环遍历导入

                        foreach (DataRow dr in dt.Rows)
                        {
                            try
                            {
                                if (entity.F_DbTable.ToString() == "Hr_personalStandards_file")
                                {

                                    // databaseLinkIBLL.ExecuteBySql(entity.F_DbId, sql);
                                    insit.GetHrStandardList(dr[1].ToString(), decimal.Parse(dr[0].ToString()), decimal.Parse(dr[2].ToString()), decimal.Parse(dr[3].ToString()));

                                }
                                DataTable d = new DataTable();
                                DataTable isBlacke = new DataTable();
                                var dp = new DynamicParameters(new { });
                                string selectsql;
                                //人员基础资料
                                if (entity.F_DbTable.ToString() == "lr_base_user")
                                {
                                    selectsql = "select * from  " + entity.F_DbTable + "  where F_EnCode='" + dr[0] + "'";
                                    d = databaseLinkIBLL.FindTable(entity.F_DbId, selectsql, dp);
                                }
                                else if (entity.F_DbTable.ToString() == "Hy_Recruit_Candidates")
                                {
                                    selectsql = "select * from  " + entity.F_DbTable + "  where  F_IDCard='" + dr[1] + "'";
                                    d = databaseLinkIBLL.FindTable(entity.F_DbId, selectsql, dp);
                                    selectsql = "select * from  Hy_Recruit_Blacklist  where  F_IDCard='" + dr[1] + "'";
                                    isBlacke = databaseLinkIBLL.FindTable(entity.F_DbId, selectsql, dp);
                                }
                                if (isBlacke.Rows.Count == 0)
                                {
                                    if (d.Rows.Count > 0)
                                    {
                                        foreach (var col in list)
                                        {
                                            string paramName = "@" + col.F_Name;
                                            DbType dbType = FieldTypeHepler.ToDbType(fieldMap[col.F_Name]);
                                           // var cellValue = dr["登录账户"];
                                            //判断是否为数据字典
                                 
                                            if (col.F_RelationType != 2)
                                            {
                                                if (string.IsNullOrEmpty(col.F_Value) && col.F_RelationType != 2) //导入没有设置默认值
                                                {
                                                    //判断是数字类型，并且模板里面该列是空的，那么赋一个默认值
                                                    if ((dbType.Equals(DbType.Int32) || dbType == DbType.Decimal || dbType == DbType.Double) && (dr[col.F_ColName] == null || dr[col.F_ColName].ToString() == ""))
                                                    {
                                                        dr[col.F_ColName] = 0.00;
                                                    }
                                                }
                                            }
                                            switch (col.F_RelationType)
                                            {
                                                case 0://无关联
                                                    dp.Add(col.F_Name, dr[col.F_ColName], dbType);
                                                    IsOnlyOne(col, sqlonly, dr[col.F_ColName].ToString(), entity.F_DbId, dbType);
                                                    break;
                                                case 1://GUID
                                                    dp.Add(col.F_Name, Guid.NewGuid().ToString(), dbType);
                                                    break;
                                                case 2://数据字典
                                                    string dataItemName = "";
                                                    if (!dataItemMap.ContainsKey(col.F_DataItemCode))
                                                    {
                                                        List<DataItemDetailEntity> dataItemList = dataItemIBLL.GetDetailList(col.F_DataItemCode);
                                                        dataItemMap.Add(col.F_DataItemCode, dataItemList);
                                                    }
                                                    dataItemName = FindDataItemValue(dataItemMap[col.F_DataItemCode], dr[col.F_ColName].ToString(), col.F_ColName);
                                                    dp.Add(col.F_Name, dataItemName, dbType);
                                                    IsOnlyOne(col, sqlonly, dataItemName, entity.F_DbId, dbType);
                                                    break;
                                                case 3://数据表
                                                    string v = "";
                                                    try
                                                    {
                                                        string[] dataSources = col.F_DataSourceId.Split(',');
                                                        string strWhere = " " + dataSources[1] + " =@" + dataSources[1];
                                                        string queryJson = "{" + dataSources[1] + ":\"" + dr[col.F_ColName].ToString() + "\"}";
                                                        DataTable sourceDt = dataSourceIBLL.GetDataTable(dataSources[0], strWhere, queryJson);
                                                        if (sourceDt.Rows.Count > 0)
                                                        {
                                                            v = sourceDt.Rows[0][0].ToString();
                                                        }
                                                        else { v = "无"; }

                                                        dp.Add(col.F_Name, v, dbType);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        throw (new Exception("【" + col.F_ColName + "】 找不到对应的数据"));
                                                    }
                                                    IsOnlyOne(col, sqlonly, v, entity.F_DbId, dbType);
                                                    break;
                                                case 4://固定值
                                                    dp.Add(col.F_Name, col.F_Value, dbType);
                                                    break;
                                                case 5://操作人ID
                                                    dp.Add(col.F_Name, userInfo.userId, dbType);
                                                    break;
                                                case 6://操作人名字
                                                    dp.Add(col.F_Name, userInfo.realName, dbType);
                                                    break;
                                                case 7://操作时间
                                                    dp.Add(col.F_Name, DateTime.Now, dbType);
                                                    break;
                                            }
                                        }

                                        //个人标准工资项
                                        if (entity.F_DbTable.ToString() == "Hr_personalStandards_file")
                                        {
                                            // databaseLinkIBLL.ExecuteBySql(entity.F_DbId, sql);
                                        }
                                        else
                                        {
                                            databaseLinkIBLL.ExecuteBySql(entity.F_DbId, sql, dp);
                                        }

                                        snum++;
                                    }
                                    else
                                    {
                                        dr["导入错误"] = "工号:" + dr[1] + "不存在！";
                                        failDt.Rows.Add(dr.ItemArray);
                                        break;
                                    }
                                }
                                else
                                {
                                    dr["导入错误"] = "身份证号:" + dr[1] + "存在于黑名单中，无法导入！";
                                    failDt.Rows.Add(dr.ItemArray);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                fnum++;
                                if (entity.F_ErrorType == 0)// 如果错误机制是终止
                                {
                                    dr["导入错误"] = ex.Message + "【之后数据未被导入】";
                                    failDt.Rows.Add(dr.ItemArray);
                                    break;
                                }
                                else
                                {
                                    dr["导入错误"] = ex.Message;
                                    failDt.Rows.Add(dr.ItemArray);
                                }
                            }
                        }

                        // 写入缓存如果有未导入的数据
                        if (failDt.Rows.Count > 0)
                        {
                            string errordt = failDt.ToJson();

                            cache.Write<string>(cacheKey + fileId, errordt, CacheId.excel);
                        }
                    }
                }


                return snum + "|" + fnum;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        #endregion
    }
}
