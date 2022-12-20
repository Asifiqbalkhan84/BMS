$(document).ready(function (
) {
    BindTable();
});

function BindTable() {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Deals.aspx/GetDealList',
        success: function (data) {
            var arraydata = $.parseJSON(data.d);
            oTable = $('#tblDeal').DataTable({
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
                        'targets': 9,
                        'searchable': true,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, full, meta) {
                            return '<div class="btn-icon-list">' +
                                '<a type="button"  class="btnEdit btn btn-edit"  href="AddDeal.aspx?ID=' + full.DealID + '">' +
                                '<i class="typcn typcn-edit" title="Edit Record"></i></a>' +
                                '<a type="button" class="btn btn-view" data-toggle="modal" data-target="#deal-details" onclick="BindDealModel(this.id)" ID="' + full.DealID + '">' +
                                '<i class="typcn typcn-eye" title="view Record"></i></a>' +
                                '<a type="button" class="btnDelete btn btn-delete" onclick="Delete(this.id)" id="' + full.DealID + '" >' +
                                '<i class="typcn typcn-trash" title="Delete Record"></i></a>' +
                                '</div>';
                        }
                    }
                ],
                columns: [
                    { 'data': "" },
                    { 'data': "DealName" },
                    { 'data': "Outlet" },
                    { 'data': "Validity" },
                    { 'data': "DiscountPer" },
                    { 'data': "DiscountFlat" },
                    { 'data': "DiscountVoucher" },
                    { 'data': "MemberOnly" },
                    { 'data': "MemberType" }                    
                ],

                aoColumns: [
                    { mData: '' },
                    { mData: 'DealName' },
                    { mData: 'Outlet' },
                    { mData: 'Validity' },
                    { mData: 'DiscountPer' },
                    { mData: 'DiscountFlat' },
                    { mData: 'DiscountVoucher' },
                    { mData: 'MemberType' },
                    { mData: 'MemberOnly' },
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
                    url: "Deals.aspx/DeleteDeal",
                    data: JSON.stringify({ ID: id }),
                    success: function (data) {
                        location.reload();
                    }
                });
            }
        });
}

function BindDealModel(id) {
    $.ajax({
        type: "POST",
        dataType: "Json",
        contentType: "application/json; charset=utf-8",
        url: "Deals.aspx/ViewDeal",
        data: "{ID :'" + id + "'}",
        success: function (data) {
            $.each(JSON.parse(data.d), function (data, value) {
                /**************************************************************************************************************/
                //console.log(value.ServiceID);
                //alert(value.DealName);
                //debugger;
                $('.DealName').html(value.DealName);
                $('.ServiceName').html(value.ServiceName);
                $('.IsFree').html(value.IsFree);
                $('.price').html(value.Price);
                $('.ByUser').html(value.ByUser);
                //$(Service).closest('td').find('.txtHrs').val(value.ServiceHRs);
                //$(Service).closest('td').find('.txtAmount').val(value.Price);
            });
        },
        failure: function () {
            console.log('Error');
        }
    });
}