
(function () {
    $(document).ready(function () {
        $('#saveIma').click(function () {
            var userMobile = $.query.get("mobile");
            var configUrl = $.query.get("configSendUrl");
            //查看页面传递参数
            //console.log("userMobile--->" + userMobile);
            //console.log("configUrl--->" + configUrl);
            //1.检查银行卡号是否正确调用阿里银行账号校验
            if ($("#bankcard").val() != null && $("#bankcard").val() != "" && $("#bankcard").val() != "null") {
                var url = "https:\//ccdcapi.alipay.com/validateAndCacheCardInfo.json?cardNo=" + $("#bankcard").val() + "&cardBinCheck=true";
                $.get(url, function (result) {
                    if (result != null) {
                        if (!result.validated) {
                            alert("银行卡号错误,请重新填写");
                            return false; 
                        }
                    } 
                });
            } else {
                alert("请填写正确的银行卡号");
                return false; 
            }
            
            var formData = new FormData();
            if (document.getElementById("img").value == "" || document.getElementById("img").value == "null") {
                return alert("请上传证件照");
            }
            formData.append("bankcard",$("#bankcard").val());
            formData.append("userMobile", userMobile);
            formData.append("file", document.getElementById("img").files[0]);
            var path = configUrl + "User/saveIma";
            console.log("------>" + path);
            $.ajax({
                 type: "post",
                 url: path,
                 data: formData,
                 enctype: 'multipart/form-data',
                 processData: false,
                 contentType: false,
                 dataType: 'json',
                 success: function (res) {
                     //learun.layer.loading(false);
                     if (res === null) {
                         alert("无法连接服务器, 请检测网络！");
                         //learun.layer.warning('无法连接服务器,请检测网络！', function () { },
                         //    '消息提示',
                         //    '关闭');
                         return;
                     }
                     if (res.code === 200) {
                        /* learun.layer.toast(res.info);*/
                         alert(res.info);
                         // learun.tab.go('my');
                     } else {
                         alert(res.info);
                         //learun.layer.warning(res.info, function () { }, '消息提示',
                         //    '关闭');
                     }
                 }
             });

        });
    });
})();