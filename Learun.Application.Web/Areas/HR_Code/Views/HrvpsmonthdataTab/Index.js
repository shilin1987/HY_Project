/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2021-06-10 13:48
 * 描  述：菜价补贴月数据
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
            }, 360, 400);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            //  导出
            $('#lr_emport').on('click', function () {
                $.ajax({
                    type: "get",  //提交方式  
                    url: top.$.rootUrl + '/HR_Code/HrvpsmonthdataTab/GetExportList?pagination=null&queryJson=null',//路径  
                    success: function (result) {//返回数据根据结果进行相应的处理  
                      
                        var obj = JSON.parse(result);
                        console.log("result.info" + obj.info)
                        window.location.href = obj.info;
                    }
                }); 
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/HR_Code/HrvpsmonthdataTab/GetPageList',
                headData: [
                    { label: "系统ID", name: "Oid", width: 180, align: "center",ishide: true},
                    { label: "年份", name: "Yearno", width: 100, align: "center"},
                    { label: "月份", name: "Monthno", width: 100, align: "center" },
                    { label: "员工编号", name: "User_code", width: 180, align: "center"},
                    { label: "员工姓名", name: "User_name", width: 180, align: "center"},
                    { label: "部门编号", name: "Deptid", width: 180, align: "center"},
                    { label: "部门名称", name: "Deptname", width: 180, align: "center"},
                    { label: "月早餐合计次数", name: "MonBreakfastTogether", width: 100, align: "center"},
                    { label: "月午餐合计次数", name: "MonLunchTogether", width: 100, align: "center"},
                    { label: "月晚餐合计次数", name: "MonDinnerTogether", width: 100, align: "center"},
                    { label: "月夜宵合计次数", name: "MonSupperTogether", width: 100, align: "center" },
                    { label: "补贴金额", name: "CountMoney", width: 100, align: "center" },
                    { label: "成本中心编号", name: "Cost_centerno", width: 180, align: "center"},
                    { label: "成本中心名称", name: "Cost_center", width: 180, align: "center"},
        
                ],
                mainId:'Oid',
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





