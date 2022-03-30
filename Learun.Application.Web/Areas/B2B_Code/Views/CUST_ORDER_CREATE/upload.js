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
        },
        initData: function () {
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }

        var f = document.getElementById('uploadFile').files[0];
        if (!!f) {
            learun.loading(true, '正在保存...');
            $.ajaxFileUpload({
                url: top.$.rootUrl + "/B2B_Code/CUST_ORDER_CREATE/UploadFile",
                secureuri: false,
                fileElementId: 'uploadFile',
                dataType: 'json',
                success: function (data) {
                    learun.loading(false);
                    var postData = {};
                    postData.strEntity = JSON.stringify({ "FCUST_CODE": $("#F_CUST_CODE").val(), "FORDER_TYPE": "", "FREMARK": "" });                  
                    postData.strEntitySub = JSON.stringify(data.data);;
                    $.lrSaveForm(top.$.rootUrl + '/B2B_Code/CUST_ORDER_CREATE/Saveupload', postData, function (res) {
                        // 保存成功后才回调
                        if (!!callBack) {
                            callBack();
                        }
                    });
                }
            });
        }
    };
    page.init();
}