var muatinController = function () {
    this.initialize = function () {
        loadData();
        //TestSave();
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '#btnmuatin', function (e) {
            e.preventDefault();
            
            var that = $('#selGiatin').val();
            Buy(that);
        });
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
       
    }
}


function loadData(isPageChanged) {
    $.ajax({
        type: 'GET',
        url: '/Nguoiban/GetAllGiatin',
        dataType: 'json',
        success: function (response) {
            console.log(response);
            $('#selGiatin').empty();
            $.each(response.Result, function (i, item) {
                $('#selGiatin').append('<option value="' + item.KeyId + '">' + item.soluongtin +" tin - "+item.gia + " VNĐ" +'</option>');
            });
        },
        error: function (status) {
            console.log(status);
            general.notify('Không thể load dữ liệu', 'error');
        }
    });
}

function Buy(that) {
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
        url: "/Nguoiban/Muatin",
        data: { id: that },
        dataType: "json",
        beforeSend: function () {
            general.startLoad();
        },
        success: function (response) {
            console.log(response);
            general.stopLoad();
        },
        error: function (status) {
            general.notify('Có lỗi trong khi ghi danh bạ!', 'error');
            general.stopLoad();
        }
    });
}
