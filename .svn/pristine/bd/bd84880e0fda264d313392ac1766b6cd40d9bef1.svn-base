/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-16 09:43
 * 描  述：测试功能
 */
var acceptClick;
var keyValue = request('keyValue');
// 设置权限
var setAuthorize;
// 设置表单数据
var setFormData;
// 验证数据是否填写完整
var validForm;
// 保存数据
var save;
var bootstrap = function ($, learun) {
    "use strict";
    // 设置权限
    setAuthorize = function (data) {
    };
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_Children').jfGrid({
                headData: [
                    {
                        label: 'F_text', name: 'F_text', width:100, align: 'left'
                        ,edit:{
                            type:'layer',
                            change: function (data, rownum, selectData) {
                                data.F_text = selectData.f_encode;
                                data.F_input = selectData.f_fullname;
                                data.F_radio = selectData.f_shortname;
                                $('#F_Children').jfGridSet('updateRow', rownum);
                            },
                            op: {
                                width: 600,
                                height: 400,
                                colData: [
                                    { label: "编码", name: "f_encode", width: 100, align: "left" },
                                    { label: "名称", name: "f_fullname", width: 100, align: "left" },
                                    { label: "简称", name: "f_shortname", width: 100, align: "left" },
                                ],
                                url: top.$.rootUrl + '/LR_SystemModule/DataSource/GetDataTable',
                                param: { code: 'crmCustomer'
}                             }
                        }
                    },
                    {
                        label: 'F_input', name: 'F_input', width:200, align: 'left'                    },
                    {
                        label: 'F_radio', name: 'F_radio', width:100, align: 'left'                    },
                ],
                isEdit: true,
                height: 400
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/ime/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            }
        }
    };
    // 设置表单数据
    setFormData = function (processId, param, callback) {
        if (!!processId) {
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/ime/GetFormDataByProcessId?processId=' + processId, function (data) {
                for (var id in data) {
                    if (!!data[id] && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                        if(id == 'F_parent' && data[id] ){
                            keyValue = data[id].F_Id;
                        }
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
        }
        callback && callback();
        }
    // 验证数据是否填写完整
    validForm = function () {
        if (!$('body').lrValidform()) {
            return false;
        }
        return true;
    };
    // 保存数据
    save = function (processId, callBack, i) {
        var postData = {};
        var formData = $('[data-table="F_parent"]').lrGetFormData();
        if(!!processId){
            formData.F_Id =processId;
        }
        postData.strEntity = JSON.stringify(formData);
        postData.strf_ChildrenList = JSON.stringify($('#F_Children').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/ime/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack(res, i);
            }
        });
    };
    page.init();
}
