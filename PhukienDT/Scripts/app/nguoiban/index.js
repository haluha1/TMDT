var nguoibanController = function () {
    this.initialize = function () {
        loadData();
        //TestSave();
        registerEvents();
    }
   
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
        general.configs.pageSize = 10;
        //$("#inputGroupFile01").on('change', function () {
        //    var dtl = {
        //        Name: "AAA",
        //        Type: 1,
        //        Price: 1,
        //        Quantity: 100,
        //        Descrip: "ABC DEF GHI"
        //    };



        //    var fileUpload = $(this).get(0);
        //    var files = fileUpload.files;
        //    var data = new FormData();

        //    if (files.length == 1) {
        //        for (var i = 0; i < files.length; i++) {
        //            data.append("UploadedImage", files[i]);
        //        }
        //        data.append("DTL", dtl);
        //        $.ajax({
        //            type: "POST",
        //            url: "/Sanpham/Upload",
        //            contentType: false,
        //            processData: false,
        //            data: data,
        //            success: function (path) {
        //                console.log(path);
        //                gAvatarImage = path;
        //                $('#imgAvatar').css('background-image', 'url("' + gAvatarImage + '")');
        //                //$('#lblAvatar').text(files[0].name);
        //            },
        //            error: function () {
        //                general.notify('Lỗi khi upload ảnh !', 'error');
        //            }
        //        });
        //    }
        //});


        $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
            var target = $(e.target).attr("href") // activated tab

            switch (target) {
                case "#home":
                    loadData(true);
                    break;
                case "#menu1":
                    loadDataCon(true);
                    break;
                case "#menu2":
                    loadDataHet(true);
                    break;
                case "#menu3":
                    loadDataKhoa(true);
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

        $('#btnthemsanpham').on('click', function () {
            $.ajax({
                type: 'GET',
                url: '/Nguoiban/GetThongtinNguoiban',
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    console.log(response);
                    if (response.Result.NccNavigation.sltinton > 0) {
                        document.getElementById('user').style.display = 'block';
                    }
                    else {
                        general.notify("Vui lòng mua thêm tin để tiếp tục!",'warn')
                    }
                },
                error: function (status) {
                }
            });
        });

        $('#btnAddSubmit').on('click', function (e) {
            e.preventDefault();
            UploadIMG();
        });


        $('#txtKeywordAll').on('keypress', function (e) {
            if (e.which === 13) {
                loadData(true);
            }
        });
        $('#txtKeywordCon').on('keypress', function (e) {
            if (e.which === 13) {
                loadDataCon(true);
            }
        });
        $('#txtKeywordHet').on('keypress', function (e) {
            if (e.which === 13) {
                loadDataHet(true);
            }
        });

        $('#img-Search-btnAll').on('click', function () {
            loadData(true);
        });

        $('#img-Search-btnCon').on('click', function () {
            loadDataCon(true);
        });
        $('#img-Search-btnHet').on('click', function () {
            loadDataHet(true);
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

    function UploadIMG() {
        var ProductType = $('#txtloaithem').val();
        var fileUpload = $('#inputGroupFile01').get(0);
        var files = fileUpload.files;
        var data = new FormData();

        if (files.length == 1) {
            for (var i = 0; i < files.length; i++) {
                data.append("UploadedImage", files[i]);
            }
            data.append("Type", ProductType);
            $.ajax({
                type: "POST",
                url: "/Sanpham/Upload",
                contentType: false,
                processData: false,
                data: data,
                success: function (response) {
                    console.log(response);
                    if (response.Status == "OK") {
                        SubmitTin(response.Result)
                    }
                    else {
                        if (response.Status == "INVALID") {
                            general.notify("Hình ảnh không hợp lệ!", 'error');
                        }
                    }
                    
                },
                error: function () {
                    general.notify('Lỗi khi upload ảnh !', 'error');
                }
            });
        }
    }

    function SubmitTin(path) {
        var Tensp = $('#txttenmoi').val();
        var Loaisp = $('#txtloaithem').val();
        var Dongia = $('#txtdongiathem').val();
        var Soluong = $('#txtsluongthem').val();
        var Mota = $('#txtmotathem').val();

        var dtl = {
            KeyId: 0,
            masp: 999,
            tensp: Tensp,
            maloai: Loaisp,
            mancc: 0,
            dongia: Dongia,
            soluong: Soluong,
            conlai: Soluong,
            mota: Mota,
            tenhinh: path,
            khuyenmai: 0,
            Status: 0
        };
        $.ajax({
            type: "POST",
            url: "/Sanpham/SaveAllEntity",
            data: { sanphamVm: dtl },
            dataType: "json",
            beforeSend: function () {
                general.startLoad();
            },
            success: function (response) {
                console.log(response);
                if (response.Status == "OK") {
                    general.notify("Thêm sản phẩm thành công!", 'success');
                    document.getElementById('user').style.display = 'none';
                }
                general.stopLoad();
            },
            error: function (status) {
                general.stopLoad();
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
        data: {
            keyword: $('#txtKeywordAll').val(),
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
                var imgsrc = "";
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
                if (item.KeyId <= 50) imgsrc = "/img/" + item.tenhinh;
                render += Mustache.render(template, {
                    ProductID: item.KeyId,
                    ProductName: item.tensp,
                    Price: item.dongia,
                    img: imgsrc,
                    ProductType: item.LoaispNavigation.tenloai,
                    Quanlity: item.soluong,
                    Sold: (item.soluong - item.conlai),
                    InStock: item.conlai
                });
                
                //end
                if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
                    render += '</div>'
                }

            });
            $('#lblTotalRecords').text(response.PageCount);
            $('#new-Product').html(render);
            wrapPaging(response.PageCount, function () {
                loadData();
            }, isPageChanged);
        },
        error: function (status) {
            console.log(status);
            //general.notify('Không thể load dữ liệu', 'error');
        }
    });
}

function loadDataCon(isPageChanged) {
    
    var template1 = $('#table-template1').html();
    var render1 = "";
    $.ajax({
        type: 'GET',
        url: '/Sanpham/GetAllSanPhamCon',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: {
            keyword: $('#txtKeywordCon').val(),
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
                var imgsrc = "";
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
                if (item.KeyId <= 50) imgsrc = "/img/" + item.tenhinh;
                render1 += Mustache.render(template1, {
                    ProductID: item.KeyId,
                    ProductName: item.tensp,
                    Price: item.dongia,
                    img: imgsrc,
                    ProductType: item.LoaispNavigation.tenloai,
                    Quanlity: item.soluong,
                    InStock: item.conlai
                });
                if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
                    render1 += '</div>'
                }

            });
            $('#lblTotalRecords').text(response.PageCount);
            $('#new-Product1').html(render1);
            wrapPaging(response.PageCount, function () {
                loadDataCon();
            }, isPageChanged);
        },
        error: function (status) {
            console.log(status);
            //general.notify('Không thể load dữ liệu', 'error');
        }
    });
}

function loadDataHet(isPageChanged) {
    var template2 = $('#table-template2').html();
    var render2 = "";
    $.ajax({
        type: 'GET',
        url: '/Sanpham/GetAllSanPhamHet',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: {
            keyword: $('#txtKeywordHet').val(),
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
                var imgsrc = "";
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
                if (item.KeyId <= 50) imgsrc = "/img/" + item.tenhinh;
                render2 += Mustache.render(template2, {
                    ProductID: item.KeyId,
                    ProductName: item.tensp,
                    Price: item.dongia,
                    img: imgsrc,
                    ProductType: item.LoaispNavigation.tenloai,
                    Quanlity: item.soluong
                });
                if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
                    render2 += '</div>'
                }

            });
            $('#lblTotalRecords').text(response.PageCount);
            $('#new-Product2').html(render2);
            wrapPaging(response.PageCount, function () {
                loadDataHet();
            }, isPageChanged);
        },
        error: function (status) {
            console.log(status);
            //general.notify('Không thể load dữ liệu', 'error');
        }
    });
}

function loadDataKhoa(isPageChanged) {
    var template3 = $('#table-template3').html();
    var render3 = "";
    $.ajax({
        type: 'GET',
        url: '/Sanpham/GetAllSanPhamKhoa',
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
                var imgsrc = "";
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
                if (item.KeyId <= 50) imgsrc = "/img/" + item.tenhinh;
                render3 += Mustache.render(template3, {
                    ProductID: item.KeyId,
                    ProductName: item.tensp,
                    Price: item.dongia,
                    img: imgsrc,
                    ProductType: item.maloai,
                    Quanlity: item.soluong,
                    Sold: item.conlai
                });
                if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
                    render3 += '</div>'
                }

            });
            $('#lblTotalRecords').text(response.PageCount);
            $('#new-Product3').html(render3);
            wrapPaging(response.PageCount, function () {
                loadDataKhoa();
            }, isPageChanged);
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

