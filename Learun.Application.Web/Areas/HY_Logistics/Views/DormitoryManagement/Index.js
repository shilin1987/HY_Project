﻿/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-02-24 10:49
 * 描  述：宿舍管理功能
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
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/HY_Logistics/DormitoryManagement/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HY_Logistics/DormitoryManagement/GetPageList',
                headData: [
                    { label: "姓名", name: "F_RealName", width: 100, align: "center"},
                    { label: "身份证号", name: "F_IDCard", width: 200, align: "center"},
                    //{
                    //    label: '性别', name: 'F_Gender', width: 45, align: 'center',

                    //},
                    {   label: '性别', name: 'F_Gender', width: 45, align: 'center',
                        formatter: function (cellvalue) {
                            return cellvalue == 0 ? "女" : "男";
                        }
                    },
                    { label: "联系方式", name: "F_Mobile", width: 200, align: "center"},
                    { label: "宿舍号", name: "F_Dormitory", width: 200, align: "center"},
                ],
                mainId:'F_UserId',
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
