var nguoibanController = function () {
    this.initialize = function () {
        loadThongtinNguoiban();
        //TestSave();
        //registerEvents();
    }
}
function loadThongtinNguoiban(isPageChanged) {
    var template = $('#table-template').html();
    var render = "";
    $.ajax({
        type: 'GET',
        url: '/Nguoiban/GetThongtinNguoiban',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            console.log(response);
            render += Mustache.render(template, {
                Tenncc: response.Result.hoten,
                Email: response.Result.email,
                Sdt: response.Result.sdt,
                Ten: response.Result.NccNavigation.tenncc,
                Gt: response.Result.NccNavigation.gioithieu,
                mk: response.Result.matkhau,
                Sltin: response.Result.NccNavigation.sltinton
            });
            
            $('#lblTotalRecords').text(response.PageCount);
            $('#new-Product').html(render);
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