/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-11-10 13:46
 * 描  述：客户端月度来料计划填报
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
            //添加
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '添加',
                    url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/Add',
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
                        url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/Form?keyValue=' + keyValue,
                        width: 1200,
                        height: 800,
                        maxmin: true,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });

            $('#F_WRITE_MONTH').lrDataItemSelect({ code: 'Month' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 删除
            $('#lr_delete').on('click', function () {       
                var keyValue = $('#gridtable').jfGridValue('F_GUID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //  导入
            $('#B2B_IMPORT').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '批导功能',
                    url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/ImportExcel',
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
                url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/GetPageList',
                headData: [
                    { label: "F_GUID", name: "F_GUID", width: 100, align: "left", ishide: true },
                    { label: "填报月份", name: "F_WRITE_MONTH", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'Month',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "填报客户", name: "F_CUST_CODE", width: 100, align: "left"},
                    { label: "填报人员", name: "F_WRITE_PRESON", width: 100, align: "left"},
                    { label: "填报时间", name: "F_WRITE_DATE", width: 100, align: "left"},
                ],
                mainId: 'F_GUID',
                isPage: true,
                reloadSelected: true,
                isSubGrid: true,
                isMultiselect: true,
                subGridExpanded: function (subid, rowdata) {
                    $('#' + subid).jfGrid({
                        url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/GetPageListSub',
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
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
