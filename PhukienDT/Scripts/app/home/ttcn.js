ttcnController = function () {
	this.initialize = function () {
		loadTTCN();
		registerEvents();
	}
	function registerEvents() {
		
		$('body').on('click', '#submit_change_pass', function (e) {
				var old_pass = $('#old_pass').val();
				var new_pass = $('#new_pass').val();
				var re_new_pass = $('#re_new_pass').val();

				// Nếu một trong các biến này rỗng
				if (old_pass == ''  || new_pass == '' || re_new_pass == '') {
					alert("Chưa Điền Đủ Thông Tin");
					//general.notify("Chưa Điền Đủ Thông Tin","error");
				}
				if (new_pass != re_new_pass) {
					alert("Mật khẩu nhập lại không khớp");
					//general.notify("Mật khẩu nhập lại không khớp", "error");
				}
				// Ngược lại
				else {
					$.ajax({
						url: '/Home/UpdatePassword', // Đường dẫn file nhận dữ liệu
						type: 'POST', // Phương thức gửi dữ liệu
						// Các dữ liệu
						data: {
							//omk: data.Result.Password,
							mk: $('#new_pass').val(),
							//id: data.Result.UserID,
							// Thực thi khi gửi dữ liệu thành công
						}, success: function (data) {
							alert("thành công");
							//general.notify("Bạn đã đổi mật khẩu thành công!", "success");

						}
					});
					// Thực thi gửi dữ liệu bằng Ajax
					
				}
			});	
        
	}
}
	function loadTTCN(isPageChanged) {
		var template = $('#table-template').html();
		var render = "";
		$.ajax({
			type: 'POST',
			url: '/Home/IsLogin',
			dataType: 'json',
			contentType: "application/json; charset=utf-8",
			data: {},
			success: function (response) {
				console.log(response);
				render += Mustache.render(template, {
						Avatar: response.Result.Avatar,
						UserID: "MaND"+ response.Result.UserID,
						Email: response.Result.Email,
						Username: response.Result.UserName,
						//Phone: response.Result.Phone
					});
				//$('#lblTotalRecords').text(response.PageCount);
				$('#Product-wrapper').html(render);
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

