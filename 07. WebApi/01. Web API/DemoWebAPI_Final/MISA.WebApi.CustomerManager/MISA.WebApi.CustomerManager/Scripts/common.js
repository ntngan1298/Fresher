$(document).ready(function () {
    //var abc = new objTest;
    //$('#popupInfoDetail').draggable();
    // Gán Event cho Button Sửa:
    $('#btnEdit').click(objTest.btnEdit_OnClientClick);

    $('.popup-header').click(function () {
        //$('#popupInfoDetail').show();
        $('#popupInfoDetail').draggable();
    });

    $('.popup-close').click(function () {
        $('.popup').hide();
    });

    // Gán Event cho Button Sửa:
    $('#btnDelete').click(function () {
        //$('.popup').hide();
        window.location.pathname = "/AddCustomer.aspx";
        //$('#popupInfoDetail').show();
        //$('#popupInfoDetail').draggable();
    });

    $('#btnSave').click(function () {
        var code = $('#txtCustomerCode').val();
        if (!code) {
            alert('Banj caanf nhapj ma khach hang!');
            $('#txtCustomerCode').attr('style', 'border-color:red;');
            $('#txtName').focus();
        } else {
            alert('theem thanh cong!');
        }
        //abc = 123;
    });

    $('#txtCustomerCode').blur(function () {
        abc = 123;
        //$('#txtCustomerCode').val(abc);
        $('#txtCustomerCode').val(code);
        $('#txtCustomerCode').attr('style', 'background-color:red;');
    });
});


var objTest = {
    btnEdit_OnClientClick: function () {
        $('.popup').show();
    }

};

var objTest2 = {
    btnEdit_OnClientClick: function () {
        alert(2);
    }

};