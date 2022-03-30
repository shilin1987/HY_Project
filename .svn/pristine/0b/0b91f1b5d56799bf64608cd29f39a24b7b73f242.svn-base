//防止滑动的时候触发点击事件
function tap(sprite, cb) {
    var tapStartTime = 0,
        tapEndTime = 0,
        tapTime = 300, //tap等待时间，在此事件下松开可触发方法
        tapStartClientX = 0,
        tapStartClientY = 0,
        tapEndClientX = 0,
        tapEndClientY = 0,
        tapScollHeight = 15, //水平或垂直方向移动超过15px测判定为取消（根据chrome浏览器默认的判断取消点击的移动量)
        cancleClick = false;
    $(document).on('touchstart', sprite, function () {
        tapStartTime = event.timeStamp;
        var touch = event.changedTouches[0];
        tapStartClientX = touch.clientX;
        tapStartClientY = touch.clientY;
        cancleClick = false;
    })
    $(document).on('touchmove', sprite, function () {
        var touch = event.changedTouches[0];
        tapEndClientX = touch.clientX;
        tapEndClientY = touch.clientY;
        if ((Math.abs(tapEndClientX - tapStartClientX) > tapScollHeight) || (Math.abs(tapEndClientY - tapStartClientY) > tapScollHeight)) {
            cancleClick = true;
        }
    })
    $(document).on('touchend', sprite, function () {
        var _this = $(this);
        tapEndTime = event.timeStamp;
        if (!cancleClick && (tapEndTime - tapStartTime) <= tapTime) {
            cb(_this);
        }
    })
}
tap(".userform", function (_this) {
    var rid = _this.attr("data-i");
    console.log(rid);
})