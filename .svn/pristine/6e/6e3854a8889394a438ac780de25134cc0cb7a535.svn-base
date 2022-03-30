/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-01-10 14:53
 * 描  述：新菜价补贴计算
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/HR_Code/FSVegetablePricesCalculation/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_Id');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/HR_Code/FSVegetablePricesCalculation/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            //  导出
            $('#lr_emport').on('click', function () {
                $.ajax({
                    type: "get",  //提交方式  
                    url: top.$.rootUrl + '/HR_Code/FSVegetablePricesCalculation/GetExportList?pagination=null&queryJson=null',//路径  
                    success: function (result) {//返回数据根据结果进行相应的处理  

                        var obj = JSON.parse(result);
                        console.log("result.info" + obj.info)
                        window.location.href = obj.info;
                    }
                }); 
            });
            //  月菜价补贴计算
            $('#lr_calculation').on('click', function () {
                $.ajax({
                    url: top.$.rootUrl + '/HR_Code/FSVegetablePricesCalculation/CalculateRerust',
                    type: "post",
                    dataType: "json",
                    cache: false,
                    success: function (data) {
                        if (data.code == 200) {
                            learun.alert.info("菜价补贴计算成功");
                        } else {
                            learun.alert.info(data);
                        }

                    },
                    error: function (e) {
                        //learun.alert.error("网络错误，请重试！！");
                    }
                });
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HR_Code/FSVegetablePricesCalculation/GetPageList',
                headData: [
                    { label: "员工编号", name: "F_UserId", width: 100, align: "center"},
                    { label: "员工姓名", name: "F_UserName", width: 100, align: "center"},
                    { label: "补贴年份", name: "F_Year", width: 100, align: "center"},
                    { label: "补贴月份", name: "F_Month", width: 100, align: "center"},
                    { label: "所属部门", name: "F_DeptId", width: 100, align: "center"},
                    { label: "部门名称", name: "F_DeptName", width: 100, align: "center"},
                    { label: "成本中心编号", name: "F_CostCenterno", width: 100, align: "center"},
                    { label: "成本中心名称", name: "F_CostCenterName", width: 100, align: "center"},
                    { label: "月早餐补贴次数", name: "F_MonBreakfastTogether", width: 100, align: "center"},
                    { label: "月午餐补贴次数", name: "F_MonLunchTogether", width: 100, align: "center"},
                    { label: "月晚餐补贴次数", name: "F_MonDinnerTogether", width: 100, align: "center"},
                    { label: "月夜宵补贴次数", name: "F_MonSupperTogether", width: 100, align: "center"},
                    { label: "月补贴金额合计", name: "F_CountMoney", width: 100, align: "center"},
                ],
                mainId:'F_Id',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
