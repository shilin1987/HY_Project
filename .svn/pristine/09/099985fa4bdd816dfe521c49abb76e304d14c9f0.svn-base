using IdentityAuthentication.Database;
using IdentityAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityAuthentication.BLL
{
    public class ComparisonOfIdCardVerificationClassBLL : BaseService
    {
        public void test()
        {
            //读写数据库示例
            var newUser = hYDatabase.lr_base_user.Where(e => e.F_UserId == "");
        }

        /// <summary>
        /// 刷身份证验证
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        public ReturnCommon VerifyIDCardAjxaData(IdCardModel idCard)
        {
            //读取应聘者信息
            try
            {
                var newCandidates = hYDatabase.Hy_Recruit_Candidates.Where(e => e.F_IDCard == idCard.IdCard);
                if (newCandidates == null || newCandidates.Count() <= 0)
                {
                    returnCommon.Message = "<span style=\"color:red\">未找到姓名" + idCard.Name + "身份证号" + idCard.IdCard + "注册信息</span>";
                }
                else
                {
                    //1.身份证自动对比
                    //2.刷身份证报到
                    var operationProcess = hYDatabase.Hy_Recruit_ProcessOperation.Where(e => e.CandidatesId == newCandidates.FirstOrDefault().F_UserId && e.SubProcessId == "3");
                    if (operationProcess == null || operationProcess.Count() <= 0)
                    {
                        returnCommon.Message = "<span style=\"color:red\">姓名" + idCard.Name + "身份证号" + idCard.IdCard + "未到自动对比操作</span>";
                    }
                    else
                    {
                        if (operationProcess.FirstOrDefault().OperationStatus == 1)
                        {
                            //报到流程
                            operationProcess = hYDatabase.Hy_Recruit_ProcessOperation.Where(e => e.CandidatesId == newCandidates.FirstOrDefault().F_UserId && e.SubProcessId == "7");
                            if (operationProcess == null || operationProcess.Count() <= 0)
                            {
                                returnCommon.Message = "<span style=\"color:red\">请勿重复对姓名" + idCard.Name + "身份证号" + idCard.IdCard + "做自动对比操作</span>";
                            }
                            else
                            {
                                if (operationProcess.FirstOrDefault().OperationStatus == 1)
                                {
                                    returnCommon.Message = "<span style=\"color:red\">应聘者" + idCard.Name + "身份证号" + idCard.IdCard + "已签到，请勿重复操作</span>";
                                }
                                else if (operationProcess.FirstOrDefault().OperationStatus == 0)
                                {
                                    if (newCandidates.FirstOrDefault().F_RealName.Trim() == idCard.Name.Trim())
                                    {
                                        operationProcess.FirstOrDefault().OperationStatus = 1;

                                        var isSuccess = hYDatabase.SaveChanges();
                                        if (isSuccess > 0)
                                        {
                                            returnCommon.Status = true;
                                            returnCommon.Message = "<span style=\"color:green\">姓名" + idCard.Name + "身份证号" + idCard.IdCard + "报到成功</span>";
                                        }
                                        else
                                        {
                                            returnCommon.Message = "<span style=\"color:red\">姓名" + idCard.Name + "身份证号" + idCard.IdCard + "报到操作失败,请联系工作人员处理</span>";
                                        }
                                    }
                                    else
                                    {
                                        returnCommon.Message = "<span style=\"color:red\">身份证号" + idCard.IdCard + "的注册姓名" + idCard.Name + "填写有误</span>";
                                    }
                                }
                                else
                                {
                                    returnCommon.Message = "<span style=\"color:red\">姓名" + idCard.Name + "身份证号" + idCard.IdCard + "未完成报到所有流程</span>";
                                }
                            }
                        }
                        else if (operationProcess.FirstOrDefault().OperationStatus == 0)
                        {
                            if (newCandidates.FirstOrDefault().F_RealName.Trim() == idCard.Name.Trim())
                            {
                                operationProcess.FirstOrDefault().OperationStatus = 1;

                                ///添加人工认证代码
                                var operation = new Hy_Recruit_ProcessOperation()
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    SubProcessId = "4",
                                    OperationStatus = 0,
                                    OperationContent = "人工审核",
                                    CandidatesId = operationProcess.FirstOrDefault().CandidatesId,
                                    OperationTime = DateTime.Now,
                                };
                                hYDatabase.Hy_Recruit_ProcessOperation.Add(operation);

                                var isSuccess = hYDatabase.SaveChanges();
                                if (isSuccess > 0)
                                {
                                    returnCommon.Status = true;
                                    returnCommon.Message = "<span style=\"color:green\">姓名" + idCard.Name + "身份证号" + idCard.IdCard + "自动对比操作已完成,请进入人工核对流程</span>";
                                }
                                else
                                {
                                    returnCommon.Message = "<span style=\"color:red\">姓名" + idCard.Name + "身份证号" + idCard.IdCard + "自动对比操作失败,请联系工作人员处理</span>";
                                }
                            }
                            else
                            {
                                returnCommon.Message = "<span style=\"color:red\">身份证号" + idCard.IdCard + "的注册姓名" + idCard.Name + "填写有误</span>";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                returnCommon.Message = "<span style=\"color:red\">姓名" + idCard.Name + "身份证号" + idCard + "自动对比操作失败,请联系工作人员处理(" + ex.Message + ")</span>";
            }
            return returnCommon;
        }
    }
}