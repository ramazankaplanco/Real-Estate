function baseRequest(url, data, type, dataType, callback) {
    $.ajax({
        url: url,
        type: type,
        data: data,
        dataType: dataType,
        success: function (data) {
            callback(true, data);
        },
        error: function (error) {
            callback(false, error);
        },
        beforeSend: function (xhr) {
            xhr.setRequestHeader("RequestVerificationToken", $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        complete: function () {
        }
    });
}

function request(url, data = null, type = "GET", dataType = "JSON") {

    let deferred = $.Deferred();

    baseRequest(url,
        data,
        type,
        dataType,
        function (result, data) {
            deferred.resolve(result, data);
        });

    return deferred.promise();
}