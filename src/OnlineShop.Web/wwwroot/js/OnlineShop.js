function ShowModal() {
    UIkit.modal("#MainModal").show();
}

function TableOperation(id, area, controller, OtherLinks = ['']) {
    if (OtherLinks.length != 0 && OtherLinks[0] != '') { Links = '<hr/>' + OtherLinks.join() } else { Links = OtherLinks.join(); }
<<<<<<< HEAD
    return '<span class=" text-center TableOperation">' +
        '<button type="button" class="btn btn-default fas fa-ellipsis-v  " data-toggle="dropdown"></button>' +
        '<span class="dropdown-menu">' +
        '<a  class="dropdown-item text-right "  href="#" onclick=' + `ShowModalConfirmRemove('${area}','${controller}','${id}')` + ' >حذف <li class="fas fa-trash"></li></a>' +
        '<a  class="dropdown-item text-right"   href="/' + area + '/' + controller + '/Edit/' + id + '"> ویرایش <li class="fas fa-edit left"></li></a>  ' +
        '<a  class="dropdown-item text-right "  href="#"  onclick=' + `ShowModalGetDetail('${area}','${controller}','${id}')` + ' >جزئیات <li class="fas fa-info"></li></a>' +
        '<a  class="dropdown-item text-right"   href="/' + "Admin" + '/' + "Attachment" + '/' + "PreView" + '/' + id + '"> ضمیمه ها  <li class="fas fa-images left"></li></a> ' +
=======
    return '<div class=" text-center dropdown dropright">' +
        '<button type="button" class="btn btn-default  dropdown-toggle dropdown-icon dropdown-toggle" data-toggle="dropdown"></button>' +
        '<div class="dropdown-menu">' +
        '<a  class="dropdown-item text-right "  href="#" onclick=' + `ShowModalConfirmRemove('${area}','${controller}','${id}')` + ' ><li class="fas fa-trash"></li>حذف</a>' +
        '<a  class="dropdown-item text-right"   href="/' + area + '/' + controller + '/Edit/' + id + '"><li class="fas fa-edit left"></li> ویرایش</a>  ' +
        '<a  class="dropdown-item text-right "  href="#"  onclick=' + `ShowModalGetDetail('${area}','${controller}','${id}')` + ' ><li class="fas fa-info"></li>جزئیات</a>' +
        '<a  class="dropdown-item text-right"   href="/' + "Identity" + '/' + "Attachment" + '/' + "PreView" + '/' + id + '"><li class="fas fa-images left"></li> ضمیمه ها </a> ' +
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2

        Links.replace(/,/g, "");//replace all ',' --> ''
    //Links.replace(",", "");
    //'<a  class="dropdown-item"  onclick=' + `ShowModalConfirmedit('${area}','${controller}','${id}')` + ' ><span uk-icon="icon: file-edit"></span>ویرایش</a>' +
    + '</span>'
    '</span>';
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
        url: "/Admin/Part/Edit/" + id + "",
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