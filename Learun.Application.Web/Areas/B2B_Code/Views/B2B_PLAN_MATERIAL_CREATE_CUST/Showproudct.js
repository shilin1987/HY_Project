var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initData();
            page.bind();
        },
        bind: function () {
            $('#mesdata').jfGrid({
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
                        label: '焊线描述', name: 'F_WIRE_SOLDER_NAME', width: 100, align: 'left'
                    },
                    {
                        label: '框架描述', name: 'F_SHELL_FRAM_NAME', width: 100, align: 'left'
                    },
                    {
                        label: 'PARTID', name: 'partid', width: 100, align: 'left'
                    },
                    {
                        label: '焊线编号', name: 'F_WIRE_SOLDER_CODE', width: 0, align: 'left', ishide: true
                    },
                    {
                        label: '框架编号', name: 'F_SHELL_FRAM_CODE', width: 0, align: 'left', ishide: true
                    },
                ],
                height: 420,
                isMultiselect: false
            })
        },
        initData: function () { }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        var sel_data = $('#mesdata').jfGridGet('rowdata');

        return sel_data;
    };
    page.init();
}

$('#lr_search').click(function () {
    $.ajax({
        type: 'post',
        url: top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/FindPartidData',
        data: {
            custcode: $("#Fcustom").val(),
            PRODUCT_MODEL: $('#F_PRODUCT_MODEL').val(),
            PACKAGING_TYPE: $('#F_PACKAGING_TYPE').val(),
            PACKAGE_MODEL: $('#F_PACKAGE_MODEL').val(),
            WAFER_MODEL: $('#F_WAFER_MODEL').val(),
        },
        success: function (data) {
            var mesdata = JSON.parse(data).data;
            for (var id in mesdata) {
                if (!!mesdata[id].length && mesdata[id].length > 0) {
                    $('#' + id).jfGridSet('refreshdata', mesdata[id]);
                    }
                }     
        }
    });
});