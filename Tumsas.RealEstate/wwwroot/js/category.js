$(document).ready(function () {
    getCategories();
});

$(document).on("click", "#categoryTable button.editCategory", function () {
    let tr = $(this).closest('tr');
    let id = tr.find('.categoryId').text();

    request("/Categories/?handler=Category", { id: id }).done(function (result, response) {
        if (result && response.success) {

            $("#Category_Id").val(response.data.id);
            $("#Category_ParentId").val(response.data.parentId);
            $("#Category_Title").val(response.data.title);
            $("#Category_Description").val(response.data.description);

            $("#categoryEditModal").modal("show");

        } else alert(response.message);
    });
});

$("#newCategory").click(function () {

    $("#categoryEditModal").modal("show");

    setTimeout(function () {
        $("#Category_Id").val('');

        clearForm($("#categoryForm"));
    }, 500);
});

$("#saveChanges").click(function () {

    if ($("#categoryForm").valid()) {

        let category = $("#categoryForm").serializeObject();

        debugger

        parseInt(category["Category.Id"]) > 0 ? putCategory(category) : postCategory(category);
    }
});

function postCategory(category) {
    request("/Categories", category, "POST").done(function (result, response) {
        if (result && response.success) {

            $("#categoryEditModal").modal("hide");

            clearForm($("#categoryForm"));

            getCategories();

        } else alert(response.message);
    });
}

function putCategory(category) {
    request("/Categories", category, "PUT").done(function (result, response) {
        if (result && response.success) {

            $("#categoryEditModal").modal("hide");

            clearForm($("#categoryForm"));

            getCategories();

        } else alert(response.message);
    });
}

function deleteCategory(category) {
    request("/Categories", { id: category["Category.Id"] }, "DELETE").done(function (result, response) {
        if (result && response.success) {

            $("#categoryEditModal").modal("hide");

            clearForm($("#categoryForm"));

            getCategories();

        } else alert(response.message);
    });
}

function getCategories() {
    request("/Categories/?handler=Categories").done(function (result, response) {
        if (result && response.success) {

            let body = "";

            response.data.forEach(function (category) {
                body +=
                    '<tr>' +
                    '<td class="categoryId">' +
                    category.id +
                    '</td>' +
                    '<td class="parent">' +
                    (category.parentTitle ?? "") +
                    '</td>' +
                    '<td class="email">' +
                    category.title +
                    '</td>' +
                    '<td class="phoneNumber">' +
                    category.description +
                    '</td>' +
                    '<td>' +
                    '<button type="button" class="editCategory btn btn-primary" data-toggle="modal" data-target="#categoryEditModal">' +
                    '<i class="fa fa-edit"></i>' +
                    '</button>' +
                    '</td>' +
                    '</tr>';
            });

            $("#categoryTable tbody").html(body);

        } else alert(response.Message);
    });
}