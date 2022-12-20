
$(document).ready(function () {
    BindOrder();
});

function BindOrder() {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Orders.aspx/GetOrderList',
        success: function (data) {
            var arraydata = $.parseJSON(data.d);
            oTable = $('#tblOrders').DataTable({
                destroy: true,
                stateSave: true,
                data: arraydata,
                paging: true,
                sort: true,
                searching: true,
                autoWidth: false,
                columnDefs: [

                    {
                        'targets': 0,
                        'searchable': true,
                        'className': 'card-header',
                        'render': function (data, type, full, meta) {
                            return '<a href="#" class="Orderdetails btnView" id="' + full.OrderID + '" onclick="ViewOrder(this.id)">OR' + full.OrderID + '</a>';
                        }
                    },
                    {
                        'targets': 11,
                        'searchable': true,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, full, meta) {
                            return '<div class="btn-icon-list">' +
                                //'<a type="button"  class="btnEdit btn btn-edit"  href="AddOrder.aspx?ID=' + full.OrderID + '">' +
                                //'<i class="typcn typcn-edit" title="Edit Record"></i></a>' +
                                '<a type="button" class="btnDelete btn btn-delete" onclick="Delete(this.id)" id="' + full.OrderID + '" >' +
                                '<i class="typcn typcn-trash" title="Delete Record"></i></a>' +
                                '<a class="btn btn-view Orderdetails btnView"  id="' + full.OrderID + '" onclick="ViewOrder(this.id)"><i class="typcn typcn-eye"></i></a>' +
                                '<a class="btn btn-view OrderPayments"  status="' + full.PaymentStatus + '" id="' + full.OrderID + '"  onclick="BindPaymentTable(this.id, \'' + full.PaymentStatus + '\');"><svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" aria-hidden="true" role="img" class="iconify iconify--carbon" width="1em" height="1em" preserveAspectRatio="xMidYMid meet" viewBox="0 0 32 32" data-icon="carbon:currency-rupee"><path d="M24 7V5H8v2h5.5a4.49 4.49 0 0 1 4.45 4H8v2h9.95a4.49 4.49 0 0 1-4.45 4H8v2.345L17.617 28l1.338-1.486L10.606 19H13.5a6.504 6.504 0 0 0 6.475-6H24v-2h-4.025a6.472 6.472 0 0 0-1.795-4z" fill="currentColor"></path></svg></a>' +
                                '</div>';
                        }
                    }
                ],
                columns: [
                    { 'data': "" },
                    { 'data': "GuestName" },
                    { 'data': "FinalValue" },
                    { 'data': "CancellationStatus" },
                    { 'data': "DateofCancel" },
                    { 'data': "PaymentStatus" },
                    { 'data': "DateofPayment" },
                    { 'data': "BillNo" },
                    { 'data': "BillDate" },
                    { 'data': "ReceiptNo" },
                    { 'data': "ReceiptDate" }

                ],
                aoColumns: [
                    { mData: '' },
                    { mData: 'GuestName' },
                    { mData: 'FinalValue' },
                    { mData: 'CancellationStatus' },
                    { mData: 'DateofCancel' },
                    { mData: 'PaymentStatus' },
                    { mData: 'DateofPayment' },
                    { mData: 'BillNo' },
                    { mData: 'BillDate' },
                    { mData: 'ReceiptNo' },
                    { mData: 'ReceiptDate' }
                ],
                dom: 'Bfrtip',
                buttons: [
                    {
                        extend: 'pdf',
                        footer: true,
                        className: 'btn btn-purple',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                        }
                    },
                    {
                        extend: 'csv',
                        footer: false,
                        className: 'btn btn-purple',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                        }

                    },
                    {
                        extend: 'print',
                        footer: false,
                        className: 'btn btn-purple',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                        }

                    },
                    {
                        extend: 'copy',
                        footer: false,
                        className: 'btn btn-purple',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                        }

                    },
                    {
                        extend: 'excel',
                        className: 'btn btn-purple',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
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
                    url: "Orders.aspx/DeleteOrder",
                    data: JSON.stringify({ ID: id }),
                    success: function (data) {
                        location.reload();
                    }
                });
            }
        });
}


function ViewOrder(id) {
    GetOrderDetails(id);
    BindDetailsTable(id);
    $('#orders-details').modal('show');
}

function BindDetailsTable(OrderID) {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Orders.aspx/GetOrderDetails',
        data: "{'OrderID':'" + OrderID + "'}",
        success: function (data) {
            var arraydata = $.parseJSON(data.d);
            oTable = $('#tblOrderDetails').DataTable({
                destroy: true,
                stateSave: true,
                data: arraydata,
                paging: false,
                "info": false,
                sort: false,
                searching: false,
                autoWidth: false,
                columnDefs: [
                    {
                        'targets': 0,
                        'searchable': true,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    },
                    {
                        'targets': 1,
                        'searchable': false,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return '<span class="text-right">' + row.OrderName + '</span>';
                        }
                    },
                    {
                        'targets': 2,
                        'searchable': false,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return '<span class="text-center">' + row.ServiceName + '</span>';
                        }
                    },
                    {
                        'targets': 3,
                        'searchable': false,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return '<span class="text-right">' + row.ServiceHrs + '</span>';
                        }
                    },
                    {
                        'targets': 4,
                        'searchable': true,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return '<span class="text-right float-right">' + row.Extras + '</span>';
                        }
                    },
                    {
                        'targets': 5,
                        'searchable': true,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return '<span class="text-right float-right">' + row.Price + '</span>';
                        }
                    },
                    {
                        'targets': 6,
                        'searchable': true,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return '<span class="text-right float-right">' + row.Discount + '</span>';
                        }
                    },
                    {
                        'targets': 7,
                        'searchable': true,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return '<span class="text-right float-right">' + row.DiscountDetails + '</span>';
                        }
                    },
                    {
                        'targets': 8,
                        'searchable': false,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return row.StaffName == null ? '' : row.StaffName;
                        }
                    },
                ],
                columns: [
                    { 'data': "OrderID" },
                    { 'data': "OrderName" },
                    { 'data': "ServiceName" },
                    { 'data': "ServiceHours" },
                    { 'data': "Price" },
                    { 'data': "Extras" },
                    { 'data': "Discount" },
                    { 'data': "DiscountDetails" },
                    { 'data': "StaffName" }
                ],
                aoColumns: [
                    { mData: 'OrderID' },
                    { mData: 'OrderName' },
                    { mData: 'ServiceName' },
                    { mData: 'ServiceHours' },
                    { mData: 'Price' },
                    { mData: 'Extras' },
                    { mData: 'Discount' },
                    { mData: 'DiscountDetails' },
                    { mData: 'StaffName' }
                ],
                "initComplete": function () {
                    $('#orders-details').modal('show');
                }
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
}

function GetOrderDetails(OrderID) {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Orders.aspx/GetOrderInfo',
        data: "{'OrderID':'" + OrderID + "'}",
        success: function (data) {
            var result = $.parseJSON(data.d);
            $.each(result, function (k, v) {
                $.each(v, function (key, value) {
                    if (key == "OrderID") {
                        $("#ContentPlaceHolder1_hdnOrderID").val(value);
                    }
                    if (key == "PaymentStatus" && value == "Paid") {
                        $(".btnSubmitPayment").css("display", "none");
                        $(".btnSubmitPayment").css("display", "block");
                    }
                    if (key == "OrderNo") {
                        $(".OrderNo").html(value);
                    }
                    if (key == "GuestName") {
                        $(".GuestName").html(value);
                    }
                    if (key == "EmailID") {
                        $(".GuestEmail").html(value);
                    }
                    if (key == "Address1") {
                        $(".Address1").html(value);
                    }
                    if (key == "Address2") {
                        $(".Address2").html(value);
                    }
                    if (key == "OrderDate") {
                        $(".OrderDate").html(value);
                    }
                    if (key == "OrderValue") {
                        $(".OrderValue").html(value);
                    }
                    if (key == "NetValue") {
                        $(".NetValue").html(value);
                    }
                    if (key == "TaxValue") {
                        $(".TaxValue").html(value);
                    }
                    if (key == "FinalValue") {
                        $(".FinalValue").html(value);
                    }
                    if (key == "Discount") {
                        $(".Discount").html(value);
                    }
                    if (key == "BillNo") {
                        $(".BillNo").html(value);
                    }
                    if (key == "BillDate") {
                        $(".BillDate").html(value);
                    }
                });
            });
            $(".Taxpercent").html("18 %");
        }
    });
}

function BindPaymentTable(OrderID, Status) {
    $("#ContentPlaceHolder1_hdnOrderID").val(OrderID);
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Orders.aspx/GetOrderPayments',
        data: "{'OrderID':'" + OrderID + "'}",
        success: function (data) {
            var arraydata = $.parseJSON(data.d);
            oTable = $('#tblPayments').DataTable({
                destroy: true,
                stateSave: true,
                data: arraydata,
                paging: false,
                "info": false,
                sort: false,
                searching: false,
                autoWidth: false,
                columnDefs: [
                    {
                        'targets': 0,
                        'searchable': true,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    },
                    {
                        'targets': 1,
                        'searchable': true,
                        'className': 'card-header',
                        'render': function (data, type, full, meta) {
                            return '<span>ORD' + full.OrderID + '</span>';
                        }
                    }
                ],
                columns: [
                    { 'data': "PayID" },
                    { 'data': "OrderID" },
                    { 'data': "DateofPayment" },
                    { 'data': "BillNo" },
                    { 'data': "ReceiptNo" },
                    { 'data': "AmountPaid" },
                    { 'data': "ModeofPayment" }
                ],
                aoColumns: [
                    { mData: 'PayID' },
                    { mData: 'OrderID' },
                    { mData: 'DateofPayment' },
                    { mData: 'BillNo' },
                    { mData: 'ReceiptNo' },
                    { mData: 'AmountPaid' },
                    { mData: 'ModeofPayment' }
                ],
                "initComplete": function () {
                    $('#payment-modal').modal('show');
                }
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
    if (Status == "Unpaid" || Status == "Partially Paid") {

        $('.btnSubmitPayment').css("display", "block");
        $('.dvAddPay').show();
    }
    else {
        $('.dvAddPay').hide();
        $('.btnSubmitPayment').css("display", "none");
    }
}
