

$(document).ready(function () {
    BindSaleByOutlet();
    BindRecentMembers();
    BindIncomeByOutlet();
    BindSaleBySaff();
    BindTherapySessions();
    BindBilling();
});

function BindRecentMembers() {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Dashboard.aspx/GetRecentMembers',
        success: function (data) {
            var arraydata = $.parseJSON(data.d);
            oTable = $('#tblNewMembers').DataTable({
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
                ],
                columns: [
                    { 'data': "SerialNo" },
                    { 'data': "GuestName" },
                    { 'data': "MobileNo" },
                    { 'data': "JoiningDate" },
                    { 'data': "DealName" }
                ],
                aoColumns: [
                    { mData: 'SerialNo' },
                    { mData: 'GuestName' },
                    { mData: 'MobileNo' },
                    { mData: 'JoiningDate' },
                    { mData: 'DealName' }
                ]
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
}

function BindIncomeByOutlet() {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Dashboard.aspx/GetIncomeByOutlet',
        success: function (data) {
            var arraydata = $.parseJSON(data.d);
            oTable = $('#tblIncome').DataTable({
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
                        'targets': 2,
                        'searchable': false,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return '<div class="text-right">' + '₹ ' + row.TotalSale.toFixed(2) + '</div>';
                        }
                    }
                ],
                columns: [
                    { 'data': "SerialNo" },
                    { 'data': "CompanyName" },
                    { 'data': "" }
                ],
                aoColumns: [
                    { mData: 'SerialNo' },
                    { mData: 'CompanyName' },
                    { mData: '' }
                ]
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });

}

function BindSaleBySaff() {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Dashboard.aspx/GetSaleBySaff',
        success: function (data) {
            var arraydata = $.parseJSON(data.d);
            oTable = $('#tblStaffIncome').DataTable({
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
                        'targets': 3,
                        'searchable': false,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return '<div class="text-right">' + '₹ ' + row.TotalSale.toFixed(2) + '</div>';
                        }
                    }
                ],
                columns: [
                    { 'data': "SerialNo" },
                    { 'data': "StaffName" },
                    { 'data': "Designation" },
                    { 'data': "" }
                ],
                aoColumns: [
                    { mData: 'SerialNo' },
                    { mData: 'StaffName' },
                    { mData: 'Designation' },
                    { mData: '' }
                ]
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
}

function BindBilling() {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Dashboard.aspx/GetBilling',
        success: function (data) {
            var arraydata = $.parseJSON(data.d);
            oTable = $('#tblBilling').DataTable({
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
                        'targets': 5,
                        'searchable': false,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, row, meta) {
                            return '<div class="text-right">' + '₹ ' + row.AmountPaid.toFixed(2) + '</div>';
                        }
                    }
                ],
                columns: [
                    { 'data': "SerialNo" },
                    { 'data': "BillNo" },
                    { 'data': "BillDate" },
                    { 'data': "GuestName" },
                    { 'data': "CompanyName" },
                    { 'data': "" }
                ],
                aoColumns: [
                    { mData: 'SerialNo' },
                    { mData: 'BillNo' },
                    { mData: 'BillDate' },
                    { mData: 'GuestName' },
                    { mData: "CompanyName" },
                    { mData: "" }
                ]
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
}

//function BindTotalVisitors() {
//    $.ajax({
//        type: "POST",
//        dataType: 'json',
//        contentType: "application/json; charset=utf-8",
//        url: 'Dashboard.aspx/BindTotalVisitors',
//        success: function (data) {
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            alert(xhr.responseText);
//        }
//    });
//}

function BindTherapySessions() {
    var TotalSessions = 0;
    var labels, data;
    var companyName = [];
    var arrdata = [];
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Dashboard.aspx/GetTherapySessions',
        success: function (data) {
            var result = $.parseJSON(data.d);
            $.each(result, function (k, v) {
                $.each(v, function (key, value) {
                    if (key == "TotalTherapySession") {
                        TotalSessions += value;
                    }
                    if (key == "CompanyName") {
                        companyName.push(value);
                    }
                    if (key == "TotalTherapySession") {
                        arrdata.push(value);
                    }
                });
            });
            $('.TherapySessions').html(TotalSessions);
            var ctx5 = document.getElementById('chartBar5').getContext('2d');
            new Chart(ctx5, {
                type: 'bar',
                data: {
                    labels: companyName,
                    datasets: [{
                        data: arrdata,
                        backgroundColor: '#560bd0'
                    }]
                },
                options: {
                    maintainAspectRatio: false,
                    tooltips: {
                        enabled: false
                    },
                    legend: {
                        display: false,
                        labels: {
                            display: false
                        }
                    },
                    scales: {
                        yAxes: [{
                            display: false,
                            ticks: {
                                beginAtZero: true,
                                fontSize: 11,
                                max: 80
                            }
                        }],
                        xAxes: [{
                            barPercentage: 0.6,
                            gridLines: {
                                color: 'rgba(0,0,0,0.08)'
                            },
                            ticks: {
                                beginAtZero: true,
                                fontSize: 11,
                                display: false
                            }
                        }]
                    }
                }
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
}

function BindSaleByOutlet() {
    var labels, data;
    var companyName = [];
    var arrdata = [];
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Dashboard.aspx/GetSaleByOutlet',
        success: function (data) {
            var result = $.parseJSON(data.d);
            $.each(result, function (k, v) {
                $.each(v, function (key, value) {
                    if (key == "CompanyName") {
                        companyName.push(value);
                    }
                    if (key == "TotalSale") {
                        arrdata.push(value);
                    }
                });
            });
            // Donut Chart
            var datapie = {
                labels: companyName,
                datasets: [{
                    data: arrdata,
                    backgroundColor: ['#6f42c1', '#007bff', '#17a2b8', '#00cccc', '#adb2bd']
                }]
            };
            var optionpie = {
                maintainAspectRatio: false,
                responsive: true,
                legend: {
                    display: false,
                },
                animation: {
                    animateScale: true,
                    animateRotate: true
                }
            };

            // For a doughnut chart
            var ctxpie = document.getElementById('chartDonut');
            var myPieChart6 = new Chart(ctxpie, {
                type: 'doughnut',
                data: datapie,
                options: optionpie
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
}

//JS for chart and linechart


//linechart

google.load("visualization", "1", { packages: ["corechart"] });
google.setOnLoadCallback(drawLine);
function drawLine() {
    var options = {
        title: 'Sales Per Day',

        bar: { groupWidth: "95%" },
        legend: { position: "none" },
        isStacked: true
    };
    $.ajax({
        type: "POST",
        url: "Dashboard.aspx/GetChartDataline",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var data = google.visualization.arrayToDataTable(r.d);
            var chart = new google.visualization.LineChart($("#linechart")[0]);
            chart.draw(data, options);
        },
        failure: function (r) {
           /* alert(r.d);*/
        },
        error: function (r) {
            /*alert(r.d);*/
        }
    });
}

//chart
var chartData; // globar variable for hold chart data
google.load("visualization", "1", { packages: ["corechart"] });

// Here We will fill chartData

$(document).ready(function () {

    $.ajax({
        url: "Dashboard.aspx/GetChartData",
        data: "",
        dataType: "json",
        type: "POST",
        contentType: "application/json; chartset=utf-8",
        success: function (data) {
            chartData = data.d;
        },
        error: function () {
           /* alert("Error loading data! Please try again.");*/
        }
    }).done(function () {
        // after complete loading data
        google.setOnLoadCallback(drawChart);
        drawChart();
    });
});


function drawChart() {
    var data = google.visualization.arrayToDataTable(chartData);

    var options = {
        title: "Most Busy Day of Outlet",
        pointSize: 2
    };

    var ColumnChart = new google.visualization.ColumnChart(document.getElementById('chart'));
    ColumnChart.draw(data, options);

}