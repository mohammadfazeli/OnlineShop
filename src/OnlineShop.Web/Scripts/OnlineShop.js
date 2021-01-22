function ShowModal() {
    UIkit.modal("#MainModal").show();
}

function TableOperation(id, area, controller, OtherLinks = ['']) {
    if (OtherLinks.length != 0 && OtherLinks[0] != '') { Links = '<hr/>' + OtherLinks.join() } else { Links = OtherLinks.join(); }
    return '<div class=" text-center ">' +
        '<button type="button" class=" btn btn-small dropdown-toggle" data-toggle="dropdown"></button>' +
        '<div class="dropdown-menu">' +
        '<a  class="dropdown-item"  onclick=' + `ShowModalConfirmRemove('${area}','${controller}','${id}')` + ' ><span uk-icon="icon: trash"></span>asdasd</a>' +
        '<a  class="dropdown-item"  href="/' + area + '/' + controller + '/Edit/' + id + '"><span uk-icon="icon: file-edit"></span>ویرایش</a>' +
        Links.replace(",", "");
    //'<a  class="dropdown-item"  onclick=' + `ShowModalConfirmedit('${area}','${controller}','${id}')` + ' ><span uk-icon="icon: file-edit"></span>ویرایش</a>' +
    + '</div>'
    '</div>';
}

function ShowModalConfirmRemove(area, controller, id) {
    $("#ShowModalConfirmRemove").remove();
    $("#ModalRemoveFooter").append('<a id="ShowModalConfirmRemove" class="uk-button uk-button-primary" href=' + `/${area}/${controller}/Remove/${id}` + '><span uk-icon="check"></span></a>');
    UIkit.modal("#ModalRemove").show();
}

function ShowModalConfirmedit(area, controller, id) {
    $.ajax({
        type: "GET",
        url: "/Admin/Part/Edit/" + id + "",
        success: function (viewHTML) {
            $("#MainModalBody").html(viewHTML);
            UIkit.modal("#MainModal").show();
        },
        error: function (errorData) { onError(errorData); }
    });
}

function clearForms() {
    $(':input').not(':button, :submit, :reset, :hidden, :checkbox, :radio').val('');
    $(':checkbox, :radio').prop('checked', false);
}