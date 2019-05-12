var modal = document.getElementById('user');

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

function validateForm() {

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
                var avatarSrc = response.Result.Avatar == '' ? "/img/login.png" : response.Result.Avatar;
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
    return false;
}

var mainController = function () {
    this.initialize = function () {
        loadData();
        Rating();
        //TestSave();
        registerEvents();
    }
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

		$('body').on('click', '.yeuthich', function (e) {
			e.preventDefault();
			$(this).prop('disabled', true);
			var that = $(this).data('id');
			likeProduct(that);
		});	

        $("#frmMaintainance").on('submit', function (e) {
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

        });

        $('#btnSearch').on('click', function () {
            sendEmail();
        });

    }

    function resetFormMaintainance() {
        $('#frmMaintainance').trigger('reset');

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
				general.notify(response.Result, 'Thêm thành công');
			}

		},
		error: function (status) {
			general.notify('Có lỗi xảy ra', 'error');
			general.stopLoading();
		}
	});
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
