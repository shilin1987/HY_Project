
/*
 * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.04.11
 * 描 述：照片上传
 */
var acceptClick;
var keyValue = request('keyValue');
var RealName = request('RealName');
var bootstrap = function ($, learun) {
    "use strict";
    var selectedRow = learun.frameTab.currentIframe().selectedRow;
    function uploadImg() {
        var f = document.getElementById('uploadFile').files[0]
        var src = window.URL.createObjectURL(f);
        document.getElementById('uploadPreview').src = src;
    };
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#uploadFile').on('change', uploadImg);
            $('.file').prepend('<img id="uploadPreview"  src="' + top.$.rootUrl + '/Platform/CandidateInformation/GetImg?keyValue=' + keyValue + '" >');
        },
        initData: function () {
            if (!!selectedRow) {
                $('#form').lrSetFormData(selectedRow);
            }
        }
    };
    //保存数据 
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var postData = $('#form').lrGetFormData();

        if (!keyValue && !postData.uploadFile) {
            learun.alert.error("请选择图片");
            return false;
        }
        var f = document.getElementById('uploadFile').files[0];
        if (!!f) {
            learun.loading(true, '正在保存...');
            $.ajax({
                data: postData,
                url: top.$.rootUrl + "/Platform/CandidateInformation/UploadFile?keyValue=" + keyValue,
                type: "post",
                fileElementId: 'uploadFile',
                dataType: "json",
                success: function (data) {
                    if (!!callBack) {
                        callBack();
                    }
                    learun.loading(false);
                    learun.layerClose(window.name);
                }
            });
        }
        else {
            $.lrSaveForm(top.$.rootUrl + '/Platform/CandidateInformation/SaveForm?keyValue=' + keyValue, postData, function (res) {
                // 保存成功后才回调 
                if (!!callBack) {
                    callBack();
                }
            });
        }
    };
    page.init();
}