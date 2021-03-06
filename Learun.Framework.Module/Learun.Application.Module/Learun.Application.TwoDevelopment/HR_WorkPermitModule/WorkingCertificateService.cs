using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.HR_Code.HeterogeneousSystemInterface;
using Learun.Application.TwoDevelopment.HR_WorkPermitModule;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_WorkPermitModule
{
    public class WorkingCertificateService : RepositoryFactory
    {
        public ReturnComment SaveInfo(string jsonStr, string userId)
        {
            ReturnComment rc = new ReturnComment();
            var db = this.BaseRepository().BeginTrans();
            try
            {
                Hy_Wl_OaReturnInfoEntity hyOaReturnInfoEntity = new Hy_Wl_OaReturnInfoEntity();
                List<Hy_Wl_OaReturnInfo_itemEntity> hyOaReturnInfo_itemlist = new List<Hy_Wl_OaReturnInfo_itemEntity>();
                userId = "System";
                MainProcessDTO obj = (MainProcessDTO)JsonNewtonsoft.FromJSON<MainProcessDTO>(jsonStr);
                //string format = "yyyy-MM-dd HH:mm:ss";
      
                if (string.IsNullOrEmpty(obj.F_No))
                {
                    rc.State = "F";
                    rc.Mes = "接口信息错误,HR单号不能为空";
                    throw ExceptionEx.ThrowBusinessException(new Exception("接口信息错误,HR单号不能为空"));
                }
                else
                {
                    hyOaReturnInfoEntity.Create(userId, obj.F_No);
                    int i = 0;
                    hyOaReturnInfoEntity.F_No = obj.F_No;
                    hyOaReturnInfoEntity.F_FlowName = obj.F_FlowName;
                    hyOaReturnInfoEntity.F_OaFlowNumber = obj.F_OaFlowNumber;
                    hyOaReturnInfoEntity.F_Requestid = obj.F_Requestid;
                    DateTime dt = DateTime.ParseExact(obj.F_ClosingTime, @"ddd MMM dd HH:mm:ss 'GMT'zzz yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                    hyOaReturnInfoEntity.F_ClosingTime = dt;
                    hyOaReturnInfoEntity.F_Type = Convert.ToInt32(obj.F_Type);
                    hyOaReturnInfoEntity.F_State = obj.F_State;
                    db.Insert(hyOaReturnInfoEntity);
                    //List<ProcessNode> processNodeList = new List<ProcessNode>();
                    //processNodeList = obj.processNode;
                    foreach (var processNode in obj.processNode)
                    {
                        Hy_Wl_OaReturnInfo_itemEntity hyOaReturnInfoitemEntity = new Hy_Wl_OaReturnInfo_itemEntity();
                        hyOaReturnInfoitemEntity.Create(userId, hyOaReturnInfoEntity.F_No);
                       // hyOaReturnInfoitemEntity.F_No = hyOaReturnInfoEntity.F_No;
                        hyOaReturnInfoitemEntity.F_NoNum = i;
                        hyOaReturnInfoitemEntity.F_CheckpointName = processNode.F_CheckpointName;
                        DateTime dt1 = DateTime.ParseExact(processNode.F_ApprovalTime, @"ddd MMM dd HH:mm:ss 'GMT'zzz yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                        hyOaReturnInfoitemEntity.F_ApprovalTime = dt1;
                        hyOaReturnInfoitemEntity.F_Opinion = processNode.F_Opinion;
                        hyOaReturnInfoitemEntity.F_TheApprover = processNode.F_TheApprover;
                        hyOaReturnInfoitemEntity.F_WhetherThrough = processNode.F_WhetherThrough;
                        i++;
                        hyOaReturnInfo_itemlist.Add(hyOaReturnInfoitemEntity);
                    }
                    db.Insert(hyOaReturnInfo_itemlist);
                    //处理逻辑
                }
                db.Commit();
                rc.State = "S";
                rc.Mes = "接口信息返回成功";
            }
            catch (Exception ex)
            {
                db.Rollback();
                rc.State = "F";
                rc.Mes = "接口失败"+ ex.Message;
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
            return rc;
        }
        /// <summary>
        /// 获取公司名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string  getDeptInfo(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return "";
                }
                return this.BaseRepository().FindEntity<DepartmentEntity>(e => e.F_DepartmentId == id).F_FullName;
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
        /// 获取岗位名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getPostInfo(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return "";
                }
                return this.BaseRepository().FindEntity<PostEntity>(e => e.F_PostId == id).F_Name;
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
