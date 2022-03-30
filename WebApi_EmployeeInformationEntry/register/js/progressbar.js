/*
 * 版 本 Learun-Mobile V2.0.0 华羿敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海华羿信息技术有限公司
 * 创建人：华羿-前端开发组
 * 日 期：2017.12.15
 * 描 述：华羿移动端框架 进度条插件
 */
(function ($, learun, fui, window) {
    "use strict";
    $.fn.progressSet = function (value) {
        if (value === undefined || value === null || value === "") {
            return;
        }
        var _style = 'transform: translate3d('+(value - 100)+'%, 0px, 0px);';
        $(this).find('span').attr('style', _style);
    };

})(window.jQuery, window.lrmui, window.fui, window);