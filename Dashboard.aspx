<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Yuan.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="az-content az-content-dashboard">
      <div class="container">
        <div class="az-content-body">
          <div class="az-dashboard-one-title">
            <div>
              <h2 class="az-dashboard-title">Hi <asp:Literal ID="ltrUserName" runat="server"></asp:Literal>!</h2>
              <p class="az-dashboard-text">Welcome to the Yuan Thai Spa Admin Control Panel</p>
            </div>
            <div class="az-content-header-right">
              <div class="media">
                <div class="media-body">
                  <label>Today's Date</label>
                  <h6><asp:Literal ID="ltrDate" runat="server"></asp:Literal></h6>
                </div><!-- media-body -->
              </div><!-- media -->
            </div>
          </div><!-- az-dashboard-one-title -->

          <div class="row row-sm mg-b-20">
            <div class="col-lg-7 mg-t-20 mg-lg-t-0">
              <div class="card card-dashboard-four">
                <div class="card-header">
                  <h6 class="card-title">Sales by Outlets</h6>
                </div><!-- card-header -->
                <div class="card-body row">
                  <div class="col-md-6 d-flex align-items-center">
                    <div class="chart"><canvas id="chartDonut"></canvas></div>
                  </div><!-- col -->
                  <div class="col-md-6 col-lg-5 mg-lg-l-auto mg-t-20 mg-md-t-0">
                    <div class="az-traffic-detail-item">
                      <div>
                        <span>Andheri</span>
                        <span>1,320 <span>(25%)</span></span>
                      </div>
                      <div class="progress">
                        <div class="progress-bar bg-purple wd-25p" role="progressbar" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                      </div><!-- progress -->
                    </div>
                    <div class="az-traffic-detail-item">
                      <div>
                        <span>Juhu</span>
                        <span>987 <span>(20%)</span></span>
                      </div>
                      <div class="progress">
                        <div class="progress-bar bg-primary wd-20p" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100"></div>
                      </div><!-- progress -->
                    </div>
                    <div class="az-traffic-detail-item">
                      <div>
                        <span>Bandra</span>
                        <span>2,010 <span>(30%)</span></span>
                      </div>
                      <div class="progress">
                        <div class="progress-bar bg-info wd-30p" role="progressbar" aria-valuenow="30" aria-valuemin="0" aria-valuemax="100"></div>
                      </div><!-- progress -->
                    </div>
                    <div class="az-traffic-detail-item">
                      <div>
                        <span>Chembur</span>
                        <span>654 <span>(15%)</span></span>
                      </div>
                      <div class="progress">
                        <div class="progress-bar bg-teal wd-15p" role="progressbar" aria-valuenow="15" aria-valuemin="0" aria-valuemax="100"></div>
                      </div><!-- progress -->
                    </div>
                    <div class="az-traffic-detail-item">
                      <div>
                        <span>Borivili</span>
                        <span>400 <span>(10%)</span></span>
                      </div>
                      <div class="progress">
                        <div class="progress-bar bg-gray-500 wd-10p" role="progressbar" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100"></div>
                      </div><!-- progress -->
                    </div>
                  </div><!-- col -->
                </div><!-- card-body -->
              </div><!-- card-dashboard-four -->
            </div><!-- col -->
            <div class="col-lg-5 mg-t-20 mg-lg-t-0">
              <div class="row row-sm">
                <div class="col-sm-6">
                  <div class="card card-dashboard-two">
                    <div class="card-header">
                      <h6>33.50% <i class="icon ion-md-trending-up tx-success"></i> <small>18.02%</small></h6>
                      <p>Cash Flow</p>
                    </div><!-- card-header -->
                    <div class="card-body">
                      <div class="chart-wrapper">
                        <div id="flotChart1" class="flot-chart"></div>
                      </div><!-- chart-wrapper -->
                    </div><!-- card-body -->
                  </div><!-- card -->
                </div><!-- col -->
                <div class="col-sm-6 mg-t-20 mg-sm-t-0">
                  <div class="card card-dashboard-two">
                    <div class="card-header">
                      <h6>86k <i class="icon ion-md-trending-down tx-danger"></i> <small>0.86%</small></h6>
                      <p>Total Visitors</p>
                    </div><!-- card-header -->
                    <div class="card-body">
                      <div class="chart-wrapper">
                        <div id="flotChart2" class="flot-chart"></div>
                      </div><!-- chart-wrapper -->
                    </div><!-- card-body -->
                  </div><!-- card -->
                </div><!-- col -->
                <div class="col-sm-12 mg-t-20">
                  <div class="card card-dashboard-three">
                    <div class="card-header">
                      <p>All Therapy Sessions</p>
                      <h6>16,869 <small class="tx-success"><i class="icon ion-md-arrow-up"></i> 2.87%</small></h6>
                      <small>The total number of therapy sessions this month till date for all outlets of Yuan Thai Spa. Average spent is Rs. 2750 / per session.</small>
                    </div><!-- card-header -->
                    <div class="card-body">
                      <div class="chart"><canvas id="chartBar5"></canvas></div>
                    </div>
                  </div>
                </div>
              </div><!-- row -->
            </div><!--col -->
          </div><!-- row -->

          <div class="row row-sm mg-b-20">
            <div class="col-lg-6">
              <div class="card card-dashboard-pageviews card-table-one">
                <div class="card-header">
                  <h6 class="card-title">Members</h6>
                  <p class="card-text">This report is based on 100% of sessions.</p>
                </div><!-- card-header -->
                <div class="card-body">
                  <div class="table-responsive">
                    <table class="table">
                    <thead class="thead-dark">
                      <tr>
                        <th class="pl-2 pr-2" scope="col">#</th>
                        <th scope="col">Name</th>
                        <th scope="col">Contact</th>
                        <th scope="col">Joining Date</th>
                        <th scope="col">Membership</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">1</th>
                        <td>John Carter</td>
                        <td>+54 82085 7849</td>
                        <td>13/09/2021</td>
                        <td>Gold</td>
                      </tr>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">2</th>
                        <td>Jack Ryan</td>
                        <td>+54 85685 5864</td>
                        <td>14/09/2021</td>
                        <td>Premium</td>
                      </tr>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">3</th>
                        <td>Joseph</td>
                        <td>+54 85585 2358</td>
                        <td>15/09/2021</td>
                        <td>Ultimate</td>
                      </tr>
                    </tbody>
                  </table>
                  </div><!-- table-responsive -->
                </div><!-- card-body -->
              </div><!-- card -->

            </div><!-- col -->
            <div class="col-lg-6 mg-t-20 mg-lg-t-0">
              <div class="card card-dashboard-pageviews card-table-one">
                <div class="card-header">
                  <h6 class="card-title">Billings</h6>
                  <p class="card-text">This report is based on 100% of sessions.</p>
                </div><!-- card-header -->
                <div class="card-body">
                  <div class="table-responsive">
                    <table class="table">
                    <thead class="thead-dark">
                      <tr>
                        <th class="pl-2 pr-2" scope="col">#</th>
                        <th scope="col">Bill Date</th>
                        <th scope="col">Name</th>
                        <th scope="col">Location</th>
                        <th scope="col">Due Date</th>
                        <th scope="col">Amount (Rs.)</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">1</th>
                        <td>13/05/21</td>
                        <td>Arsalan Khan</td>
                        <td>Bandra</td>
                        <td>29/05/21</td>
                        <td>13500</td>
                      </tr>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">2</th>
                        <td>21/08/21</td>
                        <td>Rakesh Kumar</td>
                        <td>Kurla</td>
                        <td>05/09/211</td>
                        <td>5750</td>
                      </tr>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">3</th>
                        <td>16/09/21</td>
                        <td>Peter</td>
                        <td>Mahim</td>
                        <td>30/09/21</td>
                        <td>2500</td>
                      </tr>
                    </tbody>
                  </table>
                  </div><!-- table-responsive -->
                </div><!-- card-body -->
              </div><!-- card-dashboard-four -->
            </div><!-- col -->
            
          </div><!-- row -->


          <div class="row row-sm mg-b-20">
            <div class="col-lg-6">
              <div class="card card-dashboard-pageviews card-table-one">
                <div class="card-header">
                  <h6 class="card-title">Outlets</h6>
                  <p class="card-text">This report is based on 100% of sessions.</p>
                </div><!-- card-header -->
                <div class="card-body">
                  <div class="table-responsive">
                    <table class="table">
                    <thead class="thead-dark">
                      <tr>
                        <th class="pl-2 pr-2" scope="col">#</th>
                        <th scope="col">Outlet Name</th>
                        <th scope="col">Income</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">1</th>
                        <td>Bandra</td>
                        <td>2.5L</td>
                      </tr>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">2</th>
                        <td>Juhu</td>
                        <td>1.5L</td>
                      </tr>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">3</th>
                        <td>Chembur</td>
                        <td>0.8L</td>
                      </tr>
                    </tbody>
                  </table>
                  </div><!-- table-responsive -->
                </div><!-- card-body -->
              </div><!-- card -->

            </div><!-- col -->
            <div class="col-lg-6 mg-t-20 mg-lg-t-0">
              <div class="card card-dashboard-pageviews card-table-one">
                <div class="card-header">
                  <h6 class="card-title">Staff Performance</h6>
                  <p class="card-text">This report is based on 100% of sessions.</p>
                </div><!-- card-header -->
                <div class="card-body">
                  <div class="table-responsive">
                    <table class="table">
                    <thead class="thead-dark">
                      <tr>
                        <th class="pl-2 pr-2" scope="col">#</th>
                        <th scope="col">Name</th>
                        <th scope="col">Designation</th>
                        <th scope="col">Sales Amount (Rs.)</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">1</th>
                        <td>Mark</td>
                        <td>Therapist</td>
                        <td>20,000</td>
                      </tr>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">2</th>
                        <td>Jacob</td>
                        <td>Head Masseur</td>
                        <td>30,000</td>
                      </tr>
                      <tr>
                        <th class="pl-2 pr-2" scope="row">3</th>
                        <td>Madhavi</td>
                        <td>Sr. Therapist</td>
                        <td>50,000</td>
                      </tr>
                    </tbody>
                  </table>
                  </div><!-- table-responsive -->
                </div><!-- card-body -->
              </div><!-- card-dashboard-four -->
            </div><!-- col -->
            
          </div><!-- row -->

          
        </div><!-- az-content-body -->
      </div>
    </div><!-- az-content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
    <script>
        $(function () {
            'use strict'


            $.plot('#flotChart1', [{
                data: dashData2,
                color: '#00cccc'
            }], {
                series: {
                    shadowSize: 0,
                    lines: {
                        show: true,
                        lineWidth: 2,
                        fill: true,
                        fillColor: { colors: [{ opacity: 0.2 }, { opacity: 0.2 }] }
                    }
                },
                grid: {
                    borderWidth: 0,
                    labelMargin: 0
                },
                yaxis: {
                    show: false,
                    min: 0,
                    max: 35
                },
                xaxis: {
                    show: false,
                    max: 50
                }
            });

            $.plot('#flotChart2', [{
                data: dashData2,
                color: '#007bff'
            }], {
                series: {
                    shadowSize: 0,
                    bars: {
                        show: true,
                        lineWidth: 0,
                        fill: 1,
                        barWidth: .5
                    }
                },
                grid: {
                    borderWidth: 0,
                    labelMargin: 0
                },
                yaxis: {
                    show: false,
                    min: 0,
                    max: 35
                },
                xaxis: {
                    show: false,
                    max: 20
                }
            });


            //-------------------------------------------------------------//


            // Line chart
            $('.peity-line').peity('line');

            // Bar charts
            $('.peity-bar').peity('bar');

            // Bar charts
            $('.peity-donut').peity('donut');

            var ctx5 = document.getElementById('chartBar5').getContext('2d');
            new Chart(ctx5, {
                type: 'bar',
                data: {
                    labels: [0, 1, 2, 3, 4, 5, 6, 7],
                    datasets: [{
                        data: [2, 4, 10, 20, 45, 40, 35, 18],
                        backgroundColor: '#560bd0'
                    }, {
                        data: [3, 6, 15, 35, 50, 45, 35, 25],
                        backgroundColor: '#cad0e8'
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

            // Donut Chart
            var datapie = {
                labels: ['Search', 'Email', 'Referral', 'Social', 'Other'],
                datasets: [{
                    data: [25, 20, 30, 15, 10],
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

        });
    </script>
</asp:Content>
