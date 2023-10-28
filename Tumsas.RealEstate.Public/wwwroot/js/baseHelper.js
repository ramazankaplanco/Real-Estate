$.fn.serializeObject = function (disabledFields = false) {

    let fields = disabledFields ? this.find(':input:disabled').removeAttr('disabled') : null;

    let obj = {};
    let arr = this.serializeArray();

    $.each(arr, function () {
        if (obj[this.name] !== undefined) {

            if (!obj[this.name].push)
                obj[this.name] = [obj[this.name]];

            obj[this.name].push(this.value || '');
        } else
            obj[this.name] = this.value || '';

    });

    if (fields) fields.attr('disabled', 'disabled');

    return obj;
};

function clearForm(form) {

    form.validate().resetForm();

    $(':input,select', form)
        .not(':button, :submit, :reset, :hidden')
        .val('')
        .removeAttr('checked')
        .removeAttr('selected');
}