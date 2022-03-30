/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-11-30 09:14
 * 描  述：上岗资格认证表
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var selectedRow = learun.frameTab.currentIframe().selectedRow;
    var page = {
        init: function () {
            page.initData();
        },
        bind: function () {

           
        },
        initData: function () {
            if (!!selectedRow) {
                $('#form').lrSetFormData(selectedRow);
            }
            $("#F_EnCode").bind("keyup", function (e) {
                // 兼容FF和IE和Opera
                var theEvent = e || window.event;
                var code = theEvent.keyCode || theEvent.which || theEvent.charCode;
                if (code == 13) {
                    var keyValue = $('#F_EnCode').val();
                    //$.lrSaveForm(top.$.rootUrl + '/Platform/WL_NormalShift/GetUserList?F_EnCode=' + keyValue,function (res) {
                    //    // 保存成功后才回调
                    //    debugger;
                    //    alert(111);
                    //    console.log(res);
                    //    if (res.code == 200) {
                    //        draftId = res.data;
                    //    }
                    //}, true);
                    $.ajax({
                        url: top.$.rootUrl + '/Platform/WL_NormalShift/GetUserList?F_EnCode=' + keyValue,
                        type: "post",
                        cache: false,
                        dataType:"json",
                        success: function (data) {
                            if (data.code == 200) {
                                var dataObj = data.data[0];

                                $('#F_RealName').val(dataObj.F_RealName);
                                $('#F_Gender').val(dataObj.F_Gender);
                                $('#F_DepartmentName').val(dataObj.F_SecondaryOrganization);
                                $('#F_FourLevelOrganization').val(dataObj.F_FourLevelOrganization);
                                $('#F_Education').val(dataObj.F_Education);
                                $('#F_AppointmentDate').val(dataObj.F_DateHoldingPost);
                            } else {
                                learun.alert.error(data.data.info);
                            }
                        },
                        error: function (e) {
                            alert("员工编号不存在");
                        }
                    });
                }
            });
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#SRform').lrValidform()) {
            return false;
        }
        var keyValue = $('#F_EnCode').val();
        var postData = $('#SRform').lrGetFormData();
        $.lrSaveForm(top.$.rootUrl + '/Platform/WL_NormalShift/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
