
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





homeController = function () {
    this.initialize = function () {
        loadData();
        TestSave();
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
        if ((typeof $.cookie("cart") === 'undefined') || $.cookie("cart") == null) {
            var cart = [];
            $.cookie("cart", cart);
            //JSON.parse($.cookie('cart'));
        }
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
		$('body').on('click', '.buy', function (e) {
			window.location.href = "/Sanpham/ctsp/" + $(this).data('id');
		});
        
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
        

        

        
        

    }
    //function UrlExists(url) {
    //    var http = new XMLHttpRequest();
    //    http.open('HEAD', url, false);
    //    http.send();
    //    return http.status != 404;
    //}
    




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
        url: '/Sanpham/GetNewProduct',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: {
            keyword: $('#txtKeyword').val(),
            page: 1,
            pageSize: 8
        },
        success: function (response) {
            console.log(response);
            $.each(response.Result, function (i, item) {
                //begin
                if (i % 4 == 0 && i % 2 == 0) {
                    render += '<div class="row row-space">'
                }
                var imgsrc = "";
                if (item.KeyId <= 50) {
                    imgsrc = "/img/" + item.tenhinh;
                }
                else {
                    switch (item.LoaispNavigation.KeyId) {
                        case 2: {
                            imgsrc = "/img/Bao/" + item.tenhinh;
                            break;
                        }
                        case 3: {
                            imgsrc = "/img/Ring/" + item.tenhinh;
                            break;
                        }
                        case 4: {
                            imgsrc = "/img/Khac/" + item.tenhinh;
                            break;
                        }
                        default: {
                            imgsrc = "/img/" + item.tenhinh;
                            break;
                        }
                    }
                }
                render += Mustache.render(template, {
                    ProductID: item.KeyId,
                    ProductName: item.tensp,
                    Price: item.dongia,
                    img: imgsrc
                });
                //end
                if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
                    render += '</div>'
                }

            });
            //$('#lblTotalRecords').text(response.PageCount);
            $('#new-Product').html(render);
            //wrapPaging(response.PageCount, function () {
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
    // San pham
    //var data = {
    //    KeyId: 51,
    //    masp: 51,
    //    tensp: "Sp test",
    //    maloai: 1,
    //    mancc: 1,
    //    dongia: 9999,
    //    soluong: 1,
    //    mota: "1",
    //    tenhinh: "1",
    //    khuyenmai: 0
    //};

    //Rating
    //data = {
    //    KeyId: 0,
    //    makh: 3,
    //    diem: 10,
    //    comment: "abc",
    //    RatingFor: 0, //0: Product  -  1: Merchant
    //    mancc: null,
    //    masp: 1
    //};

    var myAry = [1, 2, 3];
    $.ajax({
        type: "POST",
        url: "/KhachHang/AddToCart",
        data: { id: 1 },
        dataType: "json",
        beforeSend: function () {
            general.startLoading();
        },
        success: function (response) {
            console.log(response);
            if (response == "NOT LOGIN!") {
                $.cookie('cart', JSON.stringify(myAry));
            }
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

function CreateRandomString() {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < 6; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
}
