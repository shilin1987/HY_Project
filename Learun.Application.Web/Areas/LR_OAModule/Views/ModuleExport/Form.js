/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn) 
 * Copyright (c) 2013-2018 上海力软信息技术有限公司 
 * 创建人：超级管理员 
 * 日  期：2021-10-29 10:09 
 * 描  述：cs 
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
        },
        bind: function () {
            $('#F_Attachment01').lrUploader();
            $('#F_Attachment02').lrUploader();
            $('#F_Attachment03').lrUploader();
        },
    };
    // 保存数据 
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var Data = $('#form').lrGetFormData();
        //{
        //    strEntity: JSON.stringify($('#form').lrGetFormData())
        //};
        $.lrSaveForm(top.$.rootUrl + '/LR_OAModule/ModuleExport/UploadifyFile?keyValue=' + keyValue, Date, function (res) {
            // 保存成功后才回调 
            if (!!callBack) {
                callBack();
            }
        });

    };
    page.init();
} 
