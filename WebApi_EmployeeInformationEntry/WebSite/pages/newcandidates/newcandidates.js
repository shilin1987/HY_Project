(function () {
    var candidatesresult = null;
    var candidatesInfo = null;

    var page = {
        isScroll: true,
        init: function ($page) {
            load();
            $page.find('#outloginbtn').on('tap', function () {
                learun.layer.confirm('确定要退出账号?', function (_index) {
                    if (_index === '1') {
                        learun.isOutLogin = true;
                        learun.storage.set('logininfo', null);
                        learun.nav.go({ path: 'login', isBack: false, isHead: false });
                    }
                }, '', ['取消', '退出']);
            });

            candidatesresult = learun.storage.get('candidatesresult');//获取应聘者节点结果

            $page.find('#candidates').on('tap', function () {
                //跳转页面
                learun.nav.go({
                    path: 'newcandidates/candidates',
                    title: "常见员工招聘、培训问题解答"
                });
            });
            $page.find('#reportnotice').on('tap', function () {
                //跳转页面
                learun.nav.go({
                    path: 'newcandidates/reportnotice',
                    title: "报到须知"
                });
            });
            $page.find('#mynode').on('tap', function () {
                //跳转页面
                learun.nav.go({
                    path: 'newcandidates/mynode',
                    title: "我的应聘节点"
                });
            });
            $page.find('#mywrittenexamination').on('tap', function () {
                if (candidatesresult.info.indexOf("笔试") != -1) {
                    if (candidatesresult.state == 1) {
                        //跳转页面
                        learun.nav.go({
                            path: 'newcandidates/writtenexamination',
                            title: "笔试"
                        });
                    } else {
                        learun.layer.toast("您笔试未通过,请联系工作人员");
                    }
                } else {
                    learun.layer.toast(candidatesresult.info);
                }
            });
            $page.find('#myInformationperfection').on('tap', function () {
                //跳转页面
                learun.nav.go({
                    path: 'newcandidates/Informationperfection',
                    title: "作业员基础信息完善"
                });
            });
            $page.find('#myIDPhoto').on('tap', function () {
                //跳转页面
                if (candidatesresult.info.indexOf("上传证件照") != -1) {
                    if (candidatesresult.state == -1) {
                        learun.layer.toast("您报到信息未上传成功,请重新上传");
                    }
                    ////跳转页面
                    //learun.nav.go({
                    //    path: 'newcandidates/pictureupload',
                    //    title: "报到信息上传"
                    //});

                    candidatesInfo = learun.storage.get('logininfo');
                    var configSendUrl = config.webapi;
                    //?name="+name+"&age="+age;
                    window.location.href = 'pages/newcandidates/pictureupload/pictureupload.html' + "?mobile=" + candidatesInfo.account + "&configSendUrl=" + configSendUrl;

                } else {
                    learun.layer.toast(candidatesresult.info);
                }

            });
            $page.find('#abouthuayi').on('tap', function () {
                //跳转页面
                learun.nav.go({
                    path: 'newcandidates/abouthuayi',
                    title: "关于华羿"
                });
            });
            $page.find('#changepassword').on('tap', function () {
                //跳转页面
                learun.nav.go({
                    path: 'my/modifypassword',
                    title: "修改密码"
                });
            });
        },
        reload: function ($page, pageinfo) {
            // 移除监听事件
            document.removeEventListener('visibilitychange', function () { });
            load();
        }
    };

    return page;

    //初始化加载菜单信息
    function load() {
        candidatesInfo = learun.storage.get('logininfo');//获取应聘者账号信息
        //每次进入这个页面更新菜单信息
        var path = config.webapi + "Menu/ProcessLoad";
        learun.layer.loading(true, "正在加载菜单信息，请稍后");
        $.ajax({
            type: "post",
            url: path,
            data: {
                userId: candidatesInfo.userId,
                loginMark: learun.deviceId()
            },
            dataType: "json",
            success: function (res) {
                learun.layer.loading(false);
                if (res === null) {
                    learun.layer.warning('无法连接服务器,请检测网络！', function () { },
                        '消息提示',
                        '关闭');
                    return;
                }
                if (res.code === 200) {
                    candidatesresult = {
                        info: res.data.info,
                        state: res.data.AuxiliaryField,
                    };
                    learun.storage.set('candidatesresult', candidatesresult);
                } else {
                    learun.layer.warning(res.info, function () {
                        learun.isOutLogin = true;
                        learun.storage.set('logininfo', null);
                        learun.nav.go({ path: 'login', isBack: false, isHead: false });
                    }, '消息提示',
                        '关闭');
                }
            }
        });
    }
})();