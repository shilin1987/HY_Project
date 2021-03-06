/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-12-22 14:41
 * 描  述：身份证信息读取对比
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
            }, 220, 300);
            $('#F_State').lrDataItemSelect({ code: 'CardIdVerifyTheStatus' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                var stateValue = $('#gridtable').jfGridValue('F_State');
                learun.clientdata.getAsync('dataItem', {
                    key: stateValue,
                    code: 'CardIdVerifyTheStatus',
                    callback: function (_data) {
                        stateValue = _data.text;
                    }
                });
                if (stateValue == "待人工审核") {
                    learun.alert.info("请点击人工审核按钮");
                } else {
                    if (learun.checkrow(keyValue)) {
                        learun.layerConfirm('自动审核和人工审核进行中！', function (res) {
                            if (res) {
                                learun.generalPostForm(top.$.rootUrl + '/Platform/ComparisonOfIdCardVerificationClass/VerifyIDCard', { keyValue: keyValue }, "身份证信息对比", function () {
                                    // var dataObj = eval("(" + res + ")");
                                    // learun.alert.info(dataObj.Message);
                                    refreshGirdData();
                                });
                            }
                        });
                    }
                }
            });
            //  人工审核通过
            $('#lr_audit').on('click', function () {
                var stateValue = $('#gridtable').jfGridValue('F_State');
                var keyValue = $('#gridtable').jfGridValue('F_ID');

                learun.clientdata.getAsync('dataItem', {
                    key: stateValue,
                    code: 'CardIdVerifyTheStatus',
                    callback: function (_data) {
                        stateValue = _data.text;
                    }
                });
                if (stateValue == "待自动对比") {
                    learun.alert.info("请先进行身份证自动检验环节,");
                } else {
                    if (learun.checkrow(keyValue)) {
                        learun.layerConfirm('  人工审核通过！', function (res) {
                            if (res) {
                                learun.generalPostForm(top.$.rootUrl + '/Platform/ComparisonOfIdCardVerificationClass/AuditInfo', { keyValue: keyValue }, "人工审核通过", function () {
                                    // var dataObj = eval("(" + res + ")");
                                    // learun.alert.info(dataObj.Message);
                                    refreshGirdData();
                                });
                            }
                        });
                    }
                }
            });
            //  人工审核不通过
            $('#lr_unaudit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('人工审核不通过删除该项！', function (res) {
                        if (res) {
                            learun.generalPostForm(top.$.rootUrl + '/Platform/ComparisonOfIdCardVerificationClass/UnAuditInfo', { keyValue: keyValue }, "人工审核不通过", function () {
                              //  var dataObj = eval("(" + res + ")");
                               // learun.alert.info(dataObj.Message);
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
                url: top.$.rootUrl + '/Platform/ComparisonOfIdCardVerificationClass/GetPageList',
                headData: [
                    { label: "姓名", name: "F_UserName", width: 100, align: "center"},
                    { label: "身份证编号", name: "F_CardID", width: 100, align: "center"},
                    { label: "性别", name: "F_Sex", width: 100, align: "center" },
                    { label: "联系方式", name: "F_Contact", width: 100, align: "center" },
                    { label: "学历", name: "F_EducationInformation", width: 100, align: "center" },
                    { label: "当前状态", name: "F_State", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'CardIdVerifyTheStatus',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "最后操作日期", name: "F_OperatingTime", width: 100, align: "center"},
                    { label: "操作人员", name: "F_OperationPerson", width: 100, align: "center"},
                    { label: "身份证读取差异", name: "F_InformationContrastDifference", width: 100, align: "center"},
                ],
                mainId:'F_ID',
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
