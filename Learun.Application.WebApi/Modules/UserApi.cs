using Learun.Application.Base.SystemModule;
using Learun.Application.Organization;
using Learun.Application.Organization.ReturnModel;
using Learun.Application.TwoDevelopment.Platform;
using Learun.Util;
using Learun.Util.Operat;
using Nancy;
using System.Threading.Tasks;

namespace Learun.Application.WebApi
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.05.12
    /// 描 述：用户信息
    /// </summary>
    public class UserApi : BaseApi
    {
        /// <summary>
        /// 注册接口
        /// </summary>
        public UserApi()
            : base("/learun/adms/user")
        {
            Post["/login"] = Login;
            Post["/plogin"] = PhoneLogin;
            Post["/modifypw"] = ModifyPassword;
            Post["/registered"] = Registered;
            Post["/InformationPerfection"] = InformationPerfection;

            Get["/info"] = Info;
            Get["/map"] = GetMap;
            Get["/img"] = GetImg;
            //Registered(0);
        }
        private UserIBLL userIBLL = new UserBLL();
        private PostIBLL postIBLL = new PostBLL();
        private RoleIBLL roleIBLL = new RoleBLL();
        //private CandidateInformationIBLL candIBLL = new CandidateInformationBLL();

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response Login(dynamic _)
        {
            LoginModel loginModel = this.GetReqData<LoginModel>();

            #region 内部账户验证
            UserEntity userEntity = userIBLL.CheckLogin(loginModel.username, loginModel.password);

            #region 写入日志
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 1;
            logEntity.F_OperateTypeId = ((int)OperationType.AppLogin).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.AppLogin);
            logEntity.F_OperateAccount = loginModel.username + "(" + userEntity.F_RealName + ")";
            logEntity.F_OperateUserId = !string.IsNullOrEmpty(userEntity.F_UserId) ? userEntity.F_UserId : loginModel.username;
            logEntity.F_Module = Config.GetValue("SoftName");
            #endregion

            if (!userEntity.LoginOk)//登录失败
            {
                //写入日志
                logEntity.F_ExecuteResult = 0;
                logEntity.F_ExecuteResultJson = "登录失败:" + userEntity.LoginMsg;
                logEntity.WriteLog();
                return Fail(userEntity.LoginMsg);
            }
            else
            {
                string token = OperatorHelper.Instance.AddLoginUser(userEntity.F_Account, "HY-app", this.loginMark, false);//写入缓存信息
                //写入日志
                logEntity.F_ExecuteResult = 1;
                logEntity.F_ExecuteResultJson = "登录成功";
                logEntity.WriteLog();

                OperatorResult res = OperatorHelper.Instance.IsOnLine(token, this.loginMark);
                res.userInfo.password = null;
                res.userInfo.secretkey = null;

                var jsonData = new
                {
                    baseinfo = res.userInfo,
                    post = postIBLL.GetListByPostIds(res.userInfo.postIds),
                    role = roleIBLL.GetListByRoleIds(res.userInfo.roleIds)
                };
                return Success(jsonData);
            }
            #endregion
        }

        /// <summary>
        /// 手机号登录接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response PhoneLogin(dynamic _)
        {
             LoginModel loginModel = this.GetReqData<LoginModel>();
          
            #region 内部账户验证
            ReturnCommon<UserEntity> msg = userIBLL.CheckPhoneLogin(loginModel.username, loginModel.password);
            if (!msg.Status)
            {
                return Fail(msg.Message);
            }
            else
            {
                UserEntity userEntity = msg.Data;

                #region 写入日志
                LogEntity logEntity = new LogEntity();
                logEntity.F_CategoryId = 1;
                logEntity.F_OperateTypeId = ((int)OperationType.AppLogin).ToString();
                logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.AppLogin);
                logEntity.F_OperateAccount = loginModel.username + "(" + userEntity.F_RealName + ")";
                logEntity.F_OperateUserId = !string.IsNullOrEmpty(userEntity.F_UserId) ? userEntity.F_UserId : loginModel.username;
                logEntity.F_Module = Config.GetValue("SoftName");
                #endregion

                if (!userEntity.LoginOk)//登录失败
                {
                    //写入日志
                    logEntity.F_ExecuteResult = 0;
                    logEntity.F_ExecuteResultJson = "登录失败:" + userEntity.LoginMsg;
                    logEntity.WriteLog();
                    return Fail(userEntity.LoginMsg);
                }
                else
                {
                    string token = OperatorHelper.Instance.AddLoginUser(userEntity.F_Account, "HY_QR_Code", this.loginMark, false);//写入缓存信息
                                                                                                                               //写入日志
                    logEntity.F_ExecuteResult = 1;
                    logEntity.F_ExecuteResultJson = "登录成功";
                    logEntity.WriteLog();

                    OperatorResult res = OperatorHelper.Instance.IsOnLine(token, this.loginMark);
                    res.userInfo.password = null;
                    res.userInfo.secretkey = null;

                    var jsonData = new
                    {
                        baseinfo = res.userInfo,
                        post = postIBLL.GetListByPostIds(res.userInfo.postIds),
                        role = roleIBLL.GetListByRoleIds(res.userInfo.roleIds)
                    };
                    return Success(jsonData);
                }
            }
            #endregion
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns> 
        private Response Info(dynamic _)
        {
            var data = userInfo;
            data.password = null;
            data.secretkey = null;

            var jsonData = new
            {
                baseinfo = data,
                post = postIBLL.GetListByPostIds(data.postIds),
                role = roleIBLL.GetListByRoleIds(data.roleIds)
            };

            return Success(jsonData);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response ModifyPassword(dynamic _)
        {
            ModifyModel modifyModel = this.GetReqData<ModifyModel>();
            if (userInfo.isSystem)
            {
                return Fail("当前账户不能修改密码");
            }
            else
            {
                bool res = userIBLL.RevisePassword(modifyModel.newpassword, modifyModel.oldpassword);
                if (!res)
                {
                    return Fail("原密码错误，请重新输入");
                }
                else
                {
                    return Success("密码修改成功");
                }
            }
        }


        /// <summary>
        /// 获取所有员工账号列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetList(dynamic _)
        {
            var data = userInfo;
            data.password = null;
            data.secretkey = null;
            var jsonData = new
            {
                baseinfo = data,
                post = postIBLL.GetListByPostIds(data.postIds),
                role = roleIBLL.GetListByRoleIds(data.roleIds)
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取用户映射表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetMap(dynamic _)
        {
            string ver = this.GetReqData();// 获取模板请求数据
            var data = userIBLL.GetModelMap();
            string md5 = Md5Helper.Encrypt(data.ToJson(), 32);
            if (md5 == ver)
            {
                return Success("no update");
            }
            else
            {
                var jsondata = new
                {
                    data = data,
                    ver = md5
                };
                return Success(jsondata);
            }
        }
        /// <summary>
        /// 获取人员头像图标
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetImg(dynamic _)
        {
            string userId = this.GetReqData();// 获取模板请求数据
            userIBLL.GetImg(userId);
            return Success("获取成功");
        }

        /// <summary>
        /// 新用户注册
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response Registered(dynamic _)
        {
            RegisterModel loginModel = this.GetReqData<RegisterModel>();

            //Hy_Recruit_CandidatesEntity entity = new Hy_Recruit_CandidatesEntity()
            //{
            //    F_RealName = loginModel.RealName,
            //   // F_Gender = loginModel.Gender,
            //    F_IDCard = loginModel.IDCard,
            //    F_Mobile = loginModel.Mobile,
            //  //  F_IsGetAccommodation = loginModel.IsGetAccommodation.ToString(),
            //    F_CreateDate = System.DateTime.Now,
            //};

            ////验证验证码是否正确
            //ReturnCommon msg =candIBLL.CheckVCode(loginModel.Mobile, loginModel.VCode);
            //if (!msg.Status) {
            //    return Fail(msg.Message);
            //}

            //Hy_Recruit_CandidatesEntity entity = new Hy_Recruit_CandidatesEntity()
            //{
            //    F_RealName = "T",
            //    F_Gender = 1,
            //    F_IDCard = "TEST_ID",
            //    F_Mobile = "15618664581",
            //    F_IsGetAccommodation = 1,
            //    F_CreateDate = System.DateTime.Now,
            //};

            #region 写入日志
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 1;
            logEntity.F_OperateTypeId = ((int)OperationType.AppLogin).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.AppLogin);
            logEntity.F_OperateAccount = loginModel.Mobile + "(" + loginModel.RealName + ")";
            logEntity.F_OperateUserId = loginModel.RealName;
            logEntity.F_Module = Config.GetValue("SoftName");
            #endregion

            //var result = candIBLL.SaveEntity(entity);
            //if (result.Status)
            //{
            //    logEntity.F_ExecuteResult = 1;
            //    logEntity.F_ExecuteResultJson = "新员工APP注册成功";
            //    logEntity.WriteLog();
            //    return Success(result.Message);
            //}
            //else
            //{
            //    //写入日志
            //    logEntity.F_ExecuteResult = 0;
            //    logEntity.F_ExecuteResultJson = "新员工APP注册失败:" + result.Message;
            //  //  logEntity.F_ExecuteResultJson = "新员工APP注册失败:" + result.Message+"("+ "1:" + loginModel.RealName + ",2:" + loginModel.Gender + ",3:" + loginModel.IDCard + ",4:" + loginModel.Mobile + ",5:"+loginModel.IsGetAccommodation + ")";
            //    logEntity.WriteLog();
            //    return Fail(result.Message);
            //}

            return null;
        }

        /// <summary>
        /// 二维码现有员工信息完善
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response InformationPerfection(dynamic _)
        {
            UserEntity loginModel = this.GetReqData<UserEntity>();

            #region 写入日志
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 3;
            logEntity.F_OperateTypeId = ((int)OperationType.AppLogin).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.AppLogin);
            logEntity.F_OperateAccount = loginModel.F_Mobile;
            logEntity.F_OperateUserId = loginModel.F_UserId;
            logEntity.F_Module = Config.GetValue("SoftName");
            #endregion

            var result = userIBLL.SaveEntity(loginModel);
            if (result.Status)
            {
                logEntity.F_ExecuteResult = 1;
                logEntity.F_ExecuteResultJson = "二维码现有员工信息完善成功";
                logEntity.WriteLog();
                return Success(result.Message);
            }
            else
            {
                //写入日志
                logEntity.F_ExecuteResult = 0;
                logEntity.F_ExecuteResultJson = "二维码现有员工信息完善失败:" + result.Message;
                logEntity.WriteLog();
                return Fail(result.Message);
            }
        }
    }

    /// <summary>
    /// 新用户注册信息
    /// </summary>
    public class RegisterModel
    {
        public string RealName { get; set; }
        public int Gender { get; set; }
        public string IDCard { get; set; }
        public string Mobile { get; set; }
        /// <summary>
        /// 是否住宿舍
        /// </summary>
        public int IsGetAccommodation { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public int VCode { get; set; }
    }


    /// <summary>
    /// 登录信息
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 账号/手机号
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 密码/验证码
        /// </summary>
        public string password { get; set; }
    }
    /// <summary>
    /// 修改密码
    /// </summary>
    public class ModifyModel
    {
        /// <summary>
        /// 新密码
        /// </summary>
        public string newpassword { get; set; }
        /// <summary>
        /// 旧密码
        /// </summary>
        public string oldpassword { get; set; }
    }

    /// <summary>
    /// 二维码完善用户信息
    /// </summary>
    public class InformationPerfectionModel
    {
        public string RealName { get; set; }
        public int Gender { get; set; }
        public string IDCard { get; set; }
        public string Mobile { get; set; }
        /// <summary>
        /// 是否住宿舍
        /// </summary>
        public int IsGetAccommodation { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public int VCode { get; set; }
    }
}