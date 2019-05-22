var loginController = function () {
    this.initialize = function () {
        registerEvents();
    }

    function registerEvents() {
        $('#formLogin').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                txtEmailLogin: {
                    required: true
                },
                txtPasswordLogin: {
                    required: true
                }
            }
        });

        $('#btnLogin').on('click', function (e) {
            e.preventDefault();
            Login(e);
        });
	}
    

    
}

function Login(e) {
    if ($('#formLogin').valid()) {
        e.preventDefault();
        var username = $('#txtEmailLogin').val();
        var password = $('#txtPasswordLogin').val();

        var data = {
            Username: username,
            Password: password,
            RememberMe: true
        };

        $.ajax({
            url: '/Home/Login',
            type: 'POST',
            data: { LoginVm: data },
            beforeSend: function () {
                general.startLoad();
            },
            success: function (response) {
                console.log(response);
                if (response.Status == "OK") {
                    if (response.Result.UserType == 2) {
                        window.location.href = "/Webmaster/Index";
                    }
                    else {
                        general.notify("Bạn không được phép truy cập!", 'error');
                    }

                }
                else {
                    general.notify(response.Result + '!', 'error');
                }
                general.stopLoad();
            },
            error: function (status) {
                console.log(status);
                general.notify('Email hoặc mật khẩu không đúng!', 'error');
                general.stopLoad();
            }
        });
    }
}