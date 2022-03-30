/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-01-24 16:29
 * 描  述：客户订单审核
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
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 审核
            $('#lr_add').on('click', function () {
                var keyValue = $('#B2B_CUST_ORDER').jfGridValue('FGUID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认审核该项！', function (res) {
                        if (res) {     
                            learun.postForm(top.$.rootUrl + '/B2B_Code/B2B_CUST_ORDER_CHECK/CheckForm', { keyValue: keyValue }, function (data) {
                                //var listdata = JSON.parse(data);
                                //for (var id in listdata) {                                  
                                //    alert(listdata[id]);
                                //}
                             /*   alert(data);*/
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#B2B_CUST_ORDER').jfGridValue('FGUID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/B2B_Code/B2B_CUST_ORDER_CHECK/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#B2B_CUST_ORDER').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/B2B_Code/B2B_CUST_ORDER_CHECK/GetPageList',
                headData: [
                    { label: "客户代码", name: "FCUST_CODE", width: 100, align: "left" },
                    { label: "订单类型", name: "FORDER_TYPE", width: 100, align: "left" },
                    { label: "建立日期", name: "FCREATE_DATE", width: 130, align: "left" },
                    { label: "审核日期", name: "FCHECK_DATE", width: 130, align: "left" },
                    { label: "审核人员", name: "FCHECK_PERSON", width: 100, align: "left" },
                    { label: "状态", name: "FMANAGE_FLG", width: 100, align: "left" },
                    { label: "备注", name: "FREMARK", width: 250, align: "left" },
                ],
                mainId: 'FGUID',
                isPage: true,
                reloadSelected: true,
                isSubGrid: true,
                isMultiselect: true,
                subGridExpanded: function (subid, rowdata) {
                    $('#' + subid).jfGrid({
                        url: top.$.rootUrl + '/B2B_Code/B2B_CUST_ORDER_CHECK/GetPageListSub',
                        headData: [
                            {
                                label: 'GUID', name: 'FGUID', width: 100, align: 'center', ishide: true
                            },
                            {
                                label: 'PARTID', name: 'FPARTID', width: 100, align: 'center', ishide: true
                            },
                            {
                                label: '芯片型号', name: 'FWAFER_TYPE', width: 100, align: 'center'
                            },
                            {
                                label: '产品型号', name: 'FPRODUCT_TYPE', width: 100, align: 'left'
                            },
                            {
                                label: '封装形式', name: 'FPACKAGE_TYPE', width: 100, align: 'left'
                            },
                            {
                                label: '芯片批号', name: 'FWAFER_BATCH', width: 100, align: 'left'
                            },
                            {
                                label: '芯片片数', name: 'FWAFER_NUMBER', width: 100, align: 'left'
                            },
                            {
                                label: '芯片片号', name: 'FWAFER_NO', width: 100, align: 'left'
                            },
                            {
                                label: '芯片数量', name: 'FWAFER_QTY', width: 80, align: 'left'
                            },
                            {
                                label: '是否测试', name: 'FIS_TEST', width: 80, align: 'left'
                            },
                            {
                                label: '测试规范编号', name: 'FTEST_CODE', width: 100, align: 'left'
                            },
                            {
                                label: '是否打印', name: 'FIS_PRINT', width: 80, align: 'left'
                            },
                            {
                                label: '印章规范编号', name: 'FPRINT_CODE', width: 100, align: 'left'
                            },
                            {
                                label: '压焊图号', name: 'FBONDING_CODE', width: 100, align: 'left'
                            },
                            {
                                label: '包装方式', name: 'FPACKING_TYPE', width: 100, align: 'left'
                            },
                            {
                                label: '环保等级', name: 'FGREEN_LEVE', width: 100, align: 'left'
                            },
                            {
                                label: '封装等级', name: 'FPACKAGE_LEVE', width: 100, align: 'left'
                            },
                            {
                                label: '取片方式', name: 'FGETWAFER_TYPE', width: 100, align: 'left'
                            },
                            {
                                label: '贸易方式', name: 'FTRADE_TYPE', width: 100, align: 'left'
                            },
                            {
                                label: '用户批号', name: 'FCUST_PO', width: 80, align: 'left'
                            }
                        ],
                        mainId: 'FPARTID',
                        isSubGrid: false,
                        isMultiselect: true,
                        subGridExpanded: function (subid, rowdata) {
                            $('#' + subid).jfGrid({
                                url: top.$.rootUrl + '/B2B_Code/B2B_CUST_ORDER_CHECK/GetParamtListSub',
                                headData: [
                                    {
                                        label: 'PARTID', name: 'FPARTID', width: 100, align: 'center', ishide: true
                                    },
                                    {
                                        label: '参数编号', name: 'FPARAM_CODE', width: 150, align: 'center'
                                    },
                                    {
                                        label: '参数名称', name: 'FPARAM_NAME', width: 150, align: 'left'
                                    },
                                    {
                                        label: '参数值', name: 'FPARAM_VALUE', width: 150, align: 'left'
                                    }
                                ]
                            });
                            $('#' + subid).jfGridSet('reload', { keyValue: rowdata.FGUID, partId: rowdata.FPARTID });
                        }
                    });
                    $('#' + subid).jfGridSet('reload', { keyValue: rowdata.FGUID });
                }
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#B2B_CUST_ORDER').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#B2B_CUST_ORDER').jfGridSet('reload');
    };
    page.init();
}
