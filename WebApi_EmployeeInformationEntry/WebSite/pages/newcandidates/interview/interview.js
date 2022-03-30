(function () {

    var page = {
        isScroll: true,
        init: function ($page) {
            //面试结果
            $page.find('#F_InterviewResult').lrpicker({
                //placeholder: '请选择(必填)',
                data: IsAdopt
            });

            var Interviewuser = null;
            upload($page);

            //查询
            $page.find('#selectuser').on('tap', function () {
                var keyvalue = $('#F_RealName').text();
                $.ajax({
                    url: config.webapi + 'Interview/SelectUserInfo?userid=' + keyvalue,
                    type: "post",
                    cache: false,
                    dataType: "json",
                    success: function (data) {
                        if (data.code == 200) {
                            var ObjData = JSON.parse(data.data);
                            if (ObjData[0].F_EntryChannel == null) { $('#F_EntryChannel').text(""); } else { $('#F_EntryChannel').text(ObjData[0].F_EntryChannel); }
                            if (ObjData[0].F_IDCard == null) { $('#F_IDCard').text(""); } else { $('#F_IDCard').text(ObjData[0].F_IDCard); }
                            if (ObjData[0].F_Education == null) { $('#F_Education').text(""); } else { $('#F_Education').text(ObjData[0].F_Education); }
                            if (ObjData[0].F_Mobile == null) { $('#F_Mobile').text(""); } else { $('#F_Mobile').text(ObjData[0].F_Mobile); }
                            if (ObjData[0].F_Nation == null) { $('#F_Nation').text(""); } else { $('#F_Nation').text(ObjData[0].F_Nation); }
                            if (ObjData[0].F_GraduationUniversitie == null) { $('#F_GraduationUniversitie').text(""); } else { $('#F_GraduationUniversitie').text(ObjData[0].F_GraduationUniversitie); }
                            if (ObjData[0].F_NationAlity == null) { $('#F_NationAlity').text(""); } else { $('#F_NationAlity').text(ObjData[0].F_NationAlity); }
                            if (ObjData[0].F_MajorStudied == null) { $('#F_MajorStudied').text(""); } else { $('#F_MajorStudied').text(ObjData[0].F_MajorStudied); }
                            if (ObjData[0].F_OneWorkexperience == null) { $('#F_OneWorkexperience').text(""); } else { $('#F_OneWorkexperience').text(ObjData[0].F_OneWorkexperience); }
                            if (ObjData[0].F_TwoWorkexperience == null) { $('#F_TwoWorkexperience').text(""); } else { $('#F_TwoWorkexperience').text(ObjData[0].F_TwoWorkexperience); }
                        } else {
                            learun.layer.error(data.data.info);
                        }
                    },
                    error: function (e) {
                        learun.layer.toast("异常:");
                    }
                });
            });

            //保存
            $page.find('#saveInterview').on('tap', function () {
                var keyvalue = $('#F_RealName').text();
                if (!$('#interuserform').lrformValid()) {
                    return false;
                };
                var logininfo = learun.storage.get('logininfo');
                var F_InterviewResult = $('#F_InterviewResult').text() == '通过' ? '1' : ($('#F_InterviewResult').text() == '不通过' ? '-1' : '0');
                $.ajax({
                    url: config.webapi + 'Interview/saveInterviewSave',
                    type: "post",
                    cache: false,
                    dataType: "json",
                    data: {
                        F_ModifyUserId: logininfo.account,
                        F_CandidatesID: keyvalue,
                        F_Content: $('#F_Content').val(),
                        F_InterviewResult: F_InterviewResult,
                    },
                    success: function (data) {
                        if (data.code == 200) {
                            //learun.layer.toast("面试结束！保存成功");
                            learun.layer.warning("面试结束!", function () {
                                upload($page);
                            }, '消息提示',
                                '关闭');
                            // //跳转页面
                            //learun.nav.go({
                            //     path: 'newcandidates/interview',
                            //     title: "面试"
                            // });
                        } else {
                            learun.layer.toast(data.info);
                        }
                    },
                    error: function (e) {
                        learun.layer.toast("面试异常:");
                    }
                });
                // 移除监听事件
                $(window).off('blur resize');
            });
        },
    };
    return page;

    //加载需要面试的应聘者和面试参考题目
    function upload(obj) {
        $.ajax({
            url: config.webapi + 'Interview/SelectInteriewInfo',
            type: "post",
            cache: false,
            dataType: "json",
            success: function (data) {
                if (data.code == 200) {
                    Interviewuserdate = data.data.InterviewModeleor;
                    var InterviewQuestionBank = data.data.InterviewQuestionBank;

                    obj.find('#F_RealName').lrpicker({
                        placeholder: '请选择',
                        data: Interviewuserdate,
                    });

                    obj.find('#F_RealName').lrpickerSetData(Interviewuserdate);
                    obj.find('#F_RealName').find('.text').text("请选择");

                    $('#F_EntryChannel').text("");
                    $('#F_IDCard').text("");
                    $('#F_Education').text("");
                    $('#F_Mobile').text("");
                    $('#F_Nation').text("");
                    $('#F_GraduationUniversitie').text("");
                    $('#F_NationAlity').text("");
                    $('#F_MajorStudied').text("");
                    $('#F_OneWorkexperience').text("");
                    $('#F_TwoWorkexperience').text("");

                    var _html = "";
                    $.each(InterviewQuestionBank, function (i, item) {
                        _html += "面试题目: <span>" + item.F_Question + "</span><br />";
                        _html += "参考答案: <span >" + item.F_Answer + "</span><br />";
                    });
                    $("#questionList").html(_html)
                } else {
                    learun.layer.toast(data.info);
                }
            },
            error: function (e) {
                learun.layer.toast("异常:");
            }
        });
    };
})();