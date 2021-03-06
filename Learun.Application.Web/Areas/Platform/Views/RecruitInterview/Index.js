

/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-01-12 13:59
 * 描  述：面试信息
 */
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var startTime;
    var endTime;
    var _this = this;
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
            }, 180, 400);
            //$('#F_CandidatesID').lrDataSourceSelect({ code: 'newUser',value: 'f_id',text: 'f_realname' });
            $('#F_InterviewResult').lrDataItemSelect({ code: 'IsEnd' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/Platform/RecruitInterview/Form',
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
                var OperationStatus = $('#gridtable').jfGridValue('OperationStatus');
                if (OperationStatus!=0)
                {
                    return learun.alert.warning("已面试人员信息不能再次操作!");
                }
                    selectedRow = $('#gridtable').jfGridGet('rowdata');
                    if (learun.checkrow(keyValue)) {
                        learun.layerForm({
                            id: 'form',
                            title: '编辑',
                            url: top.$.rootUrl + '/Platform/RecruitInterview/Form?keyValue=' + keyValue,
                            width: 600,
                            height: 400,
                            callBack: function (id) {
                                return top[id].acceptClick(refreshGirdData);
                            }
                        });
                };
              
            });
            // 报告通知单
            $('#lr_Notice').on('click', function () {
                var Sunid = "7";
                learun.layerForm({
                    id: 'form',
                    title: '报告通知单',
                    url: top.$.rootUrl + '/Platform/RecruitReportNotice/FormList?Sunid=' + Sunid,
                    width: 900,
                    height: 600,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            //// 删除
            //$('#lr_delete').on('click', function () {
            //    var keyValue = $('#gridtable').jfGridValue('F_Id');
            //    if (learun.checkrow(keyValue)) {
            //        learun.layerConfirm('是否确认删除该项！', function (res) {
            //            if (res) {
            //                learun.deleteForm(top.$.rootUrl + '/Platform/RecruitInterview/DeleteForm', { keyValue: keyValue }, function () {
            //                    refreshGirdData();
            //                });
            //            }
            //        });
            //    }
            //});
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
                url: top.$.rootUrl + '/Platform/RecruitInterview/GetPageList',
                headData: [
                    //{ label: "员工姓名", name: "F_CandidatesID", width: 100, align: "left" },
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
                    { label: "身份证号", name: "F_IDCard", width: 200, align: "left" },
                    {
                        label: '性别', name: 'F_Gender', width: 45, align: 'center',
                        formatter: function (cellvalue) {
                            return cellvalue == 0 ? "女" : "男";
                        }
                    },
                    { label: "联系方式", name: "F_Mobile", width: 200, align: "left" },
                    { label: "学历", name: "F_Education", width: 200, align: "left" },
                   // { label: "面试官", name: "F_CreateUserName", width: 100, align: "left" },
                    {
                        label: "面试官", name: "F_Iuserid", width: 100, align: "left",
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
                    //{
                    //    label: "是否通过", name: "F_InterviewResult", width: 100, align: "left",
                    //    formatterAsync: function (callback, value, row, op, $cell) {
                    //        learun.clientdata.getAsync('dataItem', {
                    //            key: value,
                    //            code: 'IsEnd',
                    //            callback: function (_data) {
                    //                callback(_data.text);
                    //            }
                    //        });
                    //    }
                    //},
                    {
                        label: '状态', name: "OperationStatus",  width: 100, align: "center",
                        formatter: function (cellvalue) {
                            if (cellvalue == 1) {
                                return '<span class=\"label label-success\" style=\"cursor: pointer;\">通过</span>';
                            } else if (cellvalue == -1) {
                                
                                return '<span class=\"label label-danger\" style=\"cursor: pointer;style="background-color:red";\">不通过</span>';
                            } else if (cellvalue == 0) {
                                return '<span class=\"label label-default\" style=\"cursor: pointer;\">待面试</span>';
                            }
                        }
                    },
                    { label: "最后操作时间", name: "OperationTime", width: 150, align: "left" },
                    {
                        label: "操作者", name: "Operator", width: 100, align: "left",

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

                    {
                        //label: "报到通知单", name: "F_Notice", width: 100, align: "center", sort: false,
                        label: "报到通知单", name: "F_Notice", width: 100, align: "center", sort: false,
                        formatter: function (value, row, op, $cell) {
                            if (row.OperationStatus != 1) {
                                return '<span class=\"label label-default\" style=\"cursor: pointer;\">待发送</span>';
                            } else {
                                var $div = $('<div></div>');
                                var $hbtn = $('<span class=\"label label-info\" style=\"cursor: pointer;margin-right:8px;\">发送' + '</span>');
                                $hbtn.on('click', function () {
                                    var keyValue = $('#gridtable').jfGridValue('F_UserId');
                                    if (learun.checkrow(keyValue)) {
                                        learun.layerForm({
                                            id: 'NoticeForm',
                                            title: '报到信息编辑',
                                            url: top.$.rootUrl + '/Platform/RecruitInterview/NoticeForm?keyValue=' + keyValue,
                                            width: 600,
                                            height: 300,
                                            callBack: function (id) {
                                                return top[id].acceptClick(refreshGirdData);
                                            }
                                        });
                                    }
                                });
                                $div.append($hbtn);
                                return $div;
                            }
                        }
                    },
                ],
                mainId: 'F_UserId',
                isPage: true
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
