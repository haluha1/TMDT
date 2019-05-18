var nguoibanController = function () {
    this.initialize = function () {
        loadThongtinNguoiban();
        //TestSave();
        //registerEvents();
    }
}
function loadThongtinNguoiban(isPageChanged) {
    var template = $('#table-template').html();
    var template1 = $('#table-template1').html();
    var render = "";
    var render1 = "";
    $.ajax({
        type: 'GET',
        url: '/Nguoiban/GetThongtinNguoiban',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            console.log(response);
            render += Mustache.render(template, {
                Mancc: "NCC" + response.Result.KeyId,
                Tenncc: response.Result.hoten,
                Email: response.Result.email,
                Sdt: response.Result.sdt,
                Ten: response.Result.NccNavigation.tenncc,
                Gt: response.Result.NccNavigation.gioithieu,
                mk: response.Result.matkhau,
                Sltin: response.Result.NccNavigation.sltinton,
            });
            $.each(response.Result.NccNavigation.Hoadonmuatins, function (i,item) {
                
                render1 += Mustache.render(template1, {
                    Mahd: item.KeyId,
                    Goigiatin: item.GiatinNavigation.soluongtin + "- " + item.GiatinNavigation.gia,
                    Thoigian: item.thoigian,
                        //Trangthai: item.GiatinNavigation.trangthai
                    });
        });
            $('#lblTotalRecords').text(response.PageCount);
            $('#new-Product').html(render);
            $('#new-Product1').html(render1);
            wrapPaging(response.PageCount, function () {
                loadThongtinNguoiban();
            }, isPageChanged);
        },
        error: function (status) {
            console.log(status);
            //general.notify('Không thể load dữ liệu', 'error');
        }
    });
}

//function loadThongtinHdMuatin(isPageChanged) {
//    var template = $('#table-template').html();
//    var render = "";
//    $.ajax({
//        type: 'GET',
//        url: '/Nguoiban/GetThongtinHdMuatin',
//        dataType: 'json',
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            console.log(response);
//            render += Mustache.render(template, {
//                Mancc: "NCC" + response.Result.KeyId,
//                Tenncc: response.Result.hoten,
//                Email: response.Result.email,
//                Sdt: response.Result.sdt,
//                Ten: response.Result.NccNavigation.tenncc,
//                Gt: response.Result.NccNavigation.gioithieu,
//                mk: response.Result.matkhau,
//                Sltin: response.Result.NccNavigation.sltinton
//            });

//            $('#lblTotalRecords').text(response.PageCount);
//            $('#new-Product').html(render);
//            wrapPaging(response.PageCount, function () {
//                loadThongtinHdMuatin();
//            }, isPageChanged);
//        },
//        error: function (status) {
//            console.log(status);
//            //general.notify('Không thể load dữ liệu', 'error');
//        }
//    });
//}