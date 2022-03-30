/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-01-28 09:22
 * 描  述：作业员笔试题库
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
                    url: top.$.rootUrl + '/Platform/RecruitExaminationQuestionBank/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_Id');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/Platform/RecruitExaminationQuestionBank/Form?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('F_Id');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/Platform/RecruitExaminationQuestionBank/DeleteForm', { keyValue: keyValue}, function () {
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
                url: top.$.rootUrl + '/Platform/RecruitExaminationQuestionBank/GetPageList',
                headData: [
                    { label: "题库名称", name: "F_TestPaperName", width: 100, align: "left" },
                    //{ label: "题目内容", name: "F_Content", width: 100, align: "left" },
                    //{
                    //    label: "题目内容", name: "F_Content", width: 100, align: "left",
                    //    formatterAsync: function (callback, value, row, op, $cell) {
                    //        learun.clientdata.getAsync('custmerData', {
                    //            url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'Questions',
                    //            key: value,
                    //            keyId: 'f_id',
                    //            callback: function (_data) {
                    //                callback(_data['questions']);
                    //            }
                    //        });
                    //    }                    },
                    { label: "分类", name: "F_Description", width: 100, align: "left"},
                    { label: "及格分数线", name: "F_MinimumScore", width: 100, align: "left"},
                    { label: "创建时间", name: "F_CreateDate", width: 100, align: "left"},
                    { label: "操作者", name: "F_ModifyUserName", width: 100, align: "left"},
                ],
                mainId:'F_Id',
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
