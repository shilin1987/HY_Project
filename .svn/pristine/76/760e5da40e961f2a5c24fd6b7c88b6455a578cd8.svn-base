/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-12-27 18:33
 * 描  述：报道节点审批维护
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
           // $('#uploadFile').on('change', uploadImg);
           // $('.file').prepend('<img id="uploadPreview"  src="' + top.$.rootUrl + '/AppManager/DTImg/GetImg?keyValue=' + keyValue + '" >');
        },
        initData: function () {
            if (!!keyValue) {
                $.ajax({
                    url: top.$.rootUrl + '/Platform/RecruitReportNodeApprovalClass/getDormitoryForm',
                    type: "post",
                    cache: false,
                    data: { "keyValue": keyValue },
                    dataType: "json",
                    success: function (data) {
                        if (data.code == 200) {
                            var dataObj = data["data"];
                            $("#F_UserName").val(dataObj.F_RealName == null || dataObj.F_RealName == "null" ? "" : dataObj.F_RealName);
                            $("#F_CardId").val(dataObj.F_IDCard == null || dataObj.F_IDCard == "null" ? "" : dataObj.F_IDCard);
                            var imgurl = dataObj.F_HeadIcon == null || dataObj.F_HeadIcon == "null" ? "" : dataObj.F_HeadIcon;
                            $('.file').prepend('<img id="uploadPreview" style="width:150px;height:210px;"  src="' + imgurl+'" >');
                        } else {
                            alert("请求后台失败");
                        }
                    }
                });
            }
        }
    };
 
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        var strEntity ={
            F_CardId: $("#F_CardId").val(),
            F_Dormitory: $("#F_DormitoryButton").val()
        }
        var postData = {
            model: strEntity
        };
        console.log(postData);
        $.lrSaveForm(top.$.rootUrl + '/Platform/RecruitReportNodeApprovalClass/SavDormitory', postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
