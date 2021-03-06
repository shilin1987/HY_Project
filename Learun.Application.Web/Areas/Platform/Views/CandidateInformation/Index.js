/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-12-30 18:10
 * 描  述：应聘者信息
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
            }, 250, 400);
            $('#F_Education').lrDataItemSelect({ code: 'Education' });
            $('#F_RecruitmentChannels').lrDataItemSelect({ code: 'EntryChannel' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/Platform/CandidateInformation/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/Platform/CandidateInformation/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 上传照片
            $('#lr_upload').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '照片上传',
                        url: top.$.rootUrl + '/Platform/CandidateInformation/HeadForm?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/Platform/CandidateInformation/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });

            //  导入
            $('#lr_import').on('click', function () {
            });
            //  导出
            $('#lr_export').on('click', function () {
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/Platform/CandidateInformation/GetPageList',
                headData: [
                    { label: "应聘者姓名", name: "F_RealName", width: 100, align: "center"},
                    { label: "证件号码", name: "F_IDCard", width: 140, align: "center"},
                    { label: "联系方式", name: "F_Mobile", width: 110, align: "center"},
                    { label: "学历", name: "F_Education", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'Education',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "期望入职时间", name: "F_ExpectedentryDate", width: 110, align: "center"},
                    { label: "入职渠道", name: "F_RecruitmentChannels", width: 110, align: "center" },
                    //{
                    //    label: "入职渠道", name: "F_RecruitmentChannels", width: 100, align: "center",
                    //    formatterAsync: function (callback, value, row, op,$cell) {
                    //         learun.clientdata.getAsync('dataItem', {
                    //             key: value,
                    //             code: 'EntryChannel',
                    //             callback: function (_data) {
                    //                 callback(_data.text);
                    //             }
                    //         });
                    //    }},
                    { label: "内部推荐人编码", name: "F_InternalCode", width: 100, align: "center"},
                    { label: "内部推荐人姓名", name: "F_InternalName", width: 100, align: "center"},
                    { label: "内部推荐人公司", name: "F_InternalCompany", width: 100, align: "center"},
                    { label: "注册时间", name: "F_CreateDate", width: 110, align: "center"},
                    { label: "劳务公司", name: "F_RecruitmentCompany", width: 120, align: "center" },
                ],
                mainId:'F_UserId',
                isPage: true
            });
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
