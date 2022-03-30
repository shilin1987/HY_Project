﻿using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi_EmployeeInformationEntry.DataBase;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.BLL
{
    public class WrittenExaminationService : BaseService
    {
        /// <summary>
        /// 获取笔试题，随机给出一道笔试题
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<ApiModel> GetWrittenExaminationQuestions()
        {
            try
            {
                var sqlstr = @"select c.Questions Subject,c.F_AnswerContent Answer,c.F_Answer RightKey,
	                        c.F_QuestionsType QuestionTypeFlag,case c.F_QuestionsType when 1 then '选择题' when 2 then '填空题' end QuestionType,c.F_Score Score,d.F_TestPaperName QuestionsBank,d.F_MinimumScore BankScore from (
                            select * from (select Top 2 * From 	Hy_Recruit_WrittenExaminationQuestions
	                        where F_QuestionsType=1 order By NewID()) a
	                        union 
	                        select * from (select Top 3 * From 	Hy_Recruit_WrittenExaminationQuestions 
	                        where F_QuestionsType=2) b ) c
	                        left join Hy_Recruit_WrittenExaminationQuestionBank d
	                        on c.F_QuestionsBankID=d.F_Id";

                var writtenExaminationQuestions = hYDatabase.Database.SqlQuery<WrittenExaminationQuestionsModel>(sqlstr);
                //笔试题
                //var writtenExaminationQuestions = from w in hYDatabase.Hy_Recruit_WrittenExaminationQuestions
                //                                  join b in hYDatabase.Hy_Recruit_WrittenExaminationQuestionBank
                //                                  on w.F_QuestionsBankID equals b.F_Id
                //                                  select new WrittenExaminationQuestionsModel
                //                                  {
                //                                      Subject = w.Questions,
                //                                      Answer = w.F_AnswerContent,
                //                                      RightKey = w.F_Answer,
                //                                      QuestionTypeFlag = w.F_QuestionsType,
                //                                      QuestionType = w.F_QuestionsType == 1 ? "选择题" : "填空题",
                //                                      Score = w.F_Score,
                //                                      QuestionsBank = b.F_TestPaperName,
                //                                      BankScore = b.F_MinimumScore
                //                                  };

                if (writtenExaminationQuestions.Count() > 0)
                {
                    result.code = ResponseCode.success;
                    result.data = writtenExaminationQuestions;
                }
                else
                {
                    result.info = "未找到笔试题,请联系工作人员.";
                }
            }
            catch (Exception ex)
            {
                result.info = "查询笔试题异常,请联系工作人员处理(" + ex.Message + ")";
            }

            return result;
        }

        /// <summary>
        /// 保存笔试结果信息
        /// </summary>
        /// <param name="writtenExaminationResult"></param>
        /// <returns></returns>
        public async Task<ApiModel> SetSaveResult(WrittenExaminationResult writtenExaminationResult)
        {
            try
            {
                var wresult = hYDatabase.Hy_Recruit_ProcessOperation.Where(e => e.CandidatesId == writtenExaminationResult.candidatesId && e.OperationStatus == 0);
                if (wresult.Count() > 0)
                {
                    wresult.FirstOrDefault().OperationStatus = writtenExaminationResult.wresult;
                    wresult.FirstOrDefault().OperationTime = DateTime.Now;

                    if (writtenExaminationResult.wresult == 1)
                    {
                        var wpr = new Hy_Recruit_ProcessOperation()
                        {
                            ID = Guid.NewGuid().ToString(),
                            CandidatesId = writtenExaminationResult.candidatesId,
                            SubProcessId = "6",
                            OperationStatus = 0,
                            OperationContent = "面试",
                            OperationTime = DateTime.Now,
                        };

                        hYDatabase.Hy_Recruit_ProcessOperation.Add(wpr);
                    }

                    var isSuccess = await hYDatabase.SaveChangesAsync();
                    if (isSuccess > 0)
                    {
                        result.code = ResponseCode.success;
                    }
                    else
                    {
                        result.info = "笔试结果信息更新失败";
                    }
                }
            }
            catch (Exception ex)
            {
                result.info = "笔试结果信息更新异常,请联系工作人员:(" + ex.Message + ")";
            }

            return result;
        }
    }
}