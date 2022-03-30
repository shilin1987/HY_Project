﻿
/* * 版 本 Learun-ADMS V7.0.6 华羿软件开发平台(http://www.learun.cn) 
 * Copyright (c) 2013-2020 上海华羿信息技术有限公司 
 * 创建人：超级管理员 
 * 日  期：2019-05-09 17:27 
 * 描  述：甘特图 
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
            $('#F_Status').lrRadioCheckbox({
                type: 'radio',
                code: 'ProStatus',
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/GantProject/GetGantDetail?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
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
        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/GantProject/SaveDetail?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调 
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
} 
