﻿var modal = document.getElementById('user');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}




//$('#frmMaintainance').validate({
//    errorClass: 'red',
//    ignore: [],
//    lang: 'vi',
//    invalidHandler: function (event, validator) {
//        var errors = validator.numberOfInvalids();
//        if (errors) {
//            var errorElement = validator.errorList[0].element;
//            var errorElementTag = validator.errorList[0].element.labels[0].textContent;
//            if (errorElement.type.includes("text")) {
//                general.notify('Hãy nhập ' + errorElementTag, 'error');
//            }
//            if (errorElement.type.includes("select")) {
//                general.notify('Hãy chọn ' + errorElementTag, 'error');
//            }
//        }
//    },
//    rules: {
//        uname: {
//            required: true
//        },
//        psw: {
//            required: true
//        }
//    }
//});

var mainController = function () {
    this.initialize = function () {
        loadData();
        Rating();
        //TestSave();
        registerEvents();
        resetFormMaintainance();
        //$('#areaSignUp').fadeOut();
        //$('#areaSignIn').fadeIn();
    }
    var gIsSignInOn = true;
    function registerEvents() {
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
                txtEmail: {
                    required: true,
                    email: true
                },
                txtPassword: {
                    required: true
                }
            },
            messages: {
                txtEmail: {
                    required: "Hãy nhập email!"
                },
                txtPassword: {
                    required: "Hãy nhập mật khẩu!"
                }
            }
        });
        

        $('#btnSearch').on('click', function () {
            sendEmail();
        });

        $('#btnRegister').on('click', function (e) {
            if (gIsSignInOn == true) {
                var template = $('#SingUp-template').html();
                $('#form-body').fadeOut();
                $('#form-body').html(template);
                $('#form-body').fadeIn();
                resetFormMaintainance();
                gIsSignInOn = false;
            }
            else {
                Register(e);
            }
        });

        $('#btnSubmit').on('click', function (e) {
            if (gIsSignInOn == true) {
                Login(e);
            }
            else {
                var template = $('#SignIn-template').html();
                $('#form-body').fadeOut();
                $('#form-body').html(template);
                $('#form-body').fadeIn();
                resetFormMaintainance();
                gIsSignInOn = true;
                
            }
        });

    }

    function resetFormMaintainance() {
        $('#frmMaintainance').trigger('reset');
        $('#frmMaintainance').validate().resetForm();
    }
}

function loadData(isPageChanged) {
    $.ajax({
        url: '/Home/IsLogin',
        type: 'POST',
        success: function (response) {
            console.log(response);
            if (response.Status == "OK") {
                var avatarSrc = response.Result.Avatar == '' ? "/img/login.png" : response.Result.Avatar;
                general.notify('Xin chào ' + response.Result.UserName + '!', 'success');
                $('#avatar').prop('src', avatarSrc); // Dùng ..\\img\\search.png hoặc ../img/search.png
                $('#btnLogin').attr('onclick', '');
            }
        },
        error: function (status) {
            console.log(status);
        }
    });
}

function Login(e) {
    if ($('#frmMaintainance').valid()) {
        e.preventDefault();
        var username = $('#txtEmail').val();
        var password = $('#txtPassword').val();
        var rememberMe = $('#chkRememberMe').prop('checked');

        var data = {
            Username: username,
            Password: password,
            RememberMe: rememberMe
        };

        $.ajax({
            url: '/Home/Login',
            type: 'POST',
            data: { LoginVm: data },
            success: function (response) {
                console.log(response);
                if (response.Status == "OK") {
                    var avatarSrc = response.Result.Avatar == '' ? "../img/login.png" : response.Result.Avatar;
                    general.notify('Xin chào ' + response.Result.UserName + '!', 'success');
                    $('#avatar').prop('src', avatarSrc); // Dùng ..\\img\\search.png hoặc ../img/search.png
                    $('#btnLogin').attr('onclick', '');
                    $('#user').css('display', 'none');
                    $('#frmMaintainance').trigger('reset');
                    general.stopLoading();
                }
                else {
                    general.notify(response.Result + '!', 'error');
                }

            },
            error: function (status) {
                console.log(status);
                general.notify('Email hoặc mật khẩu không đúng!', 'error');
                general.stopLoading();
            }
        });
    }
}


function Register(e) {
    if ($('#frmMaintainance').valid()) {
        e.preventDefault();
        var Hoten = $('#txtname').val();
        var Email = $('#txtEmaildk').val();
        var Password = $('#txtpass').val();
        var Diachi = $('#txtaddress').val();
        var Sdt = $('#txtsdt').val();
        var STK = $('#txtstk').val();
        var userType = $('input[name=userType]:checked').val()
        var rememberMe = $('#chkRememberMe').prop('checked');

        var data = {
            KeyId: 0,
            matk: 0,
            hoten: Hoten,
            email: Email,
            diachi: Diachi,
            sdt: Sdt,
            sotk: STK,
            matkhau: Password,
            avatar: "",
            UserType: userType
        };

        $.ajax({
            url: '/Home/Register',
            type: 'POST',
            data: { TaikhoanVm: data },
            success: function (response) {
                console.log(response);
                if (response.Status == "OK") {
                    var avatarSrc = response.Result.Avatar == '' ? "../img/login.png" : response.Result.Avatar;
                    general.notify('Xin chào ' + response.Result.UserName + '!', 'success');
                    $('#avatar').prop('src', avatarSrc); // Dùng ..\\img\\search.png hoặc ../img/search.png
                    $('#btnLogin').attr('onclick', '');
                    $('#user').css('display', 'none');
                    $('#frmMaintainance').trigger('reset');
                    general.stopLoading();
                }
                else {
                    general.notify(response.Result + '!', 'error');
                }

            },
            error: function (status) {
                console.log(status);
                general.notify('Email hoặc mật khẩu không đúng!', 'error');
                general.stopLoading();
            }
        });
    }
}

function sendEmail() {
    $.ajax({
        url: '/Home/ConfirmEmail',
        type: 'POST',
        data: {
            toEmailAddress: "blackpigkun@gmail.com",
            subject: "Active code",
            content: "Code nè"
        },
        success: function (response) {
            console.log(response);
            
        },
        error: function (status) {
            console.log(status);
        }
    });
}

function Rating() {
    var data = {
        KeyId: 0,
        RatingFK: 1,
        makh: 3,
        diem: 10,
        comment: "abc"

    };
    $.ajax({
        url: '/Sanpham/Rating',
        type: 'POST',
        success: function (response) {
            console.log(response);

        },
        error: function (status) {
            console.log(status);
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
