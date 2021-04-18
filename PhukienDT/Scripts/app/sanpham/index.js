var sanphamController = function () {
    this.initialize = function () {
        general.configs.pageSize = 12;
		loadData();
        registerEvents();
    }

	function registerEvents() {
		$('#ddlShowPage').on('change', function () {
			general.configs.pageSize = $(this).val();
			general.configs.pageIndex = 1;
			loadData(true);
		});
		
        $('#buttonsearch').on('click', function () {
            loadData(true);
        });
        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                loadData(true);
            }
        });
		$('body').on('click', '.mua', function (e) {
			window.location.href = "/Sanpham/ctsp/" + $(this).data('id');
		});
        
	}

    function DeleteCart(that) {

        $.ajax({
            type: "POST",
            url: "/Sanpham/DeleteCart",
            data: { id: that },
            dataType: "json",
            beforeSend: function () { general.startLoad(); general.startLoading(); },
            success: function (response) {
                loadGioHang(true);
                general.stopLoad(); general.stopLoading();
            },
            error: function (status) {
                //general.notify('Có lỗi xảy ra', 'error');
                general.stopLoad(); general.stopLoading();
            }
        });
    }
    //function UrlExists(url) {
    //    var http = new XMLHttpRequest();
    //    http.open('HEAD', url, false);
    //    http.send();
    //    return http.status != 404;
    //}
    //function loadTotal() {
    //    var total = 0;
    //    $.each($('.subTotal'), function (i) {
    //        total = total + parseInt($(this).text());
    //    });
    //    $('#tongTien').text(total);
    //}
	




    function loadSTT(that) {
        $that = that;
        var tbl = $that.children();
        $.each(tbl, function (keyT, valT) {
            $(this).closest('tr').find('td:first span').html(keyT + 1)
        });
    }
    
}

function loadData(isPageChanged) {
    var ProductTypeID = window.location.href.split('/').reverse()[0];
    var template = $('#table-template').html();
    var render = "";
    $.ajax({
        type: 'GET',
        url: '/Sanpham/GetByType',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: {
            id: ProductTypeID,
            keyword: $('#txtKeyword').val(),
            page: general.configs.pageIndex,
            pageSize: general.configs.pageSize
        },
        beforeSend: function () { general.startLoad(); general.startLoading(); },
        success: function (response) {
            $.each(response.Result, function (i, item) {
                //begin
                if (i%4==0 && i%2==0) {
                    render += '<div class="row row-space flex-container">';
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
                item.tensp = item.tensp.replace(/  /g, " ");
                let shortName = item.tensp.length > 30 ? (item.tensp.substr(0, 30)+"...") : item.tensp;
                render += Mustache.render(template, {
                    ProductID: item.KeyId,
                    ProductName: shortName,
                    alt: item.tensp,
                    title: item.tensp,
                    Price: item.dongia,
					img: imgsrc,
					NhaCC: item.NccNavigation.tenncc
                });
                //end
                if ( (i%4==3 && i%2==1) || (i+1)==response.length ) {
                    render += '</div>'
                }

            });
            $('#lblTotalRecords').text(response.PageCount);
            $('#Product-wrapper').html(render);
            general.stopLoading();
            wrapPaging(response.PageCount, function () {
                loadData();
            }, isPageChanged);
            general.stopLoad(); general.stopLoading();
        },
        error: function (status) {
            general.stopLoad(); general.stopLoading();
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
        beforeSend: function () { general.startLoad(); general.startLoading(); },
        success: function (response) {
            general.stopLoad(); general.stopLoading();
        },
        error: function (status) {
            //general.notify('Có lỗi trong khi ghi danh bạ!', 'error');
            general.stopLoad(); general.stopLoading();
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
