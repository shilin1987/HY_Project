(function () {
    var page = {
        isScroll: true,
        init: function ($page, param) {
            //learun.layer.popinput('请评价一下华羿框架', function (_index, _input) { }, '华羿提示', ['取消', '确定'], '性能好');
            // 学历
            $page.find('#F_Education').lrpicker({
                placeholder: '请选择(必填)',
                data: education
            });

            $page.find('#F_RecruitmentChannels').on('DOMNodeInserted', function (obj) {
                if (obj.currentTarget.innerText == "劳务") {
                    $(".Recruitment").css("display", "block");
                   /* $(".F_RecruitmentCompany").css("z-index", "1");*/
                }
                else {
                    $(".Recruitment").css("display", "none");
                }

                if (obj.currentTarget.innerText == "内部推荐") {
                    $(".Internal").css("display", "block");
                }
                else {
                    $(".Internal").css("display", "none");
                }
            });
            // 入职渠道
            $page.find('#F_RecruitmentChannels').lrpicker({
                placeholder: '<span style="color:A4ADB3;margin-left:0px;">具体详见屏幕下方<span/> &nbsp;&nbsp;&nbsp;&nbsp;   <span style="color:black">请选择(必填)<span/>  ',
                data: entryChannel
            });
            //期望入职日期
            $page.find('#F_ExpectedentryDate').lrdate({
                type: 'date'
            });

            //绑定后台获取的数据,没有下拉框数据不显示
            page.bind($page, param);
            //保存
            $page.find('#saveUser').on('tap', function () {

                if (!$('#userform').lrformValid()) {
                    return false;
                };

                //学历
                if ($('#F_Education').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择学历！', function () { }, '消息提示', '关闭');
                }

                //期望入职时间
                if ($('#F_ExpectedentryDate').text() == "请选择") {
                    return learun.layer.warning('请选择期望入职时间！', function () { }, '消息提示', '关闭');
                }
                //获取当天日期
                function getTotay() {
                    var time = new Date();
                    var year = time.getFullYear();
                    var month = time.getMonth() + 1;
                    var date = time.getDate();
                    return year + add0(month) + add0(date);
                }
                //修改月、天的格式，保持两位数显示
                function add0(m) {
                    return m < 10 ? '0' + m : m
                }
                //替换特殊字符，组合数值型年月日
                var date = parseInt($('#F_ExpectedentryDate').text().replace(/-/g, ""));
                var currentdate = parseInt(getTotay());
                //对比入职时间大小
                if (date < currentdate) {
                    return learun.layer.warning('期望入职时间不能小于当前日期！', function () { }, '消息提示', '关闭');
                }

                //入职渠道
                if ($('#F_RecruitmentChannels').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择入职渠道！', function () { }, '消息提示', '关闭');
                }

                var chanaels = $('#F_RecruitmentChannels').text();
                if (chanaels == "内部推荐") {
                    if ($('#F_InternalCompany').val() == '' || $('#F_InternalCode').val() == '' || $('#F_InternalName').val() == '') {
                        return learun.layer.warning("请输入内部推荐人编码、姓名、公司", function () { }, '消息提示', '关闭');
                    }
                }

                //入职渠道是劳务，劳务公司必填
                if (chanaels == "劳务") {
                    if ($('#F_RecruitmentCompany').val() == '') {
                        return learun.layer.warning("请输入劳务公司", function () { }, '消息提示', '关闭');
                    }
                }

                //注册账号
                var data = {
                    IdCard: $('#F_IDCard').val(),
                    Name: $('#F_RealName').val(),
                    Education: $('#F_Education').text(),
                    Mobile: $('#F_Mobile').val(),
                    VCode: $('#F_VerificationCode').val(),
                    RecruitmentChannels: $('#F_RecruitmentChannels').text(),
                    ExpectedentryDate: $('#F_ExpectedentryDate').text(),
                    InternalCode: $('#F_InternalCode').val(),
                    InternalName: $('#F_InternalName').val(),
                    InternalCompany: $('#F_InternalCompany').val(),
                    RecruitmentCompany: $('#F_RecruitmentCompany').val(),
                };
                var path = config.webapi;
                learun.layer.loading(true, "正在注册，请稍后");
                learun.http.post(path + "Registered/SaveForm", data, function (res) {
                    learun.layer.loading(false);
                    if (res === null) {
                        learun.layer.warning('无法连接服务器,请检测网络！', function () { }, '消息提示', '关闭');
                        return;
                    };
                    //注册成功后提示跳转登录页面
                    //learun.layer.toast(res.info, function () { }, '消息提示', '关闭');
                    learun.layer.warning(res.info, function () { }, '消息提示', '关闭');
                    if (res.code === 200) {
                        // $('#F_RealName').val('');
                        // $('#F_Gender').val('');
                        // $('#F_IDCard').val('');
                        // $('#F_Mobile').val('');
                        // $('#F_IsGetAccommodation').val('');

                        learun.nav.go({ path: 'login', title: "登录" });
                        //setTimeout(function () {
                        //    //跳转页面
                        //    learun.nav.go({ path: 'login', title: "登录" });
                        //}, 12000);
                    }
                });
            });
        },
        bind: function ($page, param) {

            $("#F_IDCard").blur(function () {

                //身份证验证
                var idCard = $('#F_IDCard').val();
                if (idCard.length == 18) {
                    var idCard_string = JSON.stringify(idCard);
                    var spstr = idCard_string.split("");
                    var x = spstr[spstr.length - 2];
                    console.log(spstr)
                    if (x === "x") {
                        $('#F_IDCard').focus();
                        return learun.layer.warning('身份证号最后一位X为大写！', function () { }, '消息提示', '关闭');
                    }
                    var reg = new RegExp(/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$/);
                    var arrSplit = idCard.match(reg); //检查生日日期是否正确，value就是身份证号
                    if (!arrSplit) {
                        $('#F_IDCard').focus();
                        return learun.layer.warning('身份证号格式有问题，请重新输入！', function () { }, '消息提示',
                            '关闭');
                    }
                    var dtmBirth = new Date(arrSplit[2] + "/" + arrSplit[3] + "/" + arrSplit[4]);
                    var bGoodDay;
                    bGoodDay = (dtmBirth.getFullYear() == Number(arrSplit[2])) && ((dtmBirth
                        .getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() ==
                            Number(arrSplit[4]));
                    if (!bGoodDay) {
                        $('#F_IDCard').focus();
                        return learun.layer.warning('身份证号中的出生日期不正确！', function () { }, '消息提示', '关闭');
                    } else {
                        //检验18位身份证的校验码是否正确。 //校验位按照ISO 7064:1983.MOD 11-2的规定生成，X可以认为是数字10。
                        var valnum;
                        var arrInt = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2);
                        var arrCh = new Array('1', '0', 'X', '9', '8', '7', '6', '5', '4', '3',
                            '2');
                        var nTemp = 0,
                            i;
                        for (i = 0; i < 17; i++) {
                            nTemp += idCard.substr(i, 1) * arrInt[i];
                        }
                        valnum = arrCh[nTemp % 11];
                        if (valnum != idCard.substr(17, 1)) {
                            $('#F_IDCard').focus();
                            return learun.layer.warning('18位身份证的校验码不正确！应该为：' + valnum,
                                function () { }, '消息提示', '关闭');
                        } else {
                            //获取初始化数据
                            var path = config.webapi + "Registered/InitializationUser";
                            learun.layer.loading(true, "正在验证身份信息,请稍后..");
                            $.ajax({
                                type: "post",
                                url: path,
                                data: { IdCard: $('#F_IDCard').val() },
                                dataType: "json",
                                success: function (res) {
                                    learun.layer.loading(false);
                                    if (res === null) {
                                        learun.layer.warning('无法连接服务器,请检测网络！', function () { },
                                            '消息提示',
                                            '关闭');
                                        return;
                                    };
                                    if (res.code === 200) {
                                        var user = res.data;
                                        if (user != null) {
                                            $("#F_RealName").val(user.Name);
                                            $('#F_Education').html("<div class=\"text\">" + user.Education + "</div>");
                                            $('#F_ExpectedentryDate').html("<div class=\"text\">" + user.ExpectedentryDate + "</div>");
                                            $('#F_RecruitmentChannels').html("<div class=\"text\">" + user.RecruitmentChannels + "</div>");
                                            $("#F_InternalCompany").val(user.InternalCompany);
                                            $("#F_InternalCode").val(user.InternalCode);
                                            $("#F_InternalName").val(user.InternalName);
                                            $("#F_RecruitmentCompany").val(user.RecruitmentCompany);
                                            $("#F_Mobile").val(user.Mobile);
                                        }
                                        // learun.layer.toast(res.info);
                                        // learun.tab.go('my');
                                    } else {
                                        learun.layer.warning(res.info, function () { }, '消息提示',
                                            '关闭');
                                    }
                                    $('#F_RealName').focus();
                                }
                            });
                        }
                    }
                } else {
                    $('#F_IDCard').focus();
                    return learun.layer.warning('身份证号码长度应为18位!',
                        function () { }, '消息提示', '关闭');
                };
            });

            //手机号码失焦验证
            $("#F_Mobile").blur(function () {
                var mobile = $('#F_Mobile').val();
                if (!(/^1[3456789]\d{9}$/.test(mobile))) {
                    $('#F_Mobile').focus();
                    return learun.layer.warning('请输入正确手机号码！', function () { }, '消息提示', '关闭');
                };
            });

            // 点击获取验证码操作
            $page.find('#vercodeBtn').on('tap', function () {

                var mobile = $('#F_Mobile').val();
                if (!(/^1[3456789]\d{9}$/.test(mobile))) {
                    $('#F_Mobile').focus();
                    return learun.layer.warning('请输入正确手机号码！', function () { }, '消息提示', '关闭');
                };

                var account = $('#F_Mobile').val();
                if (account === "") {
                    $('#F_Mobile').focus();
                    return learun.layer.warning('请输入手机号码！', function () { }, '消息提示', '关闭');
                }

                //避免多次点击
                if ($('#vercodeBtn').attr('disabled') != null) {
                    $('#F_VerificationCode').focus();
                    return false;
                }

                //获取验证码
                var path = config.webapi + "Registered/GetVerificationCode";
                learun.layer.loading(true, "正在获取验证码,请稍后.");
                $.ajax({
                    type: "post",
                    url: path,
                    data: { Phone: $('#F_Mobile').val() },
                    dataType: "json",
                    //async: true, 默认true
                    success: function (res) {
                        learun.layer.loading(false);
                        if (res === null) {
                            learun.layer.warning('无法连接服务器,请检测网络！', function () { },
                                '消息提示',
                                '关闭');
                            return;
                        }
                        if (res.code === 200) {
                            learun.layer.toast(res.data.info);
                            // learun.tab.go('my');
                            let count = 60;
                            const countDown = setInterval(() => {
                                //learun.layer.warning('777', function () { }, '消息提示', '关闭');
                                if (count === 0) {
                                    $('#vercodeBtn').text('重新发送').removeAttr('disabled');
                                    $('#vercodeBtn').css({
                                        background: '#488aff',
                                        color: '#fff',
                                    });
                                    clearInterval(countDown);
                                } else {
                                    $('#vercodeBtn').attr('disabled', true);
                                    $('#vercodeBtn').css({
                                        background: '#d8d8d8',
                                        color: '#707070',
                                    });
                                    $('#vercodeBtn').text(count + '秒后重新获取');
                                }
                                count--;
                            }, 1000);
                        } else {
                            learun.layer.warning(res.data.info, function () { }, '消息提示',
                                '关闭');
                        }
                        $('#F_Mobile').focus();
                    }
                });
            });
        },
    };
    return page;


})();

