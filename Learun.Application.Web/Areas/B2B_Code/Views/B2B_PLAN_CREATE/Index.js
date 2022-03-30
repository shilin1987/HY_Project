/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：B2B_Account
 * 日  期：2021-10-28 15:35
 * 描  述：来料计划填报
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_WRITE_MONTH').lrDataItemSelect({ code: 'Month' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '手工录入',
                    url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_CREATE/Form',
                    width: 1200,
                    height: 800,
                    maxmin: true,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_GUID');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_CREATE/Form?keyValue=' + keyValue,
                        width: 1200,
                        height: 800,
                        maxmin: true,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_GUID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_CREATE/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 打印
            $('#lr_print').on('click', function () {
                learun.download({
                    method: "POST",
                    url: '/Utility/ExportExcel',
                    param: {
                        fileName: "客户来料计划批量模版",
                        columnJson: JSON.stringify([
                            { "label": "PARTID", "name": "PARTID", "width": 100, "align": "center" },
                            { "label": "产品型号", "name": "F_PRODUCT_MODEL", "width": 100, "align": "center" },
                            { "label": "封装外形", "name": "F_PACKAGE_MODEL", "width": 100, "align": "center" },
                            { "label": "封装等级", "name": "F_PRODUCT_LEVEL", "width": 100, "align": "center" },
                            { "label": "芯片型号", "name": "F_WAFER_MODEL", "width": 100, "align": "center" },
                            { "label": "晶圆尺寸", "name": "F_WAFER_SIZE", "width": 100, "align": "center" },
                            { "label": "包装方式", "name": "F_PACKAGING_TYPE", "width": 100, "align": "center" },
                            { "label": "焊线编号", "name": "F_WIRE_SOLDER_CODE", "width": 100, "align": "center" },
                            { "label": "焊线描述", "name": "F_WIRE_SOLDER_NAME", "width": 100, "align": "center" },
                            { "label": "框架编号", "name": "F_SHELL_FRAM_CODE", "width": 100, "align": "center" },
                            { "label": "框架描述", "name": "F_SHELL_FRAM_NAME", "width": 100, "align": "center" },
                            { "label": "月份", "name": "F_MONTH_ONE", "width": 100, "align": "center" },
                            { "label": "月份", "name": "F_MONTH_TWO", "width": 100, "align": "center" },
                            { "label": "月份", "name": "F_MONTH_THREE", "width": 100, "align": "center" },
                            { "label": "月份", "name": "F_MONTH_FOUR", "width": 100, "align": "center" },
                            { "label": "月份", "name": "F_MONTH_FIVE", "width": 100, "align": "center" },
                            { "label": "月份", "name": "F_MONTH_SIX", "width": 100, "align": "center" },
                            { "label": "备注", "name": "F_REMARK", "width": 100, "align": "center" }
                        ]),
                        dataJson: JSON.stringify([{
                            "F_GUID": "", "F_ID": "", "PARTID": "", "F_PRODUCT_MODEL": "", "F_PACKAGE_MODEL": "", "F_PRODUCT_LEVEL": "",
                            "F_WAFER_MODEL": "","F_WAFER_SIZE": "", "F_PACKAGING_TYPE": "", "F_WIRE_SOLDER_CODE": "", "F_WIRE_SOLDER_NAME": "",
                            "F_SHELL_FRAM_CODE": "", "F_SHELL_FRAM_NAME": "","F_MONTH_ONE": "", "F_MONTH_TWO": "", "F_MONTH_THREE": "",
                            "F_MONTH_FOUR": "", "F_MONTH_FIVE": "", "F_MONTH_SIX": "","F_REMARK": ""  
                        }])
                    }
                });
            });
            //  批量导入
            $('#B2B_INPUT').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '批导功能',
                    url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_CREATE/ImportExcel',
                    width: 480,
                    height: 450,
                    maxmin: true,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_CREATE/GetPageList',
                headData: [
                    { label: "GUID", name: "F_GUID", width: 100, align: "left",ishide:true },
                    { label: "客户代码", name: "F_CUST_CODE", width: 100, align: "left" },
                    {
                        label: "填报月份", name: "F_WRITE_MONTH", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'Month',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "填报人员", name: "F_WRITE_PRESON", width: 100, align: "left" },
                    { label: "填报时间", name: "F_WRITE_DATE", width: 100, align: "left" },
                ],
                mainId: 'F_GUID',
                isPage: true,
                reloadSelected: true,
                isSubGrid: true,
                isMultiselect: true,
                subGridExpanded: function (subid, rowdata) {
                    $('#' + subid).jfGrid({
                        url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_CREATE/GetPageListSub',
                        headData: [
                            { label: '产品型号', name: 'F_PRODUCT_MODEL', width: 100, align: 'center' },
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
                                        label: "一", name: 'F_MONTH_ONE', width: 60, align: 'center'                          
                                    },
                                    {
                                        label: "二", name: 'F_MONTH_TWO', width: 60, align: 'left'                                    
                                    },
                                    {
                                        label: '三', name: 'F_MONTH_THREE', width: 60, align: 'left'                                   
                                    },
                                    {
                                        label: '四', name: 'F_MONTH_FOUR', width: 60, align: 'left'                             
                                    },
                                    {
                                        label: '五', name: 'F_MONTH_FIVE', width: 60, align: 'left'                                     
                                    },
                                    {
                                        label: '六', name: 'F_MONTH_SIX', width: 60, align: 'left'                                  
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
                                label: '框架描述', name: 'F_SHELL_FRAM_NAME', width: 100, align: 'left'
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
                        ]
                    });
                    $('#' + subid).jfGridSet('reload', { keyValue: rowdata.F_GUID });
                }
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}