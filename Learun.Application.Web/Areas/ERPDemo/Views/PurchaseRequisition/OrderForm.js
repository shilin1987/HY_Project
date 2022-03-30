﻿/* * 版 本 Learun-ADMS V7.0.6 华羿软件开发平台(http://www.learun.cn)
 * Copyright (c) 2013-2020 上海华羿信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-09-25 13:15
 * 描  述：采购申请
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
            $('#F_PurchaseType').lrDataItemSelect({ code: 'menuTrage' });
            $('#F_Appler').lrDataSourceSelect({ code: 'userdata',value: 'f_userid',text: 'f_realname' });
            $('#F_Department').lrDataSourceSelect({ code: 'company', value: 'f_companyid', text: 'f_shortname' });
            $('#F_Purchaser').lrDataSourceSelect({ code: 'userdata', value: 'f_userid', text: 'f_realname' });
            $('#F_PaymentType').lrDataItemSelect({ code: 'Client_PaymentMode' });
            $('#F_File').lrUploader();
            $('#LR_ERP_ProductInfo').jfGrid({
                headData: [
                    {
                        label: '商品编号', name: 'F_Code', width:100, align: 'left'
                        ,edit:{
                            type:'layer',
                            change: function (data, rownum, selectData) {
                                data.F_Id = selectData.f_id;
                                data.F_Code = selectData.f_code;
                                data.F_Name = selectData.f_name;
                                data.F_BarCode = selectData.f_barcode;
                                data.F_Place = selectData.f_place;
                                data.F_Specification = selectData.f_specification;
                                data.F_Type = selectData.f_type;
                                data.F_Number = selectData.f_number;
                                data.F_Unit = selectData.f_unit;
                                data.F_Count = selectData.f_count;
                                data.F_Price = selectData.f_price;
                                data.F_Amount = selectData.f_amount;
                                data.F_Status = selectData.f_status;
                                data.F_ModifyDate = selectData.f_modifydate;
                                data.F_CreateDate = selectData.f_createdate;
                                data.F_Description = selectData.f_description;
                                data.F_EnabledMark = selectData.f_enabledmark;
                                data.F_DeleteMark = selectData.f_deletemark;
                                $('#LR_ERP_ProductInfo').jfGridSet('updateRow', rownum);
                            },
                            op: {
                                width: 600,
                                height: 400,
                                colData: [
                                    { label: "F_Id", name: "f_id", width: 100, align: "left" },
                                    { label: "商品编号", name: "f_code", width: 100, align: "left" },
                                    { label: "商品名称", name: "f_name", width: 100, align: "left" },
                                    { label: "条码", name: "f_barcode", width: 100, align: "left" },
                                    { label: "产地", name: "f_place", width: 100, align: "left" },
                                    { label: "规格", name: "f_specification", width: 100, align: "left" },
                                    { label: "型号", name: "f_type", width: 100, align: "left" },
                                    { label: "批次号", name: "f_number", width: 100, align: "left" },
                                    { label: "单位", name: "f_unit", width: 100, align: "left" },
                                    { label: "数量", name: "f_count", width: 100, align: "left" },
                                    { label: "单价", name: "f_price", width: 100, align: "left" },
                                    { label: "金额", name: "f_amount", width: 100, align: "left" },
                                    { label: "状态", name: "f_status", width: 100, align: "left" },
                                    { label: "修改日期", name: "f_modifydate", width: 100, align: "left" },
                                    { label: "创建日期", name: "f_createdate", width: 100, align: "left" },
                                    { label: "备注", name: "f_description", width: 100, align: "left" },
                                    { label: "禁用标志", name: "f_enabledmark", width: 100, align: "left" },
                                    { label: "删除标志", name: "f_deletemark", width: 100, align: "left" },
                                ],
                                url: top.$.rootUrl + '/LR_SystemModule/DataSource/GetDataTable',
                                param: { code: 'ProductInfo'
}                             }
                        }
                    },
                    {
                        label: '商品名称', name: 'F_Name', width:100, align: 'left'                    },
                    {
                        label: '条码', name: 'F_BarCode', width:100, align: 'left'                    },
                    {
                        label: '产地', name: 'F_Place', width:100, align: 'left'                    },
                    {
                        label: '规格', name: 'F_Specification', width:100, align: 'left'                    },
                    {
                        label: '型号', name: 'F_Type', width:100, align: 'left'                    },
                    {
                        label: '批次号', name: 'F_Number', width:100, align: 'left'                    },
                    {
                        label: '单位', name: 'F_Unit', width:100, align: 'left'                    },
                    {
                        label: '数量', name: 'F_Count', width: 100, align: 'left'
                        , edit: {
                            type: 'input',
                            change: function (row, rownum) {
                                row.F_Amount = parseInt(parseFloat(row.F_Price || '0') * parseFloat(row.F_Count || '0'));
                                $('#LR_ERP_ProductInfo').jfGridSet('updateRow', rownum);
                            },
                        }
                    },
                    {
                        label: '单价', name: 'F_Price', width: 100, align: 'left'
                        , edit: {
                            type: 'input',
                            change: function (row, rownum) {
                                row.F_Amount = parseInt(parseFloat(row.F_Price || '0') * parseFloat(row.F_Count || '0'));
                                $('#LR_ERP_ProductInfo').jfGridSet('updateRow', rownum);
                            },
                        }
                    },
                    {
                        label: '金额', name: 'F_Amount', width: 100, align: 'left', statistics: true
                    },
                ],
                isEdit: true,
                height: 200
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/ERPDemo/PurchaseRequisition/GetFormData?keyValue=' + keyValue, function (data) {
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
        if (!$('body').lrValidform()) {
            return false;
        }
        $('#F_PRId').val(keyValue);
        var postData = {};
        postData.strEntity = JSON.stringify($('[data-table="LR_ERP_PurchaseRequisition"]').lrGetFormData());
        postData.strlR_ERP_PurchaseOrderDetailList = JSON.stringify($('#LR_ERP_ProductInfo').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/ERPDemo/PurchaseOrder/SaveForm', postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
