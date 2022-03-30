﻿
/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-11-30 09:14
 * 描  述：上岗资格认证表
 */
var selectedRow;
var refreshGirdData;

var canvasArray = new Array();

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
            }, 220, 400);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 打印
            $('#btn_export_Insert').on('click', function () {
                previews();
            });
            // 关闭
            $('#btn_export_cancel').on('click', function () {
                $('#PreviewModal').modal('hide');
            });
            // 新增
            $('#lr_add').on('click', function () {
                selectedRow = null;
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/Platform/WL_NormalShift/Form',
                    width: 1200,
                    height: 900,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });

            //下载PDF
            $('#lr_edit').on('click', function () {
                if (canvasArray.length > 0) {
                    learun.layerConfirm('确定下载上岗证信息！', function (res) {
                        if (res) {
                            var pdf = new jsPDF('p', 'pt', 'a4');

                            // 滚动到顶部，避免打印不全
                            document.documentElement.scrollTop = 0;
                            // 设置打印比例 越大打印越小
                            pdf.internal.scaleFactor = 2;
                            var top = 10; var adoptCount = false;
                            for (var i = 0; i < canvasArray.length; i++) {
                                if (i > 0) {
                                    top += 170;
                                }
                                if (canvasArray[i].isadopt == '是') {
                                    if (canvasArray[i].canvasBase64Above.length > 0) {
                                        pdf.addImage(canvasArray[i].canvasBase64Above, 'JPEG', 10, top, 264, 160);
                                    }
                                    if (canvasArray[i].canvasBase64Below.length > 0) {
                                        pdf.addImage(canvasArray[i].canvasBase64Below, 'JPEG', 290, top, 264, 160);
                                    }
                                    adoptCount = true;
                                }
                            }

                            if (adoptCount) {
                                pdf.save('正常班上岗证.pdf');
                            } else {
                                return learun.alert.warning('未找到已审核通过上岗证信息.');
                            }
                        }
                    });
                } else {
                    return learun.alert.warning('请选择需要打印上岗证人员.');
                }
            });
            /*
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/Platform/WL_NormalShift/Form?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('F_ID');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/Platform/WL_NormalShift/DeleteForm', { keyValue: keyValue}, function () {
                            });
                        }
                    });
                }
            });
            */

        },
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/Platform/WL_NormalShift/GetPageList',
                headData: [
                    { label: "资格认证编号", name: "F_NO", width: 250, align: "left" },
                    { label: "员工编号", name: "F_EnCode", width: 250, align: "left" },
                    //{
                    //    label: "员工编号", name: "F_EnCode", width: 120, align: "center", frozen: true,
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
                    { label: "姓名", name: "F_RealName", width: 100, align: "left" },
                    //{
                    //    label: "姓名", name: "F_RealName", width: 120, align: "center", frozen: true,
                    //    formatterAsync: function (callback, value, row, op, $cell) {
                    //        learun.clientdata.getAsync('custmerData', {
                    //            url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'userdata',
                    //            key: value,
                    //            keyId: 'f_userid',
                    //            callback: function (_data) {
                    //                callback(_data['f_realname']);
                    //            }
                    //        });
                    //    }
                    //},
                    { label: "部门", name: "F_FullName", width: 100, align: "left" },
                    //{
                    //    label: "部门", name: "F_SecondaryOrganization", width: 150, align: "left",
                    //    formatterAsync: function (callback, value, row, op, $cell) {
                    //        learun.clientdata.getAsync('custmerData', {
                    //            url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'department',
                    //            key: value,
                    //            keyId: 'f_departmentid',
                    //            callback: function (_data) {
                    //                callback(_data['f_fullname']);
                    //            }
                    //        });
                    //    }
                    //},
                    //{ label: "工序", name: "F_FourLevelOrganization", width: 100, align: "left" },
                    {
                        label: "工序", name: "F_FourLevelOrganization", width: 100, align: "left",
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
                    { label: "文化程度", name: "F_Education", width: 100, align: "left" },
                    { label: "人员类别", name: "F_PersonnelCategory", width: 100, align: "left" },
                    { label: "上岗日期", name: "F_AppointmentDate", width: 100, align: "left" },
                    { label: "试用期限", name: "F_ProbationPeriod", width: 100, align: "left" },
                    {
                        label: "预览", name: "F_Redel", width: 100, align: "center", sort: false,
                        formatter: function (cellvalue, value, row, op, $cell) {
                            return cellvalue = "<a class=\"idcard\" data-toggle=\"modal\" data-target=\"#myModal\" onmouseenter=\"drawAndShareImage('" + value.F_EnCode + "','" + value.F_RealName + "','" + value.F_FullName + "','" + value.F_FourLevelOrganization + "','" + value.F_PersonnelCategory + "',false,false,'" + value.F_States + "')\"><i name=" + value.F_EnCode + "  class=\"fa fa-id-card\"></i></a>";
                        }
                    },
                    {
                        label: "审批结果", name: "F_States", width: 100, align: "center",
                        formatter: function (cellvalue) {
                            if (cellvalue == "是") {
                                return '<span class=\"label label-success\" style=\"cursor: pointer;\">通过</span>';
                            } else if (cellvalue == "否") {
                                return '<span class=\"label label-default\" style=\"cursor: pointer;\">不通过</span>';
                            } else {
                                return '<span class=\"label label-default\" style=\"cursor: pointer;\">审核中</span>';
                            }
                        }
                    },
                    { label: "是否下载", name: "F_IsDownload", width: 100, align: "left" },
                    {
                        label: "操作", name: "F_preview", width: 100, align: "center", sort: false,
                        formatter: function (cellvalue, value, row, op, $cell) {
                            return cellvalue = "<a id=\"lr_preview\" class=\"btn btn -default\" onclick=\"preview('" + value.F_ID + "')\">预览打印</a>";
                        }
                    },
                ],
                mainId: 'F_NO',
                isPage: true,
                reloadSelected: true,
                isSubGrid: true,
                isMultiselect: true,
                subGridExpanded: function (subid, rowdata) {
                    $('#' + subid).jfGrid({
                        url: top.$.rootUrl + '/Platform/WL_NormalShift/GetSubList',
                        headData: [
                            { label: "审批人", name: "F_TheApprover", width: 100, align: "left" },
                            { label: "审批结果", name: "F_WhetherThrough", width: 200, align: "left" },
                            { label: "审批日期", name: "F_ApprovalTime", width: 200, align: "left" },
                            { label: "审批意见", name: "F_Opinion", width: 100, align: "left" }
                        ]
                    });
                    $('#' + subid).jfGridSet('reload', { fno: rowdata.F_NO });
                },
                onSelectRow: function (item, k) {
                    drawAndShareImage(item.F_EnCode, item.F_RealName, item.F_FullName, item.F_FourLevelOrganization, item.F_PersonnelCategory, k, true, item.F_States);
                }
            });
            //会导致提前请求
            // page.search();
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
//预览
function preview(fid) {
    $.ajax({
        url: top.$.rootUrl + '/Platform/WL_NormalShift/GetUserNormalShiftList',
        type: "get",
        data: { fid: fid },
        dataType: "json",
        success: function (data) {
            if (data.code == 200) {
                var dataObj = data.data[0];
                $('#F_EnCodes').html(dataObj.F_EnCode);
                $('#F_RealName').html(dataObj.F_RealName);
                $('#F_Gender').html(dataObj.F_Gender);
                $('#F_DepartmentName').html(dataObj.F_SecondaryOrganization);
                $('#F_FourLevelOrganization').html(dataObj.F_FourLevelOrganization);
                $('#F_Education').html(dataObj.F_Education);
                $('#F_PersonnelCategory').html(dataObj.F_PersonnelCategory);
               

                $('#F_AppointmentDate').html(dataObj.F_AppointmentDate);
                $('#F_ProbationPeriod').html(dataObj.F_ProbationPeriod);
                $('#F_TrialDate').html(dataObj.F_TrialDate);
                $('#F_writtenExamination').html(dataObj.F_writtenExamination);
                $('#F_OperationCapability').html(dataObj.F_OperationCapability);
                $('#F_workingAttitude').html(dataObj.F_workingAttitude);
                $('#F_Responsibility').html(dataObj.F_Responsibility);
                $('#F_SUM').html(dataObj.F_SUM);
                $('#F_OperationBPM').html(dataObj.F_OperationBPM);
                $('#F_OperationDirector').html(dataObj.F_OperationDirector);
                $('#F_OperationCharge').html(dataObj.F_OperationCharge);
                $('#F_QualityManagement').html(dataObj.F_QualityManagement);
                $('#F_HumanResources').html(dataObj.F_HumanResources);


                $('#PreviewModal').modal('show');
            } else {
                learun.alert.error(data.info);
            }
        },
        error: function (e) {
            learun.alert.error("网络错误，请重试！！");
        }
    });

}
function previews() {
    var printData = document.getElementById("SRform").innerHTML; // 只打印 forPrint 这个div中的内容。
    window.document.body.innerHTML = printData;   //把 html 里的数据 复制给 body 的 html 数据 ，相当于重置了整个页面的 内容
    window.print();
    location.reload();
}
//上岗证正反面制作
function drawAndShareImage(userAccount, name, department, post, personnelCategory, isSave, flag, isadopt) {
    //对空值进行初始化赋值;
    isadopt == 'null' ? '审核中' : isadopt;

    if (userAccount != '') {
        //显示上岗证弹出层
        if (!flag) {
            $('#myModal').modal('show');
        }

        var base64Front = '';
        var base64CanvasOthenSide = '';
        //上岗证正反面模板
        var topImg = "";
        var upImg = "";
        if (personnelCategory == '品质检验类') {
            topImg = "C1.png";
            upImg = "C2.png";
        } else if (personnelCategory == '倒班工程类') {
            topImg = "B1.png";
            upImg = "B2.png";
        } else if (personnelCategory == '研发类') {
            topImg = "F1.png";
            upImg = "F2.png";
        } else if (personnelCategory == '其他') {
            topImg = "E1.png";
            upImg = "E2.png";
        } else if (personnelCategory == '生产作业类') {
            topImg = "A1.png";
            upImg = "A2.png";
        }

        //正面
        var canvas = document.getElementById("myCanvas");
        var context = canvas.getContext("2d");
        context.rect(0, 0, canvas.width, canvas.height);
        context.fillStyle = "black";
        context.fill();
        var myImage = new Image();
        myImage.src = "/Content/images/WorkLicenseTemplate/" + topImg;  //背景图片 你自己本地的图片或者在线图片
        myImage.crossOrigin = 'Anonymous';
        myImage.onload = function () {
            context.drawImage(myImage, 0, 0, 354, 213);
            context.font = "14px Courier New";
            //岗位
            //context.fillText(post, 102, 88);
            //姓名
            context.fillText(name, 102, 113);
            //编号
            context.fillText(userAccount, 102, 140);
            //部门
            context.fillText(department, 102, 167);

            //头像
            var myImage2 = new Image();
            //头像属性
            myImage2.src = "/Content/images/EmployeeAvatar/" + userAccount + ".jpg";  //你自己本地的图片或者在线图片
            myImage2.crossOrigin = 'Anonymous';
            //头像位置
            myImage2.onload = function () {
                context.drawImage(myImage2, 244, 66, 99, 140);

                base64Front = canvas.toDataURL("image/jpeg");

                //反面
                var canvasOthenSide = document.getElementById("othenSideCanvas");
                var contextOthenSide = canvasOthenSide.getContext("2d");
                contextOthenSide.rect(0, 0, canvasOthenSide.width, canvasOthenSide.height);
                contextOthenSide.fillStyle = "black";
                contextOthenSide.fill();
                var myImageOthenSide = new Image();
                myImageOthenSide.src = "/Content/images/WorkLicenseTemplate/" + upImg;  //背景图片 你自己本地的图片或者在线图片
                myImageOthenSide.crossOrigin = 'Anonymous';
                myImageOthenSide.onload = function () {
                    contextOthenSide.drawImage(myImageOthenSide, 0, 0, 354, 213);
                    contextOthenSide.font = "14px Courier New";
                    //技能一
                    contextOthenSide.fillText('', 11, 58);
                    //技能二
                    contextOthenSide.fillText('', 11, 88);
                    //技能三
                    contextOthenSide.fillText('', 11, 116);
                    //技能四
                    contextOthenSide.fillText('', 11, 142);
                    //技能五
                    contextOthenSide.fillText('', 11, 168);
                    //技能六
                    contextOthenSide.fillText('', 11, 195);


                    //添加电子印章
                    var myImage3 = new Image();
                    //印章地址
                    myImage3.src = "/Content/images/yinzhang.png";  //你自己本地的图片或者在线图片
                    myImage3.crossOrigin = 'Anonymous';
                    //印章位置
                    myImage3.onload = function () {
                        contextOthenSide.drawImage(myImage3, 44, 36, 140, 140);

                        base64CanvasOthenSide = canvasOthenSide.toDataURL("image/jpeg");

                        //选择框选择该条数据
                        if (flag) {
                            //选择该条数据则数组中保存
                            if (isSave) {
                                var canvasData = {
                                    account: userAccount,
                                    canvasBase64Above: base64Front, //正面
                                    canvasBase64Below: base64CanvasOthenSide,//反面
                                    isadopt: isadopt,//是否通过
                                };
                                canvasArray.push(canvasData);
                            }
                            //取消选中数组中删除该条数据
                            else {
                                for (var i = 0; i < canvasArray.length; i++) {
                                    if (canvasArray[i].account.indexOf(userAccount) != -1) {
                                        //选择框取消打印该条数据
                                        canvasArray.splice(canvasArray[i].account.indexOf(userAccount), 1);
                                        //数组删除之后长度就要对应缩减；
                                        i -= 1;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    } else {
        learun.alert.error(data.info);
    }
};
