﻿var giohangController = function () {
	this.initialize = function () {
		loadGioHang();
		registerEvents();
	}
    var tempData;
	function registerEvents() {
		$('body').on('click', '.btnXoa', function () {
			var id = $(this).data('id');	
			$.ajax({
				type: 'GET',
				url: '/Sanpham/DeleteItem',
				dataType: 'json',
				data: { id: id },
				
				contentType: "application/json; charset=utf-8",
				success: function (response) {

					$(this).parent().parent().remove();
					loadTotalPrice();
					loadGioHang();
					general.notify('Xóa thành công', 'success');
										},

				error: function (status) {
					$(this).parent().parent().remove();
					loadTotalPrice();
					loadGioHang();
					general.notify('Xóa thành công', 'success');
				}
			});
		});
		
		$('.soluongSp').on('change', function () {
			loadTotalPrice();

		});
		$('#ddlShowPage').on('change', function () {
			general.configs.pageSize = $(this).val();
			general.configs.pageIndex = 1;
			loadData(true);
        });
        $('#btnGoBuy').on('click', function () {
            var l = $('#new-Product tr').length;
            if (l < 1) general.notify("Giỏ hàng trống!", 'warn');
            else {
                $.ajax({
                    type: 'POST',
                    url: '/Home/IsLogin',
                    dataType: 'json',
                    beforeSend: function () { general.startLoad(); },
                    success: function (response) {
                        console.log(response);
                        tempData = {
                            UserName: response.Result.UserName,
                            Address: response.Result.Address,
                            Phone: response.Result.Phone
                        };
                        $('#chkNewInfo').prop('checked', false)
                        $("#txtName").val(tempData.UserName);
                        $("#txtAddress").val(tempData.Address);
                        $("#txtPhone").val(tempData.Phone);

                        $("#txtName").prop('disabled', true);
                        $("#txtAddress").prop('disabled', true);
                        $("#txtPhone").prop('disabled', true);
                        document.getElementById('buy').style.display = 'block';
                        general.stopLoad();
                    },
                    error: function (status) {
                        console.log(status);
                        general.stopLoad();
                        //general.notify('Không thể load dữ liệu', 'error');
                    }
                });
                
            } 
        });

        $('#chkNewInfo').on('change', function () {
            var isChecked = $(this).is(':checked');
            if (isChecked == true) {
                $("#txtName").prop('disabled', false);
                $("#txtAddress").prop('disabled', false);
                $("#txtPhone").prop('disabled', false);
            }
            else {
                //ajax => disable
                $("#txtName").val(tempData.UserName);
                $("#txtAddress").val(tempData.Address);
                $("#txtPhone").val(tempData.Phone);

                $("#txtName").prop('disabled', true);
                $("#txtAddress").prop('disabled', true);
                $("#txtPhone").prop('disabled', true);
            }
        })
        $('#btnMua').on('click', function () {
            if ($('#chkNewInfo').is(':checked') == true) {
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
            }
            SaveEntity();

			//if (!kt) {
			//	general.notify("Cảm ơn bạn đã đặt hàng!", "success");
			//	document.getElementById('buy').style.display = 'none';
			//}
		});

		$('body').on('change', '.soluongSp', function (e) {
			console.log($(this));
			var dongia = $(this).closest('tr').find('td:eq(3)').text();
			var soluong = $(this).closest('tr').find('td:eq(4) input').val()
			$(this).closest('tr').find('td:eq(5)').text(dongia * soluong);
			loadTotal();
		});

		//$('body').on('click', '.yeuthich', function (e) {
		//    e.preventDefault();
		//    $(this).prop('disabled', true);
		//    var that = $(this).data('id');
		//    likeProduct(that);
		//});
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
						KeyID: item.KeyId,
						Masp: item.KeyId
					});
					//end
					if ((i % 4 == 3 && i % 2 == 1) || (i + 1) == response.length) {
						render += '</div>'
					}

				});

				$('#lblTotalRecords').text(response.PageCount);
				$('#new-Product').html(render);
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

    function SaveEntity() {
        var uName = $('#txtName').val();
        var address = $('#txtAddress').val();
        var sdt = $('#txtPhone').val();
        var note = $('#txtNote').val();
        var information = {
            KeyId: 0,
            mahd: 0,
            makh: 0,
            ncc_FK: 0,
            tongtien: 0,
            Name: uName,
            Address: address,
            Phone: sdt,
            Note: note
        };
        var data = [];
        $.each($('#new-Product tr'), function (keyT, valT) {
            var Qty = $(this).find('td:eq(4) input').val();
            var KId = $(this).find('td:eq(-1) button').data('id');
            var sp = {
                KeyId: 0,
                masp: KId,
                User_FK: 0,
                soluong: Qty
            };
            if (Qty > 0) { data.push(sp); }
        });
        

        $.ajax({
            type: "POST",
            url: "/Hoadon/SaveAllEntity",
            data: {
                Information: information,
                Products: data
            },
            dataType: "json",
            beforeSend: function () {
                general.startLoad();
            },
            success: function (response) {
                console.log(response);
                if (response.Status == "OK") {

                    
                    general.notify("Đặt hàng thành công!", 'success');
                    document.getElementById('buy').style.display = 'none';
                    alert("Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!");
                    window.location.href = "/Home/Index";
                }
                general.stopLoad();
            },
            error: function (status) {
                general.stopLoad();
            }
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
		beforeSend: function () { general.startLoading(); },
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
function loadTotalPrice() {
	var totalPrice = 0;
	$('#giohang > tbody > tr').each(function () {
		totalPrice += parseInt($(this).find('td:eq(5)').text());	
	});
	$('#tongTien').empty();
	$('#tongTien').append(totalPrice);
}