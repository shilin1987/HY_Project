﻿(function () {

    var blurNum = 0;
    var timer = null;

    var questionTotal = 1;//当前第几题
    var currentQuestion = null;//当前正在回答的题目信息
    var totalScroe = 0;//当前得分
    var question = null;//存储全部题目信息
    var choiceval = null;//操作工选择的答案

    var page = {
        isScroll: true,
        init: function ($page, param) {
            $(".f-page-backbtn").remove();

            //倒计时
            var intDiff = parseInt(1800);//倒计时总秒数量
            timer = window.setInterval(function () {
                var day = 0,
                    hour = 0,
                    minute = 0,
                    second = 0;//时间默认值        
                if (intDiff > 0) {
                    day = Math.floor(intDiff / (60 * 60 * 24));
                    hour = Math.floor(intDiff / (60 * 60)) - (day * 24);
                    minute = Math.floor(intDiff / 60) - (day * 24 * 60) - (hour * 60);
                    second = Math.floor(intDiff) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60);
                }
                if (minute <= 9) minute = '0' + minute;
                if (second <= 9) second = '0' + second;
                // $('#day_show').html(day + "天");
                // $('#hour_show').html('<s id="h"></s>' + hour + '时');
                $('#minute_show').html('<s></s>' + minute + '分');
                $('#second_show').html('<s></s>' + second + '秒');
                intDiff--;

                if (intDiff == 0) {
                    if (currentQuestion.BankScore <= totalScroe) {
                        saveResult(1); //笔试通过
                    } else {
                        saveResult(-1);//笔试未通过
                    };
                }
            }, 1000);

            ///防止切屏
            document.addEventListener('visibilitychange', function () {
                // 用户离开了当前页面
                if (document.visibilityState === 'hidden') {
                    console.log("不可见：" + blurNum);
                } else if (document.visibilityState === 'visible') {// 用户打开或回到页面
                    blurNum++;
                    console.log("可见：" + blurNum);
                    if (blurNum >= 3) {
                        //debugger;

                        window.clearInterval(timer);//清理倒计时
                        // 移除监听事件
                        document.removeEventListener('visibilitychange', function () { });

                        learun.layer.toast("你已经违规3次考试结束！");
                        blurNum = 0;
                        learun.isOutLogin = true;
                        learun.storage.set('logininfo', null);
                        learun.nav.go({ path: 'login', isBack: false, isHead: false });
                        //$(window).off("beforeunload");
                        //CloseWebPage();
                    } else {
                        learun.layer.toast("考试中违规切换窗口" + blurNum + "次！");
                    }

                }
            });

            //绑定后台获取的数据,没有下拉框数据不显示
            page.bind($page, param);

        },
        bind: function ($page, param) {

            //绑定题目和答案
            var path = config.webapi + "WrittenExamination/GetWrittenExaminationQuestions";
            learun.layer.loading(true, "正在加载笔试题，请稍后");
            $.ajax({
                type: "get",
                url: path,
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
                        question = eval(res.data);
                        $.each(question, function (i, item) {
                            //第一次加载是选择题
                            if (item.QuestionTypeFlag == 1) {
                                $("#divquestion").html(questionTotal + "、" + item.Subject);
                                var answer = item.Answer.split("#");
                                $("#choiceA").html(answer[0]);
                                $("#choiceB").html(answer[1]);
                                $("#choiceC").html(answer[2]);
                                $("#choiceD").html(answer[3]);

                                currentQuestion = item;
                                question.splice(i, 1);
                                questionTotal++;
                                return false;
                            }
                        });
                        //learun.storage.set('question', res.data);
                        //learun.layer.warning(res.info, function () { }, '消息提示', '关闭');
                    } else {
                        learun.layer.warning(res.info, function () { }, '消息提示',
                            '关闭');
                    }
                }
            });

            //选择答案
            $page.find('.choice').on('tap', function () {
                //debugger;
                choiceval = $(this).attr('name');
                //选择后背景颜色处理
                $('.choice').css('background-color', '#FFFFFF');
                $(this).css("background-color", "#DADADA");
            });

            //下一题
            $page.find('#nextQuestion').on('tap', function () {
                if (question.length == 0) {
                    learun.layer.confirm('笔试已结束是否交卷', function (_index) {
                        if (_index == 1) {
                            if (currentQuestion.BankScore <= totalScroe) {
                                saveResult(1);
                                //笔试通过，写入操作流程表中

                            } else {
                                saveResult(-1);
                            };
                        }
                    }, '华羿提示', ['否', '是']);
                } else {
                    //如果是填空题，需要获取输入答案
                    if (currentQuestion.QuestionTypeFlag == 2) {
                        choiceval = $("#txtanswer").val();
                    }

                    //分数累加
                    if (currentQuestion.RightKey == choiceval) {
                        totalScroe += currentQuestion.Score;
                    };
                    //切题
                    $.each(question, function (i, item) {
                        //加载选择题
                        if (questionTotal <= 2) {
                            if (item.QuestionTypeFlag == 1) {
                                $("#divquestion").html(questionTotal + "、" + item.Subject);
                                var answer = item.Answer.split("#");
                                $("#choiceA").html(answer[0]);
                                $("#choiceB").html(answer[1]);
                                $("#choiceC").html(answer[2]);
                                $("#choiceD").html(answer[3]);

                                currentQuestion = item;
                                question.splice(i, 1);
                                questionTotal++;
                                return false;
                            }
                        }
                        //加载填空题
                        else if (2 < questionTotal && questionTotal <= 5) {

                            $("#txtanswer").val("");
                            //选择题和填空题切换
                            $("#choicequestion").css("display", "none");
                            $("#Completion").css("display", "block");
                            //填空题
                            if (item.QuestionTypeFlag == 2) {
                                $("#divquestion").html(questionTotal + "、" + item.Subject);
                                currentQuestion = item;
                                question.splice(i, 1);
                                questionTotal++;
                                return false;
                            }
                        } else {
                            learun.layer.toast("加载题目超过限制自动交卷");
                            if (currentQuestion.BankScore <= totalScroe) {
                                saveResult(1);
                                //笔试通过，写入操作流程表中
                            } else {
                                saveResult(-1);
                            };
                        }
                    });
                }
            });

            //交卷
            $page.find('#saveIma').on('tap', function () {
                learun.layer.confirm('确定交卷', function (_index) {
                    if (_index == 1) {
                        if (currentQuestion.BankScore <= totalScroe) {
                            saveResult(1);
                        } else {
                            saveResult(-1);
                        };
                    }
                }, '华羿提示', ['否', '是']);
            });

            ///提交考试结果
            function saveResult(wresult) {
                var loginaccount = learun.storage.get('logininfo');//获取应聘者登录信息

                var path = config.webapi + "WrittenExamination/SaveResult";
                learun.layer.loading(true, "正在保存笔试结果，请稍后");

                $.ajax({
                    type: "post",
                    url: path,
                    data: { wresult: wresult, candidatesId: loginaccount.token },
                    dataType: "json",
                    success: function (res) {
                        learun.layer.loading(false);
                        if (res === null) {
                            learun.layer.warning('无法连接服务器,请检测网络！', function () { },
                                '消息提示',
                                '关闭');
                            return;
                        };
                        blurNum = 0;
                        window.clearInterval(timer);//清理倒计时
                        // 移除监听事件
                        document.removeEventListener('visibilitychange', function () { });
                        var returninfo = wresult == 1 ? "恭喜您笔试通过,请重新登录进行信息完善" : "您笔试未通过";

                        learun.layer.toast(returninfo + res.info);
                        //if (res.code === 200) {
                        //    learun.layer.toast(returninfo +"请进行招聘下一环节");
                        //    //learun.layer.warning("恭喜您已通过笔试,请进行招聘下一环节", function () { }, '消息提示',
                        //    //    '关闭');
                        //} else {
                        //    //笔试未通过，结果写入操作流程表中
                        //    learun.layer.toast(res.info);
                        //    //learun.layer.warning("您未通过笔试，请联系工作人员", function () {}, '消息提示',
                        //    //    '关闭');
                        //};

                        learun.isOutLogin = true;
                        learun.storage.set('logininfo', null);
                        learun.nav.go({ path: 'login', isBack: false, isHead: false });
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        /*错误信息处理*/
                        //alert("进入error---");
                        //alert("状态码：" + xhr.status);
                        //alert("状态:" + xhr.readyState);//当前状态,0-未初始化，1-正在载入，2-已经载入，3-数据进行交互，4-完成。
                        //alert("错误信息:" + xhr.statusText);
                        //alert("返回响应信息：" + xhr.responseText);//这里是详细的信息
                        //alert("请求状态：" + textStatus);
                        //alert(errorThrown);
                        //alert("请求失败");
                        learun.layer.warning(xhr.responseText, function () { }, '消息提示',
                            '关闭');
                    }
                });
            }
        },
    };
    return page;
})();