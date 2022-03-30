using Dapper;
using Learun.Application.TwoDevelopment.HR_Code.Common;
using Learun.Application.TwoDevelopment.HR_Code.EverybodyStandardWage;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;


namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-15 10:19
    /// 描 述：个人标准工资维护
    /// </summary>
    public class EverybodyStandardWageService : RepositoryFactory
    {
        private ReturnCommon _return;
        private IFormulaDisassembly formula;
        public EverybodyStandardWageService()
        {
            _return = new ReturnCommon();
            formula = new FormulaDisassembly();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f_userid"></param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_EverybodyStandardWageEntity> GetHyPageList(string f_userid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_UserId,
                t.F_StandardWage
                ");
                strSql.Append("  FROM Hy_hr_EverybodyStandardWage t ");
                strSql.Append("  WHERE 1=1  and t.F_UserId = '"+ f_userid + "' ");
                return this.BaseRepository().FindList<Hy_hr_EverybodyStandardWageEntity>(strSql.ToString());
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
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_EverybodyStandardWageEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_UserId,
                t.F_StandardWage
                ");
                strSql.Append("  FROM Hy_hr_EverybodyStandardWage t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_CreateDate >= @startTime AND t.F_CreateDate <= @endTime ) ");
                }
                if (!queryParam["F_UserId"].IsEmpty())
                {
                    dp.Add("F_UserId", queryParam["F_UserId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_UserId = @F_UserId ");
                }
                if (!queryParam["F_StandardWage"].IsEmpty())
                {
                    dp.Add("F_StandardWage", "%" + queryParam["F_StandardWage"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_StandardWage Like @F_StandardWage ");
                }
                return this.BaseRepository().FindList<Hy_hr_EverybodyStandardWageEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取页面显示列表数据(标准工资子项)并计算子项非固定项目金额
        /// <summary>
        /// <param name="fid">查询参数</param>
        /// <returns></returns>
        public IEnumerable<EverybodyStandardWageSubDTO> GetSubList(string fid, decimal fcost)
        {
            try
            {
                var strSql = string.Format(@"SELECT b.F_Item SubItem,a.F_ID Id,a.F_Cost SubCost,a.F_IsFixedCost IsFixedCost,a.F_Formula Formula FROM Hy_hr_StandardWage a 
                                            left join Hy_hr_OperationItems b on a.F_ItemId = b.F_ItemId UNION
							                select b.F_Item SubItem,a.F_ID Id,a.F_Cost SubCost,2 IsFixedCost,'' Formula from 	Hy_hr_EverybodyStandardWageSub a
							                left join Hy_hr_OperationItems b on a.F_ItemId = b.F_ItemId where F_EverybodyStandardWageId='{0}'", fid);

                ///1.找到所涉及项目
                ///2.将这些项目对应的金额替换到表达式中
                ///3.替换掉其他符号@。
                ///4.生成数字运算并计算结果

                var result = this.BaseRepository().FindList<EverybodyStandardWageSubDTO>(strSql);

                //所有项目
                var items = this.BaseRepository().FindList<Hy_hr_OperationItemsEntity>();

                //通过表达式计算金额
                foreach (var item in result)
                {
                    //非固定项费用计算
                    if (item.IsFixedCost == 0 && !string.IsNullOrEmpty(item.Formula))
                    {
                        var formulaArray = item.Formula.Split('@');
                        decimal cost = fcost;
                        // decimal previousCost = fcost;
                        var exceptionInfo = string.Empty;//记录计算过程中的异常信息
                        for (var i = 0; i < formulaArray.Length; i++)
                        {
                            //标准工资已经初始化，计算公式开始必须是标准工资费用。
                            if (i > 0)
                            {
                                //判断奇偶数来区分项目和运算符
                                if (Convert.ToBoolean(i % 2))
                                {
                                    decimal nextItemCost = 0;
                                    decimal outVal = 0;
                                    var formulaCost = decimal.TryParse(formulaArray[i + 1], out outVal);
                                    if (!formulaCost)
                                    {
                                        var isExist = result.Where(e => e.SubItem == formulaArray[i + 1]);
                                        if (isExist.Count() > 0)
                                        {
                                            nextItemCost = Convert.ToDecimal(isExist.FirstOrDefault().SubCost);
                                        }
                                        else
                                        {
                                            exceptionInfo += "未找到(" + formulaArray[i + 1] + ")金额;";
                                            //return msg;
                                            //没有找到就从个人标准工资中找 
                                        }
                                    }
                                    else
                                    {
                                        nextItemCost = Convert.ToDecimal(formulaArray[i + 1]);
                                    }

                                    if (formulaArray[i] == "加法")
                                    {
                                        cost += nextItemCost;
                                    }
                                    if (formulaArray[i] == "减法")
                                    {
                                        cost -= nextItemCost;
                                    }
                                    if (formulaArray[i] == "乘法")
                                    {
                                        cost *= nextItemCost;
                                    }
                                    if (formulaArray[i] == "除法")
                                    {
                                        cost /= nextItemCost;
                                    }
                                }
                            }
                        }

                        item.SubCost = Convert.ToDouble(cost);
                        item.Remark = exceptionInfo;
                    }
                }


                return result;
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
        /// 获取Hy_hr_EverybodyStandardWage表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_EverybodyStandardWageEntity GetHy_hr_EverybodyStandardWageEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_EverybodyStandardWageEntity>(keyValue);
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
        /// 获取Hy_hr_PostLevelEntity表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_PostLevelEntity GetHy_hr_PostLevelEntityEntity(string userId)
        {
            try
            {
                var strSql = string.Format(@"SELECT b.F_ID PostLevelId,b.F_PostSalaryMinimum,b.F_PostSalaryMaximum,F_BasePay FROM [dbo].[lr_base_user] a
                                             left join [dbo].[Hy_hr_PostLevel] b on a.F_PayModel=b.F_PostlevelCode where F_UserId='{0}'", userId);
                var postLevelModel = this.BaseRepository().FindList<Hy_hr_PostLevelEntity>(strSql);
                if (postLevelModel.Count() > 0)
                {
                    return postLevelModel.FirstOrDefault();
                }
                else
                {
                    return null;
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
        /// 获取Hy_hr_EverybodyStandardWageSub表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_EverybodyStandardWageSubEntity GetHy_hr_EverybodyStandardWageSubEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_EverybodyStandardWageSubEntity>(keyValue);
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
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon DeleteEntity(string keyValue)
        {
            try
            {
                var isDel = this.BaseRepository().Delete<Hy_hr_EverybodyStandardWageEntity>(t => t.F_ID == keyValue);
                if (isDel > 0)
                {
                    _return.Status = true;
                    _return.Message = "删除成功";

                    //删除子项
                    isDel = this.BaseRepository().Delete<Hy_hr_EverybodyStandardWageSubEntity>(t => t.F_EverybodyStandardWageId == keyValue);
                }
                else
                {
                    _return.Status = false;
                    _return.Message = "删除失败";
                }
            }
            catch (Exception ex)
            {
                _return.Status = false;
                _return.Message = ex.Message;
            }

            return _return;
        }

        /// <summary>
        /// 删除子项实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon DeleteSubEntity(string keyValue)
        {
            try
            {
                var isDel = this.BaseRepository().Delete<Hy_hr_EverybodyStandardWageSubEntity>(t => t.F_ID == keyValue);
                if (isDel > 0)
                {
                    _return.Status = true;
                    _return.Message = "删除成功";
                }
                else
                {
                    _return.Status = false;
                    _return.Message = "删除失败";
                }
            }
            catch (Exception ex)
            {
                _return.Status = false;
                _return.Message = ex.Message;
            }

            return _return;
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <param name="keyValue"></param>
        /// <param name="basePay"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnCommon SaveEntity(string keyValue, string basePay, Hy_hr_EverybodyStandardWageEntity entity)
        {
            try
            {
                int addOrEdit = 0;
                var parentId = string.Empty;
                var basePayItemId = string.Empty;

                //先找到基本工资项ID
                var itemModel = this.BaseRepository().FindEntity<Hy_hr_OperationItemsEntity>(t => t.F_Item == "基本工资");
                if (itemModel == null)
                {
                    _return.Status = false;
                    _return.Message = "请先在薪资项目中维护（基本工资）这一项";
                    return _return;
                }
                else
                {
                    basePayItemId = itemModel.F_ItemId;
                }


                var isExistItem = this.BaseRepository().FindEntity<Hy_hr_EverybodyStandardWageEntity>(t => t.F_UserId == entity.F_UserId);
                //修改
                if (!string.IsNullOrEmpty(keyValue))
                {
                    if (isExistItem != null && isExistItem.F_ID != keyValue)
                    {
                        _return.Status = false;
                        _return.Message = "已存在相同数据";
                        return _return;
                    }
                    else
                    {
                        parentId = isExistItem.F_ID;
                        entity.Modify(keyValue);
                        addOrEdit = this.BaseRepository().Update(entity);
                    }
                }
                //添加
                else
                {
                    if (isExistItem != null)
                    {
                        _return.Status = false;
                        _return.Message = "已存在相同数据";
                        return _return;
                    }
                    else
                    {
                        entity.Create();
                        addOrEdit = this.BaseRepository().Insert(entity);

                        if (addOrEdit > 0)
                        {
                            parentId = this.BaseRepository().FindEntity<Hy_hr_EverybodyStandardWageEntity>(t => t.F_UserId == entity.F_UserId).F_ID;

                            var hy_Hr_Everybody = new Hy_hr_EverybodyStandardWageSubEntity()
                            {
                                F_ItemId = basePayItemId,
                                F_Cost = Convert.ToDecimal(basePay)
                            };

                            _return=SaveSubEntity(null, parentId, hy_Hr_Everybody);
                        }
                    }
                }
                if (addOrEdit > 0)
                {
                    _return.Status = true;
                    _return.Message = "保存成功";
                }
                else
                {
                    _return.Status = false;
                    _return.Message = "保存失败";
                }
            }
            catch (Exception ex)
            {
                _return.Status = false;
                _return.Message = ex.Message;
            }

            return _return;
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon SaveSubEntity(string subId, string parentId, Hy_hr_EverybodyStandardWageSubEntity entity)
        {
            try
            {
                int addOrEdit = 0;
                //1.此项目是否标准通用项目，是则不能添加
                var isExistCommonItem = this.BaseRepository().FindEntity<Hy_hr_StandardWageEntity>(t => t.F_ItemId == entity.F_ItemId);
                if (isExistCommonItem != null)
                {
                    _return.Status = false;
                    _return.Message = "此子项为通用项,已在标准工资通用项中维护.";
                    return _return;
                }

                //判断是否已存在
                var isExistItem = this.BaseRepository().FindEntity<Hy_hr_EverybodyStandardWageSubEntity>(t => t.F_EverybodyStandardWageId == parentId && t.F_ItemId == entity.F_ItemId);

                //添加
                if (string.IsNullOrEmpty(subId))
                {
                    if (isExistItem != null)
                    {
                        _return.Status = false;
                        _return.Message = "已存在相同数据";
                        return _return;
                    }
                    else
                    {
                        entity.F_EverybodyStandardWageId = parentId;
                        entity.Create();
                        addOrEdit = this.BaseRepository().Insert(entity);
                    }
                }
                //修改
                else
                {
                    if (isExistItem != null && isExistItem.F_ID != subId)
                    {
                        _return.Status = false;
                        _return.Message = "已存在相同数据";
                        return _return;
                    }
                    else
                    {
                        entity.Modify(subId);
                        addOrEdit = this.BaseRepository().Update(entity);
                    }
                }

                if (addOrEdit > 0)
                {
                    _return.Status = true;
                    _return.Message = "保存成功";
                }
                else
                {
                    _return.Status = false;
                    _return.Message = "保存失败";
                }
            }
            catch (Exception ex)
            {
                _return.Status = false;
                _return.Message = ex.Message;
            }

            return _return;
        }

        #endregion

    }
}
