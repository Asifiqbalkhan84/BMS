<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnquiryReports.aspx.cs" Inherits="Yuan.EnquiryReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="JScript/EnquiryReports.js"></script>--%>
    <style>
        th.thead-dark {
            color: #fff !important;
            background-color: #b17c0d !important;
            border-color: #b17c0d !important;
        }

        table.dataTable thead .sorting_asc {
            background-image: none !important;
        }

        table.dataTable thead .sorting_desc {
            background-image: none !important;
        }

        table.dataTable thead .sorting {
            background-image: none !important;
        }

        table#ContentPlaceHolder1_gvEnquiryReport tfoot tr th:nth-child(3) {
            text-align: end;
            padding: 10px 10px 0 0;
        }

        /*.inlinedatepicker {
            position: absolute;
            left: 140px;
            top: 24px;
            z-index: 999;
        }*/
        .datepicker.datepicker-dropdown.dropdown-menu.datepicker-orient-left.datepicker-orient-top {
            z-index: 999 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="az-content-body">
            <div class="az-dashboard-one-title">
                <div>
                    <h2 class="az-dashboard-title">Enquiries Reports</h2>
                    <!-- <p class="az-dashboard-text">Welcome to the Yuan Thai Spa Admin Control Panel</p> -->
                </div>

            </div>
            <!-- az-dashboard-one-title -->


            <div class="row row-sm mg-b-20">
                <div class="col-lg-12">
                    <div class="card card-dashboard-pageviews card-table-one">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-3 col-lg-3">
                                    <label for="min">From:</label>
                                    <%--<input type="text" id="min" class="form-control" name="min" placeholder="From date" autocomplete="off">--%>
                                    <asp:TextBox runat="server" ID="min" ClientIDMode="Static" CssClass="form-control" placeholder="From date" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-3 col-lg-3">
                                    <label for="max">To:</label>
                                    <%--<input type="text" id="max" name="max" class="form-control" placeholder="To date" autocomplete="off">--%>
                                    <asp:TextBox runat="server" ID="max" ClientIDMode="Static" CssClass="form-control" placeholder="To date" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <!-- card-header -->
                        <div class="card-body mt-3">
                            <div class="table-responsive mb-3">

                                <asp:GridView runat="server" ID="gvEnquiryReport" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                                    <Columns>
                                        <asp:BoundField DataField="EnquiryDate" HeaderText="DATE" HeaderStyle-CssClass="thead-dark" />
                                        <asp:BoundField DataField="Outlet" HeaderText="Outlet" HeaderStyle-CssClass="thead-dark" />
                                        <asp:BoundField DataField="Count" HeaderText="Enquires" HeaderStyle-CssClass="thead-dark" ItemStyle-CssClass="text-right" />
                                        <asp:BoundField DataField="Source" HeaderText="Source" HeaderStyle-CssClass="thead-dark" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <!-- table-responsive -->
                        </div>
                        <!-- card-body -->
                    </div>
                    <!-- card -->

                </div>
                <!-- col -->

            </div>
            <!-- row -->

        </div>
        <!-- az-content-body -->
    </div>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <link href="https://cdn.datatables.net/buttons/2.2.3/css/buttons.dataTables.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://cdn.datatables.net/plug-ins/1.11.5/api/sum().js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css" integrity="sha512-mSYUmp1HYZDFaVKK//63EcZq4iFWFjxSL+Z3T/aCt4IO9Cejm03q3NKKYN6pFQzY0SBOr8h+eCIAZHPXcpZaNw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js" integrity="sha512-T/tUfKSV1bihCnd+MxKD0Hm1uBBroVYBOYSk1knyvQ9VyZJpc/ALb4P0r6ubwVPSGB2GvjeoMAJJImBG12TiaQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/dataTables.buttons.min.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js" type="text/javascript"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/buttons.html5.min.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js" type="text/javascript"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/buttons.print.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $("#ContentPlaceHolder1_gvEnquiryReport").append(
                $('<tfoot/>').append($("#ContentPlaceHolder1_gvEnquiryReport thead tr").clone())
            );
            $("#ContentPlaceHolder1_gvEnquiryReport").DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[10, 20, -1], [10, 20, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    dom: 'Bfrtip',
                    buttons: [
                        'copy', 'csv', 'excel', 'pdf', 'print'
                    ],
                    drawCallback: function () {
                        var api = this.api();
                        var sum = 0;
                        var formated = 0;
                        //to show first th
                        $(api.column(0).footer()).html('');
                        $(api.column(1).footer()).html('Total');
                        $(api.column(3).footer()).html('');

                        for (var i = 2; i == 2; i++) {
                            sum = api.column(i, { page: 'current' }).data().sum();

                            //to format this sum
                            formated = parseFloat(sum).toLocaleString(undefined, { minimumFractionDigits: 0 });
                            $(api.column(i).footer()).html(formated);
                        }

                    }
                });
        });
    </script>
    <script>
        $(document).ready(function () {
            $.fn.dataTable.ext.search.push(
                function (settings, data, dataIndex) {
                    var min = $('#min').datepicker("getDate");
                    var max = $('#max').datepicker("getDate");
                    var startDate = new Date(data[0]);
                    if (min == null && max == null) { return true; }
                    if (min == null && startDate <= max) { return true; }
                    if (max == null && startDate >= min) { return true; }
                    if (startDate <= max && startDate >= min) { return true; }
                    return false;
                }
            );

            var table = $("#ContentPlaceHolder1_gvEnquiryReport").DataTable();
            $("#min").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });
            $("#max").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });


            // Event listener to the two range filtering inputs to redraw on input
            $('#min, #max').change(function () {
                table.draw();
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".buttons-copy,.buttons-csv,.buttons-csv,.buttons-excel,.buttons-pdf,.buttons-print").addClass("btn btn-purple");
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
