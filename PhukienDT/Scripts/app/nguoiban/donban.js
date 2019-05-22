var donbanController = function () {
    this.initialize = function () {
        loadDataHd();
        registerEvents();
    }

    function registerEvents() {
        //$('body').on('click', '#xemcthd', function () {
        //    var Id = $(this).parent().parent().parent().find('td:eq(0)').text();
        //    loadcthd(Id);
        //});


        general.configs.pageSize = 12;

        $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
            var target = $(e.target).attr("href") // activated tab

            switch (target) {
                case "#home":
                    loadDataHd(true);
                    break;
                case "#menu1":
                    loadDataChoxacnhan(true);
                    break;
                case "#menu2":
                    loadDataGiaohang(true);
                    break;
                case "#menu3":
                    loadDataHoanthanh(true);
                    break;
                case "#menu4":
                    loadDataHuy(true);
                    break;
            };
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

        $('body').on('click', '.btnView', function (e) {
            e.preventDefault();
            //document.getElementById('modal-add-edit').style.display = 'block';
            var that = $(this).data('id');
            resetFormMaintainance();
            loadcthd(that);
        });

        $('body').on('click', '.btnAccept', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            var data = "Giao hàng";
            UpdateInvoice(that,data);
        });
        $('body').on('click', '.btnSuccess', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            var data = "Hoàn thành";
            UpdateInvoice(that,data);
        });
        $('body').on('click', '.btnCancel', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            var data = "Hủy";
            UpdateInvoice(that,data);
        });




        //$('#btnAccept').on('click', function () {
        //    var data = "Giao hàng";
        //    UpdateInvoice(data);
        //});
        //$('#btnSuccess').on('click', function () {
        //    var data = "Hoàn thành";
        //    UpdateInvoice(data);
        //});
        //$('#btnCancel').on('click', function () {
        //    var data = "Hủy";
        //    UpdateInvoice(data);
        //});



    }
    

    function likeProduct(that) {

        $.ajax({
            type: "POST",
            url: "/Hoadon/Like",
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


function loadDataHd(isPageChanged) {
    var template = $('#table-template').html();
    var render = "";
    $.ajax({
        type: 'GET',
        url: '/Hoadon/GetAllHoadon',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: {
            keyword: $('#txtKeyword').val(),
            page: general.configs.pageIndex,
            pageSize: general.configs.pageSize
        },
        success: function (response) {
            console.log(response);
            $.each(response.Result, function (i, item) {
                //begin
                if (i % 4 == 0 && i % 2 == 0) {
                    render += '<div class="row row-space">'
                }
                //var imgsrc = "";
                //switch (item.LoaispNavigation.KeyId) {
                //    case 2: {
                //        imgsrc = "/img/Bao/" + item.tenhinh;
                //        break;
                //    }
                //    case 3: {
                //        imgsrc = "/img/Ring/" + item.tenhinh;
                //        break;
                //    }
                //    case 4: {
                //        imgsrc = "/img/Khac/" + item.tenhinh;
                //        break;
                //    }
                //    default: {
                //        imgsrc = "/img/" + item.tenhinh;
                //        break;
                //    }
                //}
                render += Mustache.render(template, {
                    KeyId: item.KeyId,
                    MaHD: item.mahd,
                    TenKH: item.makh + "- " + item.KhachHangNavigation.TaiKhoanBy.hoten,
                    dc: item.KhachHangNavigation.TaiKhoanBy.diachi,
                    sdt: item.KhachHangNavigation.TaiKhoanBy.sdt,
                    Total: item.tongtien,
                    //img: imgsrc,
                    Trangthai: item.tinhtrang,
                });
                if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
                    render += '</div>'
                }

            });
            $('#lblTotalRecords').text(response.PageCount);
            $('#new-Product').html(render);
            wrapPaging(response.PageCount, function () {
                loadDataHd();
            }, isPageChanged);
        },
        error: function (status) {
            console.log(status);
            general.notify('Không thể load dữ liệu', 'error');
        }
    });
}
function loadDataChoxacnhan(isPageChanged) {
    var template1 = $('#table-template1').html();
    var render1 = "";
    $.ajax({
        type: 'GET',
        url: '/Hoadon/GetAllHoadonChoxacnhan',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: {
            keyword: $('#txtKeyword').val(),
            page: general.configs.pageIndex,
            pageSize: general.configs.pageSize
        },
        success: function (response) {
            console.log(response);
            $.each(response.Result, function (i, item) {
                //begin
                if (i % 4 == 0 && i % 2 == 0) {
                    render1 += '<div class="row row-space">'
                }

                render1 += Mustache.render(template1, {
                    KeyId: item.KeyId,
                    MaHD: item.mahd,
                    TenKH: item.makh + "- " + item.KhachHangNavigation.TaiKhoanBy.hoten,
                    dc: item.KhachHangNavigation.TaiKhoanBy.diachi,
                    sdt: item.KhachHangNavigation.TaiKhoanBy.sdt,
                    Total: item.tongtien,
                    Trangthai: item.tinhtrang,
                });
                if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
                    render1 += '</div>'
                }

            });
            $('#lblTotalRecords').text(response.PageCount);
            $('#new-Product1').html(render1);
            wrapPaging(response.PageCount, function () {
                loadDataChoxacnhan();
            }, isPageChanged);
        },
        error: function (status) {
            console.log(status);
            general.notify('Không thể load dữ liệu', 'error');
        }
    });
}
function loadDataGiaohang(isPageChanged) {
    var template2 = $('#table-template2').html();
    var render2 = "";
    $.ajax({
        type: 'GET',
        url: '/Hoadon/GetAllHoadonGiaohang',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: {
            keyword: $('#txtKeyword').val(),
            page: general.configs.pageIndex,
            pageSize: general.configs.pageSize
        },
        success: function (response) {
            console.log(response);
            $.each(response.Result, function (i, item) {
                //begin
                if (i % 4 == 0 && i % 2 == 0) {
                    render2 += '<div class="row row-space">'
                }

                render2 += Mustache.render(template2, {
                    KeyId: item.KeyId,
                    MaHD: item.mahd,
                    TenKH: item.makh + "- " + item.KhachHangNavigation.TaiKhoanBy.hoten,
                    dc: item.KhachHangNavigation.TaiKhoanBy.diachi,
                    sdt: item.KhachHangNavigation.TaiKhoanBy.sdt,
                    Total: item.tongtien,
                    Trangthai: item.tinhtrang,
                });
                if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
                    render2 += '</div>'
                }

            });
            $('#lblTotalRecords').text(response.PageCount);
            $('#new-Product2').html(render2);
            wrapPaging(response.PageCount, function () {
                loadDataGiaohang();
            }, isPageChanged);
        },
        error: function (status) {
            console.log(status);
            general.notify('Không thể load dữ liệu', 'error');
        }
    });
}
function loadDataHoanthanh(isPageChanged) {
    var template3 = $('#table-template3').html();
    var render3 = "";
    $.ajax({
        type: 'GET',
        url: '/Hoadon/GetAllHoadonHoanthanh',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: {
            keyword: $('#txtKeyword').val(),
            page: general.configs.pageIndex,
            pageSize: general.configs.pageSize
        },
        success: function (response) {
            console.log(response);
            $.each(response.Result, function (i, item) {
                //begin
                if (i % 4 == 0 && i % 2 == 0) {
                    render3 += '<div class="row row-space">'
                }

                render3 += Mustache.render(template3, {
                    KeyId: item.KeyId,
                    MaHD: item.mahd,
                    TenKH: item.makh + "- " + item.KhachHangNavigation.TaiKhoanBy.hoten,
                    dc: item.KhachHangNavigation.TaiKhoanBy.diachi,
                    sdt: item.KhachHangNavigation.TaiKhoanBy.sdt,
                    Total: item.tongtien,
                    Trangthai: item.tinhtrang,
                });
                if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
                    render3 += '</div>'
                }

            });
            $('#lblTotalRecords').text(response.PageCount);
            $('#new-Product3').html(render3);
            wrapPaging(response.PageCount, function () {
                loadDataHoanthanh();
            }, isPageChanged);
        },
        error: function (status) {
            console.log(status);
            general.notify('Không thể load dữ liệu', 'error');
        }
    });
}
function loadDataHuy(isPageChanged) {
    var template4 = $('#table-template4').html();
    var render4 = "";
    $.ajax({
        type: 'GET',
        url: '/Hoadon/GetAllHoadonHuy',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: {
            keyword: $('#txtKeyword').val(),
            page: general.configs.pageIndex,
            pageSize: general.configs.pageSize
        },
        success: function (response) {
            console.log(response);
            $.each(response.Result, function (i, item) {
                //begin
                if (i % 4 == 0 && i % 2 == 0) {
                    render4 += '<div class="row row-space">'
                }

                render4 += Mustache.render(template4, {
                    KeyId: item.KeyId,
                    MaHD: item.mahd,
                    TenKH: item.makh + "- " + item.KhachHangNavigation.TaiKhoanBy.hoten,
                    dc: item.KhachHangNavigation.TaiKhoanBy.diachi,
                    sdt: item.KhachHangNavigation.TaiKhoanBy.sdt,
                    Total: item.tongtien,
                    Trangthai: item.tinhtrang,
                });
                if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
                    render4 += '</div>'
                }

            });
            $('#lblTotalRecords').text(response.PageCount);
            $('#new-Product4').html(render4);
            wrapPaging(response.PageCount, function () {
                loadDataHuy();
            }, isPageChanged);
        },
        error: function (status) {
            console.log(status);
            general.notify('Không thể load dữ liệu', 'error');
        }
    });
}

function loadcthd(id) {
    var template5 = $('#table-template5').html();
    var render5 = "";
    $.ajax({
        type: 'GET',
        url: '/Hoadon/GetAllCthdById',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: { id: id },
        success: function (response) {
            console.log(response);
            $('#btnAccept').data('id', response.KeyId);
            $('#btnSuccess').data('id', response.KeyId);
            $('#btnCancel').data('id', response.KeyId);
            if (response.tinhtrang == "Chờ xác nhận") {
                $('#btnAccept').css('display', 'inline-block');
                $('#btnSuccess').css('display', 'none');
                $('#btnCancel').css('display', 'inline-block');
            }
            if (response.tinhtrang == "Giao hàng") {
                $('#btnAccept').css('display', 'none');
                $('#btnSuccess').css('display', 'inline-block');
                $('#btnCancel').css('display', 'inline-block');
            }
            if (response.tinhtrang == "Hoàn thành" || response.tinhtrang == "Hủy") {
                $('#btnAccept').css('display', 'none');
                $('#btnSuccess').css('display', 'none');
                $('#btnCancel').css('display', 'none');
            }
            $('#txtKeyId').val(response.KeyId);
            $('#txtHdId').val(response.mahd);
            $('#dtDateCreate').val(response.thoigian);
            $('#txtCustomer').val(response.Name);
            $('#txtPhoneNumber').val(response.Phone);
            $('#txtAddress').val(response.Address);
            $('#txtNote').val(response.Note);
            $('#txtTotalMoney').text(response.tongtien + " VNĐ");
            $.each(response.Cthdons, function (i, item) {
                var imgsrc = "";
                switch (item.SanphamNavigation.LoaispNavigation.KeyId) {
                    case 2: {
                        imgsrc = "/img/Bao/" + item.SanphamNavigation.tenhinh;
                        break;
                    }
                    case 3: {
                        imgsrc = "/img/Ring/" + item.SanphamNavigation.tenhinh;
                        break;
                    }
                    case 4: {
                        imgsrc = "/img/Khac/" + item.SanphamNavigation.tenhinh;
                        break;
                    }
                    default: {
                        imgsrc = "/img/" + item.SanphamNavigation.tenhinh;
                        break;
                    }
                }
                if (item.KeyId <= 50) imgsrc = "/img/" + item.SanphamNavigation.tenhinh;

                render5 += Mustache.render(template5, {
                    ProductCode: item.SanphamNavigation.masp,
                    ProductName: item.SanphamNavigation.tensp,
                    Imgsrc: imgsrc,
                    Price: item.SanphamNavigation.dongia,
                    Qty: item.soluong,
                    SubTotal: item.thanhtien
                });

            });
                
            $('#new-Product5').html(render5);
            document.getElementById('modal-add-edit').style.display = 'block';
            //wrapPaging(response.PageCount, function () {
            //    loadcthd();
            //}, isPageChanged);
        },
        error: function (status) {
            console.log(status);
        }
    });
}

function UpdateInvoice(that,data) {
    //var id = $('#txtKeyId').val();

    $.ajax({
        type: "POST",
        url: "/Hoadon/UpdateStatus",
        data: { KeyId: that, Status: data },
        dataType: "json",
        beforeSend: function () {
            general.startLoad();
        },
        success: function (response) {
            if (response.Status == "OK") {
                general.notify("Cập nhật đơn hàng thành công!", 'success');
            }
                
            console.log(response);
            general.stopLoad();
            loadDataHd(true);
            loadDataChoxacnhan(true);
            loadDataGiaohang(true);
            loadDataHoanthanh(true);
            loadDataHuy(true);
            document.getElementById('modal-add-edit').style.display = 'none';

        },
        error: function (status) {
            general.stopLoad();
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
        url: "/Hoadon/SaveEntity",
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