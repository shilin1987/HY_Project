/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-01-24 14:32
 * 描  述：晶圆清单导入
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var startTime;
    var endTime;
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 时间搜索框
            $('#datesearch').lrdate({
                dfdata: [
                    { name: '今天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00') }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近7天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'd', -6) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近1个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -1) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近3个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -3) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } }
                ],
                // 月
                mShow: false,
                premShow: false,
                // 季度
                jShow: false,
                prejShow: false,
                // 年
                ysShow: false,
                yxShow: false,
                preyShow: false,
                yShow: false,
                // 默认
                dfvalue: '1',
                selectfn: function (begin, end) {
                    startTime = begin;
                    endTime = end;
                    page.search();
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#FCUST_CODE').lrDataItemSelect({ code: '' });
            $('#FWAFER_TYPE').lrDataItemSelect({ code: '' });
            $('#FMANAGE_FLG').lrDataItemSelect({ code: '' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/B2B_Code/B2B_WAFER_LIST/Form',
                    width: 450,
                    height: 360,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑

            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('FGUID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/B2B_Code/B2B_WAFER_LIST/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/B2B_Code/B2B_WAFER_LIST/GetPageList',
                headData: [
                    { label: "客户代码", name: "FCUST_CODE", width: 100, align: "left" },
                    { label: "建立日期", name: "FCREATE_DATE", width: 130, align: "left" },
                    { label: "文件名称", name: "FFILE_NAME", width: 180, align: "left" },                  
                    { label: "审核日期", name: "FCHECK_DATE", width: 130, align: "left" },
                    { label: "审核人员", name: "FCHECK_PERSON", width: 100, align: "left" },
                    { label: "状态", name: "FMANAGE_FLG", width: 100, align: "left" }
                ],
                mainId:'FGUID',
                isPage: true,           
                reloadSelected: true,
                isSubGrid: true,
                isMultiselect: true,
                subGridExpanded: function (subid, rowdata) {
                    $('#' + subid).jfGrid({
                        url: top.$.rootUrl + '/B2B_Code/B2B_WAFER_LIST/GetPageListSub',
                        headData: [
                            { label: '芯片型号', name: 'FWAFER_TYPE', width: 150, align: 'center' },
                            {
                                label: '芯片批号', name: 'FWAFER_BATCH', width: 150, align: 'center'
                            },
                            {
                                label: '片数', name: 'FWAFER_QTY', width: 120, align: 'center'
                            },
                            {
                                label: '批号', name: 'FWAFER_NUMBER', width: 150, align: 'center'
                            },
                            {
                                label: '数量', name: 'FWAFER_DIE', width: 120, align: 'center'
                            }
                        ]
                    });
                    $('#' + subid).jfGridSet('reload', { keyValue: rowdata.FGUID });
                }
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
