﻿
using Learun.Application.Organization.ReturnModel;
using Learun.Application.TwoDevelopment.Platform.RecruitSubProcessEntity;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.Platform.WL_BaseService
{
    /// <summary>
    /// 作业员招聘Base类
    /// </summary>
  public  class BaseService: RepositoryFactory
    {
        /// <summary>
        /// 根据当前流程节点找上一个和下一个流程节点
        /// </summary>
        /// <param name="CurrentProcessId">子流程Id</param>
        /// <returns></returns>
        public ReturnCommon<OutPutProcessModel> GetProcessInfo(string subProcessId) 
        {
            var msg = new ReturnCommon<OutPutProcessModel>();
            //不能乱删,表示节点是否执行失败
            msg.Status = true;
            try
            {
                var previousProcessId = string.Empty;
                var nextProcessId = string.Empty;
                var returnProcessModel = new OutPutProcessModel();

                var strSql = string.Format(@"SELECT  [MainProcessId],b.ProcessName MainProcessName,
                                        b.PorcessSort MainprocessSort,a.[ID] SubProcessId
                                        ,[Name] SubProcessName,[Sort] SubProcessSort,b.Remark MainProcessRemark
                                        ,a.[Remark] SubProcessRemark,[ParentId]
                                        FROM [HYDatabase].[dbo].[Hy_Recruit_SubProcess] a 
                                        left join [dbo].[Hy_Recruit_MainProcess] b on a.MainProcessId=b.ID order by MainprocessSort asc");

                var processModel = this.BaseRepository().FindList<MainSubProcessModel>(strSql);
                if (processModel.Count()>0)
                {
                    var processModelBySubProcessId = processModel.Where(e=>e.SubProcessId== subProcessId);
                    if (processModelBySubProcessId.Count()>0)
                    {
                        //表示流程开始第一个节点
                        if (processModelBySubProcessId.FirstOrDefault().MainprocessSort == 1 && processModelBySubProcessId.FirstOrDefault().SubProcessSort == 1)
                        {
                            var newPModel = processModel.Where(e => e.SubProcessId == "2").FirstOrDefault();
                            nextProcessId = newPModel.SubProcessId;
                            returnProcessModel.NextProcessName = newPModel.SubProcessName;
                            returnProcessModel.NextProcessId = Convert.ToInt32(newPModel.SubProcessId);
                            msg.Data = returnProcessModel;
                            return msg;
                        }
                        else 
                        {
                            var pcurrentSubId = (Convert.ToInt32(subProcessId)-1).ToString();
                            var newPModel = processModel.Where(e => e.SubProcessId == pcurrentSubId).FirstOrDefault();
                            returnProcessModel.PreviousProcessId = Convert.ToInt32(newPModel.SubProcessId);
                            returnProcessModel.PreviousProcessName = newPModel.SubProcessName;

                            var ncurrentSubId = (Convert.ToInt32(subProcessId) + 1).ToString();
                            newPModel = processModel.Where(e => e.SubProcessId == ncurrentSubId).FirstOrDefault();
                            if (newPModel == null)
                            {
                                //最后一个节点
                                nextProcessId = "";
                                returnProcessModel.NextProcessName = "";
                   
                            }
                            else
                            {
                                returnProcessModel.NextProcessId = Convert.ToInt32(newPModel.SubProcessId);
                                returnProcessModel.NextProcessName = newPModel.SubProcessName;
                            }
                            msg.Data = returnProcessModel;
                            return msg;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                msg.Status = false;
                msg.Message = ex.Message;
            }

            return msg;
        }
        /// <summary>
        /// 查询多应子流程id
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public Hy_Recruit_SubProcessEntity getHy_Recruit_SubProcessEntity(string processName)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_Recruit_SubProcessEntity>(t => t.Name == processName);
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

    }
}
