using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

using Learun.Application.TwoDevelopment.Platform.RecruitReportNodeApprovalClass;
using Learun.Application.Organization.ReturnModel;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-30 18:10
    /// 描 述：应聘者信息
    /// </summary>
    public class CandidateInformationBLL : CandidateInformationIBLL
    {
        private CandidateInformationService candidateInformationService = new CandidateInformationService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_Recruit_CandidatesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return candidateInformationService.GetPageList(pagination, queryJson);
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
        /// 获取Hy_Recruit_Candidates表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Recruit_CandidatesEntity GetHy_Recruit_CandidatesEntity(string keyValue)
        {
            try
            {
                return candidateInformationService.GetHy_Recruit_CandidatesEntity(keyValue);
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
        /// 获取信息显示
        /// <summary>
        /// <param name="F_IDCard"></param>
        /// <returns></returns>
        public IEnumerable<Hy_Platform_BlacklistEntity> GetUserBlackList(string F_IDCard)
        {
            try
            {
                return candidateInformationService.GetUserBlackList(F_IDCard);
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
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon DeleteEntity(string keyValue)
        {
            try
            {
               return candidateInformationService.DeleteEntity(keyValue);
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
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon SaveEntity( Hy_Recruit_CandidatesEntity entity)
        {
            return candidateInformationService.SaveEntity(entity);
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon SaveEntity(string keyValue, Hy_Recruit_CandidatesEntity entity)
        {
            return candidateInformationService.SaveEntity(keyValue, entity);

        }

        public ReturnCommon CheckVCode(string mobile, int vCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 报道节点查询数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Hy_Recruit_CandidatesEntity GetICardEntity(string keyValue)
        {
            try
            {
                return candidateInformationService.GetICardEntity(keyValue);
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

        public ReturnCommon SavDormitory(DormitoryDTO model)
        {
            try
            {
                return candidateInformationService.SavDormitory(model);
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
        /// 获取图片
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void GetImg(string keyValue)
        {
            Hy_Recruit_CandidatesEntity entity = GetHy_Recruit_CandidatesEntity(keyValue);
            string img = "";
            if (entity != null)
            {
                if (!string.IsNullOrEmpty(entity.F_HeadIcon))
                {
                    string fileHeadImg = Config.GetValue("fileAppDTImg");
                    string fileImg = string.Format("{0}/{1}{2}", fileHeadImg, entity.F_UserId, entity.F_HeadIcon);
                    if (DirFileHelper.IsExistFile(fileImg))
                    {
                        img = fileImg;
                        FileDownHelper.DownLoadnew(img);
                        return;
                    }
                }
            }
            else
            {
                img = "/Content/images/add.jpg";
            }
            if (string.IsNullOrEmpty(img))
            {
                img = "/Content/images/add.jpg";
            }
            FileDownHelper.DownLoad(img);
        }
        #endregion
    }
}
