using Learun.Application.Organization;
using Learun.Util;
using Learun.Util.Operat;
using ProductLifecycle.Component.Tools.Ftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using WebApi_EmployeeInformationEntry.BLL;
using WebApi_EmployeeInformationEntry.DataBase;
using WebApi_EmployeeInformationEntry.Models;
using WebApi_EmployeeInformationEntry.Utils;
using UserInfo = WebApi_EmployeeInformationEntry.Models.UserInfo;

namespace WebApi_EmployeeInformationEntry.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly BLL.UserService userService;
        private readonly BLL.DepartmentService departmentService;
        public UserController()
        {
            userService = new BLL.UserService();
            departmentService = new BLL.DepartmentService();
        }

        // GET: api/User/
        [HttpGet]
        public ApiModel Map(string token, string data)
        {
            apiModel = departmentService.map(token, data);
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "部门信息初始化", OperationType.Update, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data);
            }
        }

        /// <summary>
        /// 用户信息完善
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel InformationPerfection(UserViewModele user)
        {
            apiModel = userService.InformationPerfection(user);
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "用户信息完善", OperationType.Update, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data, "用户信息完善", OperationType.Update, "", apiModel.info, 3);
            }
        }

        /// <summary>
        /// 用户信息完善
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel saveIma()
        {
            ReturnCommon rc;
            // string userMobile = Request.Form["userMobile"];
            var request = HttpContext.Current.Request;
            string userMobile = request.Form["userMobile"] == null ? "" : request.Form["userMobile"];
            string bankCard = request.Form["bankcard"] == null ? "" : request.Form["bankcard"];
            Hy_Recruit_Candidates entity = userService.getHyEntityInformation(userMobile);
            //根据手机号获取身份证信息

            if (request.Files.Count > 0)
            {
                HttpPostedFile files = request.Files[0];
                //获取文件名称
                if (files.FileName != string.Empty)
                {

                    //获取完整的路径
                    string imgName = files.FileName;
                    string imaSuffix = imgName.Substring(imgName.LastIndexOf('.'));
                    string newFileName = entity.F_IDCard + imaSuffix;
                    string msg = "";
                    //FtpWebRequest reqFTP; 
                    byte[] buffer = new byte[files.ContentLength];
                    files.InputStream.Read(buffer, 0, files.ContentLength);
                    string sMimeType = files.ContentType.ToLower();

                    if (sMimeType.IndexOf("image/") < 0)
                        return Fail(null, "图片上传失败,请上传JPG，PNG，等文件类型", OperationType.Exception, "", apiModel.info);
                    if (files.ContentLength < 50)
                        return Fail(null, "图片上传失败,请上传JPG，PNG，等文件类型", OperationType.Exception, "", apiModel.info);
                    try
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromStream(files.InputStream);
                        if (img.Width * img.Height < 1)
                            return Fail(null, "图片上传失败,请上传JPG，PNG，等文件类型", OperationType.Exception, "", apiModel.info);
                        img.Dispose();
                    }
                    catch (Exception e)
                    {
                        apiModel.info = "图片上传失败,请上传JPG，PNG，等文件类型";
                        return Fail(null, "图片上传失败,请上传JPG，PNG，等文件类型", OperationType.Exception, "", apiModel.info);
                    }

                    rc = FileUpLoad(files, entity.F_IDCard, imaSuffix, out msg);

                    if (!rc.Status)
                    {
                        return Fail("未获取到用户图片信息", "图片上传失败,原因" + msg, OperationType.Exception, "", apiModel.info);
                    }
                    else
                    {
                        //修改实体信息
                        entity.F_ModifyDate = DateTime.Now;
                        entity.F_ModifyUserName = entity.F_RealName;
                        entity.F_Description = "上传银行卡账号和证件照信息" + entity.F_IDCard + "." + imaSuffix;
                        entity.F_BankCardNumber = bankCard;
                        entity.F_HeadIcon = imaSuffix;
                        //保存实体信息,返回正确信息
                        apiModel = userService.saveIma(entity);

                        if (apiModel.code == ResponseCode.fail)
                        {
                            return Fail(null, "证件照上传失败", OperationType.Update, "", apiModel.info);
                        }
                        else
                        {
                            return Success(apiModel.data, "证件照上传成功", OperationType.Update, "", apiModel.info, 3);
                        }
                    }
                }
                else
                {
                    return Fail(null, "未获取到用户图片信息", OperationType.Exception, "", apiModel.info);
                }
            }
            else
            {
                return Fail(null, "未获取到用户图片信息", OperationType.Exception, "", apiModel.info);
            }

        }

        protected ReturnCommon FileUpLoad(HttpPostedFile file, string cardId, string imaEndName, out string msg)
        {
            ReturnCommon rc = new ReturnCommon();
            try
            {

                FTPUpFile ftp = new FTPUpFile();
                rc.Status = ftp.UpFileService(file, cardId, imaEndName, out msg);
                rc.Message = msg;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return rc;
        }
        /// <summary>
        /// 用户信息完善
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel SaveInformation(UserViewGenModele user)
        {
            apiModel = userService.SaveInformation(user);
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "用户信息完善", OperationType.Update, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data, "用户信息完善", OperationType.Update, "", apiModel.info, 3);
            }
        }

        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiModel RevisePassword(RevisePasswordModel revisePassword)
        {
            apiModel = userService.RevisePassword(revisePassword);
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "修改登录密码", OperationType.Update, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data, "修改登录密码", OperationType.Update, "", apiModel.info, 3);
            }
        }

        /// <summary>
        /// 获取人员头像图标
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiModel Img(string data)
        {
            //userIBLL.GetImg(userId);
            return Success(null);
        }

        [HttpGet]
        public ApiModel UserMap(string token, string data)
        {
            return Success(null, "用户信息已更新", OperationType.Update, "", "update", 3);
        }

        [HttpPost]
        public ApiModel getPersonnelInformation(PersonInfoPartDTO userDTO)
        {
            apiModel = userService.getPersonnelInformation(userDTO);
            if (apiModel.code == ResponseCode.fail)
            {
                return Fail(null, "手机号不存在,未查到该用户", OperationType.AppLogin, "", apiModel.info);
            }
            else
            {
                return Success(apiModel.data);
            }
        }
    }
}
