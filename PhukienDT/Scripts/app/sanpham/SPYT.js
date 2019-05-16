var sanphamController = function () {
    this.initialize = function () {
		loadData();
		loadDetail();
		loadGioHang();
		loadSPYT();
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
        general.configs.pageSize = 12;
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
        $('#btnMua').on('click', function () {
            var kt = false;
            if ($('#txtName').val() == '') {
                general.notify("Vui lòng nhập tên người nhận!")
                kt = true;

            }
            if ($('#txtAddress').val() == '') {
                general.notify("Vui lòng nhập địa chỉ người nhận!")
                kt = true;

            }
            if ($('#txtPhone').val() == '') {
                general.notify("Vui lòng nhập số điện thoại người nhận!")
                kt = true;

            }
            if (!kt) {
                general.notify("Cảm ơn bạn đã đặt hàng!", "success");
                document.getElementById('buy').style.display = 'none';
            }
        });
        
        $('body').on('change', '.soluongSp', function (e) {
            console.log($(this));
            var dongia = $(this).closest('tr').find('td:eq(2)').text();
            var soluong = $(this).closest('tr').find('td:eq(3) input').val()
            $(this).closest('tr').find('td:eq(4)').text(dongia * soluong);
            loadTotal();
        });

        $('body').on('click', '.yeuthich', function (e) {
            e.preventDefault();
            $(this).prop('disabled', true);
            var that = $(this).data('id');
            likeProduct(that);
        });

		$('body').on('click', '.mua', function (e) {
			window.location.href = "/Sanpham/ctsp/" + $(this).data('id');
		});		
		$('body').on('click', '.themgiohang', function (e) {
			window.location.href = "/Sanpham/Giohang/" +  window.location.href.split('/').reverse()[0];;
		});
		$('body').on('click', '.yt', function (e) {
			window.location.href = "/Sanpham/Sanphamyt/" + $(this).data('id');
		});

        $('body').on('click', '.btnXoa', function (e) {
            var that = $(this).data('id');
            //DeleteCart(that);

            $(this).closest('tr').fadeOut();
        });
        

    }

    function DeleteCart(that) {

        $.ajax({
            type: "POST",
            url: "/Sanpham/DeleteCart",
            data: { id: that },
            dataType: "json",
            beforeSend: function () {
                general.startLoading();
            },
            success: function (response) {
                console.log(response);
                loadGioHang(true);


            },
            error: function (status) {
                general.notify('Có lỗi xảy ra', 'error');
                general.stopLoading();
            }
        });
    }
    //function UrlExists(url) {
    //    var http = new XMLHttpRequest();
    //    http.open('HEAD', url, false);
    //    http.send();
    //    return http.status != 404;
    //}
    function loadTotal() {
        var total = 0;
        $.each($('.subTotal'), function (i) {
            total = total + parseInt($(this).text());
        });
        $('#tongTien').text(total);
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
        beforeSend: function() { general.startLoading(); },
        success: function (response) {
            console.log(response);
            $.each(response.Result, function (i, item) {
                //begin
                if (i%4==0 && i%2==0) {
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

                render += Mustache.render(template, {
                    ProductID: item.KeyId,
                    ProductName: item.tensp,
                    Price: item.dongia,
                    img: imgsrc
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
function loadDetail() {
	var that = window.location.href.split('/').reverse()[0];
	var template = $('#table-template').html();
	var render = "";
	$.ajax({
		type: 'GET',
		url: '/Sanpham/GetCTSP',
		dataType: 'json',
		beforeSend: function () {
			general.startLoading();
		},

		data: { id: that },
		success: function (response) {
			console.log(response);
			var template = $('#table-template').html();
			var render = "";
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


			render += Mustache.render(template, {
				IMG: imgsrc,
				Tensp: response.Result.tensp,
				Dongia: response.Result.dongia,
				Soluong: response.Result.soluong
			});
			$('#lblTotalRecords').text(response.PageCount);
			$('#Product-wrapper').html(render);
			wrapPaging(response.PageCount, function () {
				//loadDetail();
			},);
		},

		error: function (status) {
			general.notify('Có lỗi xảy ra', 'error');
			general.stopLoading();
		}
	});
}
function loadGioHang(isPageChanged) {
	var that = window.location.href.split('/').reverse()[0];
	var template = $('#table-template').html();
	var render = "";
	$.ajax({
		type: 'GET',
		url: '/Sanpham/GetGioHang',
		dataType: 'json',
		contentType: "application/json; charset=utf-8",
		success: function (response) {
			console.log(response);
            var render = "";
            $.each(response.Result.CtGiohangs, function (i, item) {
                //begin
                if (i % 4 == 0 && i % 2 == 0) {
                    render += '<div class="row row-space">'
                }
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
                

                render += Mustache.render(template, {
                    IMG: imgsrc,
                    Tensp: item.SanphamNavigation.tensp,
                    Loaisp: item.SanphamNavigation.LoaispNavigation.tenloai,
                    Dongia: item.SanphamNavigation.dongia,
                    Soluong: item.soluong,
                    ThanhTien: item.SanphamNavigation.dongia * item.soluong,
                    KeyID: item.KeyId
                });
                //end
                if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
                    render += '</div>'
                }

            });
			
			


			
			$('#lblTotalRecords').text(response.PageCount);
            $('#Product-wrapper').html(render);
            $('#tongTien').text(response.Result.thanhtien);
			wrapPaging(response.PageCount, function () {
				//loadDetail();
			}, );
		},

		error: function (status) {
			general.notify('Có lỗi xảy ra', 'error');
			general.stopLoading();
		}
	});
}
function loadSPYT(isPageChanged) {
	var that = window.location.href.split('/').reverse()[0];
	var template = $('#table-template').html();
	var render = "";
	$.ajax({
		type: 'GET',
		url: '/Sanpham/GetSPYT',
		dataType: 'json',
		contentType: "application/json; charset=utf-8",
		data: {
			id: that
		},
		success: function (response) {
			console.log(response);
			var render = "";
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


			render += Mustache.render(template, {
				IMG: imgsrc,
				Tensp: response.Result.tensp,
				Loaisp: response.Result.LoaispNavigation.tenloai,
				Dongia: response.Result.dongia
			});
			$('#lblTotalRecords').text(response.PageCount);
			$('#Product-wrapper').html(render);
			wrapPaging(response.PageCount, function () {
				//loadDetail();
			}, );
		},

		error: function (status) {
			general.notify('Có lỗi xảy ra', 'error');
			general.stopLoading();
		}
	});
}