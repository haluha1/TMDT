function autoAddressbook(inp, arr) {
    var currentFocus;
    inp.on('input', function () {
        var a, b, i, val = $(this).val();
        var isAll = false;
        var idTag = $(this).attr('id');
        /*close any already open lists of autocompleted values*/
        closeAllLists();
        inp.data('addressbookid', '');
        if (!val) { isAll = true };
        currentFocus = -1;
        /*create a DIV element that will contain the items (values):*/
        a = $('<div></div>');
        a.attr('id', idTag + "autocomplete-list");
        a.addClass('auto-items');
        /*append the DIV element as a child of the autocomplete container:*/
        $(this).parent().append(a);
        /*for each item in the array...*/
        for (i = 0; i < arr.length; i++) {
            var index = 0;
            /*check if the item starts with the same letters as the text field value:*/
            if (!isAll)
                index = arr[i].Name.toUpperCase().indexOf(val.toUpperCase());
            if (index > -1) {
                /*create a DIV element for each matching element:*/
                b = $('<div></div>');
                var temp;
                /*make the matching letters bold:*/
                if (isAll)
                    temp = arr[i].Name;
                else {
                    temp = arr[i].Name.substr(0, index) + "<strong>" + arr[i].Name.substr(index, val.length) + "</strong>";
                    if (index + val.length <= arr[i].Name.length)
                        temp += arr[i].Name.substr(index + val.length);
                }
                /*insert a input field that will hold the current array item's value:*/
                temp += "<input type='hidden' data-id='" + arr[i].sId + "' value='" + arr[i].Name + "'>";
                b.html(temp);
                /*execute a function when someone clicks on the item value (DIV element):*/
                b.on("click", function () {
                    inp.val($(this).find('input').first().val());
                    inp.data('addressbookid', $(this).find('input').first().data('id'));
                    /*close the list of autocompleted values,
                    (or any other open lists of autocompleted values:*/
                    closeAllLists();
                    //Load employee for adding
                    if (idTag == "txtEmployee") loadNewUser();
                });
                a.append(b);
            }
        }
    });
    inp.on("keydown", function (e) {
        var x = $('#'+$(this).attr('id')+'autocomplete-list div');
        //if (x)
        //    x = x.find("div");
        if (e.keyCode == 40) {
            /*If the arrow DOWN key is pressed,
            increase the currentFocus variable:*/
            currentFocus++;
            /*and and make the current item more visible:*/
            addActive(x);
        }
        else if (e.keyCode == 38) { //up
            /*If the arrow UP key is pressed,
            decrease the currentFocus variable:*/
            currentFocus--;
            /*and and make the current item more visible:*/
            addActive(x);
        } else if (e.keyCode == 13) {
            /*If the ENTER key is pressed, prevent the form from being submitted,*/
            e.preventDefault();
            if (currentFocus > -1) {
                /*and simulate a click on the "active" item:*/
                if (x) x.eq(currentFocus).click();
            }
        }
    });
    function addActive(x) {
        /*a function to classify an item as "active":*/
        if (!x) return false;
        /*start by removing the "active" class on all items:*/
        removeActive(x);
        if (currentFocus >= x.length) currentFocus = 0;
        if (currentFocus < 0) currentFocus = (x.length - 1);
        /*add class "autocomplete-active":*/
        x.eq(currentFocus).addClass("autocomplete-active");
    }
    function removeActive(x) {
        /*a function to remove the "active" class from all autocomplete items:*/
        for (var i = 0; i < x.length; i++) {
            x.eq(i).removeClass("autocomplete-active");
        }
        
    }
    $(document).on("click", function (e) {
        closeAllLists(e.target);
    });
    function closeAllLists(elmnt) {
        /*close all autocomplete lists in the document,
        except the one passed as an argument:*/
        var x = $('.auto-items');
        x.each(function () {
            if (elmnt != $(this) && elmnt != inp) {
                $(this).remove();
            }
        });
    }
}
var UserData;
var gAvatarImage = "admin-side/images/user.png";
//Employee function script
function loadNewUser() {
    var that = $('#txtEmployee').data('addressbookid');
    //var that = $(this).data('id');
    $.ajax({
        type: "GET",
        url: "/addressbook/GetById",
        data: { id: that },
        dataType: "json",
        beforeSend: function () {
            general.startLoading();
        },
        success: function (response) {
            if (response != null) {
                UserData = response;
                console.log(response);
                var data = response;
                if (data.Avatar) gAvatarImage = data.Avatar;
                else gAvatarImage = "admin-side/images/user.png";
                $('#imgAvatar').css('background-image', 'url("' + gAvatarImage + '")');

                $('#txtGender').val(data.Gender == 0 ? "Nam" : data.Gender == 1 ? "Nữ" : "Khác");
                $('#txtDOB').val(general.dateFormatJson(data.Dob, true));
                $('#txtIDNumber').val(data.IdNumber);
                $('#txtPhoneNumber').val(data.PhoneNumber);
                $('#txtEmail').val(data.Email);

                if (data.IDDate) general.setDateTimePicker($('#dtIDDate'), data.IdDate);

                $('#txtAccommodationCurrent').val(data.Street);
                $('#selProvinceAC').val(data.CityFK);
                loadDistrict(data.CityFK, $('#selDistrictAC'), data.DistrictFK);
                loadWard(data.DistrictFK, $('#selWardAC'), data.WardFK);


                $('#txtTaxIDNumber').val(data.TaxIdnumber);

                if (data.LastupdatedByFk != null)
                    $('#txtLastUpdatedByFK').val(data.FullName);
                $('#dtDateModified').val(general.dateFormatJson(data.DateModified, true));
                if (data.Status == 1)
                    $('#chkStatus').prop('checked', true);
                else
                    $('#chkStatus').prop('checked', false);
                $('#modal-add-edit').modal('show');
                general.stopLoading();
            }
            general.stopLoading();
        },
        error: function (status) {
            general.notify('Có lỗi xảy ra', 'error');
            general.stopLoading();
        }
    });
}
function loadDistrict(cityId, that, value) {
    that.empty().append("<option value=''>Chọn Quận/Huyện</option>");
    $.ajax({
        type: 'GET',
        url: '/employee/GetAllDistrict',
        dataType: 'json',
        data: { cityFK: cityId },
        success: function (response) {
            $.each(response, function (i, item) {
                that.append("<option value='" + item.KeyId + "'>" + item.DistrictName + "</option>");
            });
            if (value) that.val(value);
        },
        error: function (status) {
            console.log(status);
            general.notify('Không thể load dữ liệu', 'error');
        }
    });
}
function loadWard(districtId, that, value) {
    that.empty().append("<option value=''>Chọn Phường/Xã</option>");
    $.ajax({
        type: 'GET',
        url: '/employee/GetAllWard',
        dataType: 'json',
        data: { districtFK: districtId },
        success: function (response) {
            $.each(response, function (i, item) {
                that.append("<option value='" + item.KeyId + "'>" + item.WardName + "</option>");
            });
            if (value) that.val(value);
        },
        error: function (status) {
            console.log(status);
            general.notify('Không thể load dữ liệu', 'error');
        }
    });
}