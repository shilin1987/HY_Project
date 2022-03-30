/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-02-22 09:14
 * 描  述：节点信息查询
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
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/Platform/NodeInformation/GetPageList',
                headData: [
                    { label: "姓名", name: "F_RealName", width: 100, align: "left" },
                    { label: "联系方式", name: "F_Mobile", width: 100, align: "left" },
                    { label: "身份证号", name: "F_IDCard", width: 150, align: "left" },
                    { label: "招聘渠道", name: "F_RecruitmentChannels", width: 100, align: "left" },
                    { label: "学历", name: "F_Education", width: 100, align: "left" },
                    { label: "节点名称", name: "Name", width: 100, align: "left" },
                    { label: "操作时间", name: "OperationTime", width: 100, align: "left" },
                    {
                        label: "操作人", name: "Operator", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'userdata',
                                key: value,
                                keyId: 'f_userid',
                                callback: function (_data) {
                                    callback(_data['f_realname']);
                                }
                            });
                        }
                    },
                    
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
