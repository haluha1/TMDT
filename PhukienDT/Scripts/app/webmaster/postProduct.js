var postProductController = function () {
    this.initialize = function () {
		loadData();
        registerEvents();
    }

	function registerEvents() {
		$('#ddlShowPage').on('change', function () {
			general.configs.pageSize = $(this).val();
			general.configs.pageIndex = 1;
			loadData(true);
        });
        $('#btnSearch').on('click', function () {
            loadData(true);
        });
        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                loadData(true);
            }
        });
        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            loadDetail(that);
        });
        $('#btnAccept').on('click', function (e) {
            var st = 1;
            Duyet(e,st);
        });
        $('#btnCancel').on('click', function (e) {
            var st = 4;
            Duyet(e,st);
        });
	}
    

    
}

function Duyet(e,st) {
    e.preventDefault();
    var that = $('#txtKeyId').val();
    $.ajax({
        type: "POST",
        url: "/Webmaster/DuyetPostTin",
        data: { id: that, status: st },
        dataType: "json",
        beforeSend: function () {
            general.startLoad();
        },
        success: function (response) {
            console.log(response);
            if (response.Status == "OK") {
                general.notify("Đã duyệt!", 'success');
            }
            general.stopLoad();
            loadData(true);
            $('#modal-add-edit').modal('hide');

        },
        error: function (status) {
            
            general.stopLoad();
        }
    });
}

function loadDetail(that) {
    $.ajax({
        type: "GET",
        url: "/Sanpham/GetCTSP",
        data: { id: that },
        dataType: "json",
        beforeSend: function () {
            general.startLoad();
        },
        success: function (response) {
            console.log(response);
            var imgsrc = "";
            switch (response.Result.LoaispNavigation.KeyId) {
                case 2: {
                    imgsrc = "/img/Bao/" + response.Result.tenhinh;
                    break;
                }
                case 3: {
                    imgsrc = "/img/Ring/" + response.Result.tenhinh;
                    break;
                }
                case 4: {
                    imgsrc = "/img/Khac/" + response.Result.tenhinh;
                    break;
                }
                default: {
                    imgsrc = "/img/" + response.Result.tenhinh;
                    break;
                }
            }
            if (response.Result.KeyId <= 50) imgsrc = "/img/" + response.Result.tenhinh;
            $('#imgAvatar').css('background-image', 'url("' + imgsrc + '")');
            
            $('#txtKeyId').val(response.Result.KeyId);
            $('#txtProductCode').val(response.Result.masp);
            $('#txtMerchant').val(response.Result.NccNavigation.tenncc);
            $('#txtProductName').val(response.Result.tensp);
            $('#selProductType').val(response.Result.LoaispNavigation.tenloai);
            $('#txtPrice').val(response.Result.dongia);
            $('#txtQty').val(response.Result.soluong);
            $('#txtSale').val(response.Result.khuyenmai);
            $('#txtStatus').val(response.Result.Status);
            $('#txtDescription').val(response.Result.mota);
            $('#modal-add-edit').modal('show');
            general.stopLoad();

        },
        error: function (status) {
            general.stopLoad();
        }
    });
}

function loadData(isPageChanged) {
    var template = $('#table-template').html();
    var render = "";
    $.ajax({
        type: 'GET',
        url: '/Webmaster/GetAllTin',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: {
            keyword: $('#txtKeyword').val(),
            page: general.configs.pageIndex,
            pageSize: general.configs.pageSize
        },
        success: function (response) {
            console.log(response);
            if (response.Status == "OK") {
                $.each(response.Result, function (i, item) {
                    var st = "";
                    var _color = '';
                    switch (item.Status) {
                        case 0:
                            st = "Chờ phê duyệt";
                            _color = 'blue';
                            break;
                        case 1:
                            st = "Đã duyệt";
                            _color = 'green';
                            break;
                        case 2:
                            st = "Hết hàng";
                            _color = 'orange';
                            break;
                        case 3:
                            st = "Khóa";
                            _color = 'black';
                            break;
                        case 4:
                            st = "Không duyệt";
                            _color = 'orange';
                            break;
                        default:
                            st = "Chờ phê duyệt";
                            _color = 'blue';
                            break;
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
                        KeyId: item.KeyId,
                        ProductID: item.masp,
                        ProductName: item.tensp,
                        Img: imgsrc,
                        Ncc: item.NccNavigation.tenncc,
                        Status: '<span class="badge bg-' + _color + '">' + st + '</span>',
                        Qty: item.soluong,
                        Price: item.dongia,
                        IsCompleted: item.Status == 1 ? 'style="display:none;"' : ''
                    });

                });
                $('#lblTotalRecords').text(response.PageCount);
                $('#tbl-content').html(render);
                wrapPaging(response.PageCount, function () {
                    loadData();
                }, isPageChanged);
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
