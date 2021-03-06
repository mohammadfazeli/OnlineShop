function ShowModal() {
    UIkit.modal("#MainModal").show();
}

function TableOperation(id, area, controller, OtherLinks = ['']) {
    if (OtherLinks.length != 0 && OtherLinks[0] != '') { Links = '<hr/>' + OtherLinks.join() } else { Links = OtherLinks.join(); }

    return '<span class=" text-center TableOperation dropdown dropright">' +
        '<button type="button" class="btn btn-default text-sm  dropdown-toggle" data-toggle="dropdown"></button>' +
        '<span class="dropdown-menu text-sm" style =" overflow: auto;">' +
        '<a  class="dropdown-item text-right "  href="#" onclick=' + `ShowModalConfirmRemove('${area}','${controller}','${id}')` + ' > حذف <li class="fas fa-trash"></li>  </a>' +
        '<a  class="dropdown-item text-right"   href="/' + area + '/' + controller + '/Edit/' + id + '">  ویرایش <li class="fas fa-edit left"></li>  </a>  ' +
        '<a  class="dropdown-item text-right "  href="#"  onclick=' + `ShowModalGetDetail('${area}','${controller}','${id}')` + ' > جزئیات <li class="fas fa-info"></li>  </a>' +
        '<a  class="dropdown-item text-right"   href="/' + "Admin" + '/' + "Attachment" + '/' + "PreView" + '/' + id + '">  ضمیمه ها <li class="fas fa-images left"></li>  </a> ' +

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

function OnSuccess(data) {
    debugger;
    PushMessage(data.message, data.status);
    clearForms();
}
function PushMessage(message, status) {
    switch (status) {
        case "Successfully":
            toastr.success(message);
            break;
        case "Dependent":
        case "NotExists":
        case "NotExists":
            toastr.warning(message);
            break;
        case "Fail":
            toastr.error(message);
            break;
        default:
            toastr.info(message);
    }
}