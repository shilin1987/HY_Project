/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-11-10 13:46
 * 描  述：客户端月度来料计划填报
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
            if (!keyValue.length == 0) {     
                $("#F_WRITE_MONTH").attr("disabled", "disabled");
            };

            $('#F_WRITE_MONTH').lrDataItemSelect({ code: 'Month' });      
            $('#B2B_PLAN_INCOMING_MATERIAL_SUB').jfGrid({
                rowHeight: 40,
                headData: [
                    {
                        label: '产品型号', name: 'F_PRODUCT_MODEL', width: 100, align: 'center'                       
                    },
                    {
                        label: '封装外形', name: 'F_PACKAGE_MODEL', width: 100, align: 'center'
                    },
                    {
                        label: '芯片型号', name: 'F_WAFER_MODEL', width: 100, align: 'center'
                    },
                    {
                        label: '晶圆尺寸', name: 'F_WAFER_SIZE', width: 70, align: 'center'
                    },
                    {
                        label: '包装方式', name: 'F_PACKAGING_TYPE', width: 70, align: 'center'
                    },
                    {
                        label: '封装等级', name: 'F_PRODUCT_LEVEL', width: 70, align: 'center'
                    },
                    {
                        label: '填报月份', name: 'A', width: 70, align: 'center',
                        children: [
                            {
                                label: '一', name: 'F_MONTH_ONE', width: 60, align: 'center'
                                , edit: {
                                    type: 'input'
                                }
                            },
                            {
                                label: '二', name: 'F_MONTH_TWO', width: 60, align: 'left'
                                , edit: {
                                    type: 'input'
                                }
                            },
                            {
                                label: '三', name: 'F_MONTH_THREE', width: 60, align: 'left'
                                , edit: {
                                    type: 'input'
                                }
                            },
                            {
                                label: '四', name: 'F_MONTH_FOUR', width: 60, align: 'left'
                                , edit: {
                                    type: 'input'
                                }
                            },
                            {
                                label: '五', name: 'F_MONTH_FIVE', width: 60, align: 'left'
                                , edit: {
                                    type: 'input'
                                }
                            },
                            {
                                label: '六', name: 'F_MONTH_SIX', width: 60, align: 'left'
                                , edit: {
                                    type: 'input'
                                }
                            },
                        ]
                    },
                    {
                        label: '备注', name: 'F_REMARK', width: 100, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '焊线描述', name: 'F_WIRE_SOLDER_NAME', width: 100, align: 'left'
                    },
                    {
                        label: '框架描述', name: 'F_WIRE_SOLDER_NAME', width: 100, align: 'left'
                    },
                    {
                        label: 'PARTID', name: 'PARTID', width: 100, align: 'left'
                    },
                    {
                        label: '焊线编号', name: 'F_WIRE_SOLDER_CODE', width: 0, align: 'left', ishide: true
                    },
                    {
                        label: '框架编号', name: 'F_SHELL_FRAM_CODE', width: 0, align: 'left', ishide: true
                    },
                ],
                isEdit: true,
                height: 580
            });
        },
        initData: function () {         
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/GetFormData?keyValue=' + keyValue, function (data) {                   
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
        postData.strEntitysub = JSON.stringify($('#B2B_PLAN_INCOMING_MATERIAL_SUB').jfGridGet('rowdatas'));
        postData.strEntity = JSON.stringify($('[data-table="B2B_PLAN_INCOMING_MATERIAL"]').lrGetFormData());
        $.lrSaveForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
