/*
 * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.04.18
 * 描 述：账号添加	
 */
var companyId = request('companyId');


var acceptClick;
var keyValue = '';
var bootstrap = function ($, learun) {
    "use strict";
    var selectedRow = learun.frameTab.currentIframe().selectedRow;
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            
            // 薪资计算方式
            $('#F_SalaryCalculation').lrDataItemSelect({ code: 'SalaryCalculation', maxHeight: 230 });
            // 岗级
            $('#F_SalaryMethod').lrDataItemSelect({ code: 'PostLevel', maxHeight: 230 });
            // 岗类
            $('#F_PayModel').lrDataItemSelect({ code: 'PostType', maxHeight: 230 });
            // 公司
            $('#F_PrimaryOrganization').lrDataSourceSelect({ code: 'company', value: 'f_companyid', text: 'f_fullname' });
            // 部门
            $('#F_SecondaryOrganization').lrDataSourceSelect({ code: 'department', value: 'f_departmentid', text: 'f_fullname' });
            // 三级
            $('#F_TertiaryOrganization').lrDataSourceSelect({ code: 'department', value: 'f_departmentid', text: 'f_fullname' });
            // 四级
            $('#F_FourLevelOrganization').lrDataSourceSelect({ code: 'department', value: 'f_departmentid', text: 'f_fullname' });
            // 岗位
            $('#F_PostId').lrDataSourceSelect({ code: 'post', value: 'f_postid', text: 'f_name' });
            // 性别
            $('#F_Gender').lrselect(); 
            // 是否有培训协议
            $('#F_IsTrainingAgreement').lrselect();
            // 上班制度
            $('#F_WorkingSystem').lrDataItemSelect({ code: 'shiftType' });
            //$('#F_WorkingSystem').lrselect(code);
            // 员工性质
            $('#F_EmployeeNature').lrselect();
            // 计件类型
            $('#F_PieceworkType').lrselect();
            // 离职类型
            $('#F_TypesResignation').lrselect();
            /*检测重复项*/
            $('#F_Account').on('blur', function () {
                $.lrExistField(keyValue, 'F_Account', top.$.rootUrl + '/LR_OrganizationModule/User/ExistAccount');
            });
            // 证件类型
            $('#F_DocumentType').lrDataItemSelect({ code: 'IDType' });
            // 户籍性质
            $('#F_RRNature').lrDataItemSelect({ code: 'RRNature' });
            // 整治面貌
            $('#F_PoliticalOutlook').lrDataItemSelect({ code: 'PoliticalOutlook' });
            // 婚姻状况
            $('#F_MaritalStatus').lrDataItemSelect({ code: 'MaritalStatus' });
            // 在职状态
            $('#F_OnJobStatus').lrDataItemSelect({ code: 'OnJobStatus' });
            // 薪酬结构类型
            $('#F_SalaryStructureType').lrDataItemSelect({ code: 'SalaryStructureType' });
            // 薪酬类型
            $('#F_SalaryType').lrDataItemSelect({ code: 'SalaryType' });
            // 人员类别
            $('#F_PersonnelCategory').lrDataItemSelect({ code: 'PersonnelCategory' });
            // 入职渠道
            $('#F_EntryChannel').lrDataItemSelect({ code: 'EntryChannel' });
            // 教育方式
            $('#F_EducationalMode').lrDataItemSelect({ code: 'EducationalMode' });
            // 外语水平
            $('#F_ForeignLanguageLevel').lrDataItemSelect({ code: 'ForeignLanguageLevelv' });
            // 紧急联系人关系
            $('#F_EContactRelationship').lrDataItemSelect({ code: 'EContactRelationship' });
            

            $('#F_IsQualified').lrselect();
        },
        initData: function () {
            if (!!selectedRow) {
                keyValue = selectedRow.F_UserId;
                selectedRow.F_Password = "******";
                $('#form').lrSetFormData(selectedRow);
                //$('#F_Password').attr('readonly', 'readonly');
                $('#F_Account').attr('readonly', 'readonly');

                $('#F_Password').attr('unselectable', 'on');
                $('#F_Account').attr('unselectable', 'on');
            }
            else {
                $('#F_CompanyId').val(companyId);
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var postData = $('#form').lrGetFormData(keyValue);
        if (!keyValue) {
            postData.F_Password = $.md5(postData.F_Password);
        }
        $.lrSaveForm(top.$.rootUrl + '/LR_OrganizationModule/User/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}