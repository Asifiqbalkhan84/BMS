$(document).ready(function (
) {
    BindTable();
});

function BindTable() {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Reviews.aspx/GetReview',
        success: function (data) {
            var arraydata = $.parseJSON(data.d);
            oTable = $('#tblReviews').DataTable({
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
                    },
                    {
                        'targets': 4,
                        'searchable': true,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, full, meta) {
                            return '<div class="btn-icon-list">' +
                                //'<a type="button"  class="btnEdit btn btn-edit"  href="AddReview.aspx?ID=' + full.ReviewID + '">' +
                                //'<i class="typcn typcn-edit" title="Edit Record"></i></a>' +
                                '<a type="button" class="btnDelete btn btn-delete" onclick="Delete(this.id)" id="' + full.ReviewID + '" >' +
                                '<i class="typcn typcn-trash" title="Delete Record"></i></a>' +
                                '</div>';
                        }
                    }
                ],
                columns: [
                    { 'data': "" },
                    { 'data': "FullName" },
                    { 'data': "Rating" },
                    { 'data': "Review" }
                ],

                aoColumns: [
                    { mData: '' },
                    { mData: 'FullName' },
                    { mData: 'Rating' },
                    { mData: 'Review' }
                ],
                dom: 'Bfrtip',
                buttons: [
                    {
                        extend: 'pdf',
                        footer: true,
                        className: 'btn btn-purple btnExport',
                        exportOptions: {
                            columns: [0, 1, 2, 3]
                        }
                    },
                    {
                        extend: 'csv',
                        footer: false,
                        className: 'btn btn-purple btnExport',
                        exportOptions: {
                            columns: [0, 1, 2, 3]
                        }

                    },
                    {
                        extend: 'print',
                        footer: false,
                        className: 'btn btn-purple btnExport',
                        exportOptions: {
                            columns: [0, 1, 2, 3]
                        }

                    },
                    {
                        extend: 'copy',
                        footer: false,
                        className: 'btn btn-purple btnExport',
                        exportOptions: {
                            columns: [0, 1, 2, 3]
                        }

                    },
                    {
                        extend: 'excel',
                        className: 'btn btn-purple btnExport',
                        exportOptions: {
                            columns: [0, 1, 2, 3]
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
                    url: "Reviews.aspx/DeleteReview",
                    data: JSON.stringify({ ID: id }),
                    success: function (data) {
                        if (data.d == "Success") {
                            swal("Review Inactivated successfully.");
                            BindTable();
                        }
                        else {
                            swal(data.d);
                        }
                    }
                });
            }
        });
}