/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-06-15 10:19
 * 描  述：个人标准工资维护
 */
var refreshGirdData;
var subRowId;
var parentId;
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
            }, 160, 400);
            $('#F_UserId').lrDataSourceSelect({ code: 'userdata', value: 'f_userid', text: 'f_encode' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/HR_Code/EverybodyStandardWage/Form',
                    width: 400,
                    height: 250,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 新增子项
            $('#lr_addsub').on('click', function () {
                var parentId = $('#gridtable').jfGridValue('F_ID');
               
                //新增子项金额不能大于标准工资.
                if (learun.checkrow(parentId)) {
                    learun.layerForm({
                        id: 'form',
                        title: '新增子项',
                        url: top.$.rootUrl + '/HR_Code/EverybodyStandardWage/SubForm?flag=add&parentId=' + parentId,
                        width: 400,
                        height: 300,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 编辑子项
            $('#lr_editsub').on('click', function () {
                if (subRowId == null) {
                    learun.alert.warning('请选择需要编辑子项.');
                } else {
                    var isFixedCost = $('#' + subRowId).jfGridValue('IsFixedCost');
                    if (isFixedCost == '' && isFixedCost != '0') {
                        learun.alert.warning('请选择需要编辑子项.');
                    } else {
                        var itemName = $('#' + subRowId).jfGridValue('SubItem');
                        if (itemName == '基本工资') {
                            learun.alert.warning('基本工资请在员工信息和岗级维护功能中组合编辑.');
                        } else {
                            if (isFixedCost == "2") {
                                var subId = $('#' + subRowId).jfGridValue('Id');
                                if (learun.checkrow(subId)) {
                                    learun.layerForm({
                                        id: 'form',
                                        title: '编辑子项',
                                        url: top.$.rootUrl + '/HR_Code/EverybodyStandardWage/SubForm?flag=edit&parentId=' + parentId + '&subId=' + subId,
                                        width: 400,
                                        height: 300,
                                        callBack: function (id) {
                                            return top[id].acceptClick(refreshGirdData);
                                        }
                                    });
                                }
                            } else {
                                learun.alert.warning('此子项类型请在"标准工资通用维护"中编辑.');
                            }
                        }
                    }
                }
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/HR_Code/EverybodyStandardWage/Form?keyValue=' + keyValue,
                        width: 400,
                        height: 250,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/HR_Code/EverybodyStandardWage/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 删除子项
            $('#lr_deletesub').on('click', function () {
                if (subRowId == null) {
                    learun.alert.warning('请选择需要删除子项.');
                } else {
                    var isFixedCost = $('#' + subRowId).jfGridValue('IsFixedCost');
                    if (isFixedCost == "2") {
                        var itemName = $('#' + subRowId).jfGridValue('SubItem');
                        if (itemName == '基本工资') {
                            learun.alert.warning('基本工资不能删除.');
                        } else {
                            if (learun.checkrow(subRowId)) {
                                learun.layerConfirm('是否确认删除该子项！', function (res) {
                                    if (res) {
                                        learun.deleteForm(top.$.rootUrl + '/HR_Code/EverybodyStandardWage/DeleteFormSub', { keyValue: $('#' + subRowId).jfGridValue('Id') }, function () {
                                            refreshGirdData();
                                        });
                                    }
                                });
                            }
                        }
                    } else {
                        learun.alert.warning('此类型子项请在通用费用中统一删除.');
                    }
                }
            });
            //  导出
            $('#lr-export').on('click', function () {
            });
            //  导入
            $('#lr-import').on('click', function () {
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HR_Code/EverybodyStandardWage/GetPageList',
                headData: [
                    {
                        label: "员工账号", name: "F_UserId", width: 200, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'userdata',
                                key: value,
                                keyId: 'f_userid',
                                callback: function (_data) {
                                    callback(_data['f_encode']);
                                }
                            });
                        }
                    },
                    { label: "标准工资", name: "F_StandardWage", width: 200, align: "center" },
                ],
                mainId: 'F_ID',
                isPage: true,
                rows: 20,
                reloadSelected: true,
                isSubGrid: true,             // 是否有子表
                subGridExpanded: function (subid, rowdata) {
                    $('#' + subid).jfGrid({
                        url: top.$.rootUrl + '/HR_Code/EverybodyStandardWage/GetSubList',
                        headData: [
                            { label: "子项", name: "SubItem", width: 300, align: "center" },
                            { label: "金额", name: "SubCost", width: 120, align: "center" },
                            {
                                label: "子项类型", name: "IsFixedCost", width: 120, align: "center",
                                formatter: function (cellvalue) {
                                    return cellvalue == 0 ? "公式计算" : (cellvalue == 1 ? "通用金额" : "个人分配");
                                }
                            },
                            { label: "计算过程异常备注", name: "Remark", width: 200, align: "center" },
                        ],
                    });
                    $('#' + subid).jfGridSet('reload', { fid: rowdata.F_ID, fcost: rowdata.F_StandardWage });
                    parentId = rowdata.F_ID;
                    subRowId = subid;
                },// 子表展开后调用函数
            });
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
