/* * 版 本1.0
 * Copyright (c) 
 * 创建人：超级管理员
 * 日  期：2021-06-15 10:19
 * 描  述：个人标准工资子项维护
 */
var acceptClick;
var parentId = request('parentId');
var subId = request('subId');
var isAdd = request('flag');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_ItemId').lrDataSourceSelect({ code: 'IncomePay', value: 'f_itemid', text: 'f_item', allowSearch: 'true' });
            if (!learun.checkrow(parentId)) {
                $("#F_ItemId").attr("disabled", true);
                $("#F_Cost").attr("disabled", true);
            }
        },
        initData: function () {
            if (isAdd=='edit') {
                $.lrSetForm(top.$.rootUrl + '/HR_Code/EverybodyStandardWage/GetSubFormData?keyValue=' + subId, function (data) {
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
        //子项费用不能大于标准工资费用

        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/HR_Code/EverybodyStandardWage/SaveSubForm?subId=' + subId+'&parentId=' + parentId, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
