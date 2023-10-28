$(document).ready(function () {
    getUsers();
});

$(document).on("click", "#userTable button.editUser", function () {
    let tr = $(this).closest('tr');
    let id = tr.find('.userId').text();

    request("/Users/?handler=User", { id: id }).done(function (result, response) {
        if (result && response.success) {

            $("#User_Id").val(response.data.id);
            $("#User_FirstName").val(response.data.firstName);
            $("#User_LastName").val(response.data.lastName);
            $("#User_Email").val(response.data.email);
            $("#User_PhoneNumber").val(response.data.phoneNumber);
            $("#User_Password").val(response.data.password);

            $("#userEditModal").modal("show");

        } else alert(response.message);
    });
});

$("#newUser").click(function () {

    $("#userEditModal").modal("show");

    setTimeout(function () {
        $("#User_Id").val('');

        clearForm($("#userForm"));
    }, 500);
});

$("#saveChanges").click(function () {

    if ($("#userForm").valid()) {

        let user = $("#userForm").serializeObject();

        debugger

        parseInt(user["User.Id"]) > 0 ? putUser(user) : postUser(user);
    }
});

function postUser(user) {
    request("/Users", user, "POST").done(function (result, response) {
        if (result && response.success) {

            $("#userEditModal").modal("hide");

            clearForm($("#userForm"));

            getUsers();

        } else alert(response.message);
    });
}

function putUser(user) {
    request("/Users", user, "PUT").done(function (result, response) {
        if (result && response.success) {

            $("#userEditModal").modal("hide");

            clearForm($("#userForm"));

            getUsers();

        } else alert(response.message);
    });
}

function deleteUser(user) {
    request("/Users", { id: user["User.Id"] }, "DELETE").done(function (result, response) {
        if (result && response.success) {

            $("#userEditModal").modal("hide");

            clearForm($("#userForm"));

            getUsers();

        } else alert(response.message);
    });
}

function getUsers() {
    request("/Users/?handler=Users").done(function (result, response) {
        if (result && response.success) {

            let body = "";

            response.data.forEach(function (user) {
                body +=
                    '<tr>' +
                    '<td class="userId">' +
                    user.id +
                    '</td>' +
                    '<td class="fullName">' +
                    user.fullName +
                    '</td>' +
                    '<td class="email">' +
                    user.email +
                    '</td>' +
                    '<td class="phoneNumber">' +
                    user.phoneNumber +
                    '</td>' +
                    '<td>' +
                    '<button type="button" class="editUser btn btn-primary" data-toggle="modal" data-target="#userEditModal">' +
                    '<i class="fa fa-edit"></i>' +
                    '</button>' +
                    '</td>' +
                    '</tr>';
            });

            $("#userTable tbody").html(body);

        } else alert(response.Message);
    });
}