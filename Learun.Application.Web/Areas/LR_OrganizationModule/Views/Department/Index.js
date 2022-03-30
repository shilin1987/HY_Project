﻿/*
 * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.03.22
 * 描 述：部门管理	
 */
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var companyId = '';
    var page = {
        init: function () {
            page.inittree();
            page.initGrid();
            page.bind();
        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                //location.reload();
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword, isRefreshCache: 1 });
            });
            // 新增
            $('#lr_add').on('click', function () {
                if (!companyId) {
                    learun.alert.warning('请选择公司！');
                    return false;
                }
                selectedRow = null;
                learun.layerForm({
                    id: 'form',
                    title: '添加部门',
                    url: top.$.rootUrl + '/LR_OrganizationModule/Department/Form?companyId=' + companyId,
                    width: 700,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_DepartmentId');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑部门',
                        url: top.$.rootUrl + '/LR_OrganizationModule/Department/Form?companyId=' + companyId,
                        width: 700,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_DepartmentId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_OrganizationModule/Department/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //启用
            $('#lr_enable').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_DepartmentId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【启用】该部门！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_OrganizationModule/Department/UpdateStateEnable', { keyValue: keyValue, state: 1 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 禁用
            $('#lr_stop').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_DepartmentId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【禁用】该部门！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_OrganizationModule/Department/UpdateState', { keyValue: keyValue, state: 0 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
        },
        inittree: function () {
            $('#companyTree').lrtree({
                //url: top.$.rootUrl + '/LR_OrganizationModule/Company/GetTree',
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {parentId: '0' },
                nodeClick: page.treeNodeClick
            });
            $('#companyTree').lrtreeSet('setValue', '207fa1a9-160c-4943-a89b-8fa4db0547ce');
        },
        treeNodeClick: function (item) {
            companyId = item.id;
            $('#titleinfo').text(item.text);
            page.search();
        },
        initGrid: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetList',
                headData: [
                    { label: "部门名称", name: "F_FullName", width: 200, align: "left" },
                    { label: "部门编号", name: "F_EnCode", width: 100, align: "left" },
                    { label: "部门简称", name: "F_ShortName", width: 100, align: "left" },
                    { label: "部门性质", name: "F_Nature", width: 100, align: "left" },
                    { label: "负责人", name: "F_Manager", width: 100, align: "left" },
                    { label: "电话号", name: "F_OuterPhone", width: 100, align: "left" },
                    { label: "分机号", name: "F_InnerPhone", width: 60, align: "center" },
                    {
                        label: "是否有效", name: "F_EnabledMark", width: 60, align: "center",
                        formatter: function (cellvalue) {
                            return cellvalue == 0 ? "否" : "是";
                        }
                    },
                    { label: "备注", name: "F_Description", width: 200, align: "left" }
                ],

                isTree: true,
                mainId: 'F_DepartmentId',
                parentId: 'F_ParentId',
            });
        },
        search: function (param) {
            param = param || {};
            param.companyId = companyId;
            $('#gridtable').jfGridSet('reload', param);
        }
    };

    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };

    page.init();
}


