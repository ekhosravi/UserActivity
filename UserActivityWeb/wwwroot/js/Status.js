var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/status/GetAllStatus",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "statusName", "width": "70%" },
            {
                "data": "statusId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/status/Upsert/${data}" class='btn btn-success text-white'
                                    style='cursor:pointer;'> <i class='far fa-edit'></i></a>
                            </div>`;
                }, "width": "30%"
            }
        ]
    });
}


//function loadDataTable() {
//    dataTable = $('#tblData').DataTable({
//        "ajax": {
//            "url": "/Status/GetAllStatus",
//            "type": "GET",
//            "datatype": "json"
//        },
//        "columns": [
//            { "data": "statusName", "width": "70%" },
//            {
//                "data": "statusId",
//                "render": function (data) {
//                    return `<div class="text-center">
//                                <a href="/Status/Upsert/${data}" class='btn btn-success text-white'
//                                    style='cursor:pointer;'> <i class='far fa-edit'></i></a>
//                                    &nbsp;
//                                <a onclick=Delete("/Status/Delete/${data}") class='btn btn-danger text-white'
//                                    style='cursor:pointer;'> <i class='far fa-trash-alt'></i></a>
//                                </div>
//                            `;
//                }, "width": "30%"
//            } 
//        ]
//    });
//}

//function Delete(url) {
//    swal({
//        title: "Are you sure you want to Delete?",
//        text: "You will not be able to restore the data!",
//        icon: "warning",
//        buttons: true,
//        dangerMode: true
//    }).then((willDelete) => {
//        if (willDelete) {
//            $.ajax({
//                type: 'DELETE',
//                url: url,
//                success: function (data) {
//                    if (data.success) {
//                        toastr.success(data.message);
//                        dataTable.ajax.reload();
//                    }
//                    else {
//                        toastr.error(data.message);
//                    }
//                }
//            });
//        }
//    });
//}