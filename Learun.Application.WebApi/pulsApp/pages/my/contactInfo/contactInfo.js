(function() {
	var path = config.webapi;
	var userinfo = learun.storage.get('userinfo');
	var page = {
		isScroll: true,
		init: function($page, param) {

			// 性别
			$page.find('#F_Gender').lrpicker({
				placeholder: '请选择(必填)',
				data: genderData
			});
			// 证件类型
			$page.find('#F_DocumentType').lrpicker({
				placeholder: '请选择(必填)',
				data: documentType
			});
			// 国籍
			$page.find('#F_NationAlity').lrpicker({
				placeholder: '请选择(必填)',
				data: nationAlity
			});
			// 民族
			$page.find('#F_Nation').lrpicker({
				placeholder: '请选择(必填)',
				data: nation
			});
			// 户籍性质
			$page.find('#F_RRNature').lrpicker({
				placeholder: '请选择(必填)',
				data: householdRegister
			});
			// 政治面貌
			$page.find('#F_PoliticalOutlook').lrpicker({
				placeholder: '请选择(必填)',
				data: politicalOutlook
			});
			// 婚姻状况
			$page.find('#F_MaritalStatus').lrpicker({
				placeholder: '请选择(必填)',
				data: maritalStatus
			});
			//籍贯
			$page.find('#F_NativePlace').lrpicker({
				placeholder: '请选择(必填)',
				data: cityData,
				level: 2
			});
			//入职渠道
			$page.find('#F_EntryChannel').lrpicker({
				placeholder: '请选择(必填)',
				data: entryChannel,
			});
			//学历
			$page.find('#F_Education').lrpicker({
				placeholder: '请选择(必填)',
				data: education,
			});
			//教育方式
			$page.find('#F_EducationalMode').lrpicker({
				placeholder: '请选择(必填)',
				data: educationalMode,
			});
			//外语水平
			$page.find('#F_ForeignLanguageLevel').lrpicker({
				placeholder: '请选择(必填)',
				data: englishLevel,
			});
			//是否有资格证书
			$page.find('#F_IsQualified').lrpicker({
				placeholder: '请选择(必填)',
				data: yesNo,
			});
			//紧急联系人关系
			$page.find('#F_EContactRelationship').lrpicker({
				placeholder: '请选择(必填)',
				data: kinship,
			});
			// -------------------日期-----------------------
			//证件日期开始
			$page.find('#F_IDCardStartDate').lrdate({
				type: 'date'
			});
			//证件日期结束
			$page.find('#F_IDCardEndDate').lrdate({
				type: 'date'
			});
			//入职日期
			$page.find('#F_Entrydate').lrdate({
				type: 'date'
			});
			//入职集团日期
			$page.find('#F_JoiningGroupDate').lrdate({
				type: 'date'
			});
			//入学时间
			$page.find('#F_EducationStartDate').lrdate({
				type: 'date'
			});
			//毕业时间
			$page.find('#F_EducationEndDate').lrdate({
				type: 'date'
			});
			//证书获取日期
			$page.find('#F_GetTime').lrdate({
				type: 'date'
			});
			//绑定后台获取的数据,没有下拉框数据不显示
			page.bind($page, param);
			//保存
			$page.find('#saveUser').on('tap', function() {

				if (!$('#userform').lrformValid()) {
					$('#F_Age').focus();
					return false;
				};
				///证件类型验证
				var documentType = $('#F_DocumentType').text();
				var idCard = $('#F_IDCard').val();
				if (documentType == '身份证') {
					//身份证验证
					if (idCard.length == 18) {
						var idCard_string = JSON.stringify(idCard);
						var spstr = idCard_string.split("");
						var x = spstr[spstr.length - 2];
						console.log(spstr)
						if (x === "x") {
							return learun.layer.warning('身份证号最后一位X为大写！', function() {}, '消息提示',
								'关闭');
						}
						var reg = new RegExp(/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$/);
						var arrSplit = idCard.match(reg); //检查生日日期是否正确，value就是身份证号
						if (!arrSplit) {
							return learun.layer.warning('身份证号格式有问题，请重新输入！', function() {}, '消息提示',
								'关闭');
						}
						var dtmBirth = new Date(arrSplit[2] + "/" + arrSplit[3] + "/" + arrSplit[
							4]);
						var bGoodDay;
						bGoodDay = (dtmBirth.getFullYear() == Number(arrSplit[2])) && ((dtmBirth
							.getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() ==
							Number(arrSplit[4]));
						if (!bGoodDay) {
							return learun.layer.warning('身份证号中的出生日期不正确！', function() {}, '消息提示',
								'关闭');
						} else {
							//检验18位身份证的校验码是否正确。 //校验位按照ISO 7064:1983.MOD 11-2的规定生成，X可以认为是数字10。
							var valnum;
							var arrInt = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4,
								2);
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
				} else {
					//护照编号验证
					if (!idCard || !/^((1[45]\d{7})|(G\d{8})|(P\d{7})|(S\d{7,8}))?$/.test(idCard)) {
						return learun.layer.warning('护照号码格式错误，请重新输入！', function() {}, '消息提示',
							'关闭');
					}
				}

				//证件开始过期日期验证
				var startDate = new Date($('#F_IDCardStartDate').val().replace("-", "/").replace(
					"-", "/"));
				var endDate = new Date($('#F_IDCardEndDate').val().replace("-", "/").replace("-",
					"/"));
				if (endDate < startDate) {
					return learun.layer.warning('开始时间不能大于结束日期！', function() {}, '消息提示', '关闭');
				}

				//手机号码验证
				var mobile = $('#F_Mobile').val();
				if (!(/^1[3456789]\d{9}$/.test(mobile))) {
					return learun.layer.warning('请输入正确手机号码！', function() {}, '消息提示', '关闭');
				};
				mobile = $('#F_EContactNumber').val();
				if (!(/^1[3456789]\d{9}$/.test(mobile))) {
					return learun.layer.warning('请输入正确联系人手机号码！', function() {}, '消息提示', '关闭');
				};

				//入学和毕业日期验证
				startDate = new Date($('#F_EducationStartDate').val().replace("-", "/").replace("-",
					"/"));
				endDate = new Date($('#F_EducationEndDate').val().replace("-", "/").replace("-",
					"/"));
				if (endDate < startDate) {
					return learun.layer.warning('入学时间不能大于毕业时间！', function() {}, '消息提示', '关闭');
				}

				//获取毕业证日期
				var getDate = new Date($('#F_GetTime').val().replace("-", "/").replace("-", "/"));
				if (getDate < startDate) {
					return learun.layer.warning('毕业证获取时间不能小于入学时间！', function() {}, '消息提示', '关闭');
				}

				//保存完善资料
				var data = {
					F_UserId: userinfo.baseinfo.userId,
					F_Age: $('#F_Age').val(),
					F_Gender: $('#F_Gender').val(),
					F_DocumentType: $('#F_DocumentType').val(),
					F_IDCard: $('#F_IDCard').val(),
					F_IDCardStartDate: $('#F_IDCardStartDate').val(),
					F_IDCardEndDate: $('#F_IDCardEndDate').val(),
					F_NationAlity: $('#F_NationAlity').val(),
					F_Nation: $('#F_Nation').val(),
					F_RRNature: $('#F_RRNature').val(),
					F_Mobile: $('#F_Mobile').val(),
					F_PoliticalOutlook: $('#F_PoliticalOutlook').val(),
					F_MaritalStatus: $('#F_MaritalStatus').val(),
					F_NativePlace: $('#F_NativePlace').val(),
					F_BankCardNumber: $('#F_BankCardNumber').val(),
					F_BankDeposit: $('#F_BankDeposit').val(),
					F_PostId: $('#F_PostId').val(),
					F_Entrydate: $('#F_Entrydate').val(),
					F_JoiningGroupDate: $('#F_JoiningGroupDate').val(),
					F_EntryChannel: $('#F_EntryChannel').val(),
					F_Education: $('#F_Education').val(),
					F_GraduationUniversitie: $('#F_GraduationUniversitie').val(),
					F_MajorStudied: $('#F_MajorStudied').val(),
					F_EducationStartDate: $('#F_EducationStartDate').val(),
					F_EducationEndDate: $('#F_EducationEndDate').val(),
					F_EducationalMode: $('#F_EducationalMode').val(),
					F_ForeignLanguageLevel: $('#F_ForeignLanguageLevel').val(),
					F_IsQualified: $('#F_IsQualified').val(),
					F_QualificationName: $('#F_QualificationName').val(),
					F_GetTime: $('#F_GetTime').val(),
					F_IDCardAddress: $('#F_IDCardAddress').val(),
					F_PermanentAddress: $('#F_PermanentAddress').val(),
					F_ResidentialAddress: $('#F_ResidentialAddress').val(),
					F_CurrentAddress: $('#F_CurrentAddress').val(),
					F_EmergencyContact: $('#F_EmergencyContact').val(),
					F_EContactRelationship: $('#F_EContactRelationship').val(),
					F_EContactNumber: $('#F_EContactNumber').val(),
					F_ContactAddress: $('#F_ContactAddress').val(),
				};
				var postdata = {
					token: userinfo.baseinfo.token,
					loginMark: learun.deviceId(), // 正式请换用设备号
					data: JSON.stringify(data)
				};
				learun.layer.loading(true, "正在提交，请稍后");
				learun.http.post(path + "learun/adms/user/InformationPerfection", postdata,
					function(res) {
						learun.layer.loading(false);
						if (res === null) {
							learun.layer.warning('无法连接服务器,请检测网络！', function() {}, '消息提示', '关闭');
							return;
						}
						debugger;
						learun.layer.toast(res.info);
					});
			});
		},
		bind: function($page, param) {
			var paramdata = {
				token: userinfo.baseinfo.token,
				loginMark: learun.deviceId(), // 正式请换用设备号
			};
			//获取岗位信息
			learun.http.get(path + "learun/adms/post/postlist", paramdata, function(res) {
				if (res === null) {
					learun.layer.warning('无法连接服务器,请检测网络！', function() {}, '消息提示', '关闭');
					return;
				}
				if (res.code === 200) {
					//绑定岗位
					$page.find('#F_PostId').lrpicker({
						placeholder: '请选择(必填)',
						data: res.data,
					});
				}
			});
		},
	};
	return page;
})();
