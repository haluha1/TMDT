var ctspController = function () {
    this.initialize = function () {
		loadDetail();
        //TestSave();
        registerEvents();
    }

    function registerEvents() {
        
       
		

    }

   
  
	
   
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
