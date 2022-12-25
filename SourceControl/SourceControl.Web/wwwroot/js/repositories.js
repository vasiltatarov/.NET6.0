var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Repository/GetAll"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "description", "width": "30%" },
            { "data": "type", "width": "10%" },
            { "data": "license", "width": "10%" },
            { "data": "userEmail", "width": "15%" },
            { "data": "createdOn", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/Admin/Repository/Edit?id=${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i>
                            </a>
                            <a href="/Admin/Repository/Delete?id=${data}" class="btn btn-danger mx-2">
                                <i class="bi bi-trash-fill"></i>
                            </a>
                        </div>
                    `;
                },
                "width": "15%"
            }
        ]
    });
}