/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-12-31 10:54
 * 描  述：RWrittenExamination
 */
var selectedRow;
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
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                selectedRow = null;
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/Platform/RWrittenExamination/Form',
                    width: 700,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                var OperationStatus = $('#gridtable').jfGridValue('OperationStatus');
                if (OperationStatus !== 0) {
                    return learun.alert.warning("已笔试人员信息不能再次操作！");
                }

                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/Platform/RWrittenExamination/Form?keyValue=' + keyValue,
                        width: 700,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });

            //// 删除
            //$('#lr_delete').on('click', function () {
            //    var keyValue = $('#gridtable').jfGridValue('F_Id');
            //    if (learun.checkrow(keyValue)) {
            //        learun.layerConfirm('是否确认删除该项！', function (res) {
            //            if (res) {
            //                learun.deleteForm(top.$.rootUrl + '/Platform/RWrittenExamination/DeleteForm', { keyValue: keyValue}, function () {
            //                    refreshGirdData();
            //                });
            //            }
            //        });
            //    }
            //});


            //重考
            $('#lr_reset').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                var OperationStatus = $('#gridtable').jfGridValue('OperationStatus');
                if (OperationStatus == 1 || OperationStatus == 0) {
                    return learun.alert.warning("该人员不能进行重考！！！");
                };
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否重置考试信息？', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/Platform/RWrittenExamination/Resetinfo', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                            
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/Platform/RWrittenExamination/GetPageList',
                headData: [
                    {
                        label: "员工姓名", name: "F_RealName", width: 100, align: "left",
                        //formatterAsync: function (callback, value, row, op, $cell) {
                        //    learun.clientdata.getAsync('custmerData', {
                        //        url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'newUser',
                        //        key: value,
                        //        keyId: 'f_userid',
                        //        callback: function (_data) {
                        //            callback(_data['f_realname']);
                        //        }
                        //    });
                        //}
                    },
                    { label: '身份证号', name: 'F_IDCard', width: 200, align: "left" },
                    //{
                    //    label: "身份证号", name: "F_CandidatesID", width: 100, align: "left",
                    //    formatterAsync: function (callback, value, row, op, $cell) {
                    //        learun.clientdata.getAsync('custmerData', {
                    //            url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'newUser',
                    //            key: value,
                    //            keyId: 'f_userid',
                    //            callback: function (_data) {
                    //                callback(_data['f_idcard']);
                    //            }
                    //        });
                    //    }
                    //},
                    {
                        label: '性别', name: 'F_Gender', width: 45, align: 'center',
                        formatter: function (cellvalue) {
                            return cellvalue == 0 ? "女" : "男";
                        }
                    },
                    { label: "联系方式", name: "F_Mobile", width: 200, align: "left" },
                    { label: "学历", name: "F_Education", width: 200, align: "left" },
                    {
                        label: "笔试题库", name: "F_WrittenTestQuestionBankId", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'testpaper',
                                key: value,
                                keyId: 'f_id',
                                callback: function (_data) {
                                    callback(_data['f_testpapername']);
                                }
                            });
                        }
                    },

                    // { label: '分数', name: 'F_Score', width: 200, align: "left" },
                    {
                        label: '状态', name: "OperationStatus", index: "OperationStatus", width: 100, align: "center",
                        formatter: function (cellvalue,row) {
                            if (cellvalue == 0) {
                                return '<span class=\"label label-default\" style=\"cursor: pointer;\">待笔试</span>';
                            }
                            if (cellvalue == 1) {
                                return '<span class=\"label label-success\" style=\"cursor: pointer;\">通过</span>'
                            }
                            if (cellvalue ==-1) {
                                return '<span class=\"label label-danger\" style=\"cursor: pointer;\">不通过</span>';
                            }
                           
                        }
                    },
                    { label: '操作日期', name: 'OperationTime', width: 200, align: "left" },
                    {
                        label: '操作者', name: 'Operator', width: 150, align: "left",
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
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
