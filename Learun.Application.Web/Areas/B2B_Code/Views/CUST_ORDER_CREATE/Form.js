/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-01-04 18:21
 * 描  述：客户订单维护
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#B2B_CUST_ORDER_PARAM_DATA').jfGrid({
                headData: [
                    {
                        label: 'PARTID', name: 'FPARTID', width: 100, align: 'center', ishide: false
                    },
                    {
                        label: '参数编号', name: 'FPARAM_CODE', width: 90, align: 'center'
                    },
                    {
                        label: '参数名称', name: 'FPARAM_NAME', width: 130, align: 'center'
                    },
                    {
                        label: '参数值', name: 'FPARAM_VALUE', width: 80, align: 'center',
                        edit: {
                            type: 'input'
                        }
                    },
                    {
                        label: '参考值', name: 'FPARAM_TYPE', width: 120, align: 'center'
                    }
                ],
                isEdit: false,
                height: 360,
                width: 400
            });

            $('#B2B_CUST_ORDER_SUB').jfGrid({
                headData: [
                    {
                        label: 'PARTID', name: 'FPARTID', width: 100, align: 'center', ishide: false
                    },
                    {
                        label: '芯片型号', name: 'FWAFER_TYPE', width: 100, align: 'center'
                    },
                    {
                        label: '产品型号', name: 'FPRODUCT_TYPE', width: 100, align: 'left'
                    },
                    {
                        label: '封装形式', name: 'FPACKAGE_TYPE', width: 100, align: 'left'
                    },
                    {
                        label: '芯片批号', name: 'FWAFER_BATCH', width: 100, align: 'left'
                    },
                    {
                        label: '芯片片数', name: 'FWAFER_NUMBER', width: 100, align: 'left'
                    },
                    {
                        label: '芯片片号', name: 'FWAFER_NO', width: 100, align: 'left'
                    },
                    {
                        label: '芯片数量', name: 'FWAFER_QTY', width: 80, align: 'left'
                    },
                    {
                        label: '测试规范编号', name: 'FTEST_CODE', width: 100, align: 'left'
                    },
                    {
                        label: '印章规范编号', name: 'FPRINT_CODE', width: 100, align: 'left'
                    },
                    {
                        label: '压焊图号', name: 'FBONDING_CODE', width: 100, align: 'left'
                    },
                    {
                        label: '包装方式', name: 'FPACKING_TYPE', width: 100, align: 'left'
                    },
                    {
                        label: '环保等级', name: 'FGREEN_LEVE', width: 100, align: 'left'
                    },
                    {
                        label: '封装等级', name: 'FPACKAGE_LEVE', width: 100, align: 'left'
                    },
                    {
                        label: '取片方式', name: 'FGETWAFER_TYPE', width: 100, align: 'left'
                    },
                    {
                        label: '贸易方式', name: 'FTRADE_TYPE', width: 100, align: 'left'
                    },
                    {
                        label: '用户批号', name: 'FCUST_PO', width: 80, align: 'left'
                    }
                ],
                isEdit: true
            });

            $('#B2B_CUST_ORDER_PARAM').jfGrid({              
                headData: [
                    {
                        label: 'PARTID', name: 'FPARTID', width: 100, align: 'center', ishide: false
                    },
                    {
                        label: '参数编号', name: 'FPARAM_CODE', width: 200, align: 'center'
                    },
                    {
                        label: '参数名称', name: 'FPARAM_NAME', width: 200, align: 'center'
                    },
                    {
                        label: '参数值', name: 'FPARAM_VALUE', width: 200, align: 'center'
                    }
                ]
            });

            $('#lr_form_tabs').lrFormTab();
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/B2B_Code/CUST_ORDER_CREATE/GetFormData?keyValue=' + keyValue, function (data) {
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
        postData.strEntity = JSON.stringify({ "FCUST_CODE": $("#FCUST_CODE").val(), "FORDER_TYPE": $("#FORDER_TYPE option:selected").text(), "FREMARK": $("#FREMARK").val() });
        postData.strEntityParams = JSON.stringify($('#B2B_CUST_ORDER_PARAM').jfGridGet('rowdatas'));
        postData.strEntitySub = JSON.stringify($('#B2B_CUST_ORDER_SUB').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/B2B_Code/CUST_ORDER_CREATE/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();

    ////取芯片型号
    //$('#FWAFER_TYPE').on('click', function () {
    //    var cust = $("#FCUST_CODE").val();
    //    var title = "调取芯片型号信息";
    //    var target = document.getElementById("FWAFER_TYPE");
    //    var url = "/B2B_Code/CUST_ORDER_CREATE/GetCustDeviceList";
    //    var seturl = '/B2B_Code/CUST_ORDER_CREATE/ShowList?parameters=' + "cust=" + cust + ",wafer=" + ",product=" + ",url=" + url + ",Colname=芯片型号";
    //    $('#FWAFER_TYPE').find('Option').remove();
    //    Show(title, seturl, target);
    //});

    ////取产品型号
    //$('#FPRODUCT_TYPE').on('click', function () {
    //    var cust = $("#FCUST_CODE").val();
    //    var wafer_value = $("#FWAFER_TYPE option:selected").text();  
    //    var title = "调取产品型号信息";
    //    var url = "/B2B_Code/CUST_ORDER_CREATE/GetProductList";
    //    var target = document.getElementById("FPRODUCT_TYPE");
    //    var seturl = '/B2B_Code/CUST_ORDER_CREATE/ShowList?parameters=' + "cust=" + cust + ",wafer=" + wafer_value + ",product=" + ",url=" + url + ",Colname=产品型号";
    //    $('#FPRODUCT_TYPE').find('Option').remove();
    //    Show(title, seturl, target);
    //})

    ////取封装形式
    //$('#FPACKAGE_TYPE').on('click', function () {
    //    var cust = $("#FCUST_CODE").val();     
    //    var wafer_value = $("#FWAFER_TYPE option:selected").text();
    //    var product_value = $("#FPRODUCT_TYPE option:selected").text();
    //    var title = "调取封装形式信息";
    //    var url = "/B2B_Code/CUST_ORDER_CREATE/GetPackageList";
    //    var target = document.getElementById("FPACKAGE_TYPE");
    //    var seturl = '/B2B_Code/CUST_ORDER_CREATE/ShowList?parameters=' + "cust=" + cust + ",wafer=" + wafer_value + ",product=" + product_value + ",url=" + url + ",Colname=封装形式";
    //    $('#FPACKAGE_TYPE').find('Option').remove();
    //    Show(title, seturl, target);
    //})

    //取包装方式
    //$('#FPACKING_TYPE').on('click', function () {
    //    var cust = $("#FCUST_CODE").val(); 
    //    var wafer_value = $("#FWAFER_TYPE option:selected").text(); 
    //    var product_value = $("#FPRODUCT_TYPE option:selected").text();
    //    var title = "调取包装方式信息";
    //    var url = "/B2B_Code/CUST_ORDER_CREATE/GetPackingTypeListstring";
    //    var target = document.getElementById("FPACKING_TYPE");
    //    var seturl = '/B2B_Code/CUST_ORDER_CREATE/ShowList?parameters=' + "cust=" + cust + ",wafer=" + wafer_value + ",product=" + product_value + ",url=" + url + ",Colname=包装方式";
    //    $('#FPACKING_TYPE').find('Option').remove();
    //    Show(title, seturl, target);
    //})

    //添加片号
    $("#FWAFER_NO").on('click', function () {       
        $("#FWAFER_NO").val("");
        var target = document.getElementById("FWAFER_NO");
        learun.layerForm({
            title: "晶圆片号维护",
            url: top.$.rootUrl + '/B2B_Code/CUST_ORDER_CREATE/WaferForm',
            width: 560,
            height: 530,
            maxmin: false,
            callBack: function (id) {
                var opt = document.createElement("Option");
                opt.innerHTML = top[id].acceptClick();
                target.appendChild(opt);
                return top[id].acceptClick();
            }
        });
    });

    function Show(title, url, target_obj) {
        learun.layerForm({
            title: title,
            url: top.$.rootUrl + url,
            width: 560,
            height: 400,
            maxmin: false,
            callBack: function (id) {
                var opt = document.createElement("Option");
                opt.innerHTML = top[id].acceptClick();
                target_obj.appendChild(opt);
                return top[id].acceptClick();
            }
        });
    }

    //添加行
    $("#lr_add_order").on("click", function () {

        if ($("#FPARITD").val().length == 0) {
            learun.alert.warning('产品信息等内容不能为空！');
            return;
        }
        if ($("#FWAFER_BATCH").val().length == 0) {
            learun.alert.warning('芯片批号不能为空！');
            return;
        }
        if ($("#FWAFER_NUMBER").val().length == 0) {
            learun.alert.warning('芯片数量不能为空！');
            return;
        }       

        var datarow01 = {
            FPARTID: $("#FPARITD").val(),
            FWAFER_TYPE: $("#FWAFER_TYPE").val(),
            FPRODUCT_TYPE: $("#FPRODUCT_TYPE").val(),
            FPACKAGE_TYPE: $("#FPACKAGE_TYPE").val(),
            FWAFER_BATCH: $("#FWAFER_BATCH").val(),
            FWAFER_NUMBER: $("#FWAFER_NUMBER").val(),
            FWAFER_NO: $("#FWAFER_NO").val(),
            FWAFER_QTY: $("#FWAFER_QTY").val(),
            FIS_TEST: $("#FIS_TEST").val(),
            FTEST_CODE: $("#FTEST_CODE").val(),
            FIS_PRINT: $("#FIS_PRINT").val(),
            FPRINT_CODE: $("#FPRINT_CODE").val(),
            FBONDING_CODE: $("#FBONDING_CODE").val(),
            FGREEN_LEVE: $("#FGREEN_LEVE").val(),
            FCUST_PO: $("#FCUST_PO").val(),
            FPACKING_TYPE: $("#FPACKING_TYPE").val(),
            FPACKAGE_LEVE: $("#FPACKAGE_LEVE").val(),
            FGETWAFER_TYPE: $("#FGETWAFER_TYPE option:selected").text(),
            FTRADE_TYPE: $("#FTRADE_TYPE option:selected").text(),
        };
        var datarow02 = $('#B2B_CUST_ORDER_PARAM_DATA').jfGridGet('rowdatas');
        AddRow(datarow01, datarow02);
    });

    //按客户查产品信息
    $("#btn_Search").on('click', function () {
        if ($('#FCUST_CODE').val().length == 0) {
            learun.alert.warning('请输入客户信息后在进行查询！');
        }
        else {
            learun.layerForm({
                title: "客户产品信息源",
                url: top.$.rootUrl + '/B2B_Code/CUST_ORDER_CREATE/GetDataTable?Fcustom=' + $('#FCUST_CODE').val(),
                width: 1000,
                height: 650,
                maxmin: false,
                callBack: function (data) {                   
                    var mesdata = top[data].acceptClick();
                    $("#FPARITD").val(mesdata.Column1);
                    $("#FWAFER_TYPE").val(mesdata.Column4);
                    $("#FPRODUCT_TYPE").val(mesdata.Column2);
                    $("#FPACKAGE_TYPE").val(mesdata.Column3);
                    $("#FPACKING_TYPE").val(mesdata.Column5);
                    $("#FPACKAGE_LEVE").val(mesdata.Column4);
                    $("#FTEST_CODE").val(mesdata.Column8);
                    $("#FPRINT_CODE").val(mesdata.Column11);
                    $("#FBONDING_CODE").val(mesdata.Column9);
                    $("#FGREEN_LEVE").val(mesdata.Column10);
                    //扩展参数
                    findparam();
                    return mesdata;
                }
            });           
        }
    });
}
//扩展参数
function findparam() {
    //partid变化时调扩展参数
    $.ajax({
        type: 'post',
        url: top.$.rootUrl + '/B2B_Code/CUST_ORDER_CREATE/GetOrderParamList',
        data: { PARTID: $("#FPARITD").val() },
        success: function (data) {          
            var listdata = JSON.parse(data).data;
            if (!!listdata.length && listdata.length > 0) {
                $('#B2B_CUST_ORDER_PARAM_DATA').jfGridSet('refreshdata', listdata);
            }    
        }
    });
}
//环保等级
//$("#FGREEN_LEVE").on('click', function () {
//    var target_obj = document.getElementById("FGREEN_LEVE");
//    $('#FGREEN_LEVE').find('Option').remove();
//    GetMesPortsub('/B2B_Code/CUST_ORDER_CREATE/GetOrderAttParamList', target_obj, 1);
//})

//封装等级
//$("#FPACKAGE_LEVE").on('click', function () {
//    var target_obj = document.getElementById("FPACKAGE_LEVE");
//    $('#FPACKAGE_LEVE').find('Option').remove();
//    GetMesPortsub('/B2B_Code/CUST_ORDER_CREATE/GetOrderAttParamList', target_obj, 2);
//})

//取片方式
$("#FGETWAFER_TYPE").on('click', function () {
    var target_obj = document.getElementById("FGETWAFER_TYPE");
    $('#FGETWAFER_TYPE').find('Option').remove();
    GetMesPortsub('/B2B_Code/CUST_ORDER_CREATE/GetOrderAttParamList', target_obj, 3);
})

//贸易方式
$("#FTRADE_TYPE").on('click', function () {
    var target_obj = document.getElementById("FTRADE_TYPE");
    $('#FTRADE_TYPE').find('Option').remove();
    GetMesPortsub('/B2B_Code/CUST_ORDER_CREATE/GetOrderAttParamList', target_obj, 4);
})

function GetMesPortsub(url, target_obj, type) {
    $.ajax({
        type: 'post',
        url: top.$.rootUrl + url,
        data: { type: type },
        success: function (data) {
            var listdata = JSON.parse(data).data;
            for (var id in listdata) {
                var op = new Option();
                op.text = listdata[id];
                op.value = id;
                target_obj.options.add(op);
            }
        }
    });
}

function AddRow(datarow01, datarow02) {
    $("#B2B_CUST_ORDER_SUB").jfGridSet("addRow", datarow01);
    for (var i in datarow02) {
        $("#B2B_CUST_ORDER_PARAM").jfGridSet("addRow", datarow02[i])
    }
    clear();
}

//清理数据
function clear() {
    $('#FPARITD').val('');
    $("#FWAFER_TYPE").val("");
    $("#FPRODUCT_TYPE").val("");
    $("#FPACKAGE_TYPE").val("");
    $("#FWAFER_BATCH").val("");
    $("#FWAFER_NUMBER").val("");
    $("#FWAFER_NO").val("");
    $("#FWAFER_QTY").val("");
    $("#FIS_TEST").val("");
    $("#FTEST_CODE").val("");
    $("#FIS_PRINT").val("");
    $("#FPRINT_CODE").val("");
    $("#FBONDING_CODE").val("");
    $("#FGREEN_LEVE").val("");
    $("#FCUST_PO").val("");
    $("#FPACKING_TYPE").val("");
    $("#FPACKAGE_LEVE").val("");
    $("#FGETWAFER_TYPE").val("");
    $("#FTRADE_TYPE").val("");
    $('#B2B_CUST_ORDER_PARAM_DATA').jfGridSet('reload', '');
}

//刷新页面
$("#lr_refresh").on('click', function () {
    clear();
    $("#FCUST_CODE").val('');
    $('#FORDER_TYPE').find('Option').remove();
    $('#B2B_CUST_ORDER_SUB').jfGridSet('reload', '');
    $('#B2B_CUST_ORDER_PARAM').jfGridSet('reload', '');
})