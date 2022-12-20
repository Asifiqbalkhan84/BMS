$(document).ready(function () {
    //BindSaleByOutlet();
});

function BindSaleByOutlet() {
    var labels, data;
    var companyName = [];
    var arrdata = [];
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'SalesActivityReport.aspx/GetSaleByOutlet',
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

// Chart 

google.load("visualization", "1", { packages: ["corechart"] });
google.setOnLoadCallback(drawChart);
function drawChart() {
    var options = {
        title: 'Company Sales Report Till Date',
        width: 600,
        height: 200,
        bar: { groupWidth: "20%" },
        legend: { position: "none" },
        isStacked: true
    };
    $.ajax({
        type: "POST",
        url: "SalesActivityReport.aspx/GetChartData",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            //var data = google.visualization.arrayToDataTable(r.d);
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'CompanyName');
            data.addColumn('number', 'TotalSale');

            for (var i = 0; i < r.d.length; i++) {
                data.addRow([r.d[i][0], parseInt(r.d[i][1])]);
            }
            var chart = new google.visualization.LineChart($("#chart")[0]);
            chart.draw(data, options);
        },
        failure: function (r) {
            //alert(r.d);
        },
        error: function (r) {
            //alert(r.d);
        }
    });
}




//Chart datewise ssales only for outlet login

google.load("visualization", "1", { packages: ["corechart"] });
google.setOnLoadCallback(drawChartTest);
function drawChartTest() {
    var options = {
        title: 'Company Sales Report of each Day',
        width: 600,
        height: 200,
        bar: { groupWidth: "20%" },
        legend: { position: "none" },
        isStacked: true
    };
    $.ajax({
        type: "POST",
        url: "SalesActivityReport.aspx/GetChartDataofEachDay",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            //var data = google.visualization.arrayToDataTable(r.d);
            var data = new google.visualization.DataTable();
            data.addColumn('date', 'day');
            data.addColumn('number', 'SalesDone');

            for (var i = 0; i < r.d.length; i++) {
                data.addRow([new Date(parseInt(r.d[i][0].substr(6))), parseInt(r.d[i][1])]);
            }
            var chart = new google.visualization.LineChart($("#chartTest")[0]);
            chart.draw(data, options);
        },
        failure: function (r) {
            //alert(r.d);
        },
        error: function (r) {
            //alert(r.d);
        }
    });
}



