homeController = function () {
    this.initialize = function () {
        loadData();
        //registerEvents();
    }
    var listFamilyRelationship = [];
    var listWorkingProcessDetail = [];
    var listExpertiseDetail = [];
    var listLanguageDetail = [];
    var listSalaryDetail = [];
    var gId = 0;
    var userName;
    var gEmployeeId;
    function registerEvents() {
        $('.yearpicker').datepicker({
            format: "yyyy",
            //todayBtn: "linked",
            clearBtn: true,
            language: "vi",
            todayHighlight: true,
            startView: 2,
            minViewMode: 2
        });
        loadEmployeeType();
        loadEducationalLevel();
        loadLanguage();
        loadQualification();
        loadMajor();
        loadTrainingSystem();
        loadNationality();
        loadCity();
        loadDepartment();
        loadPosition();
        loadNation();
        loadReligion();

        $('body').on('change', '#dtYear', function () {
            loadSalary(gEmployeeId);
        });
        $('#btnUpdateAvatar').on('click', function () {
            $('#fileInputAvatar').click();
        });
        $("#fileInputAvatar").on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            if (files.length == 1) {
                for (var i = 0; i < files.length; i++) {
                    data.append(files[i].name, files[i]);
                }
                $.ajax({
                    type: "POST",
                    url: "/Upload/UploadImage",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (path) {
                        console.log(path);
                        gAvatarImage = path;
                        $('#imgAvatar').css('background-image', 'url("' + gAvatarImage + '")');
                        //$('#lblAvatar').text(files[0].name);
                    },
                    error: function () {
                        general.notify('Lỗi khi upload ảnh !', 'error');
                    }
                });
            }
        });

        $('#btnDeleteAvatar').on('click', function () {
            var c = confirm('Are you sure to delete this avatar?');
            if (c) {
                gAvatarImage = "admin-side/images/user.png";
                $('#imgAvatar').css('background-image', 'url("' + gAvatarImage + '")');
                $('#fileInputAvatar').val('');
            }
            return false;
        })

        //$('#txtEmployee').prop('disabled', true);
        $("#txtId").prop('disabled', true);
        $("#txtGender").prop('disabled', true);
        $("#txtDOB").prop('disabled', true);
        $("#txtIDNumber").prop('disabled', true);
        $("#txtPhoneNumber").prop('disabled', true);
        $("#txtEmail").prop('disabled', true);
        $("#txtLastUpdatedByFK").prop('disabled', true);
        $("#dtDateModified").prop('disabled', true);
        $("#txtEmployee").prop('disabled', true);
        $("#chkStatus").prop('checked', true);
        $('#selProvinceAC').prop('disabled', true);
        $('#selDistrictAC').prop('disabled', true);
        $('#selWardAC').prop('disabled', true);
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            invalidHandler: function (event, validator) {
                // 'this' refers to the form
                //console.log(validator.errorList[0].element.labels[0].textContent);
                var errors = validator.numberOfInvalids();
                if (errors) {
                    var errorElement = validator.errorList[0].element;
                    var errorElementTag = validator.errorList[0].element.labels[0].textContent;
                    if (errorElement.type.includes("text")) {
                        general.notify('Hãy nhập ' + errorElementTag, 'error');
                    }
                    if (errorElement.type.includes("select")) {
                        general.notify('Hãy chọn ' + errorElementTag, 'error');
                    }
                    //var message = errors == 1
                    //    ? 'You missed 1 field. It has been highlighted'
                    //    : 'You missed ' + errors + ' fields. They have been highlighted';
                    ////$("div.error span").html(message);
                    //console.log(message);
                    //$("div.error").show();
                }
            },
            //showErrors: function (errorMap, errorList) {
            //    console.log("Your form contains "
            //        + this.numberOfInvalids()
            //        + " errors, see details below.");
            //    console.log(errorMap);
            //    console.log(this.defaultShowErrors() + errorList[0] + errorList[0].element.text());
            //},
            rules: {
                txtEmployee: {
                    required: true
                },
                txtIdCard: {
                    required: true
                },
                selDepartmentFK: {
                    required: true
                },
                selPositionFK: {
                    required: true
                },
                selOriginFK: {
                    required: true
                },
                txtPhoneNumberContactPerson: {
                    number: true
                },
                txtTaxIDNumber: {
                    number: true
                },
                txtBankAccountNumber: {
                    number: true
                },
                txtNOChildren: {
                    number: true
                },
                txtSalarySocialInsurance: {
                    required: true,
                    number: true
                },
                txtSalary: {
                    required: true,
                    number: true
                },
                txtNumberOfDependents: {
                    number: true
                },
                txtTravelAllowance: {
                    number: true
                },
                txtPositionAllowance: {
                    number: true
                },
                txtSeniorityAllowances: {
                    number: true
                },
                txtOtherAllowances: {
                    number: true
                },
                txtRelativesName: {
                    required: true
                },
                txtRelationship: {
                    required: true
                },
                txtYearOfBirth: {
                    required: true,
                    number: true
                },
                selDegree: {
                    required: true,
                },
                selMajor: {
                    required: true,
                },
                selTrainingSystem: {
                    required: true,
                },
                selLanguage: {
                    required: true,
                },
                selLevel: {
                    required: true,
                },
                txtCertificate: {
                    required: true,
                }
            }
        });

        $('#ddlShowPage').on('change', function () {
            general.configs.pageSize = $(this).val();
            general.configs.pageIndex = 1;
            loadData(true);
        });

        $('#txtTravelAllowance').keyup(function (event) {
            // skip for arrow keys
            if (event.which >= 37 && event.which <= 40) return;

            // format number
            $(this).val(function (index, value) {
                return value
                    .replace(/\D/g, "")
                    .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                    ;
            });
        });
        $('#txtSalary').keyup(function (event) {
            // skip for arrow keys
            if (event.which >= 37 && event.which <= 40) return;

            // format number
            $(this).val(function (index, value) {
                return value
                    .replace(/\D/g, "")
                    .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                    ;
            });
        });
        $('#txtPositionAllowance').keyup(function (event) {
            // skip for arrow keys
            if (event.which >= 37 && event.which <= 40) return;

            // format number
            $(this).val(function (index, value) {
                return value
                    .replace(/\D/g, "")
                    .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                    ;
            });
        });
        $('#txtSalarySocialInsurance').keyup(function (event) {
            // skip for arrow keys
            if (event.which >= 37 && event.which <= 40) return;

            // format number
            $(this).val(function (index, value) {
                return value
                    .replace(/\D/g, "")
                    .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                    ;
            });
        });
        $('#txtSeniorityAllowances').keyup(function (event) {
            // skip for arrow keys
            if (event.which >= 37 && event.which <= 40) return;

            // format number
            $(this).val(function (index, value) {
                return value
                    .replace(/\D/g, "")
                    .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                    ;
            });
        });
        $('#txtOtherAllowances').keyup(function (event) {
            // skip for arrow keys
            if (event.which >= 37 && event.which <= 40) return;

            // format number
            $(this).val(function (index, value) {
                return value
                    .replace(/\D/g, "")
                    .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                    ;
            });
        });

        $('#selProvincePR').on('change', function () {
            var cityId = $(this).val();
            var that = $("#selDistrictPR");
            if (cityId) {
                loadDistrict(cityId, that, '');
            }
            else {
                that.empty().append("<option value=''>Chọn Quận/Huyện</option>");
                $('#selWardPR').empty().append("<option value=''>Chọn Phường/Xã</option>");
            }
        });
        $('#selProvinceAC').on('change', function () {
            var cityId = $(this).val();
            var that = $("#selDistrictAC");
            if (cityId) {
                loadDistrict(cityId, that, '');
            }
            else {
                that.empty().append("<option value=''>Chọn Quận/Huyện</option>");
                $('#selWardAC').empty().append("<option value=''>Chọn Phường/Xã</option>");
            }
        });
        $('#selDistrictPR').on('change', function () {
            var districtId = $(this).val();
            var that = $("#selWardPR");
            if (districtId) {
                loadWard(districtId, that, '');
            }
            else {
                that.empty().append("<option value=''>Chọn Phường/Xã</option>");
            }
        });
        $('#selDistrictAC').on('change', function () {
            var districtId = $(this).val();
            var that = $("#selWardAC");
            if (districtId) {
                loadWard(districtId, that, '');
            }
            else {
                that.empty().append("<option value=''>Chọn Phường/Xã</option>");
            }
        });





        $('#btnSearch').on('click', function () {
            loadData(true);
        });
        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                loadData(true);
            }
        });
        $("#btnCreate").on('click', function () {
            gId = 0;
            resetFormMaintainance();
            $('#btnPrint').css("display", "none");
            $('#imgAvatar').css('background-image', 'url("admin-side/images/user.png")');
            var temp = $("#txtEmployee");
            loadSelEmployee(false, general.addressBookType.Employee, function (arr) {
                autoAddressbook(temp, arr);
                $('#modal-add-edit').modal('show');
            });


        });
        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            resetFormMaintainance();
            $('#txtEmployee').prop('disabled', true);
            var that = $(this).data('id');
            loadDetail(that);
        });

        $('body').on('click', '.btn-view-salary', function () {
            var id = $(this).data('id');
            loadSalary(id);
            gEmployeeId = id;
        });

        $('body').on('click', '.btn-remove', function (e) {
            e.preventDefault();
            $that = $(this).closest('tbody');
            var c = confirm('Are you sure to delete this row?');
            if (c) {
                $(this).parents('tr').fadeOut(function () {
                    if ($that.attr('id') == "tbl-FamilyRelationship") {
                        var keyid = $(this).find('td:eq(0) input').val();
                        var removeObject = keyid;
                        listFamilyRelationship.push(removeObject);
                    }
                    if ($that.attr('id') == "tbl-WorkingProcess") {
                        var keyid = $(this).find('td:eq(0) input[type="hidden"]').val();
                        var removeObject = keyid;
                        listWorkingProcessDetail.push(removeObject);
                    }
                    if ($that.attr('id') == "tbl-Expertise") {
                        var keyid = $(this).find('td:eq(0) input').val();
                        var removeObject = keyid;
                        listExpertiseDetail.push(removeObject);
                    }
                    if ($that.attr('id') == "tbl-Languages") {
                        var keyid = $(this).find('td:eq(0) input').val();
                        var removeObject = keyid;
                        listLanguageDetail.push(removeObject);
                    }
                    if ($that.attr('id') == "tbl-SalaryProcess") {
                        var keyid = $(this).find('td:eq(0) input').val();
                        var removeObject = keyid;
                        listSalaryDetail.push(removeObject);
                    }


                    $(this).remove();
                    if ($that.attr('id') != "tbl-WorkingProcess") {
                        loadSTT($that);
                    }
                });
            }
            return false;
        });

        var status;
        $('#btnSave').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var addressBookFk = $('#txtEmployee').data('addressbookid');
                if (addressBookFk == '') {
                    general.notify('Vui lòng chọn nhân viên trước !', 'error');
                    return false;
                }
                //User data
                UserData.Avatar = gAvatarImage;
                if ($('#selProvinceAC').val() != "") UserData.City = $('#selProvinceAC option:selected').text();
                if ($('#selDistrictAC').val() != "") UserData.District = $('#selDistrictAC option:selected').text();
                UserData.Employee_FK = gId;
                UserData.IsEmployee = true;
                UserData.IdDate = $('#dtp_input2').val();
                UserData.Street = $('#txtAccommodationCurrent').val();
                UserData.TaxIdnumber = $('#txtTaxIDNumber').val();


                //Employee Data
                var id = $('#txtId').val();
                var Idcard = $('#txtIdCard').val();
                var employeeTypeFK = $('#selEmployeeTypeFK').val();
                var birthplace = $('#selBirthplace option:selected').val();
                var originFK = $('#selOriginFK option:selected').val();
                var nationFK = $('#selNationFK option:selected').val();
                var nationalityFK = $('#selNationality option:selected').val();
                var iDDate = general.dateFormatJson(general.getDatePicker($('#dtIDDate')), false);
                var permanentResidence = $('#txtPermanentResidence').val();
                var wardPR = $('#selWardPR').val();
                var districtPR = $('#selDistrictPR option:selected').val();
                var provincePR = $('#selProvincePR option:selected').val();
                var accommodationCurrent = $('#txtAccommodationCurrent').val();
                var wardAC = $('#selWardAC').val();
                var districtAC = $('#selDistrictAC option:selected').val();
                var provinceAC = $('#selProvinceAC option:selected').val();
                var infoContactPerson = $('#txtInfoContactPerson').val();
                var phoneNumberContactPerson = $('#txtPhoneNumberContactPerson').val();
                var aTMAccountName = $('#txtATMAccountName').val();
                var iDAccount = $('#txtIDAccount').val();
                var nOChildren = $('#txtNOChildren').val();
                var numberOfProfile = $('#txtNumberOfProfile').val();
                var numberOfContract = $('#txtNumberOfContract').val();
                var laborContractType = $('#selLaborContractType').val();
                var signDate = general.dateFormatJson(general.getDatePicker($('#dtSignDate')), false);
                var timeExpireContract = general.dateFormatJson(general.getDatePicker($('#dtTimeExpireContract')), false);
                var timeExpireProbation = general.dateFormatJson(general.getDatePicker($('#dtTimeExpireProbation')), false);
                var startDate = general.dateFormatJson(general.getDatePicker($('#dtStartDate')), false);
                var infoSaveFile = $('#txtInfoSaveFile').val();
                var layOffDate = general.dateFormatJson(general.getDatePicker($('#dtLayOffDate')), false);
                var literacy = $('#selLiteracy option:selected').val();
                var iDSocialInsurance = $('#txtIDSocialInsurance').val();
                var salarySocialInsurance = general.toFloat($('#txtSalarySocialInsurance').val());
                var socialInsuranceDate = general.dateFormatJson(general.getDatePicker($('#txtSocialInsuranceDate')), false);
                var salary = $('#txtSalary').val();
                var numberOfDependents = $('#txtNumberOfDependents').val();
                var isUnionMember = $("#chkIsUnionMember").is(':checked');
                var travelAllowance = general.toFloat($('#txtTravelAllowance').val());
                var positionAllowance = general.toFloat($('#txtPositionAllowance').val());
                var seniorityAllowances = general.toFloat($('#txtSeniorityAllowances').val());
                var otherAllowances = general.toFloat($('#txtOtherAllowances').val());


                var religionFK = $('#selReligionFK option:selected').val();
                var taxIdNumber = $('#txtTaxIDNumber').val();
                var bankAccountNumber = $('#txtBankAccountNumber').val();
                var departmentFK = $('#selDepartmentFK option:selected').val();
                var positionFK = $('#selPositionFK option:selected').val();
                var note = $('#txtNotes').val();



                var a = $("#chkStatus").is(':checked');
                if (a == true) status = 1;
                else status = 0;

                var FamilyC = $("input[name='optradio']:checked").val();



                //FamilyRelationship Data
                var listDataFamilyRelationship = [];
                $.each($('#tbl-FamilyRelationship tr'), function (i, item) {
                    var keyid = $(this).find('td:eq(0) input').val();
                    var relativesName = $(this).find('td:eq(1) input').val();
                    var yearOfBirth = $(this).find('td:eq(2) input').val();
                    var gender = $(this).find('td:eq(3) select').val();
                    //if (gender) gender = gender == "Nam" ? 0 : 1;
                    var relationship = $(this).find('td:eq(4) input').val();
                    var job = $(this).find('td:eq(5) input').val();
                    var died = $(this).find('td:eq(6) label input').is(':checked');
                    var data = {
                        KeyId: keyid,
                        EmployeeFK: gId,
                        RelativesName: relativesName,
                        YearOfBirth: yearOfBirth,
                        Gender: gender,
                        Relationship: relationship,
                        Job: job,
                        Died: died,
                    };
                    listDataFamilyRelationship.push(data);
                });

                //WorkingProcess Data
                var listDataWorkingProcess = [];
                $.each($('#tbl-WorkingProcess tr'), function (i, item) {
                    var keyid = $(this).find('td:eq(0) input[type="hidden"]').val();
                    var mobilizeDate = $(this).find('td:eq(0) input[type="text"]').val();
                    var numberDesignation = $(this).find('td:eq(1) input').val();
                    var oldWorkPlace = $(this).find('td:eq(2) input').val();
                    var oldPosition = $(this).find('td:eq(3) input').val();

                    var data = {
                        KeyId: keyid,
                        EmployeeFK: gId,
                        MobilizeDate: mobilizeDate,
                        NumberDesignation: numberDesignation,
                        OldWorkPlace: oldWorkPlace,
                        OldPosition: oldPosition
                    };
                    listDataWorkingProcess.push(data);
                });

                //Expertise Data
                var listDataExpertise = [];
                $.each($('#tbl-Expertise tr'), function (i, item) {
                    var keyid = $(this).find('td:eq(0) input[type="hidden"]').val();
                    var degree = $(this).find('td:eq(1) select').val();
                    var major = $(this).find('td:eq(2) select').val();
                    var trainingSystem = $(this).find('td:eq(3) select').val();

                    var data = {
                        KeyId: keyid,
                        EmployeeFK: gId,
                        DegreeFK: degree,
                        MajorFK: major,
                        TrainingSystemFK: trainingSystem
                    };
                    listDataExpertise.push(data);
                });

                //Language Data
                var listDataLanguage = [];
                $.each($('#tbl-Languages tr'), function (i, item) {
                    var keyid = $(this).find('td:eq(0) input[type="hidden"]').val();
                    var language = $(this).find('td:eq(1) select').val();
                    var level = $(this).find('td:eq(2) select').val();
                    var certificate = $(this).find('td:eq(3) input').val();

                    var data = {
                        KeyId: keyid,
                        EmployeeFK: gId,
                        LanguageFK: language,
                        LevelFK: level,
                        Certificate: certificate
                    };
                    listDataLanguage.push(data);
                });

                //Salary Data
                var listDataSalary = [];
                $.each($('#tbl-SalaryProcess tr'), function (i, item) {
                    var keyid = $(this).find('td:eq(0) input[type="hidden"]').val();
                    var fluctuationsDate = $(this).find('td:eq(1) input').val();
                    var salaryBeforeInscrease = general.toFloat($(this).find('td:eq(2) input').val());
                    var percentInscrease = $(this).find('td:eq(3) input').val();
                    var amountInscrease = general.toFloat($(this).find('td:eq(4) input').val());
                    var salaryAfterInscrease = general.toFloat($(this).find('td:eq(5) input').val());
                    var note = $(this).find('td:eq(6) input').val();

                    var data = {
                        KeyId: keyid,
                        EmployeeFK: gId,
                        FluctuationsDate: fluctuationsDate,
                        SalaryBeforeInscrease: salaryBeforeInscrease,
                        PercentInscrease: percentInscrease,
                        AmountInscrease: amountInscrease,
                        SalaryAfterInscrease: salaryAfterInscrease,
                        Note: note
                    };
                    listDataSalary.push(data);
                });



                var data = {
                    AccommodationCurrent: accommodationCurrent,
                    EmployeeTypeFK: employeeTypeFK,
                    KeyId: gId,
                    Id: id,
                    IDAccount: iDAccount,
                    IdCard: Idcard,
                    IDDate: iDDate,
                    InfoContactPerson: infoContactPerson,
                    InfoSaveFile: infoSaveFile,
                    IDSocialInsurance: iDSocialInsurance,
                    IsUnionMember: isUnionMember,
                    User_FK: addressBookFk,
                    BankName: aTMAccountName,
                    Birthplace: birthplace,
                    DistrictACFK: districtAC,
                    DistrictPRFK: districtPR,
                    FamilyCircumstances: FamilyC,
                    OriginFk: originFK,
                    OtherAllowances: otherAllowances,
                    PermanentResidence: permanentResidence,
                    LaborContractType: laborContractType,
                    LiteracyFk: literacy,
                    NationFk: nationFK,
                    NationalityFk: nationalityFK,
                    NOChildren: nOChildren,
                    NumberOfDependents: numberOfDependents,
                    NumberOfContract: numberOfContract,
                    NumberOfProfile: numberOfProfile,
                    PhoneNumberContactPerson: phoneNumberContactPerson,
                    ProvinceACFk: provinceAC,
                    ProvincePRFk: provincePR,
                    ReligionFk: religionFK,
                    Salary: salary,
                    SalarySocialInsurance: salarySocialInsurance,
                    SeniorityAllowances: seniorityAllowances,
                    Department_FK: departmentFK,
                    PositionAllowance: positionAllowance,
                    PositionFk: positionFK,
                    TaxIdnumber: taxIdNumber,
                    TravelAllowance: travelAllowance,
                    BankAccountNumber: bankAccountNumber,
                    Note: note,
                    SignContractDate: signDate,
                    TimeExpireContract: timeExpireContract,
                    TimeExpireProbation: timeExpireProbation,
                    StartDate: startDate,
                    LayOffDate: layOffDate,
                    SocialInsuranceDate: socialInsuranceDate,
                    //LastUpdatedByFk: lastUpdatedBy,
                    //DateModified: lastUpdatedDate,
                    Status: status,
                    WardPRFK: wardPR,
                    WardACFK: wardAC,
                    FamilyCircumstancesDetails: listDataFamilyRelationship,
                    WorkingProcessDetails: listDataWorkingProcess,
                    ExpertiseDetails: listDataExpertise,
                    LanguageDetails: listDataLanguage,
                    SalaryDetails: listDataSalary
                    //UserBy: UserData
                };

                $.ajax({
                    type: "POST",
                    url: "/employee/SaveEntity",
                    data: {
                        employeeVm: data,
                        //hpFamilyCircumstancesDetailVm: listDataFamilyRelationship,
                        FamilyRmObject: listFamilyRelationship,
                        //hpWorkingProcessDetailVm: listDataWorkingProcess,
                        WorkingProcessRmObject: listWorkingProcessDetail,
                        //hpExpertiseDetailVm: listDataExpertise,
                        ExpertiseRmObject: listExpertiseDetail,
                        //hpLanguageDetailVm: listDataLanguage,
                        LanguageRmObject: listLanguageDetail,
                        //hpSalaryDetailVm: listDataSalary,
                        SalaryRmObject: listSalaryDetail,
                        RefUser: UserData
                    },
                    dataType: "json",
                    beforeSend: function () {
                        general.startLoading();
                    },
                    success: function (response) {
                        SaveUser();
                        //SaveHpFamilyCircumstancesDetail(gId);
                        //DeleteHpFamilyCircumstancesDetail();
                        //SaveHpWorkingProcessDetail(gId);
                        //SaveHpExpertiseDetail(gId);
                        //SaveHpSalaryDetail(gId);
                        //SaveHpLanguageDetail(gId);
                        if (gId == 0)
                            updateIsEmployee(addressBookFk);
                        general.notify('Ghi thành công!', 'success');
                        $('#modal-add-edit').modal('hide');
                        resetFormMaintainance();

                        general.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        general.notify('Có lỗi trong khi ghi danh bạ!', 'error');
                        general.stopLoading();
                    }
                });
                return false;
            }


        });
        $('#btnPrint').on('click', function (e) {
            //loadReceipt();
            //$('#title').text("PHIẾU BIÊN NHẬN");
            var id = $('#txtId').val();
            var idcard = $('#txtIdCard').val();
            var employeeTypeFK = $('#selEmployeeTypeFK option:selected').text();
            var dOB = $('#txtDOB').val();
            var gender = $('#txtGender').val();
            var birthplace = $('#selBirthplace option:selected').text();
            var originFK = $('#selOriginFK option:selected').text();
            var nationFK = $('#selNationFK option:selected').text();
            var nationalityFK = $('#selNationality option:selected').text();
            var iDDate = general.dateFormatJson(general.getDatePicker($('#dtIDDate')), true);
            var permanentResidence = $('#txtPermanentResidence').val();
            var wardPR = $('#selWardPR option:selected').text();
            var districtPR = $('#selDistrictPR option:selected').text();
            var provincePR = $('#selProvincePR option:selected').text();
            var accommodationCurrent = $('#txtAccommodationCurrent').val();
            var wardAC = $('#selWardAC option:selected').text();
            var districtAC = $('#selDistrictAC option:selected').text();
            var provinceAC = $('#selProvinceAC option:selected').text();
            var infoContactPerson = $('#txtInfoContactPerson').val();
            var phoneNumberContactPerson = $('#txtPhoneNumberContactPerson').val();
            var aTMAccountName = $('#txtATMAccountName').val();
            var iDAccount = $('#txtIDAccount').val();
            var nOChildren = $('#txtNOChildren').val();
            var numberOfProfile = $('#txtNumberOfProfile').val();
            var numberOfContract = $('#txtNumberOfContract').val();
            var laborContractType = $('#selLaborContractType option:selected').text();
            var signDate = general.dateFormatJson(general.getDatePicker($('#dtSignDate')), true);
            var timeExpireContract = general.dateFormatJson(general.getDatePicker($('#dtTimeExpireContract')), true);
            var timeExpireProbation = general.dateFormatJson(general.getDatePicker($('#dtTimeExpireProbation')), true);
            var startDate = general.dateFormatJson(general.getDatePicker($('#dtStartDate')), true);
            var infoSaveFile = $('#txtInfoSaveFile').val();
            var layOffDate = general.dateFormatJson(general.getDatePicker($('#dtLayOffDate')), true);
            var literacy = $('#selLiteracy option:selected').text();
            var iDSocialInsurance = $('#txtIDSocialInsurance').val();
            var salarySocialInsurance = general.toFloat($('#txtSalarySocialInsurance').val());
            var socialInsuranceDate = general.dateFormatJson(general.getDatePicker($('#txtSocialInsuranceDate')), true);
            var salary = $('#txtSalary').val();
            var numberOfDependents = $('#txtNumberOfDependents').val();
            var isUnionMember = $("#chkIsUnionMember").is(':checked') == true ? "checked" : "";
            var travelAllowance = general.toFloat($('#txtTravelAllowance').val());
            var positionAllowance = general.toFloat($('#txtPositionAllowance').val());
            var seniorityAllowances = general.toFloat($('#txtSeniorityAllowances').val());
            var otherAllowances = general.toFloat($('#txtOtherAllowances').val());


            var religionFK = $('#selReligionFK option:selected').text();
            var taxIdNumber = $('#txtTaxIDNumber').val();
            var bankAccountNumber = $('#txtBankAccountNumber').val();
            var departmentFK = $('#selDepartmentFK option:selected').text();
            var positionFK = $('#selPositionFK option:selected').text();
            var notes = $('#txtNotes').val();

            var employee = $('#txtEmployee').val();
            var iDNumber = $('#txtIDNumber').val();
            var iDPlace = $('#selIDPlace option:selected').text();
            var phoneNumber = $('#txtPhoneNumber').val();
            var email = $('#txtEmail').val();
            var lastUpdatedByFK = $('#txtLastUpdatedByFK').val();
            var dateModified = $('#dtDateModified').val();
            var status = $('#chkStatus').prop("checked") == true ? "checked" : "";

            var FamilyC = $("input[name='optradio']:checked").val();
            var rdoSingle = "";
            if (FamilyC == 1) rdoSingle = "checked";
            var rdoMarried = "";
            if (FamilyC == 2) rdoMarried = "checked";
            var rdoDivorced = "";
            if (FamilyC == 3) rdoDivorced = "checked";
            var rdoRemarried = "";
            if (FamilyC == 4) rdoRemarried = "checked";

            //FamilyCircumstance
            var tbl = $('#tbl-FamilyRelationship').children();
            var tblFamily = "";
            $.each(tbl, function (keyT, valT) {
                tblFamily += "<tr>";
                tblFamily += "<td><span>" + (keyT + 1) + "</span></td>";
                tblFamily += "<td><label>" + $(this).closest('tr').find('td:eq(1) input').val() + "</label></td>";
                tblFamily += "<td><label>" + $(this).closest('tr').find('td:eq(2) input').val() + "</label></td>";
                tblFamily += "<td><label>" + $(this).closest('tr').find('td:eq(3) select option:selected').text() + "</label></td>";
                tblFamily += "<td><label>" + $(this).closest('tr').find('td:eq(4) input').val() + "</label></td>";
                tblFamily += "<td><label>" + $(this).closest('tr').find('td:eq(5) input').val() + "</label></td>";
                var tmp = $(this).closest('tr').find('td:eq(6) input').prop("checked") == true ? "checked" : "";
                tblFamily += "<td><input type='checkbox' " + tmp + " ></td>";
                tblFamily += "</tr>";
            });
            //WorkingProcess
            var tbl = $('#tbl-WorkingProcess').children();
            var tblWorking = "";
            $.each(tbl, function (keyT, valT) {
                tblWorking += "<tr>";
                tblWorking += "<td><label>" + general.dateFormatJson($(this).closest('tr').find('td:eq(0) input[type=date]').val(), true) + "</label></td>";
                tblWorking += "<td><label>" + $(this).closest('tr').find('td:eq(1) input').val() + "</label></td>";
                tblWorking += "<td><label>" + $(this).closest('tr').find('td:eq(2) input').val() + "</label></td>";
                tblWorking += "<td><label>" + $(this).closest('tr').find('td:eq(3) input').val() + "</label></td>";
                tblWorking += "</tr>";
            });
            //ProfessionalExpertise
            var tbl = $('#tbl-Expertise').children();
            var tblExpertise = "";
            $.each(tbl, function (keyT, valT) {
                tblExpertise += "<tr>";
                tblExpertise += "<td><span>" + (keyT + 1) + "</span></td>";
                tblExpertise += "<td><label>" + $(this).closest('tr').find('td:eq(1) select option:selected').text() + "</label></td>";
                tblExpertise += "<td><label>" + $(this).closest('tr').find('td:eq(2) select option:selected').text() + "</label></td>";
                tblExpertise += "<td><label>" + $(this).closest('tr').find('td:eq(3) select option:selected').text() + "</label></td>";
                tblExpertise += "</tr>";
            });

            var tbl = $('#tbl-Languages').children();
            var tblLanguages = "";
            $.each(tbl, function (keyT, valT) {
                tblLanguages += "<tr>";
                tblLanguages += "<td><span>" + (keyT + 1) + "</span></td>";
                tblLanguages += "<td><label>" + $(this).closest('tr').find('td:eq(1) select option:selected').text() + "</label></td>";
                tblLanguages += "<td><label>" + $(this).closest('tr').find('td:eq(2) select option:selected').text() + "</label></td>";
                tblLanguages += "<td><label>" + $(this).closest('tr').find('td:eq(3) input').val() + "</label></td>";
                tblLanguages += "</tr>";
            });
            //SalaryProcess
            var tbl = $('#tbl-SalaryProcess').children();
            var tblSalaryProcess = "";
            $.each(tbl, function (keyT, valT) {
                tblSalaryProcess += "<tr>";
                tblSalaryProcess += "<td><span>" + (keyT + 1) + "</span></td>";
                tblSalaryProcess += "<td><label>" + general.dateFormatJson($(this).closest('tr').find('td:eq(1) input').val(), true) + "</label></td>";
                tblSalaryProcess += "<td><label>" + $(this).closest('tr').find('td:eq(2) input').val() + "</label></td>";
                tblSalaryProcess += "<td><label>" + $(this).closest('tr').find('td:eq(3) input').val() + "</label></td>";
                tblSalaryProcess += "<td><label>" + $(this).closest('tr').find('td:eq(4) input').val() + "</label></td>";
                tblSalaryProcess += "<td><label>" + $(this).closest('tr').find('td:eq(5) input').val() + "</label></td>";
                tblSalaryProcess += "<td><label>" + $(this).closest('tr').find('td:eq(6) input').val() + "</label></td>";
                tblSalaryProcess += "</tr>";
            });



            var divToPrint = '';
            var template = $('#table-print-template').html();
            var divToPrint = Mustache.render(template, {
                Avatar: gAvatarImage,
                Employee: employee,
                Id: id,
                IdCard: idcard,
                DOB: dOB,
                Gender: gender,
                EmployeeTypeFK: employeeTypeFK,
                Nationality: nationalityFK,
                Birthplace: birthplace,
                OriginFK: originFK,
                NationFK: nationFK,
                ReligionFK: religionFK,
                IDNumber: iDNumber,
                IDDate: iDDate,
                IDPlace: iDPlace,
                PhoneNumber: phoneNumber,
                Email: email,
                ProvincePR: provincePR,
                DistrictPR: districtPR,
                WardPR: wardPR,
                PermanentResidence: permanentResidence,
                ProvinceAC: provinceAC,
                DistrictAC: districtAC,
                WardAC: wardAC,
                AccommodationCurrent: accommodationCurrent,
                InfoContactPerson: infoContactPerson,
                PhoneNumberContactPerson: phoneNumberContactPerson,
                TaxIDNumber: taxIdNumber,
                BankAccountNumber: bankAccountNumber,
                ATMAccountName: aTMAccountName,
                IDAccount: iDAccount,
                Notes: notes,
                LastUpdatedByFK: lastUpdatedByFK,
                DateModified: dateModified,
                Status: status,
                RdoSingle: rdoSingle,
                RdoMarried: rdoMarried,
                RdoDivorced: rdoDivorced,
                RdoRemarried: rdoRemarried,
                tblFamilyRelationship: tblFamily,
                NOChildren: nOChildren,
                NumberOfProfile: numberOfProfile,
                NumberOfContract: numberOfContract,
                LaborContractType: laborContractType,
                SignDate: signDate,
                TimeExpireContract: timeExpireContract,
                TimeExpireProbation: timeExpireProbation,
                StartDate: startDate,
                DepartmentFK: departmentFK,
                PositionFK: positionFK,
                InfoSaveFile: infoSaveFile,
                LayOffDate: layOffDate,
                tblWorkingProcess: tblWorking,
                Literacy: literacy,
                tblExpertise: tblExpertise,
                tblLanguages: tblLanguages,
                IDSocialInsurance: iDSocialInsurance,
                SalarySocialInsurance: salarySocialInsurance,
                SocialInsuranceDate: socialInsuranceDate,
                Salary: salary,
                NumberOfDependents: numberOfDependents,
                IsUnionMember: isUnionMember,
                TravelAllowance: travelAllowance,
                PositionAllowance: positionAllowance,
                SeniorityAllowances: seniorityAllowances,
                OtherAllowances: otherAllowances,
                tblSalaryProcess: tblSalaryProcess
            });
            //$.get('PrintEmployee.txt', function (data) {
            //    divToPrint = data;
            //}, "text");
            //var divToPrint = $('#section-print').html();
            var newWin = window.open('', 'Print-Window');
            newWin.document.open();
            var temp = '<html><head><meta charset="UTF-8"><meta charset="utf-8"><meta http-equiv="X-UA-Compatible" content="IE=edge"><meta name="viewport" content="width=device-width, initial-scale=1"><link href="/lib/bootstrap/dist/css/bootstrap.css" rel="stylesheet"><link href="/lib/font-awesome/css/font-awesome.css" rel="stylesheet"><link href="/lib/jquery-ui/themes/flick/jquery-ui.css" rel="stylesheet"><link href="/lib/nprogress/nprogress.css" rel="stylesheet"><link href="/lib/bootstrap-datepicker/dist/css/bootstrap-datepicker3.css" rel="stylesheet"><link href="/lib/notifyjs/dist/styles/metro/notify-metro.css" rel="stylesheet"><link href="/lib/ckeditor/skins/moono/editor.css" rel="stylesheet"><link href="/lib/timepicker.js/timepicker.min.css" rel="stylesheet"><link href="/admin-side/css/custom.css" rel="stylesheet"><link href="/admin-side/css/style.css" rel="stylesheet"><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"><meta charset="utf-8"><meta name="keywords" content="Classy Login form Responsive,Login form web template,Sign up Web Templates,Flat Web Templates,Login signup Responsive web template,Smartphone Compatible web template,free webdesigns for Nokia,Samsung,LG,SonyEricsson,Motorola web design"><link href="//fonts.googleapis.com/css?family=Roboto+Condensed:400,700" rel="stylesheet"><link href="/css/autocomplete.css" rel="stylesheet"></head>';
            newWin.document.write(temp + '<body onload="window.print();">' + divToPrint + '</body></html>');
            // newWin.print();
            newWin.document.close();
            //setTimeout(function () { newWin.close(); }, 10);
            //$('#modal-receipt').modal('show');
            //window.print();

        });
        $('#btn-add-relationship').on('click', function () {
            var template = $('#FamilyRelationship-template').html();
            var stt = $('#tbl-FamilyRelationship tr').length + 1;
            var render = Mustache.render(template, {
                KeyId: 0,
                stt: stt,
                FullName: '',
                YearOfBirth: '',
                //Gender: '',
                Relationship: '',
                Job: '',
                Died: ''
            });
            $('#tbl-FamilyRelationship').append(render);

            $(".year-picker").datepicker({
                format: "yyyy",
                minViewMode: 2,
                maxViewMode: 2,
                clearBtn: true,
                language: "vi",
            });
            //loadSTT($('#tbl-FamilyRelationship'));
        });
        $('#btn-add-working-process').on('click', function () {
            var template = $('#WorkingProcess-template').html();
            var render = Mustache.render(template, {
                KeyId: 0,
                MobilizeDate: '',
                NumberDesignation: '',
                OldWorkPlace: '',
                OldPosition: ''
            });
            $('#tbl-WorkingProcess').append(render);

            $(".date-picker").datepicker({
                format: "dd/mm/yyyy",
                maxViewMode: 2,
                todayBtn: "linked",
                clearBtn: true,
                language: "vi",
                daysOfWeekHighlighted: "0",
                todayHighlight: true
            });
        });
        $('#btn-add-language').on('click', function () {
            var template = $('#Languages-template').html();
            var stt = $('#tbl-Languages tr').length + 1;
            var language = $('#selLanguages-template').html();
            var level = $('#selLevels-template').html();
            var render = Mustache.render(template, {
                KeyId: 0,
                stt: stt,
                Language: language,
                Level: level,
                Certificate: ''
            });
            $('#tbl-Languages').append(render);
            //loadSTT($('#tbl-Languages'));
        });
        $('#btn-add-expertise').on('click', function () {
            var template = $('#Expertise-template').html();
            var stt = $('#tbl-Expertise tr').length + 1;
            var degree = $('#selLevels-template').html();
            var major = $('#selMajors-template').html();
            var trainingSystem = $('#selTrainingSystems-template').html();
            var render = Mustache.render(template, {
                KeyId: 0,
                stt: stt,
                Degree: degree,
                Major: major,
                TrainingSystem: trainingSystem
            });
            $('#tbl-Expertise').append(render);
            //loadSTT($('#tbl-Expertise'));
        });
        $('#btn-add-salary-process').on('click', function () {
            var template = $('#SalaryProcess-template').html();
            var stt = $('#tbl-SalaryProcess tr').length + 1;
            var render = Mustache.render(template, {
                KeyId: 0,
                stt: stt,
                FluctuationsDate: '',
                SalaryBeforeInscrease: '',
                PercentInscrease: '',
                AmountInscrease: '',
                SalaryAfterInscrease: '',
                Note: ''
            });
            $('#tbl-SalaryProcess').append(render);
            $('#txtSalaryBeforeInscrease' + stt).keyup(function (event) {
                // skip for arrow keys
                if (event.which >= 37 && event.which <= 40) return;

                // format number
                $(this).val(function (index, value) {
                    return value
                        .replace(/\D/g, "")
                        .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                        ;
                });
            });
            $('#txtAmountInscrease' + stt).keyup(function (event) {
                // skip for arrow keys
                if (event.which >= 37 && event.which <= 40) return;

                // format number
                $(this).val(function (index, value) {
                    return value
                        .replace(/\D/g, "")
                        .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                        ;
                });
            });
            $('#txtSalaryAfterInscrease' + stt).keyup(function (event) {
                // skip for arrow keys
                if (event.which >= 37 && event.which <= 40) return;

                // format number
                $(this).val(function (index, value) {
                    return value
                        .replace(/\D/g, "")
                        .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                        ;
                });
            });
            loadSTT($('#tbl-SalaryProcess'));

            $(".date-picker").datepicker({
                format: "dd/mm/yyyy",
                maxViewMode: 2,
                todayBtn: "linked",
                clearBtn: true,
                language: "vi",
                daysOfWeekHighlighted: "0",
                todayHighlight: true
            });
        });

    }
    //function UrlExists(url) {
    //    var http = new XMLHttpRequest();
    //    http.open('HEAD', url, false);
    //    http.send();
    //    return http.status != 404;
    //}
    function loadDetail(that) {

        $.ajax({
            type: "GET",
            url: "/employee/GetById",
            data: { id: that },
            dataType: "json",
            beforeSend: function () {
                general.startLoading();
            },
            success: function (response) {
                console.log(response);
                var data = response;
                UserData = data.UserBy;
                gId = data.KeyId;
                //getLastUpdateBy(data.LastupdatedByFk);
                $('#txtId').val(data.Id);
                if (data.UserBy != null)
                    $('#txtEmployee').val(data.UserBy.FullName);
                $('#txtEmployee').data('addressbookid', data.User_FK);
                if (data.UserBy.Avatar) {
                    gAvatarImage = data.UserBy.Avatar;
                    //var isExist = UrlExists(gAvatarImage);
                    //if (!isExist) $('#imgAvatar').css('background-image', 'url("admin-side/images/imagenotfound")');
                }
                else gAvatarImage = "admin-side/images/user.png";

                $('#imgAvatar').css('background-image', 'url("' + gAvatarImage + '")');





                var gender = "";
                if (data.UserBy.Gender == 0) gender = "Nam";
                if (data.UserBy.Gender == 1) gender = "Nữ";
                if (data.UserBy.Gender == 2) gender = "Khác";
                $('#txtGender').val(gender);
                $('#txtDOB').val(general.dateFormatJson(data.UserBy.Dob, true));
                $('#txtIDNumber').val(data.UserBy.IdNumber);
                $('#txtPhoneNumber').val(data.UserBy.PhoneNumber);
                $('#txtEmail').val(data.UserBy.Email);


                $('#txtIdCard').val(data.IdCard);
                $('#selBirthplace').val(data.Birthplace);
                $('#selEmployeeTypeFK').val(data.EmployeeTypeFK);
                $('#selOriginFK').val(data.OriginFk);
                $('#selNationFK').val(data.NationFk);
                $('#selNationality').val(data.NationalityFk);

                if (data.IDDate)
                    general.setDatePicker($('#dtIDDate'), general.dateFormatJson(data.IDDate, false));
                $('#txtPermanentResidence').val(data.PermanentResidence);


                $('#selProvincePR').val(data.ProvincePRFk);
                loadDistrict(data.ProvincePRFk, $('#selDistrictPR'), data.DistrictPRFK);
                loadWard(data.DistrictPRFK, $('#selWardPR'), data.WardPRFK);


                $('#txtAccommodationCurrent').val(data.AccommodationCurrent);


                $('#selProvinceAC').val(data.ProvinceACFk);
                loadDistrict(data.ProvinceACFk, $('#selDistrictAC'), data.DistrictACFK);
                loadWard(data.DistrictACFK, $('#selWardAC'), data.WardACFK);



                $('#txtInfoContactPerson').val(data.InfoContactPerson);
                $('#txtPhoneNumberContactPerson').val(data.PhoneNumberContactPerson);
                $('#txtATMAccountName').val(data.BankName);
                $('#txtIDAccount').val(data.IDAccount);



                $('#selReligionFK').val(data.ReligionFk);
                $('#selDepartmentFK').val(data.Department_FK);
                $('#selPositionFK').val(data.PositionFk);
                $('#txtTaxIDNumber').val(data.TaxIdnumber);
                $('#txtBankAccountNumber').val(data.BankAccountNumber);
                $('#txtNotes').val(data.Note);
                if (data.LastupdatedByFk != null)
                    $('#txtLastUpdatedByFK').val(data.LastupdatedBy.FullName);
                $('#dtDateModified').val(general.dateFormatJson(data.DateModified, true));
                if (data.Status == 1)
                    $('#chkStatus').prop('checked', true);
                else
                    $('#chkStatus').prop('checked', false);


                $("[name='optradio']").prop("checked", false);
                var FamilyC = data.FamilyCircumstances;
                if (FamilyC) {
                    var rdo = $('*[name="optradio"]');
                    $.each(rdo, function (keyT, valT) {
                        if ((valT.value == $.trim(FamilyC)) && ($.trim(FamilyC) != '') && ($.trim(FamilyC) != null))
                            $('*[name="optradio"][value="' + (FamilyC) + '"]').prop('checked', true);
                    });
                }
                $('#txtNOChildren').val(data.NOChildren);



                loadFamilyCircumstances(data.KeyId);
                loadHpWorkingProcessdetail(data.KeyId);
                loadHpExpertiseDetail(data.KeyId);
                loadHpLanguageDetail(data.KeyId);
                loadHpSalaryDetail(data.KeyId);



                $('#txtNumberOfProfile').val(data.NumberOfProfile);
                $('#txtNumberOfContract').val(data.NumberOfContract);
                $('#selLaborContractType').val(data.LaborContractType);
                if (data.SignContractDate) general.setDatePicker($('#dtSignDate'), data.SignContractDate);
                if (data.TimeExpireContract) general.setDatePicker($('#dtTimeExpireContract'), data.TimeExpireContract);
                if (data.TimeExpireProbation) general.setDatePicker($('#dtTimeExpireProbation'), data.TimeExpireProbation);
                if (data.StartDate) general.setDatePicker($('#dtStartDate'), data.StartDate);
                $('#txtInfoSaveFile').val(data.InfoSaveFile);
                if (data.LayOffDate) general.setDatePicker($('#dtLayOffDate'), data.LayOffDate);

                $('#selLiteracy').val(data.LiteracyFk);

                $('#txtIDSocialInsurance').val(data.IDSocialInsurance);
                $('#txtSalarySocialInsurance').val(general.toMoney(data.SalarySocialInsurance));
                if (data.SocialInsuranceDate) general.setDatePicker($('#txtSocialInsuranceDate'), data.SocialInsuranceDate);
                $('#txtSalary').val(general.toMoney(data.Salary));
                $('#txtNumberOfDependents').val(data.NumberOfDependents);
                $('#chkIsUnionMember').prop('checked', data.IsUnionMember);
                $('#txtTravelAllowance').val(general.toMoney(data.TravelAllowance));
                $('#txtPositionAllowance').val(general.toMoney(data.PositionAllowance));
                $('#txtSeniorityAllowances').val(general.toMoney(data.SeniorityAllowances));
                $('#txtOtherAllowances').val(general.toMoney(data.OtherAllowances));
                $('#modal-add-edit').modal('show');
                general.stopLoading();

            },
            error: function (status) {
                general.notify('Có lỗi xảy ra', 'error');
                general.stopLoading();
            }
        });
    }




    function loadSTT(that) {
        $that = that;
        var tbl = $that.children();
        $.each(tbl, function (keyT, valT) {
            $(this).closest('tr').find('td:first span').html(keyT + 1)
        });
    }

    function resetFormMaintainance() {
        $('#frmMaintainance').trigger('reset');

    }
}

function loadData(isPageChanged) {
    var template = $('#table-template').html();
    var render = "";
    $.ajax({
        type: 'GET',
        url: '/Home/GetAllLoaiSP',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            console.log(response);

            //$('#lblTotalRecords').text(response.RowCount);
            //$('#tbl-content').html(render);
            //wrapPaging(response.RowCount, function () {
            //    loadData();
            //}, isPageChanged);
        },
        error: function (status) {
            console.log(status);
            //general.notify('Không thể load dữ liệu', 'error');
        }
    });
}
function wrapPaging(recordCount, callBack, changePageSize) {
    var totalsize = Math.ceil(recordCount / general.configs.pageSize);
    //Unbind pagination if it existed or click change pagesize
    if ($('#paginationUL a').length === 0 || changePageSize === true) {
        $('#paginationUL').empty();
        $('#paginationUL').removeData("twbs-pagination");
        $('#paginationUL').unbind("page");
    }
    //Bind Pagination Event
    if (totalsize > 0)
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                general.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
}
