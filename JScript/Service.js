
$(document).ready(function () {
    BindService();

});

function BindService() {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Services.aspx/GetServiceList',
        success: function (data) {
            var arraydata = $.parseJSON(data.d);
            oTable = $('#tblServices').DataTable({
                destroy: true,
                stateSave: true,
                data: arraydata,
                paging: true,
                sort: true,
                searching: true,
                columnDefs: [
                    {
                        'targets': 0,
                        'searchable': false,
                        'className': 'card-header',
                        'render': function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    },
                    {
                        'targets': 8,
                        'searchable': false,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, full, meta) {
                            return '<div class="btn-icon-list">' +
                                '<a type="button"  class="btnEdit btn btn-edit"  href="AddServices.aspx?ID=' + full.ServiceID + '">' +
                                '<i class="typcn typcn-edit" title="Edit Record"></i></a>' +
                                '<a type="button" class="btnDelete btn btn-delete" onclick="Delete(this.id)" id="' + full.ServiceID + '" >' +
                                '<i class="typcn typcn-trash" title="Delete Record"></i></a>' +
                                '</div>';
                        }
                    }
                ],
                columns: [
                    { 'data': "" },
                    { 'data': "ServiceName" },
                    { 'data': "CatName" },
                    /*{ 'data': "ServiceDesc" },*/
                    { 'data': "ServiceHR" },
                    { 'data': "Price" },
                    { 'data': "SpecialOfferPrice" },
                    { 'data': "SpOfferValidity" },
                    { 'data': "OnlinePrice" },
                    { 'data': "Action" }

                ],

                aoColumns: [
                    { mData: '' },
                    { mData: 'ServiceName' },
                    { mData: 'CatName' },
                    /*{ mData: 'ServiceDesc' },*/
                    { mData: 'ServiceHR' },
                    { mData: 'Price' },
                    { mData: 'SpecialOfferPrice' },
                    { mData: 'SpOfferValidity' },
                    { mData: 'OnlinePrice' },
                    { mData: 'Action' },
                    { mData: '' }
                ],
                dom: 'Bfrtip',
                buttons: [
                    {
                        extend: 'pdf',
                        footer: true,
                        className: 'btn btn-purple',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6]
                        }
                    },
                    {
                        extend: 'csv',
                        footer: false,
                        className: 'btn btn-purple',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6]
                        }

                    },
                    {
                        extend: 'print',
                        footer: false,
                        className: 'btn btn-purple',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6]
                        }

                    },
                    {
                        extend: 'copy',
                        footer: false,
                        className: 'btn btn-purple',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6]
                        }

                    },
                    {
                        extend: 'excel',
                        className: 'btn btn-purple',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6]
                        },
                        footer: false
                    }
                ]
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
}

function Delete(id) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this !",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: "POST",
                    dataType: 'json',
                    contentType: "application/json; charset=utf-8",
                    url: "Services.aspx/DeleteService",
                    data: JSON.stringify({ ID: id }),
                    success: function (data) {
                        location.reload();
                    }
                });
            }
        });
}