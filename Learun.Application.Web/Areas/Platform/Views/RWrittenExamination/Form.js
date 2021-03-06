/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-12-31 10:54
 * 描  述：RWrittenExamination
 */
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var selectedRow = learun.frameTab.currentIframe().selectedRow;
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {

            $('#OperationStatus').lrDataItemSelect({ code: 'IsEnd' });
            $('#OperationStatus').lrselectSet("1");
            // 员工
           /* $('#F_CandidatesID').lrDataSourceSelect({ code: 'newUser', value: 'f_userid', text: 'f_realname' });*/
            //题库
            $('#F_WrittenTestQuestionBankId').lrDataSourceSelect({ code: 'testPaper', value: 'f_id', text: 'f_testpapername' });
        },
        initData: function () {
            if (!!selectedRow) {
                $('#form').lrSetFormData(selectedRow);
            }
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var postData = $('#form').lrGetFormData();
        $.lrSaveForm(top.$.rootUrl + '/Platform/RWrittenExamination/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };

    page.init();
}
