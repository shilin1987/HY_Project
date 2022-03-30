/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-06-10 11:29
 * 描  述：标准工资维护
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

            //计算公式初始化只读
            $("#F_Formula").attr('readonly', true);
        },
        bind: function () {
            $('#F_ItemId').lrDataSourceSelect({ code: 'IncomePay', value: 'f_itemid', text: 'f_item' });
            $('#F_ParentItemId').lrDataSourceSelect({ code: 'IncomePay', value: 'f_itemid', text: 'f_item' });
            $('#parentItem').lrDataSourceSelect({ code: 'IncomePay', value: 'f_itemid', text: 'f_item' });
            $('#childrenItem').lrDataSourceSelect({ code: 'IncomePay', value: 'f_itemid', text: 'f_item' });
            $('#formula').lrDataItemSelect({ code: 'CalculationFormula' });

            $('#F_IsFixedCost').lrRadioCheckbox({
                type: 'radio',
                code: 'IsEnd',
            });

            // 组合表达式
            $('#plusitem').on('click', function () {
                //是否固定费用
                var fixedcost = $('input:radio[name="F_IsFixedCost"]:checked').val();
                if (fixedcost != "0") {
                    learun.alert.warning('请选择固定费用为"否"');
                    return false;
                }

                //计算公式是否为空验证并给表达式赋值
                if ($("#parentItem div").html() == "==请选择==" || $("#formula div").html() == "==请选择==") {
                    learun.alert.warning('请选择计算(父)项目/计算公式');
                    return false;
                } else {
                    if ($("#childrenItem div").html() == "==请选择==" && $("#calculatedValue").val() == "") {
                        learun.alert.warning('请输入计算(子)项目/计算数值');
                        return false;
                    } else if ($("#childrenItem div").html() != "==请选择==" && $("#calculatedValue").val() != "") {
                        learun.alert.warning('只能选择一项(计算(子)项目/计算数值)用来计算');
                        return false;
                    } else {

                        var formula = $("#F_Formula").val();
                        //计算公式取消只读
                        $("#F_Formula").attr('readonly', false);
                        //第一次赋值
                        if ($("#F_Formula").val() == "") {
                            if ($("#childrenItem div").html() != "==请选择==") {
                                formula = $("#parentItem div").html() + "@" + $("#formula div").html() + "@" + $("#childrenItem div").html();
                            } else {
                                formula = $("#parentItem div").html() + "@" + $("#formula div").html() + "@" + $("#calculatedValue").val();
                            }
                        }
                        //组合赋值
                        else {
                            if ($("#childrenItem div").html() != "==请选择==") {
                                formula += "@" + $("#formula div").html() + "@" + $("#childrenItem div").html();
                            } else {
                                formula += "@" + $("#formula div").html() + "@" + $("#calculatedValue").val();
                            }
                        }

                        //表达式赋值
                        $("#F_Formula").val(formula);

                        //计算公式设置只读
                        $("#F_Formula").attr('readonly', true);
                    }
                }
            });
            // 清空表达式
            $('#clearformula').on('click', function () {
                $("#F_Formula").val("");
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/HR_Code/StandardWage/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
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
        if (!$('body').lrValidform()) {
            return false;
        }

        //是否固定费用
        var fixedcost = $('input:radio[name="F_IsFixedCost"]:checked').val();
        if (fixedcost == "undefined") {
            learun.alert.warning('请选择是否固定费用');
            return false;
        }
        else if (fixedcost == "0") {
            var formula = $("#F_Formula").val();
            if (formula == "") {
                learun.alert.warning('请输入计算表达式');
                return false;
            }
        }
        //else if (fixedcost == "1") {
        //    //费用不能为空验证.
        //    var cost = $("#F_Cost").val();
        //    if (cost == "") {
        //        learun.alert.warning('请输入项目费用');
        //        return false;
        //    }
        //}

        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/HR_Code/StandardWage/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
