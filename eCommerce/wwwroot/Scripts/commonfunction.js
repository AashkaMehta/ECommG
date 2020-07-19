function FillPostCodeType() {
    var postcode = $('#ddlpostcode').val();
    if (postcode != "") {
        $.ajax({
            url: '/Common/FillPostCodeType',
            type: "GET",
            dataType: "JSON",
            data: { PostCode: postcode },
            success: function (data) {
                $("#DestinationPostCodeType").val(data);
            },
            error: function (reponse) {
                $("#DestinationPostCodeType").val('');
            }
        });
    }
    else {
        $("#DestinationPostCodeType").val('');
    }
}

function FillPostCode() {
    var cityid = $('#ddlcity').val();
    if (cityid != "") {
        $.ajax({
            url: '/Common/FillPostCode',
            type: "GET",
            dataType: "JSON",
            data: { cid: cityid },
            success: function (data) {
                // celar city and area
                $("#ddlpostcode").html("<option value=''>--Select Post Code--</option>").show();
                $('#ddlpostcode').select2("val", '');
                var markup = "<option value=''>--Select Post Code--</option>";
                for (var x = 0; x < data.length; x++) {
                    markup += "<option value=" + data[x]["Value"] + ">" + data[x]["Text"] + "</option>";
                }
                $("#ddlpostcode").html(markup).show();
            },
            error: function (reponse) {
                $("#ddlpostcode").html("<option value=''>--Select Post Code--</option>").show();
                $('#ddlpostcode').select2("val", '');
            }
        });
    }
    else {
        $("#ddlpostcode").html("<option value=''>--Select Post Code--</option>").show();
        $('#ddlpostcode').select2("val", '');
    }
}

function FillCity() {
    var stateid = $('#ddlstate').val();
    if (stateid != "") {
        $.ajax({
            url: '/Common/FillCity',
            type: "GET",
            dataType: "JSON",
            data: { sid: stateid },
            success: function (data) {
                // celar city and area
                $("#ddlcity").html("<option value=''>--Select City--</option>").show();
                $('#ddlcity').select2("val", '');
                var markup = "<option value=''>--Select City--</option>";
                for (var x = 0; x < data.length; x++) {
                    markup += "<option value=" + data[x]["Value"] + ">" + data[x]["Text"] + "</option>";
                }
                $("#ddlcity").html(markup).show();
            },
            error: function (reponse) {
                $("#ddlcity").html("<option value=''>--Select City--</option>").show();
                $('#ddlcity').select2("val", '');
            }
        });
    }
    else {
        $("#ddlcity").html("<option value=''>--Select City--</option>").show()
        $('#ddlcity').select2("val", '');
    }
}

// Ajax call to fill city dropdown by state id for driver
function FillCityOther() {
    var stateid = $('#ddlstatep').val();
    if (stateid != "") {
        $.ajax({
            url: '/Common/FillCity',
            type: "GET",
            dataType: "JSON",
            data: { sid: stateid },
            success: function (data) {
                // celar city and area
                $("#ddlcityp").html("<option value=''>--Select City--</option>").show();
                $('#ddlcityp').select2("val", '');
                var markup = "<option value=''>--Select City--</option>";
                for (var x = 0; x < data.length; x++) {
                    markup += "<option value=" + data[x]["Value"] + ">" + data[x]["Text"] + "</option>";
                }
                $("#ddlcityp").html(markup).show();
            },
            error: function (reponse) {
                $("#ddlcityp").html("<option value=''>--Select City--</option>").show();
                $('#ddlcityp').select2("val", '');
            }
        });
    }
    else {
        $("#ddlcityp").html("<option value=''>--Select City--</option>").show();
        $('#ddlcityp').select2("val", '');
    }
}

function IsNumeric(evt) {

    var charCode = (evt.which) ? evt.which : evt.keyCode;
    // Added to allow decimal, period, or delete
    if (charCode > 31 && (charCode < 44 || charCode > 57))
        return false;
    return true;
}

function IsAlphaNumeric(evt) {

    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if ((charCode >= 48 && charCode <= 57) || (charCode >= 65 && charCode <= 90) || charCode == 32 || (charCode >= 97 && charCode <= 122))
        return true;
    return false;
}
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    // Added to allow decimal, period, or delete
    if (charCode > 31 && (charCode < 44 || charCode > 57))
        return false;

    return true;
}
(function ($) {
    $.each($.validator.methods, function (key, value) {
        $.validator.methods[key] = function () {
            if (arguments.length > 0) {
                arguments[0] = $.trim(arguments[0]);
            }
            return value.apply(this, arguments);
        };
    });
}(jQuery));
function ValidateForm() {
    if ($('#myform').valid()) {
        console.log('FORM VALID');
    } else {
        console.log('FORM INVALID');
        return false;
    }
}

function CancelForm(url) {
    $.confirm({
        title: 'Confirm Cancel!',
        content: 'Are you sure that you want to cancel, data entered recently will be lost?',
        buttons: {
            proceed: function () {
                window.location.href = url;
            },
            cancel: function () {

            },
        }
    });
}
//function MoveNext(url) {
//    $.confirm({
//        title: 'Confirm Move!',
//        content: 'Are you sure that you want to move to next page, data entered which was not saved will be lost?',
//        buttons: {
//            proceed: function () {
//                window.location.href = url;
//            },
//            cancel: function () {

//            },
//        }
//    });
//} 

function MoveNext(url) {
    swal({
        title: "Are you sure?",
        text: "Do you want to Procced",
        type: "info",
        showCancelButton: true,
        confirmButtonColor: "#963694",
        confirmButtonText: "Yes, Procced!",
        closeOnConfirm: false
    }, function () {
        window.location.href = url;
        //swal("Deleted!", "Your imaginary file has been deleted.", "success");
    });
}


function MovePrevious(url) {
    //$.confirm({
    //    title: 'Confirm Move!',
    //    content: 'Are you sure that you want to move to previous page, data entered which was not saved will be lost?',
    //    buttons: {
    //        proceed: function () {
    //            window.location.href = url;
    //        },
    //        cancel: function () {

    //        },
    //    }
    //});
    swal({
        title: "Are you sure?",
        text: "Do you want to Move!",
        type: "info",
        showCancelButton: true,
        confirmButtonColor: "#963694",
        confirmButtonText: "Yes, Procced!",
        closeOnConfirm: false
    }, function () {
        window.location.href = url;
        //swal("Deleted!", "Your imaginary file has been deleted.", "success");
    });
}
function clear_form_elements(ele) {
    $(ele).find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'select-multiple':
            case 'select-one':
            case 'text':
            case 'textarea':
                $(this).val('');
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}

$(document).ready(function () {
    $("input:text:visible:enabled:not([readonly='readonly']):first").focus();
});
