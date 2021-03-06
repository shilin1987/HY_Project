/*
 * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.03.22
 * 描 述：人员管理	
 */
var selectedRow;
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var companyId = '';
    var departmentId = '';
    var page = {
        init: function () {
            page.inittree();
            page.initGrid();
            page.bind();
        },
        bind: function () {
            page.search();
            // 查询
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);

            $('#F_UserState').lrDataItemSelect({ code: 'UserState' });
            $('#F_OnJobStatus').lrDataItemSelect({ code: 'OnJobStatus' });
            // 部门选择
            $('#department_select').lrselect({
                type: 'tree',
                placeholder: '请选择部门',
                // 是否允许搜索
                allowSearch: true,
                select: function (item) {

                    if (!item || item.value == '-1') {
                        departmentId = '';
                    }
                    else {
                        departmentId = item.value;
                    }
                    page.search();
                }
            });

            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
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
                    title: '添加账号',
                    url: top.$.rootUrl + '/LR_OrganizationModule/User/Form?companyId=' + companyId,
                    width: 1000,
                    height: 500,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑账号',
                        url: top.$.rootUrl + '/LR_OrganizationModule/User/Form?companyId=' + companyId,
                        width: 1000,
                        height: 500,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            //导入excel
            $('#lr_batchupdate').on('click', function () {
                    learun.layerForm({
                        id: 'ImportForm',
                        title: '导入Excel',
                        url: top.$.rootUrl + '/LR_OrganizationModule/User/ImportForm?id=87e82dc7-1f44-4014-a525-d107b590ea59',
                        width: 800,
                        height: 400,
                        maxmin: true,
                        btn: null
                    }) 
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_OrganizationModule/User/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 用户数据导出
            $('#lr_export').on('click', function () {
                /***
                 * 1.获取查询的json数据
                 * 2.请求地址封装成参数传过去
                 * 3.在excel通用页面直接导出
                 * */
                //console.log("$('#F_OnJobStatus').text()--->" + $('#F_OnJobStatus').text());
                var queryJson = {
                    F_Account: $('#F_Account').val(),
                    F_RealName: $('#F_RealName').val(),
                    F_OnJobStatus: ($('#F_OnJobStatus').text() == "==请选择==") ? "" : $('#F_OnJobStatus').text(),
                    F_UserState: $('#F_UserState').text() == "==请选择==" ? "" : $('#F_UserState').text()
                };
            
                //var queryJsonStr = JSON.stringify(queryJson);
                //console.log("queryJsonStr---->" + queryJsonStr);
                //console.log("queryJsonStr---->" + queryJsonStr);
                var excelUrl = "/LR_OrganizationModule/User/GetPageList";
                //console.log("excelUrl---->" + excelUrl);
                var param = {
                    pagination: '',
                    keyword: '',
                    companyId: '207fa1a9-160c-4943-a89b-8fa4db0547ce',
                    departmentId: '',
                    queryJson: queryJson
                };
                var paramStr = JSON.stringify(param);
                paramStr = paramStr.replace(/\"/g, '@');
                //var paramStr = '{\"pagination\":\"\",\"keyword\":\"\",\"companyId\":\"207fa1a9-160c-4943-a89b-8fa4db0547ce\",\"departmentId\":\"\",\"queryJson\":\"{\"F_Account\":\"\",\"F_RealName\":\"\",\"F_UserState\":\"在职\"}\"}'
                console.log("paramStr---->" + paramStr);
                learun.layerForm({
                    id: "ExcelExportForm",
                    title: '导出Excel数据',
                    url: top.$.rootUrl + '/Utility/GeneralExcelExportForm?gridId=gridtable&filename='+ encodeURI(encodeURI("用户导出")) + '&excelUrl=' + excelUrl + '&paramStr=' + paramStr,
                    width: 500,
                    height: 380,
                    callBack: function (id) {
                        return top[id].acceptClick();
                    },
                    btn: ['导出Excel', '关闭']
                });
            });
            // 启用
            $('#lr_enabled').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【启用】账号！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_OrganizationModule/User/UpdateState', { keyValue: keyValue, state: 1 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 禁用
            $('#lr_disabled').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【禁用】账号！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_OrganizationModule/User/UpdateState', { keyValue: keyValue, state: 0 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 重置账号
            $('#lr_resetpassword').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认要【重置密码】！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_OrganizationModule/User/ResetPassword', { keyValue: keyValue }, function () {
                            });
                        }
                    });
                }
            });
            // 功能授权
            $('#lr_authorize').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'authorizeForm',
                        title: '功能授权 - ' + selectedRow.F_RealName,
                        url: top.$.rootUrl + '/LR_AuthorizeModule/Authorize/Form?objectId=' + keyValue + '&objectType=2',
                        width: 550,
                        height: 690,
                        btn: null
                    });
                }
            });
            // 移动功能授权
            $('#lr_appauthorize').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'appAuthorizeForm',
                        title: '移动功能授权 - ' + selectedRow.F_RealName,
                        url: top.$.rootUrl + '/LR_AuthorizeModule/Authorize/AppForm?objectId=' + keyValue + '&objectType=2',
                        width: 550,
                        height: 690,
                        callBack: function (id) {
                            return top[id].acceptClick();
                        }
                    });
                }
            });
            // 数据授权
            $('#lr_dataauthorize').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'dataAuthorizeForm',
                        title: '数据授权 - ' + selectedRow.F_RealName,
                        url: top.$.rootUrl + '/LR_AuthorizeModule/DataAuthorize/Index?objectId=' + keyValue + '&objectType=2',
                        width: 1100,
                        height: 700,
                        maxmin: true,
                        btn: null
                    });
                }
            });

            // 自定义表单数据授权
            $('#lr_cdataauthorize').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'dataAuthorizeForm',
                        title: '自定义表单数据授权 - ' + selectedRow.F_RealName,
                        url: top.$.rootUrl + '/LR_AuthorizeModule/DataAuthorize/CustomerFormIndex?objectId=' + keyValue + '&objectType=2',
                        width: 1100,
                        height: 700,
                        maxmin: true,
                        btn: null
                    });
                }
            });

            // 设置Ip过滤
            $('#lr_ipfilter').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'filterIPIndex',
                        title: 'TCP/IP 地址访问限制 - ' + selectedRow.F_RealName,
                        url: top.$.rootUrl + '/LR_AuthorizeModule/FilterIP/Index?objectId=' + keyValue + '&objectType=Uesr',
                        width: 600,
                        height: 400,
                        btn: null,
                        callBack: function (id) { }
                    });
                }
            });
            // 设置时间段过滤
            $('#lr_timefilter').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_UserId');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'filterTimeForm',
                        title: '时段访问过滤 - ' + selectedRow.F_RealName,
                        url: top.$.rootUrl + '/LR_AuthorizeModule/FilterTime/Form?objectId=' + keyValue + '&objectType=Uesr',
                        width: 610,
                        height: 470,
                        callBack: function (id) {
                            return top[id].acceptClick();
                        }
                    });
                }
            });
        },
        inittree: function () {
            $('#companyTree').lrtree({
                // 访问数据接口地址
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                // 访问数据接口参数
                param: {parentId: '' },
                nodeClick: page.treeNodeClick
            });
           // $('#companyTree').lrtreeSet('setValue', '53298b7a-404c-4337-aa7f-80b2a4ca6681');
        },
        treeNodeClick: function (item) {
            companyId = item.id;
            departmentId = item.departmentId;
            $('#titleinfo').text(item.text);
            $('#department_select').lrselectRefresh({
                // 访问数据接口地址
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                // 访问数据接口参数
                param: { companyId: companyId, departmentId: departmentId, parentId: '0' },
            });
            page.search();
        },
        initGrid: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_OrganizationModule/User/GetPageList',
                headData: [
                    { label: '员工编号', name: 'F_Account', width: 100, align: 'left', frozen: true },
                    //{
                    //    label: "员工编号", name: "F_UserId", width: 120, align: "center", frozen: true,
                    //    formatterAsync: function (callback, value, row, op, $cell) {
                    //        learun.clientdata.getAsync('custmerData', {
                    //            url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'userdata',
                    //            key: value,
                    //            keyId: 'f_userid',
                    //            callback: function (_data) {
                    //                callback(_data['f_encode']);
                    //            }
                    //        });
                    //    }
                    //},
                    { label: '姓名', name: 'F_RealName', width: 100, align: 'left', frozen: true },
                    { label: '年龄', name: 'F_Age', width: 100, align: 'left', frozen: true },
                    {
                        label: '性别', name: 'F_Gender', width: 45, align: 'center', frozen: true,
                        formatter: function (cellvalue) {
                            return cellvalue == 0 ? "女" : "男";
                        }
                    },
                    { label: '证件类型', name: 'F_DocumentType', width: 100, align: 'center', frozen: true, },
                    { label: '证件号码', name: 'F_IDCard', width: 100, align: 'center', frozen: true, },
                    { label: '出生日期', name: 'F_Birthday', width: 100, align: 'center', frozen: true, },
                    { label: '国籍', name: 'F_NationAlity', width: 100, align: 'center',  },
                    { label: '民族', name: 'F_Nation', width: 100, align: 'center',  },
                    { label: '户籍性质', name: 'F_RRNature', width: 100, align: 'center',  },
                    { label: '手机号码', name: 'F_Mobile', width: 100, align: 'center', },
                    { label: '政治面貌', name: 'F_PoliticalOutlook', width: 100, align: 'center',  },
                    { label: '婚姻状况', name: 'F_MaritalStatus', width: 100, align: 'center',  },
                    { label: '籍贯', name: 'F_NativePlace', width: 100, align: 'center',  },
                    { label: '人员状态', name: 'F_UserState', width: 100, align: 'center', },
                    { label: '在职状态', name: 'F_OnJobStatus', width: 100, align: 'center',  },
                    { label: '身份证开始日期', name: 'F_IDCardStartDate', width: 100, align: 'center', },
                    { label: '身份证结束日期', name: 'F_IDCardEndDate', width: 100, align: 'center', },
                    { label: '银行卡开户行', name: 'F_BankDeposit', width: 100, align: 'center', },
                    { label: '银行卡卡号', name: 'F_BankCardNumber', width: 100, align: 'center', },
                    { label: '一卡通卡号', name: 'F_OneCardNumber', width: 100, align: 'center', },
                    //{ label: '二级组织(部门)', name: 'F_SecondaryOrganization', width: 150, align: 'left' },
                    {
                        label: "二级组织(部门)", name: "F_SecondaryOrganization", width: 150, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'department',
                                key: value,
                                keyId: 'f_departmentid',
                                callback: function (_data) {
                                    callback(_data['f_fullname']);
                                }
                            });
                        }
                    },

                    //{ label: '三级组织', name: 'F_TertiaryOrganization', width: 100, align: 'left'},
                    {
                        label: "三级组织", name: "F_TertiaryOrganization", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'department',
                                key: value,
                                keyId: 'f_departmentid',
                                callback: function (_data) {
                                    callback(_data['f_fullname']);
                                }
                            });
                        }
                    },
                    //{ label: '四级组织', name: 'F_FourLevelOrganization', width: 100, align: 'left' },
                    {
                        label: "四级组织", name: "F_FourLevelOrganization", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'department',
                                key: value,
                                keyId: 'f_departmentid',
                                callback: function (_data) {
                                    callback(_data['f_fullname']);
                                }
                            });
                        }
                    },
                    { label: '五级组织', name: 'F_FiveLevelOrganization', width: 100, align: 'left' },
                    { label: '六级组织', name: 'F_SixLevelOrganization', width: 100, align: 'left' },
                   // { label: '岗位名称', name: 'F_PostId', width: 100, align: 'left' },

                    {
                        label: "岗位名称", name: "F_PostId", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'post',
                                key: value,
                                keyId: 'f_postid',
                                callback: function (_data) {
                                    callback(_data['f_name']);
                                }
                            });
                        }
                    },

                    { label: '担任本岗位日期', name: 'F_DateHoldingPost', width: 100, align: 'left' },
                    { label: '班次', name: 'F_WorkingSystem', width: 100, align: 'left' },



                    { label: '薪酬结构类型', name: 'F_SalaryStructureType', width: 100, align: 'left' },
                    {
                        label: '岗级', name: 'F_SalaryMethod', width: 100, align: 'left',
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'PostLevel',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    {
                        label: '岗类', name: 'F_PayModel', width: 100, align: 'left',
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'PostType',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: '薪酬类型', name: 'F_SalaryType', width: 100, align: 'left' },
                    { label: '人员类别', name: 'F_PersonnelCategory', width: 100, align: 'left' },
                    
                    
                    { label: '入职日期', name: 'F_Entrydate', width: 100, align: 'left' },
                    { label: '入职集团日期', name: 'F_JoiningGroupDate', width: 100, align: 'left' },
                    { label: '入职渠道', name: 'F_EntryChannel', width: 100, align: 'left' },
                    { label: '下线日期', name: 'F_OfflineDate', width: 100, align: 'left' },
                    { label: '转正日期', name: 'F_ConfirmationDate', width: 100, align: 'left' },
                    { label: '内部推荐人编码', name: 'F_InternalCode', width: 100, align: 'left' },
                    { label: '内部推荐人姓名', name: 'F_InternalName', width: 100, align: 'left' },
                    { label: '内部推荐人公司', name: 'F_InternalCompany', width: 100, align: 'left' },
                    { label: '劳务转自招日期', name: 'F_LaborRecruitmentDate', width: 100, align: 'left' },
                    { label: '代招公司', name: 'F_RecruitmentCompany', width: 100, align: 'left' },


                    { label: '最高学历', name: 'F_Education', width: 100, align: 'left' },
                    { label: '毕业院校', name: 'F_GraduationUniversitie', width: 100, align: 'left' },
                    { label: '所学专业', name: 'F_MajorStudied', width: 100, align: 'left' },
                    { label: '最高学历开始日期', name: 'F_EducationStartDate', width: 100, align: 'left' },
                    { label: '最高学历结束日期', name: 'F_EducationEndDate', width: 100, align: 'left' },
                    { label: '教育方式', name: 'F_EducationalMode', width: 100, align: 'left' },
                    { label: '外语水平', name: 'F_ForeignLanguageLevel', width: 100, align: 'left' },

                    //{ label: '是否获取职业资格认证', name: 'F_IsQualified', width: 100, align: 'left' },
                    {
                        label: '是否获取职业资格认证', name: 'F_IsQualified', width: 100, align: 'left', formatter: function (cellvalue) {
                            return cellvalue == 0 ? "否" : "是";
                        }
                    },
                    { label: '获取职业资格认证名称', name: 'F_QualificationName', width: 100, align: 'left' },
                    { label: '获取时间', name: 'F_GetTime', width: 100, align: 'left' },


                    { label: '内部职称类型', name: 'F_InternalTitleType', width: 100, align: 'left' },
                    { label: '内部职称', name: 'F_InternalTitle', width: 100, align: 'left' },
                    { label: '内部职称授予时间', name: 'F_InternalTitleDate', width: 100, align: 'left' },
                    { label: '社会职称类型', name: 'F_SocialTitleType', width: 100, align: 'left' },
                    { label: '社会职称', name: 'F_SocialTitle', width: 100, align: 'left' },
                    { label: '社会职称授予时间', name: 'F_SocialTitleDate', width: 100, align: 'left' },


                    { label: '身份证地址', name: 'F_IDCardAddress', width: 100, align: 'left' },
                    { label: '户籍地址', name: 'F_PermanentAddress', width: 100, align: 'left' },
                    { label: '居住地址', name: 'F_ResidentialAddress', width: 100, align: 'left' },
                    { label: '现住地址', name: 'F_CurrentAddress', width: 100, align: 'left' },
                    { label: '紧急联系人', name: 'F_EmergencyContact', width: 100, align: 'left' },
                    { label: '紧急联系关系', name: 'F_EContactRelationship', width: 100, align: 'left' },
                    { label: '紧急联系人电话', name: 'F_EContactNumber', width: 100, align: 'left' },
                    { label: '联系地址', name: 'F_ContactAddress', width: 100, align: 'left' },


                    { label: '劳动合同起始时间', name: 'F_laborContractStartDate', width: 100, align: 'left' },
                    { label: '劳动合同结束时间', name: 'F_laborContractEndDate', width: 100, align: 'left' },
                    { label: '劳动合同状态', name: 'F_LaborContractStatus', width: 100, align: 'left' },
                    {
                        label: '是否有培训协议', name: 'F_IsTrainingAgreement', width: 150, align: 'left', formatter: function (cellvalue) {
                            return cellvalue == 0 ? "否" : "是";
                        }
                    },
                    { label: '服务期开始时间', name: 'F_StartDateService', width: 150, align: 'left' },
                    { label: '服务期结束时间', name: 'F_EndDateService', width: 150, align: 'left' },



                    { label: '离职办理日期', name: 'F_DepartureDate', width: 100, align: 'left' },
                    { label: '考勤截止日期', name: 'F_AttendanceDeadline', width: 100, align: 'left' },
                    { label: '离职原因', name: 'F_TypesResignation', width: 100, align: 'left' },
                    { label: '离职证明是否开具', name: 'F_IsEsignationCertificate', width: 100, align: 'left' },
                    { label: '折旧处理', name: 'F_Depreciation', width: 100, align: 'left' },
                    
                    //{
                    //    label: "状态", name: "F_EnabledMark", index: "F_EnabledMark", width: 50, align: "center", frozen: true,
                    //    formatter: function (cellvalue) {
                    //        if (cellvalue == 1) {
                    //            return '<span class=\"label label-success\" style=\"cursor: pointer;\">正常</span>';
                    //        } else if (cellvalue == 0) {
                    //            return '<span class=\"label label-default\" style=\"cursor: pointer;\">禁用</span>';
                    //        }
                    //    }
                    //},
                    ////{ label: '一级组织(公司)', name: 'F_PrimaryOrganization', width: 150, align: 'left' },
                    //{
                    //    label: "一级组织(公司)", name: "F_PrimaryOrganization", width: 150, align: "left",
                    //    formatterAsync: function (callback, value, row, op, $cell) {
                    //        learun.clientdata.getAsync('custmerData', {
                    //            url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'company',
                    //            key: value,
                    //            keyId: 'f_companyid',
                    //            callback: function (_data) {
                    //                callback(_data['f_fullname']);
                    //            }
                    //        });
                    //    }
                    //},
                    
                    //{ label: '招聘渠道', name: 'F_RecruitmentChannels', width: 100, align: 'left' },
                    //{ label: '上班制度', name: 'F_WorkingSystem', width: 100, align: 'left' },
                    //{ label: '担任本岗位日期', name: 'F_DateHoldingPost', width: 150, align: 'left' },
                    //{ label: '员工性质', name: 'F_EmployeeNature', width: 100, align: 'left' },
                    //{ label: '员工性质变化时间', name: 'F_EmployeeNatureChangeDate', width: 150, align: 'left' },
                    //{ label: '计件类型', name: 'F_PieceworkType', width: 100, align: 'left'},
                    //{ label: '转正时间', name: 'F_TimeBecomeRegular', width: 100, align: 'left' },
                    //{ label: '上班制度转换时间', name: 'F_TimeShiftWorkSystem', width: 150, align: 'left' },
                    //{ label: '离职类型', name: 'F_TypesResignation', width: 100, align: 'left' },
                    //{ label: '补办离职手续时间', name: 'F_MakeUpTime', width: 150, align: 'left' },
                    //{ label: '备注', name: 'F_Description', index: 'F_Description', width: 250, align: 'left'}
                ],
                isPage: true,
                reloadSelected: true,
                mainId: 'F_UserId'
            });
        },
        search: function (param) {
            param = param || {};
            console.log("$('#F_Account').val()" + $('#F_Account').val());
            param.queryJson = JSON.stringify({
                F_Account: ($('#F_Account').val() == "" || $('#F_Account').val() == "null") ? "" : $('#F_Account').val(),
                F_RealName: ($('#F_RealName').val() == "" || $('#F_RealName').val() == "null") ? "" : $('#F_RealName').val(),
                F_OnJobStatus: ($('#F_OnJobStatus').text() == "==请选择==") ? "" : $('#F_OnJobStatus').text(),
                F_UserState: $('#F_UserState').text() == "==请选择==" ? "在职" : $('#F_UserState').text()
            });
            console.log("param.queryJson---->"+param.queryJson);
            if (companyId == "" || companyId == null || companyId == "null") {
                param.companyId = '207fa1a9-160c-4943-a89b-8fa4db0547ce';
            } else {
                param.companyId = companyId;
            }
            param.departmentId = departmentId;
            $('#gridtable').jfGridSet('reload', param);
        }
    };

    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };

    page.init();
}


