<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FreeSlots.aspx.cs" Inherits="Yuan.FreeSlots" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
         .datepicker.datepicker-dropdown.dropdown-menu.datepicker-orient-left.datepicker-orient-top{
                z-index: 999 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="az-content-body">
            <div class="az-dashboard-one-title">
                <div>
                    <h2 class="az-dashboard-title">Free Slots</h2>
                    <!-- <p class="az-dashboard-text">Welcome to the Yuan Thai Spa Admin Control Panel</p> -->
                </div>
                <div class="az-content-header-right">
                    <div class="media">
                        <div class="media-body">
                            <a href="javascript:history.go(-1)" class="btn btn-purple"><i class="typcn typcn-arrow-back"></i>Back</a>
                        </div>
                        <!-- media-body -->
                    </div>
                    <!-- media -->
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
                                    <input type="text" id="min" class="form-control" name="min" placeholder="From date" autocomplete="off">
                                </div>
                                <div class="col-md-3 col-lg-3">
                                    <label for="max">To:</label>
                                    <input type="text" id="max" name="max" class="form-control" placeholder="To date" autocomplete="off">
                                </div>
                            </div>
                            <div class="float-left">
                                <%--  <asp:DropDownList runat="server" ID="dlappointmentslots" CssClass="form-control"></asp:DropDownList>--%>
                            </div>
                        </div>
                        <div class="card-body mt-3">
                            <div class="table-responsive mb-3">
                                <asp:GridView runat="server" ID="gvfreeslots" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                                    <Columns>
                                        <asp:BoundField DataField="CompanyName" HeaderText="OUTLET" HeaderStyle-CssClass="thead-dark" />
                                        <asp:BoundField DataField="DateofAppoint" HeaderText="DATE" HeaderStyle-CssClass="thead-dark" />
                                        <asp:BoundField DataField="Slots" HeaderText="SLOTS" HeaderStyle-CssClass="thead-dark" />
                                        <asp:BoundField DataField="NoofSlots" HeaderText="FREESLOTS" HeaderStyle-CssClass="thead-dark" />
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

    <%-- SCRIPT --%>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css" integrity="sha512-mSYUmp1HYZDFaVKK//63EcZq4iFWFjxSL+Z3T/aCt4IO9Cejm03q3NKKYN6pFQzY0SBOr8h+eCIAZHPXcpZaNw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js" integrity="sha512-T/tUfKSV1bihCnd+MxKD0Hm1uBBroVYBOYSk1knyvQ9VyZJpc/ALb4P0r6ubwVPSGB2GvjeoMAJJImBG12TiaQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script type="text/javascript">
        $(function () {
            $("#ContentPlaceHolder1_gvfreeslots").DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[10, 20, -1], [10, 20, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true
                });
        });
    </script>
    <script>
        $(document).ready(function () {
            $.fn.dataTable.ext.search.push(
                function (settings, data, dataIndex) {
                    var min = $('#min').datepicker("getDate");
                    var max = $('#max').datepicker("getDate");
                    var startDate = new Date(data[1]);
                    if (min == null && max == null) { return true; }
                    if (min == null && startDate <= max) { return true; }
                    if (max == null && startDate >= min) { return true; }
                    if (startDate <= max && startDate >= min) { return true; }
                    return false;
                }
            );

            var table = $("#ContentPlaceHolder1_gvfreeslots").DataTable();
            $("#min").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });
            $("#max").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });


            // Event listener to the two range filtering inputs to redraw on input
            $('#min, #max').change(function () {
                table.draw();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
