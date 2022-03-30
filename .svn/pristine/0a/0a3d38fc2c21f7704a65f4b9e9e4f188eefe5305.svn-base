(function () {
    var page = {
        isScroll: true,
        init: function ($page, param) {

            //绑定后台获取的数据,没有下拉框数据不显示
            page.bind($page, param);
            //保存
            $page.find('#saveUser').on('tap', function () {

                if (!$('#userform').lrformValid()) {
                    return false;
                };

                //注册账号
                var data = {
                    RealName: $('#F_RealName').val(),
                    Gender: gender,
                    IDCard: idCard,
                    Mobile: mobile,
                    VCode: $('#F_VerificationCode').val(),
                    IsGetAccommodation: isGetAccommodation
                };
                var postdata = {
                    token: '',
                    loginMark: learun.deviceId(), // 正式请换用设备号
                    data: JSON.stringify(data)
                };
                var path = config.webapi;
                learun.layer.loading(true, "正在注册，请稍后");
                learun.http.post(path + "learun/adms/user/registered", postdata, function (res) {
                    learun.layer.loading(false);
                    if (res === null) {
                        learun.layer.warning('无法连接服务器,请检测网络！', function () { }, '消息提示', '关闭');
                        return;
                    };
                    //注册成功后提示跳转登录页面
                    learun.layer.toast(res.info);
                    if (res.code === 200) {
                        // $('#F_RealName').val('');
                        // $('#F_Gender').val('');
                        // $('#F_IDCard').val('');
                        // $('#F_Mobile').val('');
                        // $('#F_IsGetAccommodation').val('');
                        setTimeout(function () {
                            //跳转页面
                            learun.nav.go({ path: 'login', title: "登录" });
                        }, 2000);
                    }
                });
            });
        },
        bind: function ($page, param) {

        },
    };
    return page;
})();
