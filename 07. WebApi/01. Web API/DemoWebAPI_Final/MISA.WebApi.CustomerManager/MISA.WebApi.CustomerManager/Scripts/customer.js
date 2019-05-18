

$(document).ready(function () {
    oCustomeJS.loadData();
    $('#btnAdd').click(oCustomeJS.add);
    $('#btnEdit').click(oCustomeJS.edit);
    $('#btnDelete').click(oCustomeJS.delete);
    $('#btnRefresh').click(oCustomeJS.refresh);
});

/* -------------------------------
 * Đối tượng quản lý JS của Customer
 * Created by: NVMANH (03/03/2018)
 */
var oCustomeJS = {
    self: this,
    uri: '/api/Customer',
    numberPope: 10,
    formatRowItem: function (item) {
        var html = '<td>' + item.MemberCardCode + '</td>' +
            '<td>' + item.FullName + '</td>' +
            '<td>' + item.CompanyName + '</td>' +
            '<td>' + item.CompanyCodeTax + '</td>' +
            '<td>' + item.Address + '</td>' +
            '<td>' + item.PhoneNumber + '</td>' +
            '<td>' + item.Email + '</td>' +
            '<td>' + item.MemberCardCode + '</td>' +
            '<td>' + item.RankCard + '</td>' +
            '<td>' + item.DebitAmount + '</td>' +
            '<td>' + item.Note + '</td>' +
            '<td>' + '' + '</td>';
        return html;
    },

    /* -------------------------------
     * Load lại dữ liệu
     * Created by: NVMANH (03/03/2018)
     */
    reloadData: function () {
        $('#tbCustomers tbody').html('');
        oCustomeJS.loadData();
    },

    /* -------------------------------
     * Load dữ liệu lấy từ database lên bảng
     * Created by: NVMANH (03/03/2018)
     */
    loadData: function () {
        $('.loading').show()
        setTimeout(function () {
            $.getJSON(oCustomeJS.uri)
                .done(function (data) {
                    // On success, 'data' contains a list of products.
                    $.each(data, function (key, item) {
                        // Add a list item for the product.
                        $('<tr>', { html: oCustomeJS.formatRowItem(item), id: item.CustomerID }).appendTo($('#tbCustomers tbody'));
                    });
                    $('#tbCustomers tbody tr').click(oCustomeJS.setRowSelected);
                    $('.loading').hide()
                });

        }, 500)
    },
    add: function (sender) {
        dialog = $("#dialog-form").dialog({
            autoOpen: false,
            height: 340,
            resize:false,
            width: 565,
            modal: true,
            buttons: [
                     {
                         id: "btnHelpDialog",
                         text: "Giúp",
                         click: function () {
                             $(this).dialog("close");
                         }
                     },
                    {
                        id: "btnSaveCustomer",
                        text: "Cất",
                        click: function () {
                            $(this).dialog("close");
                        }
                    },
                    {
                        id: "btnSaveAndAddDialog",
                        text: "Cất và thêm",
                        click: function () {
                            $(this).dialog("close");
                        }
                    },
                    {
                        id: "btnCloseDialog",
                        text: "Hủy bỏ",
                        click: function () {
                            $(this).dialog("close");
                        }
                    }
            ],
            close: function () {
                //form[0].reset();
                //allFields.removeClass("ui-state-error");
            }
        });
        dialog.dialog("open");
    },
    edit: function (sender) {

    },
    refresh: function () {
        oCustomeJS.reloadData();
    },
    /* -------------------------------
     * Xóa khách hàng
     * Created by: NVMANH (03/03/2018)
     */
    delete: function (sender) {
        var me = this,
            rowSelected = $('#tbCustomers tbody .rowSelected'),
            customerSelected;
        if (rowSelected.length > 0) {
            customerSelected = rowSelected[0];
            $('.delete-msg-content').html('Bạn có thực sự muốn xóa bản ghi này?');
            $(function () {
                $("#dialog-message").dialog({
                    modal: true,
                    buttons: {
                        Ok: function () {
                            serviceAjax.delete(oCustomeJS.uri, { "": customerSelected.id }, oCustomeJS.afterDelete);
                            $(this).dialog("close");
                        }
                    }
                });
            });
        } else {
            $('.delete-msg-content').html('Không có bản ghi nào được chọn.<br> Vui lòng kiểm tra lại.');
            $(function () {
                $("#dialog-message").dialog({
                    modal: true,
                    buttons: {
                        Ok: function () {
                            $(this).dialog("close");
                        }
                    }
                });
            });
        }
        $('#dialog-message').show();
    },

    /* -------------------------------
     * Hàm thực hiện sau khi xóa dữ liệu
     * Created by: NVMANH (03/03/2018)
     */
    afterDelete: function (data) {
        oCustomeJS.reloadData();
    },

    /* -------------------------------
     * Set row selected
     * Created by: NVMANH (03/03/2018)
     */
    setRowSelected: function (sender) {
        var me = this;
        $('tr').removeClass('rowSelected');
        me.classList.add('rowSelected');
    }
}
