var acceptClick;
var dfopid = request('dfopid');
var keyValue = request('keyValue');
var setdata = "";
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initData();     
            page.bind();
        },
        bind: function () {
            $('#MES_LIST_DATA').jfGrid({
                headData: [
                    {                      
                        label: $("#Colname").val(), name: 'data', width: 100, align: 'center'
                    }
                ],
                isEdit: false,
                height: 280,
                width: 800
            });
            
        },
        initData: function () {   
            var parameters = { CustCode: $("#cust").val(), CustDevice: $("#wafer").val(), InputPart: $("#product").val()}
            $.ajax({
                type: 'post',
                url: top.$.rootUrl + $("#url").val() ,
                data: parameters,
                success: function (list) {                 
                    var listdata = JSON.parse(list).data;   
                    for (var id in listdata) {
                        var datarow = { data: listdata[id]}; 
                        datarow["data"] = listdata[id];                    
                        $("#MES_LIST_DATA").jfGridSet("addRow", datarow);
                    };
                }
            });
        }
    };
    // 保存数据
    acceptClick = function () {
        return $('#MES_LIST_DATA').jfGridValue('data');           
        //learun.layerClose(window.name);//关闭窗体*/
    };
    page.init();
}