(function () {
    var path = config.webapi;
    var userinfo = learun.storage.get('userinfo');
    var page = {
        isScroll: true,
        init: function ($page, param) {

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

            $("#F_IDCard").blur(function () {
                if ($('#F_DocumentType').text() == '身份证') {
                    var idVal = $("#F_IDCard").val();
                    if (idVal.length > 9) {
                        var year = idVal.substring(10, 6);
                        var mydate = new Date();
                        var currentYear = mydate.getFullYear();
                        var age = currentYear - year;
                        $('#F_Age').val(age);
                    }
                    //识别性别并录入
                    if (parseInt(idVal.substr(16, 1)) % 2 == 1) {
                        $('#F_Gender').html("<div class=\"text\">男</div>");
                    } else {
                        $('#F_Gender').html("<div class=\"text\">女</div>");
                    }
                }
            });

            //绑定后台获取的数据,没有下拉框数据不显示
            page.bind($page, param);
            //保存
            //下拉框html方式赋值验证无法通过；
            $page.find('#saveUser').on('tap', function () {

                ///证件类型验证
                var documentType = $('#F_DocumentType').text();
                if (documentType == "请选择(必填)") {
                    return learun.layer.warning('请选择证件类型！', function () { }, '消息提示', '关闭');
                }
                // onblur="this.v();"
                //INPUT输入框验证
                if (!$('#userform').lrformValid()) {
                    $('#F_Age').focus();
                    return false;
                };

                //性别
                if ($('#F_Gender').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择性别！', function () { }, '消息提示', '关闭');
                }

                //证件开始日期
                if ($('#F_IDCardStartDate').text() == "请选择") {
                    return learun.layer.warning('请选择证件开始日期！', function () { }, '消息提示', '关闭');
                }

                //证件结束日期
                if ($('#F_IDCardEndDate').text() == "请选择") {
                    return learun.layer.warning('请选择证件结束日期！', function () { }, '消息提示', '关闭');
                }

                //国籍
                if ($('#F_NationAlity').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择国籍！', function () { }, '消息提示', '关闭');
                }

                //民族
                if ($('#F_Nation').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择民族！', function () { }, '消息提示', '关闭');
                }

                //户籍性质
                if ($('#F_RRNature').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择户籍性质！', function () { }, '消息提示', '关闭');
                }

                //政治面貌
                if ($('#F_PoliticalOutlook').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择政治面貌！', function () { }, '消息提示', '关闭');
                }

                //婚姻状况
                if ($('#F_MaritalStatus').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择婚姻状况！', function () { }, '消息提示', '关闭');
                }

                //籍贯
                if ($('#F_NativePlace').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择籍贯！', function () { }, '消息提示', '关闭');
                }

                //入职日期
                if ($('#F_Entrydate').text() == "请选择") {
                    return learun.layer.warning('请选择入职日期！', function () { }, '消息提示', '关闭');
                }

                //入职渠道
                if ($('#F_EntryChannel').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择入职渠道！', function () { }, '消息提示', '关闭');
                }

                //最高学历
                if ($('#F_Education').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择最高学历！', function () { }, '消息提示', '关闭');
                }

                //最高学历开始时间
                if ($('#F_EducationStartDate').text() == "请选择") {
                    return learun.layer.warning('请选择最高学历开始时间！', function () { }, '消息提示', '关闭');
                }

                //最高学历结束时间
                if ($('#F_EducationEndDate').text() == "请选择") {
                    return learun.layer.warning('请选择最高学历结束时间！', function () { }, '消息提示', '关闭');
                }

                //教育方式
                if ($('#F_EducationalMode').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择教育方式！', function () { }, '消息提示', '关闭');
                }

                //外语水平
                if ($('#F_ForeignLanguageLevel').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择外语水平！', function () { }, '消息提示', '关闭');
                }

                //资格证书
                if ($('#F_IsQualified').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择资格证书！', function () { }, '消息提示', '关闭');
                }

                //联系人关系
                if ($('#F_EContactRelationship').text() == "请选择(必填)") {
                    return learun.layer.warning('请选择联系人关系！', function () { }, '消息提示', '关闭');
                }

                var idCard = $('#F_IDCard').val();
                if (documentType == '身份证') {
                    //身份证验证
                    if (idCard.length == 18) {
                        var idCard_string = JSON.stringify(idCard);
                        var spstr = idCard_string.split("");
                        var x = spstr[spstr.length - 2];
                        console.log(spstr)
                        if (x === "x") {
                            $('#F_IDCard').focus();
                            return learun.layer.warning('身份证号最后一位X为大写！', function () { }, '消息提示',
                                '关闭');
                        }
                        var reg = new RegExp(/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$/);
                        var arrSplit = idCard.match(reg); //检查生日日期是否正确，value就是身份证号
                        if (!arrSplit) {
                            $('#F_IDCard').focus();
                            return learun.layer.warning('身份证号格式有问题，请重新输入！', function () { }, '消息提示',
                                '关闭');
                        }
                        var dtmBirth = new Date(arrSplit[2] + "/" + arrSplit[3] + "/" + arrSplit[
                            4]);
                        var bGoodDay;
                        bGoodDay = (dtmBirth.getFullYear() == Number(arrSplit[2])) && ((dtmBirth
                            .getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() ==
                                Number(arrSplit[4]));
                        if (!bGoodDay) {
                            $('#F_IDCard').focus();
                            return learun.layer.warning('身份证号中的出生日期不正确！', function () { }, '消息提示',
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
                                $('#F_IDCard').focus();
                                return learun.layer.warning('18位身份证的校验码不正确！应该为：' + valnum,
                                    function () { }, '消息提示', '关闭');
                            }
                        }
                    } else {
                        $('#F_IDCard').focus();
                        return learun.layer.warning('身份证号码长度应为18位!',
                            function () { }, '消息提示', '关闭');
                    };
                } else {
                    //护照编号验证
                    //if (idCard.length != 9) {
                    //    $('#F_IDCard').focus();
                    //    return learun.layer.warning('护照号码长度为9位，请重新输入！', function () { }, '消息提示',
                    //        '关闭');
                    //}
                }

                //证件开始过期日期验证
                var startDate = new Date($('#F_IDCardStartDate').text().replace("-", "/").replace(
                    "-", "/"));
                var endDate = new Date($('#F_IDCardEndDate').text().replace("-", "/").replace("-",
                    "/"));
                if (endDate < startDate) {
                    return learun.layer.warning('证件开始时间不能大于结束日期！', function () { }, '消息提示', '关闭');
                }

                //手机号码验证
                var mobile = $('#F_Mobile').val();
                if (!(/^1[3456789]\d{9}$/.test(mobile))) {
                    $('#F_Mobile').focus();
                    return learun.layer.warning('请输入正确手机号码！', function () { }, '消息提示', '关闭');
                };
                //mobile = $('#F_EContactNumber').val();
                //if (!(/^1[3456789]\d{9}$/.test(mobile))) {
                //    $('#F_EContactNumber').focus();
                //    return learun.layer.warning('请输入正确联系人手机号码！', function () { }, '消息提示', '关闭');
                //};
                //入学和毕业日期验证
                startDate = new Date($('#F_EducationStartDate').text().replace("-", "/").replace("-",
                    "/"));
                endDate = new Date($('#F_EducationEndDate').text().replace("-", "/").replace("-",
                    "/"));
                if (endDate < startDate) {
                    return learun.layer.warning('最高学历开始时间不能大于结束时间！', function () { }, '消息提示', '关闭');
                };

                //获取毕业证日期
                var getDate = new Date($('#F_GetTime').text().replace("-", "/").replace("-", "/"));
                if (getDate < startDate) {
                    $('#F_IDCard').focus();
                    return learun.layer.warning('毕业证获取时间不能小于最高学历开始时间！', function () { }, '消息提示', '关闭');
                };

                //资格证书有无
                if ($('#F_IsQualified').text() == "有") {
                    if ($('#F_QualificationName').val() == '' || $('#F_GetTime').text() == "请选择") {
                        $('#F_QualificationName').focus();
                        return learun.layer.warning('请输入证书名称和证书获取日期！', function () { }, '消息提示', '关闭');
                    }
                };

                //入职渠道
                if ($('#F_EntryChannel').text() == "劳务" || $('#F_EntryChannel').text() == "劳务代招" || $('#F_EntryChannel').text() == "劳务转自招") {
                    if ($('#F_RecruitmentCompany').val() == '') {
                        $('#F_RecruitmentCompany').focus();
                        return learun.layer.warning('请输入劳务公司！', function () { }, '消息提示', '关闭');
                    }
                }


                //保存完善资料
                var user = {
                    F_UserId: userinfo.baseinfo.userId,
                    F_Age: $('#F_Age').val(),
                    F_Gender: $('#F_Gender').text() == "男" ? 1 : 0,
                    F_DocumentType: $('#F_DocumentType').text(),
                    F_IDCard: $('#F_IDCard').val(),
                    F_IDCardStartDate: $('#F_IDCardStartDate').text(),
                    F_IDCardEndDate: $('#F_IDCardEndDate').text(),
                    F_NationAlity: $('#F_NationAlity').text(),
                    F_Nation: $('#F_Nation').text(),
                    F_RRNature: $('#F_RRNature').text(),
                    F_Mobile: $('#F_Mobile').val(),
                    F_PoliticalOutlook: $('#F_PoliticalOutlook').text(),
                    F_MaritalStatus: $('#F_MaritalStatus').text(),
                    F_NativePlace: $('#F_NativePlace').text(),
                    F_BankCardNumber: $('#F_BankCardNumber').val(),
                    F_BankDeposit: $('#F_BankDeposit').val(),
                    //F_PostId: $('#F_PostId').text(),
                    F_Entrydate: $('#F_Entrydate').text(),
                    F_JoiningGroupDate: $('#F_JoiningGroupDate').text(),
                    F_EntryChannel: $('#F_EntryChannel').text(),
                    F_Education: $('#F_Education').text(),
                    F_GraduationUniversitie: $('#F_GraduationUniversitie').val(),
                    F_MajorStudied: $('#F_MajorStudied').val(),
                    F_EducationStartDate: $('#F_EducationStartDate').text(),
                    F_EducationEndDate: $('#F_EducationEndDate').text(),
                    F_EducationalMode: $('#F_EducationalMode').text(),
                    F_ForeignLanguageLevel: $('#F_ForeignLanguageLevel').text(),
                    F_IsQualified: $('#F_IsQualified').text() == "有" ? 1 : 0,
                    F_QualificationName: $('#F_QualificationName').val(),
                    F_GetTime: $('#F_GetTime').text() == "请选择" ? "" : $('#F_GetTime').text(),
                    F_IDCardAddress: $('#F_IDCardAddress').val(),
                    F_PermanentAddress: $('#F_PermanentAddress').val(),
                    F_ResidentialAddress: $('#F_ResidentialAddress').val(),
                    F_CurrentAddress: $('#F_CurrentAddress').val(),
                    F_EmergencyContact: $('#F_EmergencyContact').val(),
                    F_EContactRelationship: $('#F_EContactRelationship').text(),
                    F_EContactNumber: $('#F_EContactNumber').val(),
                    F_ContactAddress: $('#F_ContactAddress').val(),
                    F_InternalCode: $('#F_InternalCode').val(),
                    F_InternalName: $('#F_InternalName').val(),
                    F_InternalCompany: $('#F_InternalCompany').val(),
                    F_RecruitmentCompany: $('#F_RecruitmentCompany').val(),

                    //最先部门信息
                    F_DepartmentId: userinfo.baseinfo.departmentId,
                };
                var postdata = {
                    token: userinfo.baseinfo.token,
                    loginMark: learun.deviceId(), // 正式请换用设备号
                    data: user
                };

                path = config.webapi + "User/InformationPerfection";
                learun.layer.loading(true, "正在保存，请稍后");

                $.ajax({
                    type: "post",
                    url: path,
                    data: postdata,
                    dataType: "json",
                    success: function (res) {
                        learun.layer.loading(false);
                        if (res === null) {
                            learun.layer.warning('无法连接服务器,请检测网络！', function () { },
                                '消息提示',
                                '关闭');
                            return;
                        }
                        if (res.code === 200) {
                            learun.layer.toast(res.info);
                            // learun.tab.go('my');
                        } else {
                            learun.layer.warning(res.info, function () { }, '消息提示',
                                '关闭');
                        }
                        $('#F_IDCard').focus();
                    }
                });
            });
        },
        bind: function ($page, param) {
            var paramdata = {
                token: userinfo.baseinfo.token,
                loginMark: learun.deviceId(), // 正式请换用设备号
                userId: userinfo.baseinfo.userId,
            };

            //绑定岗位
            //$page.find('#F_PostId').lrpicker({
            //    placeholder: '请选择(必填)',
            //    data: JSON.parse(userinfo.baseinfo.postIds),
            //});
            path = config.webapi+ "User/InitializationUser";
            //数据初始化
            $.ajax({
                type: "post",
                url: path,
                cache: false,
                data: paramdata,
                dataType: "json",
                success: function (res) {
                    learun.layer.loading(false);
                    if (res === null) {
                        learun.layer.warning('无法连接服务器,请检测网络！', function () { },
                            '消息提示',
                            '关闭');
                        return;
                    }
                    if (res.code === 200) {
                        var userInfo = res.data[0];
                        if (userInfo.F_Age > 0) {
                            $('#F_Age').val(userInfo.F_Age);
                        }
                        if (userInfo.F_Gender != null) {
                            var gender = userInfo.F_Gender == 1 ? "男" : "女";
                            $('#F_Gender').html("<div class=\"text\">"+gender+"</div>");
                        }
                        if (userInfo.F_DocumentType != null) {
                            $('#F_DocumentType').html("<div class=\"text\">" + userInfo.F_DocumentType + "</div>");
                        }
                        if (userInfo.F_IDCard != null) {
                            $('#F_IDCard').val(userInfo.F_IDCard);
                        }
                        if (userInfo.F_IDCardStartDate != null) {
                            $('#F_IDCardStartDate').html("<div class=\"text\">" + userInfo.F_IDCardStartDate.split('T')[0] + "</div>");
                        }
                        if (userInfo.F_IDCardEndDate != null) {
                            $('#F_IDCardEndDate').html("<div class=\"text\">" + userInfo.F_IDCardEndDate.split('T')[0] + "</div>");
                        }
                        if (userInfo.F_NationAlity != null) {
                            $('#F_NationAlity').html("<div class=\"text\">" +userInfo.F_NationAlity + "</div>");
                        }
                        if (userInfo.F_Nation != null) {
                            $('#F_Nation').html("<div class=\"text\">" + userInfo.F_Nation + "</div>");
                        }
                        if (userInfo.F_RRNature != null) {
                            $('#F_RRNature').html("<div class=\"text\">" +userInfo.F_RRNature + "</div>");
                        }
                        if (userInfo.F_Mobile != null) {
                            $('#F_Mobile').val(userInfo.F_Mobile);
                        }
                        if (userInfo.F_Mobile != null) {
                            $('#F_PoliticalOutlook').html("<div class=\"text\">" + userInfo.F_PoliticalOutlook + "</div>");
                        }
                        if (userInfo.F_MaritalStatus != null) {
                            $('#F_MaritalStatus').html("<div class=\"text\">" + userInfo.F_MaritalStatus + "</div>");
                        }
                        if (userInfo.F_NativePlace != null) {
                            $('#F_NativePlace').html("<div class=\"text\">" + userInfo.F_NativePlace + "</div>");
                        }
                        if (userInfo.F_BankCardNumber != null) {
                            $('#F_BankCardNumber').val(userInfo.F_BankCardNumber);
                        }
                        if (userInfo.F_BankDeposit != null) {
                            $('#F_BankDeposit').val(userInfo.F_BankDeposit);
                        }
                        if (userInfo.F_Entrydate != null) {
                            $('#F_Entrydate').html("<div class=\"text\">" + userInfo.F_Entrydate.split('T')[0] + "</div>");
                        }
                        if (userInfo.F_JoiningGroupDate != null) {
                            var groupDate = userInfo.F_JoiningGroupDate == null ? "请选择" : userInfo.F_JoiningGroupDate.split('T')[0];
                            $('#F_JoiningGroupDate').html("<div class=\"text\">" + groupDate + "</div>");
                        }
                        if (userInfo.F_EntryChannel != null) {
                            $('#F_EntryChannel').html("<div class=\"text\">" + userInfo.F_EntryChannel + "</div>");
                        }
                        if (userInfo.F_Education != null) {
                            $('#F_Education').html("<div class=\"text\">" + userInfo.F_Education + "</div>");
                        }
                        if (userInfo.F_GraduationUniversitie != null) {
                            $('#F_GraduationUniversitie').val(userInfo.F_GraduationUniversitie);
                        }
                        if (userInfo.F_MajorStudied != null) {
                            $('#F_MajorStudied').val(userInfo.F_MajorStudied);
                        }
                        if (userInfo.F_EducationStartDate != null) {
                            $('#F_EducationStartDate').html("<div class=\"text\">" + userInfo.F_EducationStartDate.split('T')[0] + "</div>");
                        }
                        if (userInfo.F_EducationEndDate != null) {
                            $('#F_EducationEndDate').html("<div class=\"text\">" + userInfo.F_EducationEndDate.split('T')[0] + "</div>");
                        }
                        if (userInfo.F_EducationalMode != null) {
                            $('#F_EducationalMode').html("<div class=\"text\">" + userInfo.F_EducationalMode + "</div>");
                        }
                        if (userInfo.F_ForeignLanguageLevel != null) {
                            $('#F_ForeignLanguageLevel').html("<div class=\"text\">" + userInfo.F_ForeignLanguageLevel + "</div>");
                        }
                        if (userInfo.F_IsQualified != null) {
                            var qualified = userInfo.F_IsQualified == 1 ? "有" : "无";
                            $('#F_IsQualified').html("<div class=\"text\">" + qualified + "</div>");
                        }
                        if (userInfo.F_QualificationName != null) {
                            $('#F_QualificationName').val(userInfo.F_QualificationName);
                        }
                        if (userInfo.F_GetTime != null) {
                            var getTime = userInfo.F_GetTime == null ? "请选择" : userInfo.F_GetTime.split('T')[0];
                            $('#F_GetTime').html("<div class=\"text\">" + getTime + "</div>");
                        }
                        if (userInfo.F_IDCardAddress != null) {
                            $('#F_IDCardAddress').val(userInfo.F_IDCardAddress);
                        }
                        if (userInfo.F_PermanentAddress != null) {
                            $('#F_PermanentAddress').val(userInfo.F_PermanentAddress);
                        }
                        if (userInfo.F_ResidentialAddress != null) {
                            $('#F_ResidentialAddress').val(userInfo.F_ResidentialAddress);
                        }
                        if (userInfo.F_CurrentAddress != null) {
                            $('#F_CurrentAddress').val(userInfo.F_CurrentAddress);
                        }
                        if (userInfo.F_EmergencyContact != null) {
                            $('#F_EmergencyContact').val(userInfo.F_EmergencyContact);
                        }
                        if (userInfo.F_EmergencyContact != null) {
                            $('#F_EContactRelationship').html("<div class=\"text\">" + userInfo.F_EContactRelationship + "</div>");
                        }
                        if (userInfo.F_EContactNumber != null) {
                            $('#F_EContactNumber').val(userInfo.F_EContactNumber);
                        }
                        if (userInfo.F_ContactAddress != null) {
                            $('#F_ContactAddress').val(userInfo.F_ContactAddress);
                        }
                        if (userInfo.F_InternalCode != null) {
                            $('#F_InternalCode').val(userInfo.F_InternalCode);
                        }
                        if (userInfo.F_InternalName != null) {
                            $('#F_InternalName').val(userInfo.F_InternalName);
                        }
                        if (userInfo.F_InternalCompany != null) {
                            $('#F_InternalCompany').val(userInfo.F_InternalCompany);
                        }
                        if (userInfo.F_RecruitmentCompany != null) {
                            $('#F_RecruitmentCompany').val(userInfo.F_RecruitmentCompany);
                        }
                        // learun.layer.toast(res.info);
                        // learun.tab.go('my');
                    } else {
                        learun.layer.warning(res.info, function () { }, '消息提示',
                            '关闭');
                    }
                }
            });
        },
    };
    return page;
})();

