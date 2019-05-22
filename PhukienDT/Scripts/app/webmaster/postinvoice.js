var postinvoiceController = function () {
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
            Duyet(that);
        });
        
	}
    

    
}

function Duyet(that) {
    $.ajax({
        type: "POST",
        url: "/Webmaster/DuyetPostInvoice",
        data: { id: that },
        dataType: "json",
        beforeSend: function () {
            general.startLoad();
        },
        success: function (response) {
            console.log(response);
            general.stopLoad();
            general.notify("Đã duyệt!", 'success');
            loadData(true);

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
        url: '/Webmaster/GetAllHoadonmuatin',
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
                    var _color = '';
                    var status = '';
                    var isCompleted = "";
                    if (item.Status == 0) {
                        _color = 'red';
                        status = 'Chưa thanh toán'

                    }
                    else {
                        _color = 'green';
                        status = 'Đã thanh toán';
                        isCompleted = 'style="display: none;"';
                    }
                    
                    render += Mustache.render(template, {
                        KeyId: item.KeyId,
                        MaHD: item.mahd,
                        NCC: item.NccNavigation.tenncc,
                        Type: item.GiatinNavigation.soluongtin + " tin",
                        Time: item.thoigian,
                        Status: '<span class="badge bg-' + _color + '">' + status + '</span>',
                        IsCompleted: isCompleted
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
