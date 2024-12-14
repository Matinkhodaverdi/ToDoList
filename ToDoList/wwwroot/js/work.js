const da = require("../AdminLTE/plugins/fullcalendar/locales/da");

var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Work/GetAll"
        },
        "columns": [
            { "data": "isActive", "width": "10%" },
            { "data": "name", "width": "60%" },
            { "data": "star", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class = "w-75 btn-group" "role = group">
                    <a href = "/Work/Upsert?id=${data}"  class="btn btn-primary mx-2">
                    <i class="bi bi-pencil-square"></i>
                    </a>

                    <a onClick=Delete('/Work/Delete/${data}' class="btn btn-danger mx-2">
                    <i class="bi bi-trash-fill"></i>
                    </a>
                    </div>
                    `
                },
                "width":"20%"
            },
        ]
    });

}

function Delete(url) {
    Swal.fire({
        title: 'آیا از حذف مطمئنید؟',
        text: "شما نمی توانید این را برگردانید!",
        icon: 'warning',
        showCancelButton: true,
        cancelButtonText: "نه!",
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله حذفش کن'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}     