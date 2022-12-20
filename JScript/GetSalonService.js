$(document).ready(function () {
    BindTable();
});

function BindTable() {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'invoice.aspx/GetSalonServices',
        success: function (data) {
            var arraydata = $.parseJSON(data.d);
            oTable = $('#tblsalonservice').DataTable({
                destroy: true,
                stateSave: true,
                data: arraydata,
                paging: true,
                sort: true,
                searching: true,
                columnDefs: [
                    {
                        'targets': 0,
                        'searchable': true,
                        'className': 'card-header',
                        'render': function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    }
                ],
                columns: [
                    { 'data': "" },
                    { 'data': "Date" },
                    { 'data': "OutletName" },
                    { 'data': "FullName" },
                    { 'data': "CatName" },
                    { 'data': "ServiceName" },
                    { 'data': "Amountpaid" }
                ],

                aoColumns: [
                    { mData: '' },
                    { mData: "Date" },
                    { mData: "OutletName" },
                    { mData: "FullName" },
                    { mData: "CatName" },
                    { mData: "ServiceName" },
                    { mData: "Amountpaid" },
                    { mData: '' }
                ],
                dom: 'Bfrtip',
                buttons: [
                    {
                        extend: 'pdf',
                        footer: true,
                        className: 'btn btn-purple btnExport',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6]
                        }
                    },
                    {
                        extend: 'csv',
                        footer: false,
                        className: 'btn btn-purple btnExport',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6]
                        }

                    },
                    {
                        extend: 'print',
                        footer: false,
                        className: 'btn btn-purple btnExport',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6]
                        }

                    },
                    {
                        extend: 'copy',
                        footer: false,
                        className: 'btn btn-purple btnExport',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6]
                        }

                    },
                    {
                        extend: 'excel',
                        className: 'btn btn-purple btnExport',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6]
                        },
                        footer: false
                    }
                ]
            });
            HideShowButton();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
}