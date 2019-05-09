var modal = document.getElementById('user');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}



var slideIndex;
// KHai bào hàm hiển thị slide
function showSlides() {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }

    slides[slideIndex].style.display = "block";
    dots[slideIndex].className += " active";
    //chuyển đến slide tiếp theo
    slideIndex++;
    //nếu đang ở slide cuối cùng thì chuyển về slide đầu
    if (slideIndex > slides.length - 1) {
        slideIndex = 0
    }
    //tự động chuyển đổi slide sau 5s
    setTimeout(showSlides, 3000);
}
//mặc định hiển thị slide đầu tiên 
showSlides(slideIndex = 0);


function currentSlide(n) {
    showSlides(slideIndex = n);
}


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
            var avatarSrc = response.Avatar == '' ? "../img/login.png" : response.Avatar;
            general.notify('Xin chào ' + response.UserName + '!', 'success');
            $('#avatar').prop('src', avatarSrc); // Dùng ..\\img\\search.png hoặc ../img/search.png
            $('#btnLogin').attr('onclick', '');
            $('#user').css('display', 'none');
            $('#frmMaintainance').trigger('reset');
            general.stopLoading();
        },
        error: function (status) {

            console.log(status);
            
            return true;
            general.notify('Email hoặc mật khẩu không đúng!', 'error');
            general.stopLoading();
        }
    });
    return false;
}

mainController = function () {
    this.initialize = function () {
        loadData();
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
        
        
    }

    function resetFormMaintainance() {
        $('#frmMaintainance').trigger('reset');

    }
}

function loadData(isPageChanged) {
    $.ajax({
        url: '/Home/IsLogin',
        type: 'POST',
        success: function (response) {
            console.log(response);
            if (response) {
                var avatarSrc = response.Avatar == '' ? "../img/login.png" : response.Avatar;
                general.notify('Xin chào ' + response.UserName + '!', 'success');
                $('#avatar').prop('src', avatarSrc); // Dùng ..\\img\\search.png hoặc ../img/search.png
                $('#btnLogin').attr('onclick', '');
            }
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
