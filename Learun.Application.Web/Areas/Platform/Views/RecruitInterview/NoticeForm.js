﻿/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-12-27 18:33
 * 描  述：报到通知单
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
        },
        initData: function () {
            if (!!keyValue) {
                $.ajax({
                    url: top.$.rootUrl + '/Platform/RecruitInterview/GetUserlist',
                    type: "post",
                    cache: false,
                    data: { "keyValue": keyValue },
                    dataType: "json",
                    success: function (data) {
                        if (data.code == 200) {
                            var dataObj = data["data"];
                            $("#F_RealName").val(dataObj.F_RealName == null || dataObj.F_RealName == "null" ? "" : dataObj.F_RealName);
                            $("#F_Mobile").val(dataObj.F_Mobile == null || dataObj.F_Mobile == "null" ? "" : dataObj.F_Mobile);
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
            F_RealName: $("#F_RealName").val(),
            F_Mobile: $("#F_Mobile").val(),
            F_SendOutDate: $("#F_SendOutDate").val()
        }
        var postData = {
            model: strEntity
        };
        console.log(postData);
        $.lrSaveForm(top.$.rootUrl + '/Platform/RecruitInterview/SendDate', postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
