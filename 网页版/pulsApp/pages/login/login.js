(function() {
	var page = {
		headColor: '#ffffff',
		init: function($page) {
			$page.find('#loginBtn').on('tap', function() {
				var account = $('#account').val();
				var password = $('#password').val();

				if (account === "") {
					learun.layer.warning('请输入账号！', function() {}, '消息提示', '关闭');
				} else if (password === "") {
					learun.layer.warning('请输入密码！', function() {}, '消息提示', '关闭');
				} else {
					var path = config.webapi+ "User/Login";
					learun.layer.loading(true, "正在登录，请稍后");

					$.ajax({
						type: "post",
						url: path,
						data: {
							username: account,
							password: $.md5(password),
							loginMark: learun.deviceId()
						},
						dataType: "json",
						success: function(res) {
							learun.layer.loading(false);
							if (res === null) {
								learun.layer.warning('无法连接服务器,请检测网络！', function() {},
									'消息提示',
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
								$('#account').val('');
								$('#password').val('');
								learun.tab.go('my');
							} else {
								learun.layer.warning(res.info, function() {}, '消息提示',
									'关闭');
							}
						}
					});
					// learun.http.post(path + "User/login", postdata, function(res) {
					// 	learun.layer.loading(false);
					// 	if (res === null) {
					// 		learun.layer.warning('无法连接服务器,请检测网络！', function() {}, '消息提示',
					// 			'关闭');
					// 		return;
					// 	}

					// 	if (res.code === 200) {
					// 		var logininfo = {
					// 			account: account,
					// 			token: res.data.baseinfo.token,
					// 			date: learun.date.format(new Date(),
					// 				'yyyy-MM-dd hh:mm:ss')
					// 		};

					// 		learun.storage.set('logininfo', logininfo);
					// 		learun.storage.set('userinfo', res.data);
					// 		$('#account').val('');
					// 		$('#password').val('');
					// 		learun.tab.go('my');
					// 	} else {
					// 		learun.layer.warning(res.info, function() {}, '消息提示', '关闭');
					// 	}
					// });
				}
			});
			//手机快捷登录
			$page.find('#signInQuickly').on('tap', function() {
				//跳转页面
				learun.nav.go({
					path: 'login/phoneLogin',
					title: "登录"
				});
			});

			//注册
			$page.find('#register').on('tap', function() {
				//跳转页面
				learun.nav.go({
					path: 'Platform/Candidates',
					title: "注册"
				});
			});
		}
	};
	return page;
})();
