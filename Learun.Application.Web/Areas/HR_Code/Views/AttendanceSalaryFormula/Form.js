/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-06-29 16:05
 * 描  述：考勤工资表达式
 */
var acceptClick;
var keyValue = request('keyValue');
var arrFul = new Array();

var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('#computNo').hide();
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#parentItem').lrDataSourceSelect({ code: 'IncomePay', value: 'f_itemid', text: 'f_item' });//通过创建字典来改变获取的项目分类
            $('#F_ShiftType').lrDataItemSelect({ code: 'AttendanceFormulaType' });
            $('#F_ShiftNo').lrDataSourceSelect({ code: 'FormulaNumber', value: 'f_formulaid', text: 'f_formulacode' });//通过创建字典来改变获取的项目分类
            
            // 组合表达式
            $('#plusitem').on('click', function () {


                var val2 = $("#F_ShiftNo div").html();
              
                //checkValueCalculated($("#parentItem div").html(), $("#F_ShiftNo div").html());
                var calculatedVal = $("#calculatedValue").val();
                if ($("#parentItem div").html() == "==请选择==" && calculatedVal == "" && val2 == "==请选择==") {
                    return learun.alert.warning('请选择计算项或者计算数值或者计算公式只能选一个');
                } else if ($("#parentItem div").html() != "==请选择==" && calculatedVal != "" && val2 != "==请选择==") {
                    return learun.alert.warning('计算项和计算数值和计算公式同时只能填一个');
                } else if ($("#parentItem div").html() != "==请选择==" && calculatedVal == "" && val2 != "==请选择==") {
                    return learun.alert.warning('计算项计算公式同时只能填一个');
                } else if ($("#parentItem div").html() != "==请选择==" && calculatedVal != "" && val2 == "==请选择==") {
                    return learun.alert.warning('计算项计算值同时只能填一个');
                } else if ($("#parentItem div").html() == "==请选择==" && calculatedVal != "" && val2 != "==请选择==") {
                    return learun.alert.warning('计算值计算公式同时只能填一个');
                }
                else {
                    var txtarea = $.trim($("#F_Expression").val());
                    if (calculatedVal != "") {
                        txtarea = insertInportTxt($.trim("@" + calculatedVal + "@"));
                        //insertAtCursor(document.getElementById("F_Expression"), $.trim("@" + calculatedVal + "@"));
                        // txtarea += "@" + calculatedVal + "@"
                    } else if ($("#parentItem div").html() != "==请选择==") {
                        if (txtarea == "" || txtarea == null || txtarea == "null") {
                            txtarea += "@" + $("#parentItem div").html() + "@";
                        } else {
                            txtarea = insertInportTxt("@" + $("#parentItem div").html() + "@");
                        }
                        //insertAtCursor(document.getElementById("F_Expression"), $.trim("@" + $("#parentItem div").html() + "@"));
                        //txtarea += "@" + $("#parentItem div").html() + "@"
                    } else if ($("#F_ShiftNo div").html() != "==请选择==") {
                        txtarea = insertInportTxt($.trim("@" + $("#F_ShiftNo div").html() + "@"));
                        //insertAtCursor(document.getElementById("F_Expression"), $.trim("@" + $("#F_ShiftNo div").html() + "@"));
                        //txtarea += "@" + $("#F_ShiftNo div").html() + "@"
                    }
                    //存放上次公式
                    arrFul.push(txtarea);
                    //计算公式取消只读
                    $("#F_Expression").attr('readonly', false);
                    //表达式赋值
                    $("#F_Expression").val(txtarea);
                    //计算公式设置只读
                   // $("#F_Expression").attr('readonly', true);
                }
            });
            //公式退回
            $('#abdicationformula').on('click', function () {
                //arrFul.pop();
                $("#F_Expression").val(arrFul.pop());
            });
            // 清空表达式
            $('#clearformula').on('click', function () {
                $("#F_Expression").val("");
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/HR_Code/AttendanceSalaryFormula/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            }
           // if ("#F_ShiftNo div").html() == "") {
                
           // }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }

        if ($("#F_ShiftNo div").html() == "==请选择==") {
            learun.alert.warning('计算公式分类必须选择');
            return false;
        }
        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/HR_Code/AttendanceSalaryFormula/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}

function addFormula(obj)
{
    var txtarea = $.trim($("#F_Expression").val());

    txtarea = insertInportTxt($(obj).val());
    arrFul.push(txtarea);
    //var txtarea = $.trim($("#F_Expression").val()) + $(obj).val();

    //计算公式取消只读
    $("#F_Expression").attr('readonly', false);
    //表达式赋值
    $("#F_Expression").val(txtarea);
    //计算公式设置只读
    $("#F_Expression").attr('readonly', true);
}
//公式退回
function insertAtCursor(myField, myValue) {

    //IE 浏览器 
    if (document.selection) {
        myField.focus();
        sel = document.selection.createRange();
        sel.text = myValue;
        sel.select();
    }
    else if (myField.selectionStart || myField.selectionStart == '0') {
            //FireFox、Chrome等 
        var startPos = myField.selectionStart;
        var endPos = myField.selectionEnd;

        // 保存滚动条 
        var restoreTop = myField.scrollTop;
        myField.value = myField.value.substring(0, startPos) + myValue + myField.value.substring(endPos, myField.value.length);

        if (restoreTop > 0) {
            myField.scrollTop = restoreTop;
        }

        myField.focus();
        myField.selectionStart = startPos + myValue.length;
        myField.selectionEnd = startPos + myValue.length;
    } else {
        myField.value += myValue;
        myField.focus();
    }
    return myField.value;
}
function insertInportTxt(insertTxt) {

    var elInput = document.getElementById("F_Expression");  //获取Dom
    var startPos = elInput.selectionStart
    var endPos = elInput.selectionEnd

    if (startPos === undefined || endPos === undefined) return
    var txt = elInput.value
    var result = txt.substring(0, startPos) + insertTxt + txt.substring(endPos)
    elInput.value = result

    elInput.focus()
    elInput.selectionStart = startPos + insertTxt.length
    elInput.selectionEnd = startPos + insertTxt.length
    return elInput.value;
}

