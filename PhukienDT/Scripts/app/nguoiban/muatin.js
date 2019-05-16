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
