﻿(function () {
    var page = {
        isScroll: true,
        init: function ($page) {
            $page.find('#savepassword').on('tap', function () {
                if (!$('#modifypasswordform').lrformValid()) {
                    return false;
                }
                var formdata = $('#modifypasswordform').lrformGet();
                if (formdata.newpassword1 === formdata.newpassword) {
                    var userinfo = learun.storage.get('logininfo');
                    //userinfo = learun.storage.get('userinfo');
                    var req = {
                        newpassword: formdata.newpassword,
                        oldpassword: formdata.oldpassword,
                        userid: userinfo.userId
                    };
                    learun.layer.loading(true);
                    // 访问后台修改密码
                    $.ajax({
                        type: "post",
                        url: config.webapi + "user/RevisePassword",
                        data: req,
                        dataType: "json",
                        success: function (res) {
                            learun.layer.loading(false);
                            if (res === null) {
                                learun.layer.warning('无法连接服务器,请检测网络！', function () { },
                                    '保存异常',
                                    '关闭');
                                return;
                            };
                            if (res.code === 200) {
                                // 表单数据保存成功，发起流程
                                learun.layer.toast(res.info);
                                learun.storage.set('logininfo', null);
                                learun.nav.go({ path: 'login', isBack: false, isHead: false });
                            } else {
                                learun.layer.warning(res.info, function () { }, '修改失败',
                                    '关闭');
                            }
                        }
                    });
                }
                else {
                    learun.layer.toast('二次输入密码不同');
                }
            });
        }
    };
    return page;
})();