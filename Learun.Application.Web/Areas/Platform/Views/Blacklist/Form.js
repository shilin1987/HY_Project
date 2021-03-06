
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
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/Platform/Blacklist/GetFormData?keyValue=' + keyValue, function (data) {
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
        var idCard = $('#F_IDCard').val();
        if (!$('body').lrValidform()) {
            return false;
        }
        //身份证校验
        if (idCard.length == 18) {
            var idCard_string = JSON.stringify(idCard);
            var spstr = idCard_string.split("");
            var x = spstr[spstr.length - 2];
            console.log(spstr)
            if (x === "x") {
                return alert('身份证号最后一位X为大写！',
                    function () { }, '消息提示', '关闭');
            }
            var reg = new RegExp(/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$/);
            var arrSplit = idCard.match(reg); //检查生日日期是否正确，value就是身份证号
            if (!arrSplit) {
                return alert('身份证号格式有问题，请重新输入！',
                    function () { }, '消息提示', '关闭');
            }
            var dtmBirth = new Date(arrSplit[2] + "/" + arrSplit[3] + "/" + arrSplit[4]);
            var bGoodDay;
            bGoodDay = (dtmBirth.getFullYear() == Number(arrSplit[2])) && ((dtmBirth.getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() == Number(arrSplit[4]));
            if (!bGoodDay) {
                return alert('身份证号中的出生日期不正确！',
                    function () { }, '消息提示', '关闭');
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
                    return alert('18位身份证的校验码不正确！应该为：' + valnum,
                        function () { }, '消息提示', '关闭');
                }
            }
        }
        else {
            return alert('身份证号码长度应为18位!',
                function () { }, '消息提示', '关闭');
        };
        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/Platform/Blacklist/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
  
}

