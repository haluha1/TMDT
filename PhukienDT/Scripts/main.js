var modal = document.getElementById('user');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}





var mainController = function () {
    this.initialize = function () {
        //Rating();
        registerEvents();
        resetFormMaintainance();
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
                },
                uname: {
                    required: true
                },
                pass: {
                    required: true
                },
                sdt: {
                    required: true,
                    number: true
                },
                stk: {
                    required: true,
                    number: true
                }

            },
            messages: {
                txtEmail: {
                    required: "Hãy nhập email!"
                },
                txtPassword: {
                    required: "Hãy nhập mật khẩu!"
                },
                uname: {
                    required: "Hãy nhập họ tên!"
                },
                pass: {
                    required: "Hãy nhập mật khẩu!"
                },
                sdt: {
                    required: "Hãy nhập sđt!",
                    number: "Sđt phải là các ký tự số!"
                },
                stk: {
                    required: "Hãy nhập số tài khoản!",
                    number: "Số tài khoản phải là số!"
                }

            }
        });


        $('#btnSearch').on('click', function () {
            loadData(true);
        });

        $('body').on('click', '#btnActive', function (e) {
            confirmRegister(e);
        });
        $('body').on('click', '.yeuthich', function (e) {
            e.preventDefault();
            $(this).prop('disabled', true);
            var that = $(this).data('id');
            likeProduct(that);
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


function likeProduct(that) {
    $.ajax({
        type: "POST",
        url: "/Sanpham/Like",
        data: { id: that },
        dataType: "json",
        beforeSend: function () {
            general.startLoading();
        },
        success: function (response) {
            console.log(response);
            if (response.Status == "OK") {
                general.notify(response.Result, 'success');
            }

        },
        error: function (status) {
            general.notify('Có lỗi xảy ra', 'error');
            general.stopLoading();
        }
    });
}

function confirmRegister(e) {
    if ($('#frmMaintainance').valid()) {
        e.preventDefault();
        var code = $('#txtCode').val();
        var that = $('#btnActive').data('id');
        $.ajax({
            url: '/Home/ConfirmCode',
            type: 'POST',
            data: { id: that, Code: code },
            success: function (response) {
                console.log(response);
                if (response.Status == "OK" && response.Result.KeyId != 0) {

                    var avatarSrc = "/img/login.png";
                    if (response.Result.Avatar == null || response.Result.Avatar == '') {
                        avatarSrc = "/img/login.png";
                    }
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
                    if (response.Result.UserType == 0) {
                        var avatarSrc = response.Result.Avatar == '' ? "/img/login.png" : "/img/" + response.Result.Avatar;
                        general.notify('Xin chào ' + response.Result.UserName + '!', 'success');
                        $('#avatar').prop('src', avatarSrc); // Dùng ..\\img\\search.png hoặc /img/search.png
                        $('#btnExit').css('display', 'block');
                        $('#btnLogin').attr('onclick', '');
                        $('#user').css('display', 'none');
                        $('#frmMaintainance').trigger('reset');
                    }
                    if (response.Result.UserType == 1) {
                        window.location.href = "/Nguoiban";
                    }
                    
                }
                else {
                    general.notify(response.Result + '!', 'error');
                }

            },
            error: function (status) {
                console.log(status);
                general.notify('Email hoặc mật khẩu không đúng!', 'error');
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
                    var template = $('#SignUpConfirm-template').html();
                    var render = "";
                    render += Mustache.render(template, {
                        ID: response.Result.KeyId
                    });
                    $('#btnArea').html('');
                    $('#form-body').fadeOut();
                    $('#form-body').html(render);
                    $('#form-body').fadeIn();
                }
                else {
                    general.notify(response.Result, 'error');
                }

            },
            error: function (status) {
                console.log(status);
                general.notify('Email hoặc mật khẩu không đúng!', 'error');
                general.stopLoading();
            }
        });
    }
    else {
        $('#txtname').focus();
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
