(function() {
	var page = {
		headColor: '#ffffff',
		init: function($page, param) {

			page.bind($page, param);

			$page.find('#loginBtn').on('tap', function() {
				var account = $('#F_Mobile').val();
				var password = $('#F_VerificationCode').val();

				if (account === "") {
					learun.layer.warning('请输入手机号码！', function() {}, '消息提示', '关闭');
				} else if (password === "") {
					learun.layer.warning('请输入验证码！', function() {}, '消息提示', '关闭');
				} else {
					if(!(/^1[3456789]\d{9}$/.test(account))){
						return learun.layer.warning('请输入正确手机号码！', function() {}, '消息提示', '关闭');
					}
					var data = {
						username: account,
						password: password
					};
					var postdata = {
						token: '',
						loginMark: learun.deviceId(), // 正式请换用设备号
						data: JSON.stringify(data)
					};
					var path = config.webapi;
					learun.layer.loading(true, "正在登录，请稍后");
					learun.http.post(path + "learun/adms/user/plogin", postdata, function(res) {
						learun.layer.loading(false);
						if (res === null) {
							learun.layer.warning('无法连接服务器,请检测网络！', function() {}, '消息提示',
								'关闭');
							return;
						}

						if (res.code === 200) {
							var logininfo = {
								account: account,
								token: res.data.baseinfo.token,
								date: learun.date.format(new Date(),
									'yyyy-MM-dd hh:mm:ss')
							};
							learun.storage.set('logininfo', logininfo);
							learun.storage.set('userinfo', res.data);
							$('#F_Mobile').val('');
							$('#F_VerificationCode').val('');
							learun.tab.go('workspace');
						} else {
							learun.layer.warning(res.info, function() {}, '消息提示', '关闭');
						}
					});
				}
			});
		},
		bind: function($page, param) {

			// 点击获取验证码操作
			$page.find('#vercodeBtn').on('tap', function() {
				var account = $('#F_Mobile').val();
				if (account === "") {
					return learun.layer.warning('请输入手机号！', function() {}, '消息提示', '关闭');
				}
				if(!(/^1[3456789]\d{9}$/.test(account))){
					return learun.layer.warning('请输入正确手机号码！', function() {}, '消息提示', '关闭');
				}
				//避免多次点击
				if ($('#vercodeBtn').attr('disabled') != null) {
					return false;
				}
				let count = 60;

				const countDown = setInterval(() => {
					//learun.layer.warning('777', function () { }, '消息提示', '关闭');
					if (count === 0) {
						$('#vercodeBtn').text('重新发送').removeAttr('disabled');
						$('#vercodeBtn').css({
							background: '#488aff',
							color: '#fff',
						});
						clearInterval(countDown);
					} else {
						$('#vercodeBtn').attr('disabled', true);
						$('#vercodeBtn').css({
							background: '#d8d8d8',
							color: '#707070',
						});
						$('#vercodeBtn').text(count + '秒后重新获取');
					}
					count--;
				}, 1000);
			});

		},
	};
	return page;
})();
