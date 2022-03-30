/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-06-29 16:05
 * 描  述：考勤工资表达式
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
            }, 150, 400);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/HR_Code/AttendanceSalaryFormula/Form',
                    width: 800,
                    height: 500,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_FormulaId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/HR_Code/AttendanceSalaryFormula/Form?keyValue=' + keyValue,
                        width: 800,
                        height: 500,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_FormulaId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/HR_Code/AttendanceSalaryFormula/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 禁用
            $('#lr_stop').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_FormulaId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【禁用】该项数据！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/HR_Code/AttendanceSalaryFormula/UpdateState', { keyValue: keyValue, state: 0 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 启用
            $('#lr_enable').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_FormulaId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【启用】该项数据！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/HR_Code/AttendanceSalaryFormula/UpdateState', { keyValue: keyValue, state: 1 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HR_Code/AttendanceSalaryFormula/GetPageList',
                headData: [
                    { label: "公式编号", name: "F_FormulaCode", width: 200, align: "center" },
                    {
                        label: "计算公式分类", name: "F_ShiftType", width: 200, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'AttendanceFormulaType',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },

                    {
                        label: "是否启用", name: "F_EnabledMark", width: 100, align: "center",
                        formatter: function (cellvalue) {
                            if (cellvalue == 1) {
                                return '是';
                            } else if (cellvalue == 0) {
                                return '否';
                            }
                        }
                    },

                    { label: "公式描述", name: "F_FormulaName", width: 200, align: "center"},
                    { label: "计算表达式", name: "F_Expression", width: 400, align: "center"},
                ],
                mainId:'F_FormulaId',
                isPage: true
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
