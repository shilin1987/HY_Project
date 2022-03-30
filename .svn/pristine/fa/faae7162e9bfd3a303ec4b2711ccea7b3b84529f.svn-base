/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-01-12 21:11
 * 描  述：菜价补贴月明细数据
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
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/HR_Code/FSVegetablePriceSubsidyMonthlyDetails/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/HR_Code/FSVegetablePriceSubsidyMonthlyDetails/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
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
                            learun.deleteForm(top.$.rootUrl + '/HR_Code/FSVegetablePriceSubsidyMonthlyDetails/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 打印
            $('#lr_print').on('click', function () {
                //  月菜价补贴计算
                    $.ajax({
                        url: top.$.rootUrl + '/HR_Code/FSVegetablePriceSubsidyMonthlyDetails/CalculateRerust',
                        type: "post",
                        dataType: "json",
                        success: function (data) {
                            if (data.code == 200) {
                                learun.alert.info("菜价补贴计算成功");
                            } else {
                                learun.alert.info(data);
                            }
                        },
                        error: function (e) {
                            //learun.alert.error("网络错误，请重试！！");
                        }
                    });
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HR_Code/FSVegetablePriceSubsidyMonthlyDetails/GetPageList',
                headData: [
                    { label: "人员工号", name: "F_UserId", width: 100, align: "center"},
                    { label: "人员姓名", name: "F_UserName", width: 100, align: "center"},
                    { label: "年份", name: "F_Year", width: 100, align: "center"},
                    { label: "月份", name: "F_Month", width: 100, align: "center"},
                    { label: "班次", name: "F_ShiftType", width: 100, align: "center" },
                    { label: "班次名称", name: "F_ShiftName", width: 100, align: "center" },
                    { label: "夜班白班", name: "F_ShiftTypeExend", width: 100, align: "center" },
                    { label: "实际出勤", name: "F_Time", width: 100, align: "center" },
                    { label: "班次时长", name: "F_ShiftTime", width: 100, align: "center" },
                    { label: "签卡", name: "F_Qk", width: 100, align: "center"},
                    { label: "早餐", name: "F_Breakfast", width: 100, align: "center"},
                    { label: "午餐", name: "F_Lunch", width: 100, align: "center"},
                    { label: "晚餐", name: "F_Dinner", width: 100, align: "center"},
                    { label: "夜宵", name: "F_Night", width: 100, align: "center"},
                    { label: "标准金额合计", name: "F_StandardCombined", width: 100, align: "center"},
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
