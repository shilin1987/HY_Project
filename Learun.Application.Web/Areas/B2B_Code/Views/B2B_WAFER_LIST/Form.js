/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-01-24 14:32
 * 描  述：晶圆清单导入
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {            
            page.bind();
            page.initData();
        },
        bind: function () {},
        initData: function () {}
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        var f = document.getElementById('uploadFile').files[0];
        if (!!f) {       
            learun.loading(true, '正在保存...');
            $.ajaxFileUpload({
                url: top.$.rootUrl + "/B2B_Code/B2B_WAFER_LIST/UploadFile",
                secureuri: false,
                fileElementId: 'uploadFile',
                dataType: 'json',
                success: function (data) {
                    learun.loading(false);
                    var postData = {};
                    postData.strEntity = JSON.stringify({ "FCUST_CODE": $("#FCUST_CODE").val(), "FFILE_NAME": f.name});
                    postData.strEntitySub = JSON.stringify(data.data);
                    $.lrSaveForm(top.$.rootUrl + '/B2B_Code/B2B_WAFER_LIST/Saveupload', postData, function (res) {
                        // 保存成功后才回调
                        if (!!callBack) {
                            callBack();
                        }
                    });
                }
            });
        }
    };
    page.init();
}
