/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-11-10 13:46
 * 描  述：客户端月度来料计划填报
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    var one, two, three, four, five, six, monthdata;
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {

            $('#F_WRITE_MONTH').lrDataItemSelect({ code: 'Month' });

            ///通过后台调取
            //$('#F_PRODUCT_MODEL').lrDataSourceSelect({ code: 'B2B_MES_PRATID', value: '产品型号', text: '产品型号' });  
            //$('#F_WIRE_SOLDER_NAME').lrselect({
            //    url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/GetProuduct?custcode=' + $('#F_CUST_CODE').val(),
            //    text: 'F_WIRE_SOLDER_NAME',
            //    value: 'F_SHELL_FRAM_CODE',
            //    allowSearch: true,
            //    maxHeight: 400
            //});

            $('#B2B_PLAN_INCOMING_MATERIAL_SUB').jfGrid({
                rowHeight: 30,
                headData: [
                    {
                        label: '产品型号', name: 'F_PRODUCT_MODEL', width: 100, align: 'center'
                    },
                    {
                        label: '封装外形', name: 'F_PACKAGE_MODEL', width: 100, align: 'center'
                    },
                    {
                        label: '芯片型号', name: 'F_WAFER_MODEL', width: 100, align: 'center'
                    },
                    {
                        label: '晶圆尺寸', name: 'F_WAFER_SIZE', width: 70, align: 'center'
                    },
                    {
                        label: '包装方式', name: 'F_PACKAGING_TYPE', width: 70, align: 'center'
                    },
                    {
                        label: '封装等级', name: 'F_PRODUCT_LEVEL', width: 70, align: 'center'
                    },
                    {
                        label: '填报月份', name: 'A', width: 70, align: 'center',
                        children: [
                            {
                                label: '1', name: 'F_MONTH_ONE', width: 60, align: 'center'
                                , edit: {
                                    type: 'input'
                                }
                            },
                            {
                                label: '2', name: 'F_MONTH_TWO', width: 60, align: 'left'
                                , edit: {
                                    type: 'input'
                                }
                            },
                            {
                                label: '3', name: 'F_MONTH_THREE', width: 60, align: 'left'
                                , edit: {
                                    type: 'input'
                                }
                            },
                            {
                                label: '4', name: 'F_MONTH_FOUR', width: 60, align: 'left'
                                , edit: {
                                    type: 'input'
                                }
                            },
                            {
                                label: '5', name: 'F_MONTH_FIVE', width: 60, align: 'left'
                                , edit: {
                                    type: 'input'
                                }
                            },
                            {
                                label: '6', name: 'F_MONTH_SIX', width: 60, align: 'left'
                                , edit: {
                                    type: 'input'
                                }
                            },
                        ]
                    },
                    {
                        label: '备注', name: 'F_REMARK', width: 100, align: 'left'
                        , edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '焊线描述', name: 'F_WIRE_SOLDER_NAME', width: 100, align: 'left'
                    },
                    {
                        label: '框架描述', name: 'F_SHELL_FRAM_NAME', width: 100, align: 'left'
                    },
                    {
                        label: 'PARTID', name: 'PARTID', width: 100, align: 'left'
                    },
                    {
                        label: '焊线编号', name: 'F_WIRE_SOLDER_CODE', width: 0, align: 'left', ishide: true
                    },
                    {
                        label: '框架编号', name: 'F_SHELL_FRAM_CODE', width: 0, align: 'left', ishide: true
                    },
                ],
                isEdit: true,
                height: 340,
                isMultiselect: true
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        var postData = {};
        postData.strEntitysub = JSON.stringify($('#B2B_PLAN_INCOMING_MATERIAL_SUB').jfGridGet('rowdatas'));;
        postData.strEntity = JSON.stringify($('[data-table="B2B_PLAN_INCOMING_MATERIAL"]').lrGetFormData());
        $.lrSaveForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/AddSaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();

    $('#btn_Search01').on('click', function () {     
        if ($("#PARTID").val().length == 0) {
            learun.alert.warning("请输入PRATID编号！");
            return;
        }
        else {
            $.lrSetForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/GetProuduct?partid=' + $("#PARTID").val(), function (data) {
                $('#F_PRODUCT_MODEL').val(data[0]["F_PRODUCT_MODEL"]);
                $('#F_PACKAGE_MODEL').val(data[0]["F_PACKAGE_MODEL"]);
                $('#F_PRODUCT_LEVEL').val(data[0]["F_PRODUCT_LEVEL"]);
                $('#F_PACKAGING_TYPE').val(data[0]["F_PACKAGING_TYPE"]);
                $('#F_WAFER_MODEL').val(data[0]["F_WAFER_MODEL"]);
                $('#F_WAFER_SIZE').val(data[0]["F_WAFER_SIZE"]);
                $('#F_WIRE_SOLDER_NAME').val(data[0]["F_WIRE_SOLDER_NAME"]);
                $('#F_SHELL_FRAM_NAME').val(data[0]["F_SHELL_FRAM_NAME"]);
                $('#F_WIRE_SOLDER_CODE').val(data[0]["F_WIRE_SOLDER_CODE"]);
                $('#F_SHELL_FRAM_CODE').val(data[0]["F_SHELL_FRAM_CODE"]);
            });
        }
        $.lrSetForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/GetProuduct?partid=' + $("#PARTID").val(), function (data) {
            $('#F_PRODUCT_MODEL').val(data[0]["F_PRODUCT_MODEL"]);
            $('#F_PACKAGE_MODEL').val(data[0]["F_PACKAGE_MODEL"]);
            $('#F_PRODUCT_LEVEL').val(data[0]["F_PRODUCT_LEVEL"]);
            $('#F_PACKAGING_TYPE').val(data[0]["F_PACKAGING_TYPE"]);
            $('#F_WAFER_MODEL').val(data[0]["F_WAFER_MODEL"]);
            $('#F_WAFER_SIZE').val(data[0]["F_WAFER_SIZE"]);
            $('#F_WIRE_SOLDER_NAME').val(data[0]["F_WIRE_SOLDER_NAME"]);
            $('#F_SHELL_FRAM_NAME').val(data[0]["F_SHELL_FRAM_NAME"]);
            $('#F_WIRE_SOLDER_CODE').val(data[0]["F_WIRE_SOLDER_CODE"]);
            $('#F_SHELL_FRAM_CODE').val(data[0]["F_SHELL_FRAM_CODE"]);
        });
    });

    $('#btn_Search02').on('click', function () {       
        learun.layerForm({
            title: "客户产品信息源",
            url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/GetDataTable?Fcustom=' + $('#F_CUST_CODE').val(),
            width: 1000,
            height: 650,
            maxmin: false,
            callBack: function (data) {
                var mesdata = top[data].acceptClick();
                $("#PARTID").val(mesdata.PARTID);
                $("#F_PRODUCT_MODEL").val(mesdata.F_PRODUCT_MODEL);
                $("#F_PACKAGE_MODEL").val(mesdata.F_PACKAGE_MODEL);
                $("#F_PRODUCT_LEVEL").val(mesdata.F_PRODUCT_LEVEL);
                $("#F_PACKAGING_TYPE").val(mesdata.F_PACKAGING_TYPE);
                $("#F_WAFER_MODEL").val(mesdata.F_WAFER_MODEL);
                $("#F_WAFER_SIZE").val(mesdata.F_WAFER_SIZE);
                $("#F_WIRE_SOLDER_NAME").val(mesdata.F_WIRE_SOLDER_NAME);
                $("#F_WIRE_SOLDER_CODE").val(mesdata.F_WIRE_SOLDER_CODE);
                $("#F_SHELL_FRAM_NAME").val(mesdata.F_SHELL_FRAM_NAME);
                $("#F_SHELL_FRAM_CODE").val(mesdata.F_SHELL_FRAM_CODE);
                return mesdata;
            }
        });
    });

    $('#btn_Search03').on('click', function () {
        if ($("#F_CUST_CODE").val().length == 0) {
            learun.alert.warning('请选择客户代码后在进行查询！');
        }
        else {
            $.lrSetForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/GetPartidData?custcode=' + $("#F_CUST_CODE").val(), function (data) {
                for (var id in data) {
                    if (!!data[id].length && data[id].length > 0) {
                        $('#' + id).jfGridSet('refreshdata', data[id]);
                    }
                }
            });
        }
    });

    $("#lr_refresh").on('click', function () {
        clear();
    });

    $("#btn_Downexce").on('click', function () {
        if ($("#F_WRITE_MONTH").text() == "==请选择==") {
            learun.alert.warning('请选择具体填报的月份！');
        }
        else {           
            var month = parseInt($("#F_WRITE_MONTH").text());
            one = month
            two = month + 1 > 12 ? 1 : month + 1;
            three = month + 2 > 12 ? month + 2 - 12 : month + 2;
            four = month + 3 > 12 ? month + 3 - 12 : month + 3;
            five = month+ 4 > 12 ? month + 4 - 12 : month + 4;
            six = month + 5 > 12 ? month + 5 - 12 : month +5;

            if ($("#F_CUST_CODE").val().length == 0) {
                learun.alert.warning('请填写客户代码后在进行查询！');
            }
            else if ($('#B2B_PLAN_INCOMING_MATERIAL_SUB').jfGridGet('rowdatas').length == 0) {
                learun.alert.warning('请查询客户对应的产品信息后在进行下载！');
            }
            else {
                learun.download({
                    method: "POST",
                    url: '/Utility/ExportExcel',
                    param: {
                        fileName: "客户产品信息",
                        columnJson: JSON.stringify([
                            { "label": "PARTID", "name": "PARTID", "width": 100, "align": "center" },
                            { "label": "产品型号", "name": "F_PRODUCT_MODEL", "width": 100, "align": "center" },
                            { "label": "封装外形", "name": "F_PACKAGE_MODEL", "width": 100, "align": "center" },
                            { "label": "封装等级", "name": "F_PRODUCT_LEVEL", "width": 100, "align": "center" },
                            { "label": "芯片型号", "name": "F_WAFER_MODEL", "width": 100, "align": "center" },
                            { "label": "晶圆尺寸", "name": "F_WAFER_SIZE", "width": 100, "align": "center" },
                            { "label": "包装方式", "name": "F_PACKAGING_TYPE", "width": 100, "align": "center" },
                            { "label": "焊线编号", "name": "F_WIRE_SOLDER_CODE", "width": 100, "align": "center" },
                            { "label": "焊线描述", "name": "F_WIRE_SOLDER_NAME", "width": 100, "align": "center" },
                            { "label": "框架编号", "name": "F_SHELL_FRAM_CODE", "width": 100, "align": "center" },
                            { "label": "框架描述", "name": "F_SHELL_FRAM_NAME", "width": 100, "align": "center" },
                            { "label": one + "月份", "name": "F_MONTH_ONE", "width": 100, "align": "center" },
                            { "label": two + "月份", "name": "F_MONTH_TWO", "width": 100, "align": "center" },
                            { "label": three + "月份", "name": "F_MONTH_THREE", "width": 100, "align": "center" },
                            { "label": four + "月份", "name": "F_MONTH_FOUR", "width": 100, "align": "center" },
                            { "label": five + "月份", "name": "F_MONTH_FIVE", "width": 100, "align": "center" },
                            { "label": six + "月份", "name": "F_MONTH_SIX", "width": 100, "align": "center" },
                            { "label": "备注", "name": "F_REMARK", "width": 100, "align": "center" }]),
                        dataJson: JSON.stringify($('#B2B_PLAN_INCOMING_MATERIAL_SUB').jfGridGet('settingInfo').rowdatas)
                    }
                });
            }
        }
    });
}

//添加行
$("#lr_add_order").on("click", function () {

    //if ($("#FWAFER_TYPE option:selected").text().length == 0) {
    //    learun.alert.warning('产品型号不能为空！');
    //    return;
    //}
    //if ($("#FPRODUCT_TYPE option:selected").text().length == 0) {
    //    learun.alert.warning('产品型号不能为空！');
    //    return;
    //}
    //if ($("#FPACKAGE_TYPE option:selected").text().length == 0) {
    //    learun.alert.warning('封装形式不能为空！');
    //    return;
    //}
    //if ($("#FWAFER_NUMBER").val().length == 0) {
    //    learun.alert.warning('芯片数量不能为空！');
    //    return;
    //}
    var datarow = {
        PARTID: $("#PARTID").val(),
        F_PRODUCT_MODEL: $("#F_PRODUCT_MODEL").val(),
        F_PACKAGE_MODEL: $("#F_PACKAGE_MODEL").val(),
        F_PRODUCT_LEVEL: $("#F_PRODUCT_LEVEL").val(),
        F_PACKAGING_TYPE: $("#F_PACKAGING_TYPE").val(),
        F_WAFER_MODEL: $("#F_WAFER_MODEL").val(),
        F_WAFER_SIZE: $("#F_WAFER_SIZE").val(),
        F_WIRE_SOLDER_NAME: $("#F_WIRE_SOLDER_NAME").val(),
        F_WIRE_SOLDER_CODE: $("#F_WIRE_SOLDER_CODE").val(),
        F_SHELL_FRAM_NAME: $("#F_SHELL_FRAM_NAME").val(),
        F_SHELL_FRAM_CODE: $("#F_SHELL_FRAM_CODE").val(),
        F_MONTH_ONE: $("#F_MONTH_ONE").val(),
        F_MONTH_TWO: $("#F_MONTH_TWO").val(),
        F_MONTH_THREE: $("#F_MONTH_THREE").val(),
        F_MONTH_FOUR: $("#F_MONTH_FOUR").val(),
        F_MONTH_FIVE: $("#F_MONTH_FIVE").val(),
        F_MONTH_SIX: $("#F_MONTH_SIX").val(),
        F_REMARK: $("#F_REMARK").val(),
    };
    AddRow(datarow);
});

function AddRow(datarow) {
    $("#B2B_PLAN_INCOMING_MATERIAL_SUB").jfGridSet("addRow", datarow);
    clear();
};

function clear() {
    $("#PARTID").val("");
    $("#F_PRODUCT_MODEL").val("");
    $("#F_PACKAGE_MODEL").val("");
    $("#F_PRODUCT_LEVEL").val("");
    $("#F_PACKAGING_TYPE").val("");
    $("#F_WAFER_MODEL").val("");
    $("#F_WAFER_SIZE").val("");
    $("#F_WIRE_SOLDER_NAME").val("");
    $("#F_WIRE_SOLDER_CODE").val("");
    $("#F_SHELL_FRAM_NAME").val("");
    $("#F_SHELL_FRAM_CODE").val("");
    $("#F_MONTH_ONE").val("");
    $("#F_MONTH_TWO").val("");
    $("#F_MONTH_THREE").val("");
    $("#F_MONTH_FOUR").val("");
    $("#F_MONTH_FIVE").val("");
    $("#F_MONTH_SIX").val("");
    $("#F_REMARK").val("");
}

$('#F_WRITE_MONTH').change(function () {
    var two, three, four, five, six,monthdata;
    if ($("#F_WRITE_MONTH").text() == "==请选择==") {
        $("#MONTH_ONE").html("1月份");
        $("#MONTH_TWO").html("2月份");
        $("#MONTH_THREE").html("3月份");
        $("#MONTH_FOUR").html("4月份");
        $("#MONTH_FIVE").html("5月份");
        $("#MONTH_SIX").html("6月份");
    }
    else {
        monthdata = parseInt($("#F_WRITE_MONTH").text());
        two = monthdata + 1 > 12 ? 1 : monthdata + 1;
        three = monthdata + 2 > 12 ? monthdata + 2-12 : monthdata + 2;
        four = monthdata + 3 > 12 ? monthdata + 3-12 : monthdata + 3;
        five = monthdata + 4 > 12 ? monthdata + 4-12 : monthdata + 4;
        six = monthdata + 5 > 12 ? monthdata + 5-12 : monthdata + 5;
      
        $("#MONTH_ONE").html(monthdata+"月份");
        $("#MONTH_TWO").html(two+"月份");
        $("#MONTH_THREE").html(three+"月份");
        $("#MONTH_FOUR").html(four+"月份");
        $("#MONTH_FIVE").html(five+"月份");
        $("#MONTH_SIX").html(six + "月份");

        $(".jfgrid-head-cell span:eq(7)").html(monthdata);
        $(".jfgrid-head-cell span:eq(8)").html(two);
        $(".jfgrid-head-cell span:eq(9)").html(three);
        $(".jfgrid-head-cell span:eq(10)").html(four);
        $(".jfgrid-head-cell span:eq(11)").html(five);
        $(".jfgrid-head-cell span:eq(12)").html(six);   
    }
});

//$('#F_WIRE_SOLDER_NAME').on('change', function (data) {

//    $('#F_WIRE_SOLDER_NAME').lrselect({
//        url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/GetProuduct?custcode=' + $('#F_CUST_CODE').val(),
//        text: 'F_SHELL_FRAM_NAME',
//        value: 'F_SHELL_FRAM_CODE',
//        allowSearch: true,
//        maxHeight: 400
//    });
//})