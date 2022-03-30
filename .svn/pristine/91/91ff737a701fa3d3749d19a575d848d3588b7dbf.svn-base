/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-06-15 10:19
 * 描  述：个人标准工资维护
 */
var acceptClick;
var keyValue = request('keyValue');
var isAdd = false;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_UserId').lrDataSourceSelect({
                code: 'userdata', value: 'f_userid', text: 'f_account', allowSearch: 'true',
                select: function (item) {
                    if (item != null) {
                        $.lrSetForm(top.$.rootUrl + '/HR_Code/EverybodyStandardWage/GetFormInitData?userId=' + item.f_userid, function (data) {

                            if (data.minimum != null && data.maxmum != null && data.basepay != null) {
                                $("#Postlevellabstart").text(data.minimum );
                                $("#Postlevellabend").text( data.maxmum);
                                $("#BasePaylab").text(data.basepay);
                            }
                            else {
                                learun.alert.warning('未找到此员工岗级信息.');
                            }

                        });
                    }
                }
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/HR_Code/EverybodyStandardWage/GetFormData?keyValue=' + keyValue, function (data) {
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

        if ($("#F_StandardWage").val() < $("#Postlevellabstart").text() || $("#F_StandardWage").val() > $("#Postlevellabend").text())
        {
            return learun.alert.warning('标准工资应在岗级工资范围内.');
        }

        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/HR_Code/EverybodyStandardWage/SaveForm?keyValue=' + keyValue + '&basePay=' + $("#BasePaylab").text(), postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
