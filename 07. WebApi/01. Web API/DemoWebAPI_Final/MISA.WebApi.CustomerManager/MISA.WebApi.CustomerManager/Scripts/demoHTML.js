/* ----------------------------------
 * Descreption: Hàm demo sử dụng js
 * Created by : NVMANH (30/01/2018)
 * ---------------------------------- */

$(document).ready(function () {
    $('.demoDiv').blur(function () {
        var name = $('.demoDiv');
        if (name.text() == '') {
            name.addClass('');
            name[0].title = 'Bạn cần nhập tên';
            name.focus();
        }
    });
    $('tr').click(function () {
        debugger;
    });
    // jQuery methods go here...
});

var oCustomeJS = {
    self :this,
    numberPope:10,
    demoAlert: function (param) {
        var me = this;
        var divDemo = document.getElementsByClassName('demoDiv')[0];
        if (divDemo.value == '') {
            divDemo.style.background = 'red';
        }

        var object = {
            Name: "Mạnh",
            Age: 13,
            Class: "FPT Univesity",
            getName: function () {

            }
        }
    }
}
