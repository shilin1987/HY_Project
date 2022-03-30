(function () {
    var page = {
        init: function ($page) {
            $page.find('#dialog1').on('tap', function () {
                learun.layer.warning('欢迎使用华羿框架', function () { }, '华羿提示', '好的');
            });
            $page.find('#dialog2').on('tap', function () {
                learun.layer.confirm('华羿框架很不错', function (_index) { }, '华羿提示', ['否', '是']);
            });
            $page.find('#dialog3').on('tap', function () {
                learun.layer.popinput('请评价一下华羿框架', function (_index, _input) { }, '华羿提示', ['取消', '确定'],'性能好');
            });
            $page.find('#dialog4').on('tap', function () {
                learun.layer.toast('欢迎使用华羿框架');
            });
            $page.find('#dialog5').on('tap', function () {
                learun.layer.loading(true, '数据加载中');
                setTimeout(function () {
                    learun.layer.loading(false);
                }, 3000);
            });
        }
    };
    return page;
})();