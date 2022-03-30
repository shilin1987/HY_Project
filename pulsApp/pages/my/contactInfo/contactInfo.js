(function() {
	var page = {
		isScroll: true,
		init: function($page, param) {

			// 性别
			$page.find('#F_Gender').lrpicker({
				placeholder: '请选择(必填)',
				data: genderData
			});
			//籍贯
			$page.find('#F_NativePlace').lrpicker({
			    placeholder: '请选择(必填)',
			    data: cityData,
			    level: 2
			});
			//绑定后台获取的数据,没有下拉框数据不显示
			page.bind($page, param);
			//保存
			$page.find('#saveUser').on('tap', function() {
				
				if (!$('#userform').lrformValid()) {
					return false;
				};
				
				//选择框空判断
				var gender=$('#F_Gender').text()=='男'?'1':($('#F_Gender').text()=='女'?'0':'-1');
				if(gender=='-1'){
					return learun.layer.warning('请选择性别！', function() {}, '消息提示', '关闭');
				}
				var isGetAccommodation=$('#F_IsGetAccommodation').text()=='分配'?'1':($('#F_IsGetAccommodation').text()=='不分配'?'0':'-1');
				if(isGetAccommodation=='-1'){
					return learun.layer.warning('请选择是否分配住宿！', function() {}, '消息提示', '关闭');
				}
				
				//身份证验证
				var idCard = $('#F_IDCard').val();
				if (idCard.length == 18) {
					var idCard_string = JSON.stringify(idCard);
					var spstr = idCard_string.split("");
					var x = spstr[spstr.length - 2];
					console.log(spstr)
					if (x === "x") {
						return learun.layer.warning('身份证号最后一位X为大写！', function() {}, '消息提示', '关闭');
					}
					var reg = new RegExp(/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$/);
					var arrSplit = idCard.match(reg); //检查生日日期是否正确，value就是身份证号
					if (!arrSplit) {
						return learun.layer.warning('身份证号格式有问题，请重新输入！', function() {}, '消息提示',
							'关闭');
					}
					var dtmBirth = new Date(arrSplit[2] + "/" + arrSplit[3] + "/" + arrSplit[4]);
					var bGoodDay;
					bGoodDay = (dtmBirth.getFullYear() == Number(arrSplit[2])) && ((dtmBirth
						.getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() ==
						Number(arrSplit[4]));
					if (!bGoodDay) {
						return learun.layer.warning('身份证号中的出生日期不正确！', function() {}, '消息提示', '关闭');
					} else {
						//检验18位身份证的校验码是否正确。 //校验位按照ISO 7064:1983.MOD 11-2的规定生成，X可以认为是数字10。
						var valnum;
						var arrInt = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2);
						var arrCh = new Array('1', '0', 'X', '9', '8', '7', '6', '5', '4', '3',
							'2');
						var nTemp = 0,
							i;
						for (i = 0; i < 17; i++) {
							nTemp += idCard.substr(i, 1) * arrInt[i];
						}
						valnum = arrCh[nTemp % 11];
						if (valnum != idCard.substr(17, 1)) {
							return learun.layer.warning('18位身份证的校验码不正确！应该为：' + valnum,
								function() {}, '消息提示', '关闭');
						}
					}
				} else {
					return learun.layer.warning('身份证号码长度应为18位!',
						function() {}, '消息提示', '关闭');
				};
				
				//手机号码验证
				var mobile = $('#F_Mobile').val();
				if (!(/^1[3456789]\d{9}$/.test(mobile))) {
					return learun.layer.warning('请输入正确手机号码！', function() {}, '消息提示', '关闭');
				};
				
				//注册账号
				var data = {
					RealName: $('#F_RealName').val(),
					Gender: gender,
					IDCard: idCard,
					Mobile: mobile,
					VCode:$('#F_VerificationCode').val(),
					IsGetAccommodation: isGetAccommodation
				};
				var postdata = {
					token: '',
					loginMark: learun.deviceId(), // 正式请换用设备号
					data: JSON.stringify(data)
				};
				var path = config.webapi;
				learun.layer.loading(true, "正在注册，请稍后");
				learun.http.post(path + "learun/adms/user/registered", postdata, function(res) {
					learun.layer.loading(false);
					if (res === null) {
						learun.layer.warning('无法连接服务器,请检测网络！', function() {}, '消息提示', '关闭');
						return;
					}
					//注册成功后提示跳转登录页面
					learun.layer.toast(res.info);
					if (res.code === 200) {
						// $('#F_RealName').val('');
						// $('#F_Gender').val('');
						// $('#F_IDCard').val('');
						// $('#F_Mobile').val('');
						// $('#F_IsGetAccommodation').val('');
						setTimeout(function () {
						   //跳转页面
						    learun.nav.go({ path: 'login', title: "登录" });
						}, 2000);
					}
				});
			});
		},
		bind: function($page, param) {

			// 点击获取验证码操作
			$page.find('#vercodeBtn').on('tap', function() {
				var account = $('#F_Mobile').val();
				if (account === "") {
					return learun.layer.warning('请输入手机号码！', function() {}, '消息提示', '关闭');
				}
				if (!(/^1[3456789]\d{9}$/.test(account))) {
					return learun.layer.warning('请输入正确手机号码！', function() {}, '消息提示', '关闭');
				}
				//避免多次点击
				if ($('#vercodeBtn').attr('disabled') != null) {
					return false;
				}
			});
		},
	};
	return page;
})();
