﻿/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-09-27 09:59
 * 描  述：黑名单永不录用
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
                    url: top.$.rootUrl + '/Platform/Blacklist/Form',
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
                        url: top.$.rootUrl + '/Platform/Blacklist/Form?keyValue=' + keyValue,
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
                            learun.deleteForm(top.$.rootUrl + '/Platform/Blacklist/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 禁用
            $('#lr_stop').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【禁用】该项数据！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/Platform/Blacklist/UpdateState', { keyValue: keyValue, state: 0 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 启用
            $('#lr_enable').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【启用】该项数据！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/Platform/Blacklist/UpdateState', { keyValue: keyValue, state: 1 }, function () {
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
                url: top.$.rootUrl + '/Platform/Blacklist/GetPageList',
                headData: [
                    { label: "姓名", name: "F_UserName", width: 100, align: "left" },
                    //{
                    //    label: "是否有效", name: "F_EnabledMark", width: 100, align: "center",
                    //    formatter: function (cellvalue) {
                    //        return cellvalue == 1 ? "是" : "否";
                    //    }
                    //},
                    { label: "身份证号", name: "F_IDCard", width: 200, align: "left" },
                    { label: "原因说明", name: "F_Description", width: 200, align: "left" },
                    
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
