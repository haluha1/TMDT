homeController = function () {
    this.initialize = function () {
        //loadData();
        //TestSave();
        registerEvents();
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
        //$('.yearpicker').datepicker({
        //    format: "yyyy",
        //    //todayBtn: "linked",
        //    clearBtn: true,
        //    language: "vi",
        //    todayHighlight: true,
        //    startView: 2,
        //    minViewMode: 2
        //});
        
        //loadReligion();
        
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            invalidHandler: function (event, validator) {
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
                }
            },
            rules: {
                
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
        

        $('body').on('click', '.yeuthich', function (e) {
            e.preventDefault();
            $(this).prop('disabled', true);
            var that = $(this).data('id');
            likeProduct(that);
        });

        
        

    }
    //function UrlExists(url) {
    //    var http = new XMLHttpRequest();
    //    http.open('HEAD', url, false);
    //    http.send();
    //    return http.status != 404;
    //}
    function likeProduct(that) {

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
        url: '/Sanpham/GetAllSanPham',
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

function TestSave() {
    var data = {
        KeyId: 51,
        masp: 51,
        tensp: "Sp test",
        maloai: 1,
        mancc: 1,
        dongia: 9999,
        soluong: 1,
        mota: "1",
        tenhinh: "1",
        khuyenmai: 0
    };

    $.ajax({
        type: "POST",
        url: "/Sanpham/SaveEntity",
        data: { sanphamVm: data },
        dataType: "json",
        beforeSend: function () {
            general.startLoading();
        },
        success: function (response) {
            console.log(response);
            general.stopLoading();
        },
        error: function (status) {
            general.notify('Có lỗi trong khi ghi danh bạ!', 'error');
            general.stopLoading();
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
