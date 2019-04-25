function autoAddressbook(inp, arr) {
    /*the autocomplete function takes two arguments,
    the text field element and an array of possible autocompleted values:*/
    var currentFocus;
    /*execute a function when someone writes in the text field:*/
    inp.addEventListener("input", function (e) {
        var a, b, i, val = this.value;
        var isAll = false;
        var idTag = this.id;
        /*close any already open lists of autocompleted values*/
        closeAllLists();
        inp.setAttribute('data-addressbookid', '');
        if (!val) { isAll = true; }
        currentFocus = -1;
        /*create a DIV element that will contain the items (values):*/
        a = document.createElement("DIV");
        a.setAttribute("id", this.id + "autocomplete-list");
        a.setAttribute("class", "auto-items");
        /*append the DIV element as a child of the autocomplete container:*/
        this.parentNode.appendChild(a);
        /*for each item in the array...*/
        for (i = 0; i < arr.length; i++) {
            var index = 0;
            /*check if the item starts with the same letters as the text field value:*/
            if (!isAll)
                index = arr[i].Name.toUpperCase().indexOf(val.toUpperCase());
            if (index > -1) {
                /*create a DIV element for each matching element:*/
                b = document.createElement("DIV");
                /*make the matching letters bold:*/
                if (isAll)
                    b.innerHTML = arr[i].Name;
                else {
                    b.innerHTML = arr[i].Name.substr(0, index)
                    b.innerHTML += "<strong>" + arr[i].Name.substr(index, val.length) + "</strong>";
                    if (index + val.length <= arr[i].Name.length)
                        b.innerHTML += arr[i].Name.substr(index + val.length);
                }
                /*insert a input field that will hold the current array item's value:*/
                b.innerHTML += "<input type='hidden' data-id='" + arr[i].sId + "' value='" + arr[i].Name + "'>";
                /*execute a function when someone clicks on the item value (DIV element):*/
                b.addEventListener("click", function (e) {
                    /*insert the value for the autocomplete text field:*/
                    inp.value = this.getElementsByTagName("input")[0].value;
                    inp.setAttribute('data-addressbookid', this.getElementsByTagName("input")[0].getAttribute('data-id'));
                    /*close the list of autocompleted values,
                    (or any other open lists of autocompleted values:*/
                    closeAllLists();

                    //Load employee for adding
                    if (idTag == "txtEmployee") loadNewUser();
                });
                a.appendChild(b);
                
            }
        }
    });
    /*execute a function presses a key on the keyboard:*/
    inp.addEventListener("keydown", function (e) {
        var x = document.getElementById(this.id + "autocomplete-list");
        if (x) x = x.getElementsByTagName("div");
        if (e.keyCode == 40) {
            /*If the arrow DOWN key is pressed,
            increase the currentFocus variable:*/
            currentFocus++;
            /*and and make the current item more visible:*/
            addActive(x);
        } else if (e.keyCode == 38) { //up
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
                if (x) x[currentFocus].click();
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
        x[currentFocus].classList.add("autocomplete-active");
    }
    function removeActive(x) {
        /*a function to remove the "active" class from all autocomplete items:*/
        for (var i = 0; i < x.length; i++) {
            x[i].classList.remove("autocomplete-active");
        }
    }
    function closeAllLists(elmnt) {
        /*close all autocomplete lists in the document,
        except the one passed as an argument:*/
        var x = document.getElementsByClassName("auto-items");
        for (var i = 0; i < x.length; i++) {
            if (elmnt != x[i] && elmnt != inp) {
                x[i].parentNode.removeChild(x[i]);
            }
        }
    }
    /*execute a function when someone clicks in the document:*/
    document.addEventListener("click", function (e) {
        closeAllLists(e.target);
    });
}
var UserData;
var gAvatarImage = "admin-side/images/user.png";
//Employee function script
function loadNewUser() {
    var that = document.getElementById('txtEmployee').getAttribute('data-addressbookid');
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

                $('#txtGender').val(data.Gender == 0 ? "Nam" : data.Gender==1?"Nữ":"Khác");
                $('#txtDOB').val(general.dateFormatJson(data.Dob, true));
                $('#txtIDNumber').val(data.IdNumber);
                $('#txtPhoneNumber').val(data.PhoneNumber);
                $('#txtEmail').val(data.Email);

                if (data.IDDate) general.setDateTimePicker($('#dtIDDate'), data.IdDate);

                $('#txtAccommodationCurrent').val(data.Street);
                //$('#selDistrictAC').val(data.DistrictAC);
                //$('#selProvinceAC').val(data.ProvinceACFk);

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
