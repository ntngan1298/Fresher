var serviceAjax = {
    getJson: function (uri, callback) {
        $.getJSON(uri)
        .done(function (data) {
            return data;
        });
    },
    post: function () {
        $.ajax({
            url: uri,
            type: 'POST',
            data: param,
            dataType: 'application/json',
            success: function (result) {
                callback(result);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var exceptionMessage = JSON.parse(XMLHttpRequest.responseText).ExceptionMessage;
                alert(exceptionMessage);
            }
        });
    },

    put: function (uri,param, callback) {
        $.ajax({
            url: uri,
            type: 'PUT',
            data: param,
            dataType: 'application/json',
            success: function (result) {
                callback(result);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var exceptionMessage = JSON.parse(XMLHttpRequest.responseText).ExceptionMessage;
                alert(exceptionMessage);
            }
        });
    },
    delete: function (uri, param, callback) {
        debugger;
        $.ajax({
            url: uri,
            type: 'DELETE',
            data: param,
            dataType:'application/json',
            success: function (result) {
                callback(result);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var exceptionMessage = JSON.parse(XMLHttpRequest.responseText).ExceptionMessage;
                alert(exceptionMessage);
            }
        });
    },
}