function ShowModal() {
    UIkit.modal("#MainModal").show();
}

function TableOperation(id, area, controller, OtherLinks = ['']) {
    if (OtherLinks.length != 0 && OtherLinks[0] != '') { Links = '<hr/>' + OtherLinks.join() } else { Links = OtherLinks.join(); }
    return '<div class=" text-center dropdown dropright">' +
        '<button type="button" class="btn btn-default  dropdown-toggle dropdown-icon dropdown-toggle" data-toggle="dropdown"></button>' +
        '<div class="dropdown-menu">' +
        '<a  class="dropdown-item text-right "  href="#" onclick=' + `ShowModalConfirmRemove('${area}','${controller}','${id}')` + ' ><li class="fas fa-trash"></li>حذف</a>' +
        '<a  class="dropdown-item text-right"   href="/' + area + '/' + controller + '/Edit/' + id + '"><li class="fas fa-edit left"></li> ویرایش</a>  ' +
        '<a  class="dropdown-item text-right " href="#"  onclick=' + `ShowModalGetDetail('${area}','${controller}','${id}')` + ' ><li class="fas fa-info"></li>جزئیات</a>' +

        Links.replace(",", "");
    //'<a  class="dropdown-item"  onclick=' + `ShowModalConfirmedit('${area}','${controller}','${id}')` + ' ><span uk-icon="icon: file-edit"></span>ویرایش</a>' +
    + '</div>'
    '</div>';
}

function ShowModalConfirmRemove(area, controller, id) {
    $("#ShowModalConfirmRemove").remove();
    $("#ModalRemoveFooter").append('<div class="float-right"> <a id="ShowModalConfirmRemove" class=" btn  btn-outline-success btn-flat right" href=' + `/${area}/${controller}/Remove/${id}` + '><span class="fas fa-check"></span></a></div>');
    $("#ModalRemove").modal();
}

function ShowModalGetDetail(area, controller, id) {
    $.ajax({
        type: "GET",
        url: "/" + area + "/" + controller + "/GetInfo/" + id,
        success: function (viewHTML) {
            $("#ModalInfoBody").html(viewHTML);
            $("#ModalInfo").modal();
        },
        error: function (errorData) { onError(errorData); }
    });
}

function ShowModalConfirmedit(area, controller, id) {
    $.ajax({
        type: "GET",
        url: "/Identity/Part/Edit/" + id + "",
        success: function (viewHTML) {
            $("#MainModalBody").html(viewHTML);
            //UIkit.modal("#MainModal").show();
            $("#MainModal").modal();
        },
        error: function (errorData) { onError(errorData); }
    });
}

function clearForms() {
    $(':input').not(':button, :submit, :reset, :hidden, :checkbox, :radio').val('');
    $(':checkbox, :radio').prop('checked', false);
}