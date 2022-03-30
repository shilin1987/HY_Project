/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-11-02 16:41
 * 描  述：客户月度来料计划合并功能
 */
var acceptClick;
var keyValue = request('keyValue');
var month;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_MERGE_MONTH').lrDataItemSelect({ code: 'Month' });
            $('#B2B_PLAN_MATERIAL_MERGE_SUB').jfGrid({
                headData: [                    
                    {
                        label: 'GUID', name: 'F_SUBGUID', width: 0, align: 'left',ishide:'1'},
                    {
                        label: 'PARTID', name: 'F_PARTID', width: 100, align: 'left', ishide: '1'
                    },
                    {
                        label: '客户代码', name: 'F_CUST_CODE', width: 100, align: 'left'},
                    {
                        label: '产品型号', name: 'F_PRODUCT_MODEL', width:100, align: 'left'},
                    {
                        label: '封装形式', name: 'F_PACKAGE_MODEL', width:100, align: 'left'},
                    {
                        label: '封装等级', name: 'F_PRODUCT_LEVEL', width:100, align: 'left'},
                    {
                        label: '芯片型号', name: 'F_WAFER_MODEL', width:100, align: 'left'},
                    {
                        label: '晶圆尺寸', name: 'F_WAFER_SIZE', width:100, align: 'left'},
                    {
                        label: '包装方式', name: 'F_PACKAGING_TYPE', width: 100, align: 'left'
                    },
                    {
                        label: '填报月份', name: 'A', width: 100, align: 'center',
                        children: [
                            {
                                label: '一', name: 'F_MONTH_ONE', width: 70, align: 'center'
                            },
                            {
                                label: '二', name: 'F_MONTH_TWO', width: 70, align: 'center'
                            },
                            {
                                label: '三', name: 'F_MONTH_THREE', width: 70, align: 'center'
                            },
                            {
                                label: '四', name: 'F_MONTH_FOUR', width: 70, align: 'center'
                            },
                            {
                                label: '五', name: 'F_MONTH_FIVE', width: 70, align: 'center'
                            },
                            {
                                label: '六', name: 'F_MONTH_SIX', width: 70, align: 'center'
                            }
                        ]
                    },                
                    {
                        label: '焊线描述', name: 'F_WIRE_SOLDER_NAME', width: 100, align: 'left'},
                    {
                        label: '框架描述', name: 'F_SHELL_FRAM_NAME', width: 100, align: 'left'},
                    {
                        label: '焊线编号', name: 'F_WIRE_SOLDER_CODE', width: 100, align: 'left', ishide:'1'},
                    {
                        label: '框架编号', name: 'F_SHELL_FRAM_CODE', width: 100, align: 'left',ishide:'1'},
                ],
                isEdit: false,
                height: 600
            });
        },

        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ＭERGE_CREATE/GetFormData?keyValue=' + keyValue, function (data) {
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
        postData.strb2B_PLAN_MATERIAL_MERGE_SUBList = JSON.stringify($('#B2B_PLAN_MATERIAL_MERGE_SUB').jfGridGet('rowdatas'));
        postData.strEntity = JSON.stringify($('[data-table="B2B_PLAN_MATERIAL_MERGE"]').lrGetFormData());
        $.lrSaveForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ＭERGE_CREATE/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();

    $('#btn_Search').on('click', function () {
        month = $("#F_MERGE_MONTH").text();
        $.lrSetForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_ＭERGE_CREATE/GetPlanData?moth=' + $("#F_MERGE_MONTH").text(), function (data) {
        for (var id in data) {
            if (!!data[id].length && data[id].length > 0) {
                $('#' + id).jfGridSet('refreshdata', data[id]);
            }            
        }
        });      

    });
}
