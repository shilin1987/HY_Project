/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-11-16 14:11
 * 描  述：来料计划产能分配
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
            $('#F_ALLOT_MONTH').lrDataItemSelect({ code: 'Month' });          

            $('#B2B_PLAN_MATERIAL_ALLOT_SUB').jfGrid({
                headData: [
                    {
                        label: '客户代码', name: 'F_CUST_CODE', width: 100, align: 'center'
                    },
                    {
                        label: '系列', name: 'F_PRODUCT_SERIES', width: 100, align: 'left'
                    },
                    {
                        label: '外形', name: 'F_PACKAGE_MODEL', width: 100, align: 'left'
                    },                    
                    {
                        label: '月份一', name: 'A', width: 70, align: 'center',
                        children: [{
                            label: '计划', name: 'F_PLAN_MONTH_ONE', width: 90, align: 'center'
                        },
                            {
                                label: '实际', name: 'F_REAL_MONTH_ONE', width: 90, align: 'center'
                            }]
                    },
                    {
                        label: '月份二', name: 'B', width: 70, align: 'center',
                        children: [{
                            label: '计划', name: 'F_PLAN_MONTH_TWO', width: 90, align: 'center'},
                            {
                                label: '实际', name: 'F_REAL_MONTH_TWO', width: 90, align: 'center'
                            }]
                    },
                    {
                        label: '月份三', name: 'C', width: 70, align: 'center',
                        children: [{
                            label: '计划', name: 'F_PLAN_MONTH_THREE', width: 90, align: 'center'
                            },
                            {
                                label: '实际', name: 'F_REAL_MONTH_THREE', width: 90, align: 'center'
                            }]
                    },                                
                    {
                        label: '未投', name: 'F_WT_QTY', width: 90, align: 'center'},
                    {
                        label: '库存', name: 'F_KC_QTY', width: 90, align: 'center'},
                    {
                        label: '产能', name: 'F_ALLOT_QTY', width: 90, align: 'center'
                        ,edit:{
                            type:'input'
                        }
                    },
                    {
                        label: '日投量', name: 'F_ALLOT_DAY_QTY', width: 90, align: 'center'
                        ,edit:{
                            type:'input'
                        }
                    },
                ],
                isEdit: true,                
                height: 500
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ALLOT/GetFormData?keyValue=' + keyValue, function (data) {
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
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        var postData = {};
        postData.strb2B_PLAN_MATERIAL_ALLOT_SUBList = JSON.stringify($('#B2B_PLAN_MATERIAL_ALLOT_SUB').jfGridGet('rowdatas'));
        postData.strEntity = JSON.stringify($('[data-table="B2B_PLAN_MATERIAL_ALLOT"]').lrGetFormData());
        $.lrSaveForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ALLOT/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };

    $("#btn_Downexcel").on('click', function () {     
        if ($("#F_ALLOT_MONTH").text() == "" || $("#F_ALLOT_MONTH").text() == null) {   
            learun.alert.warning('请选择月份！');
        }
        else {          
            learun.download({
                method: "POST",
                url: '/Utility/ExportExcel',
                param: {
                    fileName: "产能分配",
                    columnJson: JSON.stringify([
                        { "label": "系列", "name": "F_PRODUCT_SERIES", "width": 100, "align": "center" },
                        { "label": "外形", "name": "F_PACKAGE_MODEL", "width": 100, "align": "center" },
                        { "label": "客户代码", "name": "F_CUST_CODE", "width": 100, "align": "center" },
                        { "label": "月份一计划", "name": "F_PLAN_MONTH_ONE", "width": 100, "align": "center" },
                        { "label": "月份一实际", "name": "F_REAL_MONTH_ONE", "width": 100, "align": "center" },
                        { "label": "月份二计划", "name": "F_PLAN_MONTH_TWO", "width": 100, "align": "center" },
                        { "label": "月份二实际", "name": "F_REAL_MONTH_TWO", "width": 100, "align": "center" },
                        { "label": "月份三计划", "name": "F_PLAN_MONTH_THREE", "width": 100, "align": "center" },
                        { "label": "月份三实际", "name": "F_REAL_MONTH_THREE", "width": 100, "align": "center" },
                        { "label": "未投", "name": "F_WT_QTY", "width": 100, "align": "center" },
                        { "label": "库存", "name": "F_KC_QTY", "width": 100, "align": "center" },
                        { "label": "产能", "name": "F_ALLOT_QTY", "width": 100, "align": "center" },
                        { "label": "日投量", "name": "F_ALLOT_DAY_QTY", "width": 100, "align": "center" }]),
                    dataJson: JSON.stringify($('#B2B_PLAN_MATERIAL_ALLOT_SUB').jfGridGet('settingInfo').rowdatas)
                }
            });
        }

    });

    page.init();
}

$('#btn_Search').on('click', function () {
    if ($("#F_ALLOT_MONTH").text() == "" || $("#F_ALLOT_MONTH").text() == null) {       
        learun.alert.warning('请选择月份！');
    }
    else {

        $.lrSetForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ALLOT/GetPlanData?month=' + $("#F_ALLOT_MONTH").text(), function (data) {
            for (var id in data) {
                if (!!data[id].length && data[id].length > 0) {
                    $('#' + id).jfGridSet('refreshdata', data[id]);
                }
            }
        });
    }
});