var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";

    var page = {
        init: function () {
            //page.initData();
            page.bind();
        },
        bind: function () {
            $('#F_WRITE_MONTH').lrDataItemSelect({ code: 'Month' });
        },
        initData: function () {}
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
                url: top.$.rootUrl + "/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/UploadFile" ,
                secureuri: false,
                fileElementId: 'uploadFile',
                dataType: 'json',
                success: function (data) {
                    learun.loading(false);               

                    var postData = {};
                    postData.strEntitysub = JSON.stringify(data.data);
                    postData.strEntity = JSON.stringify($('[data-table="B2B_PLAN_INCOMING_MATERIAL"]').lrGetFormData());
                    $.lrSaveForm(top.$.rootUrl + '/B2B_Code/B2B_PLAN_MATERIAL_CREATE_CUST/SaveForm?keyValue=' + keyValue, postData, function (res) {
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