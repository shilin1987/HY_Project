/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2022-02-23 14:08
 * 描  述：MB52报表
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
            //
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 340, 520);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/B2B_Code/B2B_Report_MB52/GetPageList',
                headData: [
                    { label: "客户代码", name: "CUST_CODE", width: 100, align: 'center' },
                    { label: "客户PO", name: "CUST_PO", width: 100, align: 'center' },
                    { label: "产品型号", name: "CUST_PARTIN", width: 100, align: 'center' },
                    { label: "出厂产品型号", name: "CUST_PARTOUT", width: 100, align: 'center' },
                    { label: "晶圆芯片批次", name: "WAFER_LOT_NO", width: 100, align: 'center' },
                    { label: "客户批次", name: "ZCUST_LOT", width: 100, align: 'center' },
                    { label: "封装形式", name: "PACKAGE_M", width: 100, align: 'center' },
                    { label: "库存地点", name: "LGORT", width: 100, align: 'center' },
                    { label: "BIN别", name: "BIN", width: 100, align: 'center' },
                    { label: "非限制库存", name: "CLABS", width: 100, align: 'center' },
                    { label: "中转中库存", name: "CUMLM", width: 100, align: 'center' },
                    { label: "扣押冻结库存", name: "CSPEM", width: 100, align: 'center' },
                    { label: "特殊库存标识", name: "SOBKZ", width: 100, align: 'center' },
                    { label: "内盒箱号", name: "INBOX_NO", width: 100, align: 'center' },
                    { label: "外箱箱号", name: "ZOUT_BOX", width: 100, align: 'center' },
                    { label: "收货日期", name: "ERSDA", width: 100, align: 'center' },
                    { label: "流程卡号", name: "CHILD_LOT", width: 100, align: 'center' },
                    { label: "芯片型号", name: "CUST_DEVICE", width: 100, align: 'center' },
                    { label: "入库单号", name: "RECEIPT_NO", width: 100, align: 'center' },
                    { label: "备注", name: "REMARK", width: 100, align: 'center' },
                    { label: "备注4(批次)", name: "CUST_BIN", width: 100, align: 'center' },
                    { label: "MES PartID", name: "PARTID", width: 100, align: 'center' },
                    { label: "物料编号", name: "MATNR", width: 100, align: 'center' },
                    { label: "物料描述", name: "MAKTX", width: 100, align: 'center' },
                    { label: "特殊工艺", name: "ZZGYLC", width: 100, align: 'center' },
                    { label: "包装方式", name: "PACKAGE_TYPE", width: 100, align: 'center' },
                    { label: "包装方式说明", name: "ZZBZFS_DESC", width: 100, align: 'center' },
                    { label: "封装等级", name: "ZASSY_GRADE", width: 100, align: 'center' },
                    { label: "环保等级", name: "ZEP_GRADE", width: 100, align: 'center' },
                    { label: "MES工单类型", name: "ORDER_TYPE", width: 100, align: 'center' },
                    { label: "DATE CODE", name: "DATECODE", width: 100, align: 'center' },
                    { label: "印章内容", name: "MARKING_INFO", width: 100, align: 'center' },
                    { label: "Lot ID", name: "LOTID", width: 100, align: 'center' },
                    { label: "工厂", name: "WERKS", width: 100, align: 'center' },
                    { label: "仓储地点描述 ", name: "LGOBE", width: 100, align: 'center' },
                    { label: "单位", name: "UNIT", width: 100, align: 'center' },
                    { label: "库存类型", name: "STOCK_TYPE", width: 100, align: 'center' },
                    { label: "加工类型", name: "ZZJGLX", width: 100, align: 'center' },
                    { label: "批号", name: "CHARG", width: 100, align: 'center' },
                    { label: "客户编号", name: "KUNNR", width: 100, align: 'center' },
                    { label: "VMI", name: "VMI", width: 100, align: 'center' },
                    { label: "货位", name: "ZBIN", width: 100, align: 'center' },
                    { label: "业务类型", name: "ZZBIZ_TYPE", width: 100, align: 'center' }
                ],
                mainId:'F_GUID',
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
