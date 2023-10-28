let baseUrl = "https://localhost:7079/api"

$(document).ready(function () {
    getCategories();
});

function getCategories() {
    request(`${baseUrl}/Categories`).done(function (result, response) {

        if (result && response.success) {

            let options = `<option value=""> - </option>`;

            response.data.forEach(function (category) {
                options += `<option value="${category.id}"> ${category.title} </option>`;
            });

            $("#category").append(options);

        } else alert(response.Message);
    });
}