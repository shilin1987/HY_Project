var acceptClick;
var dfopid = request('dfopid');
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#WAFER_NO').jfGrid({
                headData: [
                    {
                        label: '片号', name: 'WAFER_NO', width: 100, align: 'center',
                        edit: {
                            type: 'input'
                        }
                    }
                ],
                isEdit: true,
                height: 410,
                width: 500,
                isMultiselect: true
            });
        },
        initData: function () {
            for (var i = 0; i < 25; i++) {
                $("#WAFER_NO").jfGridSet("addRow", { WAFER_NO: i + 1 });
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        var rowdata = $('#WAFER_NO').jfGridValue('WAFER_NO');      
        return rowdata;
    };
    page.init();
};