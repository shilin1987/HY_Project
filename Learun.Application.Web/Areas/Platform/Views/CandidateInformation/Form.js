/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-12-30 18:10
 * 描  述：应聘者信息
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_Education').lrDataItemSelect({ code: 'Education' });
            $('#F_RecruitmentChannels').lrDataItemSelect({ code: 'EntryChannel' });
            // 校验
            $('#btn_check').on('click', function () {
                var idCard = $('#F_IDCard').val();
                //身份证校验
                if (idCard.length == 18) {
                    var idCard_string = JSON.stringify(idCard);
                    var spstr = idCard_string.split("");
                    var x = spstr[spstr.length - 2];
                    console.log(spstr)
                    if (x === "x") {
                        //return alert('身份证号最后一位X为大写！',
                        //    function () { }, '消息提示', '关闭');
                        learun.alert.error('身份证号最后一位X为大写！');
                    }
                    var reg = new RegExp(/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$/);
                    var arrSplit = idCard.match(reg); //检查生日日期是否正确，value就是身份证号
                    if (!arrSplit) {
                        //return alert('身份证号格式有问题，请重新输入！',
                        //    function () { }, '消息提示', '关闭');
                        learun.alert.error('身份证号格式有问题，请重新输入');
                    }
                    var dtmBirth = new Date(arrSplit[2] + "/" + arrSplit[3] + "/" + arrSplit[4]);
                    var bGoodDay;
                    bGoodDay = (dtmBirth.getFullYear() == Number(arrSplit[2])) && ((dtmBirth.getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() == Number(arrSplit[4]));
                    if (!bGoodDay) {
                        //return alert('身份证号中的出生日期不正确！',
                        //    function () { }, '消息提示', '关闭');
                        learun.alert.error('身份证号中的出生日期不正确！');
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
                            //return alert('18位身份证的校验码不正确！应该为：' + valnum,
                            //    function () { }, '消息提示', '关闭');
                            learun.alert.error('18位身份证的校验码不正确！应该为：' + valnum);
                        }
                        $.ajax({
                            url: top.$.rootUrl + '/Platform/CandidateInformation/GetUserBlackList?F_IDCard=' + idCard,
                            type: "post",
                            cache: false,
                            dataType: "json",
                            success: function (data) {
                                if (data.code == 200) {
                                    var dataObj = data.data[0];
                                    if (dataObj == null) {
                                        //return alert('身份证号校验正常！',
                                        //    function () { }, '消息提示', '关闭');
                                        learun.alert.info('身份证号校验成功！');
                                    }
                                    else {
                                        //return alert('身份证号存在黑名单中！',
                                        //    function () { }, '消息提示', '关闭');
                                        learun.alert.error('该身份证号存在黑名单中！');
                                    }
                                } else {
                                    learun.alert.error(data.data.info);
                                }
                            },
                        });
                    }
                }
                else {
                    //return alert('身份证号码长度应为18位!',
                    //    function () { }, '消息提示', '关闭');
                    learun.alert.error('身份证号码长度应为18位!');
                };
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/Platform/CandidateInformation/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        var Mobile = $('#F_Mobile').val();
        if (!$('body').lrValidform()) {
            return false;
        }
        //手机号验证
        if (Mobile.length == 11)
        {
            var myreg = /^[1][3,4,5,6,7,8,9][0-9]{9}$/;
            if (!myreg.test(Mobile)) {
                return alert("请填写正确的手机号码");
            }
        } else {
            return alert('手机号码长度应为11位!',
                function () { }, '消息提示', '关闭');}

        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/Platform/CandidateInformation/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
