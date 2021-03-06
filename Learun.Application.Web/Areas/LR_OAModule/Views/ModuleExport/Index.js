/*
 * 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2017 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.06.20
 * 描 述：文件管理	
 */
var refreshGirdData; // 更新数据
var bootstrap = function ($, learun) {
    "use strict";

    var page = {
        init: function () {
            //$.lrSetForm(top.$.rootUrl + '/LR_OAModule/ModuleExport/GetFormData?keyValue=3587a099-980d-4342-864f-a9f48e90e03b', function (data) {//
            //    $('.price-info').lrSetFormData(data.customerData);
            //    var html = "";
            //    for (var item in data.orderProductData) {
            //        html += "<tr><td>"+ (parseInt(item)+1) +"</td><td>" + data.orderProductData[item].F_ProductName + "</td><td>定制</td><td>" + data.orderProductData[item].F_Qty + "</td><td>套</td><td>" + data.orderProductData[item].F_Amount + "</td><td>" + data.orderProductData[item].F_Amount * data.orderProductData[item].F_Qty + "</td><td>&nbsp;</td></tr>";
            //    }
            //    html += "<tr><td>4</td><td>服务器硬件</td><td>联想</td><td>5</td><td>台</td><td>20000.00</td><td>100000.00</td><td>&nbsp;</td></tr><tr><td>5</td><td>数据库正版</td><td>SQLServer</td><td>5</td><td>套</td><td>9998.00</td><td>49990.00</td><td>&nbsp;</td></tr><tr><td>6</td><td>服务费</td><td>&nbsp;</td><td>1</td><td>年</td><td>80000.00</td><td>80000.00</td><td>&nbsp;</td></tr><tr><td>7</td><td>差旅费用</td><td>&nbsp;</td><td>1</td><td>年</td><td>60000.00</td><td>80000.00</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>;"
            //    html += '<tr><td colspan="7" style="text-align: right; border-right: none;">币种：人民币&nbsp;&nbsp;&nbsp;&nbsp;总计：323323.00</td><td>&nbsp;</td></tr><tr><td style="height: 80px;">备注</td><td colspan="7"></td></tr>';

            //    $('.price-table tbody').append(html);
            //});
            page.bind();
        },
        bind: function () {

            $.ajax({
                url: top.$.rootUrl + '/LR_OAModule/ModuleExport/GetDepartmentList',
                type: "get",
                dataType: "json",
                success: function (data) {
                    if (data.code == 200) {
                        var dataObj = data.data[0];
                        $('#F_Department').val(dataObj.F_SecondaryOrganization);
                    } else {
                        learun.alert.error("没有该员工部门信息");
                    }
                },
                error: function (e) {
                    alert(222);
                    learun.alert.error("网络错误，请重试！！");
                }
            });
            // 部门
            //$('#F_Department').lrDataSourceSelect({ code: 'department', value: 'f_departmentid', text: 'f_fullname' });
            // 岗级
            $('#F_JobRank').lrDataItemSelect({ code: 'PostLevel', maxHeight: 230 });
            // 岗类
            $('#F_JobType').lrDataItemSelect({ code: 'PostType', maxHeight: 230 });
            //导出Excel
            //$("#btn_export_Excel").on('click', function () {
            //    learun.download({ url: top.$.rootUrl + '/LR_OAModule/ModuleExport/ExportExcel', param: { keyValue: "0105baea-cb9f-4f13-914e-b913ec698e1e", __RequestVerificationToken: $.lrToken }, method: 'POST' });
            //});
            //导出Word
            //$("#btn_export_Word").on('click', function () {
            //    learun.download({ url: top.$.rootUrl + '/LR_OAModule/ModuleExport/ExportWord', param: { keyValue: "0105baea-cb9f-4f13-914e-b913ec698e1e", __RequestVerificationToken: $.lrToken }, method: 'POST' });
            //});
            //导出PDF
            //$("#btn_export_PDF").on('click', function () {
            //    learun.download({ url: top.$.rootUrl + '/LR_OAModule/ModuleExport/ExportPDF', param: { __RequestVerificationToken: $.lrToken }, method: 'POST' });
            //});

            // 提交
            $('#btn_export_Insert').on('click', function () {
                /*
                if (!$('#SRform').lrValidform()) {
                    return false;
                }
                var formData = $('#SRform').lrGetFormData();
                if (!keyValue && !formData.uploadFile) {
                    learun.alert.error("上传附件");
                    return false;
                }
                */
                // $("#form").submit();
                //var formData = $('#form').lrGetFormData();
                var formData = new FormData();
                //$('#F_Department').lrselect(text);
                //console.log($('#F_Department').text());
                if ($('#F_Department').val() == null || $('#F_Department').val() == '') {
                    learun.alert.error("需求部门不能为空");
                    return false;
                }
                if ($('#F_JobName').val() == null || $('#F_JobName').val() == '') { learun.alert.error("需求岗位名称不能为空"); return false; }
                if ($('#F_JonNum').val() == null || $('#F_JonNum').val() == '') { learun.alert.error("岗位编制人数不能为空"); return false; }
                if ($('#F_CurrentJobName').val() == null || $('#F_CurrentJobName').val() == '') { learun.alert.error("岗位现有人数不能为空"); return false; }
                if ($('#F_DeptMentJonNum').val() == null || $('#F_DeptMentJonNum').val() == '') { learun.alert.error("部门编制人数不能为空"); return false; }
                if ($('#F_CurrentDeptMentJonNum').val() == null || $('#F_CurrentDeptMentJonNum').val() == '') { learun.alert.error("部门现有人数不能为空"); return false; }
                if ($('#F_ApplyRecruitNum').val() == null || $('#F_ApplyRecruitNum').val() == '') { learun.alert.error("申请招聘人数不能为空"); return false; }
                if ($('#F_DemandReasonStatement').val() == null || $('#F_DemandReasonStatement').val() == '') { learun.alert.error("需求原因说明不能为空"); return false; }
                if ($('#F_RecommendedSalaryRange').val() == null || $('#F_RecommendedSalaryRange').val() == '') { learun.alert.error("建议薪酬区间不能为空"); return false; }
                if ($('#F_ExpectedArrivalDate').val() == null || $('#F_ExpectedArrivalDate').val() == '') { learun.alert.error("期望到岗日期不能为空"); return false; }
                if ($('#F_TheSystemTime').val() == null || $('#F_TheSystemTime').val() == '') { learun.alert.error("申请日期不能为空"); return false; }
                if ($('#F_JobDescriptions').val() == null || $('#F_JobDescriptions').val() == '') { learun.alert.error("岗位描述不能为空"); return false; }
                if ($('#F_MainDuties').val() == null || $('#F_MainDuties').val() == '') { learun.alert.error("主要职责不能为空"); return false; }
                if ($('#F_BasicConditions').val() == null || $('#F_BasicConditions').val() == '') { learun.alert.error("基本条件不能为空"); return false; }
                if ($('#F_SupposedToKnow').val() == null || $('#F_SupposedToKnow').val() == '') { learun.alert.error("必备知识不能为空"); return false; }
                if ($('#F_EssentialSkill').val() == null || $('#F_EssentialSkill').val() == '') { learun.alert.error("必备技能不能为空"); return false; }
                if ($('#F_CapacityRequirements').val() == null || $('#F_CapacityRequirements').val() == '') { learun.alert.error("能力要求不能为空"); return false; }
                if ($('#F_ExperienceRequirements').val() == null || $('#F_ExperienceRequirements').val() == '') { learun.alert.error("经验要求不能为空"); return false; }
                if ($('#F_SpecialRequirements').val() == null || $('#F_SpecialRequirements').val() == '') { learun.alert.error("其他特殊需求不能为空"); return false; }
                if (($('#uploadFile1').val() == null || $('#uploadFile1').val() == '') && ($('#uploadFile2').val() == null || $('#uploadFile2').val() == '') && ($('#uploadFile3').val() == null || $('#uploadFile3').val() == ''))
                { learun.alert.error("相关附件不能为空，至少上传一个附件！"); return false; }

                formData.append('F_Department', $('#F_Department').val());
                formData.append('F_JobName', $('#F_JobName').val());
                formData.append('F_JonNum', $('#F_JonNum').val());
                formData.append('F_CurrentJobName', $('#F_CurrentJobName').val());
                formData.append('F_DeptMentJonNum', $('#F_DeptMentJonNum').val());
                formData.append('F_CurrentDeptMentJonNum', $('#F_CurrentDeptMentJonNum').val());
                formData.append('F_ApplyRecruitNum', $('#F_ApplyRecruitNum').val());
                formData.append('F_DegreeOfEmergency', $('#F_DegreeOfEmergency').val());
                formData.append('F_RequirementTypes', $('#F_RequirementTypes').val());
                formData.append('F_DemandReasonStatement', $('#F_DemandReasonStatement').val());
                formData.append('F_JobRank', $('#F_JobRank:first-child').text());
                formData.append('F_JobType', $('#F_JobType:first-child').text());
                formData.append('F_RecommendedSalaryRange', $('#F_RecommendedSalaryRange').val());
                formData.append('F_RecruitmentChannels', $('#F_RecruitmentChannels').val());
                formData.append('F_ExpectedArrivalDate', $('#F_ExpectedArrivalDate').val());
                formData.append('F_TheSystemTime', $('#F_TheSystemTime').val());
                formData.append('F_JobDescriptions', $('#F_JobDescriptions').val());
                formData.append('F_MainDuties', $('#F_MainDuties').val());
                formData.append('F_BasicConditions', $('#F_BasicConditions').val());
                formData.append('F_SupposedToKnow', $('#F_SupposedToKnow').val());
                formData.append('F_EssentialSkill', $('#F_EssentialSkill').val());
                formData.append('F_CapacityRequirements', $('#F_CapacityRequirements').val());
                formData.append('F_ExperienceRequirements', $('#F_ExperienceRequirements').val());
                formData.append('F_SpecialRequirements', $('#F_SpecialRequirements').val());
                formData.append('F_DepartmentOfOpinion', $('#F_DepartmentOfOpinion').val());
                formData.append('F_DepartmentOfOpinionOne', $('#F_DepartmentOfOpinionOne').val());
                formData.append('F_DepartmentOfOpinionT', $('#F_DepartmentOfOpinionT').val());
                formData.append('F_HumanResources', $('#F_HumanResources').val());
                formData.append('F_HumanResourcesOne', $('#F_HumanResourcesOne').val());
                formData.append('F_HumanResourcesT', $('#F_HumanResourcesT').val());
                formData.append('F_TheSignature_01', $('#F_TheSignature_01').val());
                formData.append('F_TheSignature_02', $('#F_TheSignature_02').val());
                formData.append('F_TheSignature_03', $('#F_TheSignature_03').val());
                formData.append('F_TheSignature_04', $('#F_TheSignature_04').val());
                formData.append('F_TheSignature_05', $('#F_TheSignature_05').val());
                formData.append('F_TheSignature_06', $('#F_TheSignature_06').val());
                formData.append("file", document.getElementById("uploadFile1").files[0]);
                formData.append("file", document.getElementById("uploadFile2").files[0]);
                formData.append("file", document.getElementById("uploadFile3").files[0]);
               // var formData = new FormData($('#fileform')[0]);
                $.ajax({
                    url: top.$.rootUrl + '/LR_OAModule/ModuleExport/SaveForm',
                    type: "post",
                    data: formData,
                    cache: false,
                    enctype: 'multipart/form-data',
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        var dataObj = eval("(" + data + ")");
                        learun.alert.info(dataObj.info);
                        //alert(dataObj.info);
                        location.reload();
                        $.ajax({
                            url: top.$.rootUrl + '/LR_OAModule/ModuleExport/GetDepartmentList',
                            type: "post",
                            dataType: "json",
                            success: function (data) {
                                if (data.code == 200) {
                                    var dataObj = data.data[0];
                                    $('#F_Department').val(dataObj.F_SecondaryOrganization);
                                } else {
                                    learun.alert.error(data.data.info);
                                }
                            },
                            error: function (e) {
                                //learun.alert.error("网络错误，请重试！！");
                            }
                        });
                    },
                    error: function (e) {
                       // learun.alert.error("网络错误，请重试！！");
                    }
                });
                /*
                console.log(formData);
                $.lrSaveForm(top.$.rootUrl + '/LR_OAModule/ModuleExport/SaveForm', formData, function (res) {
                    // 保存成功后才回调
                    console.log(res);
                    if (res.code == 200) {
                        draftId = res.data;
                    }
                }, true);
                */
            });
         
        }
    };
    page.init();
}


