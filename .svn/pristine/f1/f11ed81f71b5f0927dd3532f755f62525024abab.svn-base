/*
 * 版 本 Learun-ADMS V7.0.6 华羿软件开发平台(http://www.learun.cn)
 * Copyright (c) 2013-2020 上海华羿信息技术有限公司
 * 创建人：华羿-前端开发组
 * 日 期：2019.08.27
 * 描 述：单据编码
 */
//style="padding:20px 100px 20px 100px;"
var bootstrap = function ($, learun) {
    "use strict";

    function makeCode() {
        var count = $("#txt_num").val();
        if (count > 100) { return false; }
        var text = $("#txt_code").val();
        var myCode = new Array();
        $("#qrcode").html("");
        for (var i = 0; i < count; ++i) {
            myCode[i] = text;
            var html = '<div id="qrcode' + i + '" style="padding:40px 40px 40px 40px; float:left"><div>';
            $("#qrcode").append(html);

            var qrcode = new QRCode(document.getElementById("qrcode" + i), {
                width: 200,
                height: 200
            });
            qrcode.makeCode(myCode[i]);
        }
    }

    makeCode();

    //打印
    $('#lr-print').on('click', function () {
        $("#qrcode").jqprint();
    });

    //生成
    $('#lr-ok').on('click', function () {
        makeCode();
    });
}
