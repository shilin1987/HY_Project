(function () {
    var page = {
        isScroll: true,
        init: function ($page) {

            var candidatesInfo = learun.storage.get('logininfo');//获取应聘者账号信息
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
                        //$page.find('#timeline1').ftimeline([
                        //    {
                        //        title: res.info,
                        //        people: '',
                        //        content: '',
                        //        time: ''
                        //    },

                        //]);
                        
                        if (res.data.info.indexOf("自动对比") != -1) {
                            $("#currentNodeId").attr("src","images/hy0.png");
                        }
                        else if (res.data.info.indexOf("笔试") != -1) {
                            $("#currentNodeId").attr("src", "images/hy1.png");
                        }
                        else if (res.data.info.indexOf("面试") != -1) {
                            $("#currentNodeId").attr("src", "images/xxws2.png");
                        } else if (res.data.info.indexOf("上传证件照") != -1) {
                            $("#currentNodeId").attr("src", "images/zjz1.png");
                        }
                        else if (res.data.info.indexOf("报到完成") != -1) {
                            $("#currentNodeId").attr("src", "images/all.png");
                        }

                        $("#showInfo").html(res.data.info);

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
            //learun.layer.loading(true, "正在查询，请稍后");
            //获取当前登录者流程节点
            //$("#mynodeid").html(info.info);
        }
    };


    return page;
})();