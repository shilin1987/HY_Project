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
                        label: '产品型号', name: 'Column2', width: 120, align: 'center'
                    },
                    {
                        label: '封装外形', name: 'Column3', width: 120, align: 'center'
                    },
                    {
                        label: '芯片型号', name: 'Column6', width: 120, align: 'center'
                    },
                    {
                        label: '晶圆尺寸', name: 'Column7', width: 80, align: 'center'
                    },
                    {
                        label: '包装方式', name: 'Column5', width: 100, align: 'center'
                    },
                    {
                        label: '封装等级', name: 'Column4', width: 120, align: 'center'
                    },
                    {
                        label: '环保等级', name: 'Column10', width: 120, align: 'center' 
                    },
                    {
                        label: '测试规范编号', name: 'Column8', width: 120, align: 'center'
                    },
                    {
                        label: '印章规范编号', name: 'Column11', width: 120, align: 'center'
                    },
                    {
                        label: '压焊图号及版本', name: 'Column9', width: 120, align: 'center'
                    },
                    {
                        label: 'PARTID', name: 'Column1', width: 110, align: 'left'
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
        url: top.$.rootUrl + '/B2B_Code/CUST_ORDER_CREATE/FindPartidData',
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