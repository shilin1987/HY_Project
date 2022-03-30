/*
 * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.04.11
 * 描 述：excel 数据导出	
 */
var gridId = request('gridId');
var filename = decodeURI(request('filename'));
var excelUrl = request('excelUrl');
var param = decodeURI(request('paramStr'));

var acceptClick;
var bootstrap = function ($, learun) {
    "use strict";

    var page = {
        init: function () {
            var columnModel = learun.frameTab.currentIframe().$('#' + gridId).jfGridGet('settingInfo').headData;
            var $ul = $('.sys_spec_text');
            $.each(columnModel, function (i,item) {
                var label = item.label;
                var name = item.name;
                if (!!label) {
                    $ul.append("<li data-value='" + name + "' title='" + label + "'><a>" + label + "</a><i></i></li>");
                }
            });
            $(".sys_spec_text li").addClass("active");
            $(".sys_spec_text li").click(function () {
                if (!!$(this).hasClass("active")) {
                    $(this).removeClass("active");
                } else {
                    $(this).addClass("active").siblings("li");
                }
            });
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        var exportField = [];
        $('.sys_spec_text ').find('li.active').each(function () {
            var value = $(this).attr('data-value');
            exportField.push(value);
        });

        
        var columnJson = JSON.stringify(learun.frameTab.currentIframe().$('#' + gridId).jfGridGet('settingInfo').headData);

        var rowJson = "";
 
        param = param.replace(/@/g, '"');
        console.log("------------param>" + param);
        var datainfo = JSON.parse(param);
        console.log("---------->data:" + datainfo);
        debugger;
        $.ajax({
            url: top.$.rootUrl + excelUrl,
            type: "get",
            data: datainfo,
            dataType: "json",
            success: function (data) {
                if (data.code == 200) {
                    debugger;
                    learun.download({
                        method: "POST",
                        url: '/Utility/ExportExcel',
                        param: {
                            fileName: filename,
                            columnJson: columnJson,
                            dataJson: data.info,
                            exportField: String(exportField),
                            modeleId: ''
                        }
                    });
                } else {
                    learun.alert.error("没有该员工部门信息");
                }
            },
            error: function (e) {
                learun.alert.error("网络错误，请重试！！");
            }
        });

    };
    page.init();
}