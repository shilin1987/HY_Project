﻿using Learun.Application.TwoDevelopment.Platform;
using Learun.Cache.Base;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi_EmployeeInformationEntry.DataBase;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.BLL
{
    public class InterviewService : BaseService
    {
        /// <summary>
        /// 查询面试环节人员信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApiModel> SelectInteriewInfo()
        {
            var AllList = new ALLInterviewModele();
            try
            {
                //面试人员查询
                var sql = @"select a.F_UserId value, a.F_RealName text from Hy_Recruit_Candidates  a  left join Hy_Recruit_ProcessOperation b
                            on a.F_UserId=b.CandidatesId where OperationStatus=0 and SubProcessId=6 ";
                var InterviewModel = await hYDatabase.Database.SqlQuery<InterviewModele>(sql).ToListAsync();

                if (InterviewModel.Count() > 0)
                {
                    //面试题查询
                    var sqlInterviewQuestion = @" select F_Question,F_Answer from  dbo.Hy_Recruit_InterviewQuestionBank";
                    var InterviewQuestionList = await hYDatabase.Database.SqlQuery<Hy_Recruit_InterviewQuestionBankEntity>(sqlInterviewQuestion).ToListAsync();

                    AllList.InterviewModeleor = InterviewModel;
                    AllList.InterviewQuestionBank = InterviewQuestionList;
                    result.code = ResponseCode.success;
                    result.data = AllList;
                }
                else
                {
                    result.info = "未找到可面试人员信息";
                }
            }
            catch (Exception ex)
            {
                result.info = ex.Message;
            }
            return result;
        }
        /// <summary>
        /// 根据ID查询面试者信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApiModel> SelectUserInfo(string userName)
        {
            if (userName != null)
            {
                try
                {
                    //找到当前面试人员
                    var candidatesEntity = from h in hYDatabase.Hy_Recruit_Candidates
                                           join o in hYDatabase.Hy_Recruit_ProcessOperation
                                           on h.F_UserId equals o.CandidatesId
                                           where o.SubProcessId == "6" && o.OperationStatus == 0
                                           && h.F_RealName == userName
                                           select h;

                    if (candidatesEntity.Count() > 0)
                    {
                        var interviewEntity = hYDatabase.Hy_Recruit_Interview.Where(e => e.F_CandidatesID == candidatesEntity.FirstOrDefault().F_UserId);
                        if (interviewEntity.Count() == 0)
                        {
                            var interview = new Hy_Recruit_Interview()
                            {
                                F_Id = Guid.NewGuid().ToString(),
                                F_CandidatesID = candidatesEntity.FirstOrDefault().F_UserId,
                                F_StartTime = DateTime.Now.ToString(),
                                F_CreateDate = DateTime.Now,
                            };
                            hYDatabase.Hy_Recruit_Interview.Add(interview);

                            if (await hYDatabase.SaveChangesAsync() > 0)
                            {
                                result.info = "面试开始！";
                            }
                        }

                        result.code = ResponseCode.success;
                        result.data = candidatesEntity.ToList();
                    }
                    else
                    {
                        result.info = "未找到面试者信息！";
                    }

                }
                catch (Exception ex)
                {
                    result.info = "面试者信息加载失败:" + ex.Message;
                }
            }
            else
            {
                result.info = "面试者姓名为空！";
            }
            return result;
        }

        /// <summary>
        /// 面试签到
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ApiModel UserSave(string KeyValue)
        {
            if (KeyValue != null)
            {
                try
                {
                    //找到当前面试人员
                    var candidatesEntity = from h in hYDatabase.Hy_Recruit_Candidates
                                           join o in hYDatabase.Hy_Recruit_ProcessOperation
                                           on h.F_UserId equals o.CandidatesId
                                           where o.SubProcessId == "6" && o.OperationStatus == 0
                                           select h;

                    if (candidatesEntity.Count() > 0)
                    {
                        var interview = new Hy_Recruit_Interview()
                        {
                            F_Id = Guid.NewGuid().ToString(),
                            F_CandidatesID = candidatesEntity.FirstOrDefault().F_UserId,
                            F_StartTime = DateTime.Now.ToString(),
                            F_CreateDate = DateTime.Now,
                        };
                        hYDatabase.Hy_Recruit_Interview.Add(interview);

                        if (hYDatabase.SaveChanges() > 0)
                        {
                            result.code = ResponseCode.success;
                            result.info = "面试开始！";
                        }
                    }
                    else
                    {
                        result.info = "未找到面试者信息！";
                    }

                    //var sql = @" update dbo.Hy_Recruit_Interview set F_StartTime='" + DateTime.Now.ToString() + "' where F_CandidatesID=(select f_userid from  Hy_Recruit_Candidates where F_RealName='" + KeyValue + "')";

                }
                catch (Exception ex)
                {
                    result.info = "面试者信息加载失败:" + ex.Message;
                }
            }
            else
            {
                result.code = ResponseCode.fail;
                result.info = "面试者姓名参数为空！";
            }

            return result;
        }

        /// <summary>
        /// 保存面试结果
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ApiModel saveInterviewSave(IsDoptModele entity)
        {
            if (entity.F_CandidatesID != null)
            {
                try
                {
                    var editInterview = from i in hYDatabase.Hy_Recruit_Interview
                                        join c in hYDatabase.Hy_Recruit_Candidates
                                        on i.F_CandidatesID equals c.F_UserId
                                        where c.F_RealName == entity.F_CandidatesID
                                        && (i.F_EndTime == "" || i.F_EndTime == null)
                                        select i;
                    if (editInterview.Count() > 0)
                    {
                        editInterview.FirstOrDefault().F_EndTime = DateTime.Now.ToString();
                        editInterview.FirstOrDefault().F_ModifyUserName = entity.F_ModifyUserId;//面试官
                        editInterview.FirstOrDefault().F_InterviewResult = entity.F_InterviewResult;

                        var interviewOperation = hYDatabase.Hy_Recruit_ProcessOperation.Where(e => e.CandidatesId == editInterview.FirstOrDefault().F_CandidatesID && e.SubProcessId == "6");
                        if (interviewOperation.Count() > 0)
                        {
                            interviewOperation.FirstOrDefault().OperationStatus = Convert.ToInt32(entity.F_InterviewResult);

                            if (interviewOperation.FirstOrDefault().OperationStatus > 0)
                            {
                                var uploadInfo = new Hy_Recruit_ProcessOperation
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    SubProcessId = "7",
                                    OperationStatus = 0,
                                    OperationContent = "上传证件照等信息",
                                    CandidatesId = editInterview.FirstOrDefault().F_CandidatesID,
                                    OperationTime = DateTime.Now,
                                };

                                hYDatabase.Hy_Recruit_ProcessOperation.Add(uploadInfo);
                            }
                            if (hYDatabase.SaveChanges() > 0)
                            {
                                result.code = ResponseCode.success;
                                result.info = "该员工面试结束！";
                            }
                            else
                            {
                                result.info = "面试环节出错,请联系工作人员";
                            }
                        }
                        else
                        {
                            result.info = "未找到该应聘者面试信息,请联系工作人员";
                        }
                    }
                    else
                    {
                        result.info = "未找到该应聘者面试信息,请联系工作人员";
                    }
                }
                catch (Exception ex)
                {
                    result.info = ex.Message;
                }
            }
            else
            {
                result.code = ResponseCode.fail;
                result.info = "未找到应聘者信息！";
            }

            return result;
        }
    }
}