using Learun.Application.TwoDevelopment.Platform;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApi_EmployeeInformationEntry.DataBase;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.BLL
{
    public class RegisteredService : BaseService
    {
        /// <summary>
        /// 根据身份证查询基础信息
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        public async Task<ApiModel> InitializationUser(string idCard)
        {
            try
            {
                ///1.查询是否再黑名单
                ///2.查询年龄是否超限
                var isBlackList = await hYDatabase.Hy_Recruit_Blacklist.Where(e => e.F_IDCard == idCard).ToListAsync();
                if (isBlackList.Count() > 0)
                {
                    result.code = ResponseCode.fail;
                    result.info = "您不符合我们招聘条件,谢谢参与!";

                    return result;
                }

                //由于注册表单没有岗位，无法关联到年龄信息
                //var isBlackList = hYDatabase.Hy_Recruit_AgeLimit;
                //if (isBlackList.Count() > 0)
                //{
                //    result.code = ResponseCode.fail;
                //    result.info = "您的年龄不符合我们招聘条件,谢谢参与!";
                //}

                var userEntity = from u in hYDatabase.Hy_Recruit_Candidates.Where(e => e.F_IDCard == idCard)
                                 select new RegisteredViewModel
                                 {
                                     IdCard = u.F_IDCard,
                                     Name = u.F_RealName,
                                     Education = u.F_Education,
                                     RecruitmentChannels = u.F_RecruitmentChannels,
                                     InternalCode = u.F_InternalCode,
                                     InternalName = u.F_InternalName,
                                     InternalCompany = u.F_InternalCompany,
                                     ExpectedentryDate = u.F_ExpectedentryDate == null ? "" : u.F_ExpectedentryDate,
                                     RecruitmentCompany = u.F_RecruitmentCompany,
                                     Mobile = u.F_Mobile
                                 };

                result.code = ResponseCode.success;
                if (userEntity != null && userEntity.Count() > 0)
                {
                    result.data = userEntity.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.info = "根据身份证查询个人信息异常,请联系工作人员处理(" + ex.Message + ")";
            }

            return result;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="registered"></param>
        /// <returns></returns>
        public async Task<ApiModel> GetVerificationCode(string phone)
        {
            if (phone != null)
            {
                try
                {
                    //在职员工手机号是否使用
                    var userEntity = hYDatabase.lr_base_user.Where(e => e.F_Mobile == phone && e.F_UserState=="在职");
                    if (userEntity == null || userEntity.Count() == 0)
                    {
                        //应聘者信息手机号是否使用
                        var candidatesEntity = hYDatabase.Hy_Recruit_Candidates.Where(c => c.F_Mobile == phone);
                        if (candidatesEntity == null || candidatesEntity.Count() == 0)
                        {
                            //生成验证码并发送
                            var vcode = CommonHelper.RndNum(4);
                            var sms = new Hy_SMS()
                            {
                                Phone = phone,
                                VCode = vcode,
                                SendTime = DateTime.Now
                            };
                            hYDatabase.Hy_SMS.Add(sms);
                            //保存成功发送短信
                            if (await hYDatabase.SaveChangesAsync() > 0)
                            {
                                string mobile = phone,
                                content = "【华羿微电】欢迎您注册华羿微电子股份有限公司HR平台，您的注册验证码为" + vcode + "，该验证码3分钟内有效，请勿泄露于他人。",
                                account = "109751",
                                password = "X6pkMb",
                                extno = "10690565708 ",
                                url = "https://api.juhedx.com/sms?action=send";
                                byte[] byteArray = Encoding.UTF8.GetBytes("&account=" + account + "&password=" + password + "&mobile=" + mobile + "&content=" + content + "&extno=" + extno + "&rt=json");
                                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
                                webRequest.Method = "POST";
                                webRequest.ContentType = "application/x-www-form-urlencoded";
                                webRequest.ContentLength = byteArray.Length;
                                Stream newStream = webRequest.GetRequestStream();
                                newStream.Write(byteArray, 0, byteArray.Length);
                                newStream.Close();
                                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                                sr.ReadToEnd();
                                //string Message = sr.ReadToEnd();
                                //System.Console.Write(Message);
                                //System.Console.Read();

                                result.code = ResponseCode.success;
                                result.info = "验证码发送成功";
                            }
                            else
                            {
                                result.info = "生成短信验证码保存到数据库失败";
                            }
                        }
                        else
                        {
                            result.info = "此手机号已被其他应聘者使用";
                        }
                    }
                    else
                    {
                        result.info = "此手机号已被在职员工使用";
                    }
                }
                catch (Exception ex)
                {
                    result.info = "发送失败:" + ex.Message;
                }
            }
            else
            {
                result.info = "手机号为空";
            }

            return result;
        }

        /// <summary>
        /// 发送报告单
        /// </summary>
        /// <param name="registered"></param>
        /// <returns></returns>
        public async Task<ApiModel> SetSendReport(ReportModel report)
        {
            if (report != null)
            {
                try
                {
                    //发送短信
                    string mobile = report.Phone,
                    content = "【华羿微电】录用通知:" + report.Name + ",恭喜您已被华羿微电录用,请于" + report.CheckInTime + "来公司报到。1、携带本人身份证及复印件2、毕业证（复印件）3、1寸免冠照片3张（红底）4、3月内体检报告5、招商银行储蓄卡",
                    account = "109751",
                    password = "X6pkMb",
                    extno = "10690565708 ",
                    url = "https://api.juhedx.com/sms?action=send";
                    byte[] byteArray = Encoding.UTF8.GetBytes("&account=" + account + "&password=" + password + "&mobile=" + mobile + "&content=" + content + "&extno=" + extno + "&rt=json");
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
                    webRequest.Method = "POST";
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    webRequest.ContentLength = byteArray.Length;
                    Stream newStream = webRequest.GetRequestStream();
                    newStream.Write(byteArray, 0, byteArray.Length);
                    newStream.Close();
                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    sr.ReadToEnd();
                    //string Message = sr.ReadToEnd();
                    //System.Console.Write(Message);
                    //System.Console.Read();

                    result.code = ResponseCode.success;
                    result.info = "报到单发送成功";

                }
                catch (Exception ex)
                {
                    result.info = "发送失败:" + ex.Message;
                }
            }
            else
            {
                result.info = "手机号、姓名、报到时间等参数为空";
            }

            return result;
        }

        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="registered"></param>
        /// <returns></returns>
        public ApiModel SaveForm(RegisteredViewModel registered)
        {
            try
            {
                var userEntity = hYDatabase.Hy_Recruit_Candidates.Where(e => e.F_IDCard == registered.IdCard);
                if (userEntity != null && userEntity.Count() > 1)
                {
                    result.info = "此身份证号已被多次注册使用";
                    return result;
                }
                else if (userEntity != null && userEntity.Count() == 1)
                {
                    //检测验证码是否正确
                    var sendSMS = hYDatabase.Hy_SMS.Where(e => e.Phone == registered.Mobile).OrderByDescending(k => k.SendTime);
                    if (sendSMS.Count() > 0)
                    {
                        var time = DateTime.Now - sendSMS.FirstOrDefault().SendTime;
                        var totalSeconds = time.Value.TotalSeconds;
                        if (totalSeconds > 180)
                        {
                            result.info = "此验证码已失效,请重新获取";
                            return result;
                        }
                    }
                    else
                    {
                        result.info = "请先获取手机验证码";
                        return result;
                    }

                    var sex = registered.IdCard.Substring(14, 3);
                    var sexInt = int.Parse(sex) % 2 == 0 ? 0 : 1;

                    userEntity.FirstOrDefault().F_Gender = sexInt;
                    userEntity.FirstOrDefault().F_IDCard = registered.IdCard;
                    userEntity.FirstOrDefault().F_RealName = registered.Name;
                    userEntity.FirstOrDefault().F_Education = registered.Education;
                    userEntity.FirstOrDefault().F_RecruitmentChannels = registered.RecruitmentChannels;
                    userEntity.FirstOrDefault().F_InternalCode = registered.InternalCode;
                    userEntity.FirstOrDefault().F_InternalName = registered.InternalName;
                    userEntity.FirstOrDefault().F_InternalCompany = registered.InternalCompany;
                    userEntity.FirstOrDefault().F_ExpectedentryDate = registered.ExpectedentryDate;
                    userEntity.FirstOrDefault().F_RecruitmentCompany = registered.RecruitmentCompany;
                    userEntity.FirstOrDefault().F_Mobile = registered.Mobile;
                    userEntity.FirstOrDefault().F_ModifyDate = DateTime.Now;
                    userEntity.FirstOrDefault().F_Register = 1;//是否已注册，注册后才能登录，劳务只导入信息不能登录
                }
                else if (userEntity == null || userEntity.Count() == 0)
                {
                    var userEntitys = new Hy_Recruit_Candidates()
                    {
                        F_UserId = Guid.NewGuid().ToString(),
                        F_IDCard = registered.IdCard,
                        F_RealName = registered.Name,
                        F_Education = registered.Education,
                        F_RecruitmentChannels = registered.RecruitmentChannels,
                        F_InternalCode = registered.InternalCode == null ? "" : registered.InternalCode,
                        F_InternalName = registered.InternalName == null ? "" : registered.InternalName,
                        F_InternalCompany = registered.InternalCompany == null ? "" : registered.InternalCompany,
                        F_ExpectedentryDate = registered.ExpectedentryDate,
                        F_RecruitmentCompany = registered.RecruitmentCompany,
                        F_Mobile = registered.Mobile,
                        F_CreateDate = DateTime.Now,
                        F_PWD = registered.IdCard.Substring(registered.IdCard.Length - 6),
                        F_Register = 1
                    };
                    hYDatabase.Hy_Recruit_Candidates.Add(userEntitys);

                    //向操作表写入数据

                    //注册
                    var operatorReistered = new Hy_Recruit_ProcessOperation()
                    {
                        ID = Guid.NewGuid().ToString(),
                        SubProcessId = "1",
                        OperationStatus = 1,
                        OperationContent = "应聘者注册",
                        CandidatesId = userEntitys.F_UserId,
                        OperationTime = DateTime.Now
                    };
                    hYDatabase.Hy_Recruit_ProcessOperation.Add(operatorReistered);

                    //应聘
                    var operatorCandidate = new Hy_Recruit_ProcessOperation()
                    {
                        ID = Guid.NewGuid().ToString(),
                        SubProcessId = "2",
                        OperationStatus = 1,
                        OperationContent = "应聘者推荐人信息完善",
                        CandidatesId = userEntitys.F_UserId,
                        OperationTime = DateTime.Now
                    };
                    hYDatabase.Hy_Recruit_ProcessOperation.Add(operatorCandidate);

                    //自动对比
                    var operatorWritten = new Hy_Recruit_ProcessOperation()
                    {
                        ID = Guid.NewGuid().ToString(),
                        SubProcessId = "3",
                        OperationStatus = 0,
                        OperationContent = "自动对比",
                        CandidatesId = userEntitys.F_UserId,
                        OperationTime = DateTime.Now
                    };
                    hYDatabase.Hy_Recruit_ProcessOperation.Add(operatorWritten);
                }

                var isSuccess = hYDatabase.SaveChanges();

                if (isSuccess > 0)
                {
                    result.code = ResponseCode.success;
                    result.info = "注册成功!默认密码为身份证后六位";

                    //var tipsInfo = hYDatabase.Hy_Recruit_InfoTips.Where(e => e.SubProcessId == "1");
                    //if (tipsInfo.Count() > 0)
                    //{
                    //    result.info += tipsInfo.FirstOrDefault().Content;
                    //}
                }
                else
                {
                    result.info = "注册失败";
                }
            }
            catch (Exception ex)
            {
                result.info = "注册异常,请联系工作人员处理(" + ex.Message + ")";
            }

            return result;
        }
    }
}