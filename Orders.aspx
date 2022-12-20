<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Yuan.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JScript/Orders.js"></script>
    <style type="text/css">
        .table .thead-dark th {
            white-space: nowrap;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="az-content-body">
            <div class="az-dashboard-one-title">
                <div>
                    <h2 class="az-dashboard-title">Orders</h2>
                    <!-- <p class="az-dashboard-text">Welcome to the Yuan Thai Spa Admin Control Panel</p> -->
                </div>
                <div class="az-content-header-right">
                    <div class="media">
                        <div class="media-body">
                            <a href="AddOrder.aspx" class="btn btn-purple"><i class="typcn typcn-document-add"></i>Add Orders</a>
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
                        <div class="card-body mt-3">
                            <div class="table-responsive mb-3">
                                <table id="tblOrders" class="table table-striped table-bordered">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th class="pl-2 pr-2" scope="col">#</th>
                                            <th scope="col">Guest Name</th>
                                            <th scope="col">Order Value</th>
                                            <th scope="col">Cancelled</th>
                                            <th scope="col">Date of Cancel</th>
                                            <th scope="col">Paid</th>
                                            <th scope="col">Date of Payment</th>
                                            <th scope="col">Bill No</th>
                                            <th scope="col">Bill Date</th>
                                            <th scope="col">Receipt No</th>
                                            <th scope="col">Receipt Date</th>
                                            <th scope="col">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
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

    <!-- Modal -->
    <div class="modal fade" id="orders-details" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-xl modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle"><span class="GuestName"></span><span class="Membership"></span></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div id="invoice">

                        <div class="toolbar hidden-print">
                            <div class="text-right">
                                <button id="printInvoice" class="btn btn-info"><i class="fa fa-print"></i>Print</button>
                                <button class="btn btn-info"><i class="fa fa-file-pdf-o"></i>Export as PDF</button>
                            </div>
                            <hr>
                        </div>
                        <div class="invoice">
                            <div style="min-width: 600px">
                                <header>
                                    <div class="row">
                                        <div class="col mb-3">
                                            <a target="_blank" href="#">
                                                <img src="img/logo.png" data-holder-rendered="true" width="250px" />
                                            </a>
                                        </div>
                                        <div class="col-4 company-details">
                                            <h2 class="name">
                                                <a target="_blank" href="#"><span id="CompanyName" class="CompanyName"></span>
                                                </a>
                                            </h2>
                                            <div>Shanti Kutir Co-Op Hou.Soc.Ltd.</div>
                                            <div>Linking road Opp Mcdonald Telephone Exch.</div>
                                            <div>Mumbai - 400052</div>
                                            <div>info@yuanthaispa.com</div>
                                        </div>
                                    </div>
                                </header>
                                <main>
                                    <div class="row contacts">
                                        <div class="col invoice-to mb-3">
                                            <div class="text-gray-light">INVOICE TO:</div>
                                            <h2 class="to"><span id="Guestname" class="GuestName"></span></h2>
                                            <div class="address">
                                                <span id="Address1" class="Address1"></span>
                                                <br />
                                                <span id="Address2" class="Address2"></span>
                                            </div>
                                            <div class="email"><a href=""><span id="GuestEmail" class="GuestEmail"></span></a></div>
                                        </div>
                                        <div class="col-4 mt-3 invoice-details">
                                            <h1 class="invoice-id"><span id="BillNo" class="BillNo"></span></h1>
                                            <div class="date">Date of Invoice: <span id="BillDate" class="BillDate"></span></div>
                                            <%--<div class="date">Due Date: 03/11/2021</div>--%>
                                        </div>
                                    </div>
                                    <div class="table-responsive mb-3">
                                        <table id="tblOrderDetails" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Order</th>
                                                    <th>Service</th>
                                                    <th>Service Hrs</th>
                                                    <th>Extras</th>
                                                    <th>Price</th>
                                                    <th>Discount</th>
                                                    <th>Discount Details</th>
                                                    <th>Serviced By</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <td colspan="6"></td>
                                                    <td colspan="2">Net Total</td>
                                                    <td>Rs. <span id="NetValue" class="NetValue text-right"></span></td>
                                                </tr>
                                                <%-- <tr>
                                                    <td colspan="6"></td>
                                                    <td colspan="2">TaxRate </td>
                                                    <td><span class="Taxpercent"></span></td>
                                                </tr>--%>
                                                <tr>
                                                    <td colspan="6"></td>
                                                    <td colspan="2">Tax <span class="Taxpercent"></span></td>
                                                    <td>Rs.<span id="TaxValue" class="TaxValue text-right"></span></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6"></td>
                                                    <td colspan="2">SubTotal </td>
                                                    <td>Rs.<span id="OrderValue" class="OrderValue text-right"></span></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6"></td>
                                                    <td colspan="2">Discount </td>
                                                    <td>Rs.<span id="Discount" class="Discount text-right"></span></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6"></td>
                                                    <td colspan="2">Grand Total</td>
                                                    <td>Rs. <span id="FinalValue" class="FinalValue text-right"></span></td>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                    <!-- table-responsive -->
                                    <div class="thanks">Thank you!</div>
                                    <div class="notices">
                                        <div>Remarks: <span id="Remark"></span></div>
                                        <div class="notice">A finance charge of 1.5% will be made on unpaid balances after 30 days.</div>
                                    </div>
                                </main>
                                <footer>
                            </div>
                            <!--DO NOT DELETE THIS div. IT is responsible for showing footer always at the bottom-->
                            <div></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Ends-->

    <!-- Modal -->
    <div class="modal fade" id="payment-modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="OrderPayments">Payment Details</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:HiddenField ID="hdnOrderID" runat="server" />
                    <div class="row mb-4  dvAddPay">

                        <div class="col-lg-6 pb-2 pt-1">
                            <label>Total Amount</label>
                            <input type="text" id="txtTotal" runat="server" class="form-control" placeholder="Total Amount">
                        </div>
                        <!-- col -->

                        <div class="col-lg-6 pb-2 pt-1">
                            <label>Enter Pay Amount</label>
                            <input type="text" id="txtAmount" runat="server" class="form-control" placeholder="Enter Pay Amount">
                        </div>
                        <!-- col -->

                        <div class="col-lg-6 pb-2 pt-1">
                            <label>Mode Of Payment</label>
                            <asp:DropDownList ID="ddlModeofPay" runat="server" CssClass="form-control">
                                <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                <asp:ListItem Text="Netbanking" Value="Netbanking"></asp:ListItem>
                                <asp:ListItem Text="Credit Card" Value="Credit Card"></asp:ListItem>
                                <asp:ListItem Text="UPI" Value="UPI"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!-- col -->

                        <div class="col-lg-6 pb-2 pt-1">
                            <label>Recieved By</label>
                            <asp:DropDownList ID="ddlStaff" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <!-- col -->

                        <div class="col-lg-6 pb-2 pt-1">
                            <label>Balance Amount</label>
                            <input type="text" runat="server" id="BalanceAmount" class="form-control" placeholder="Balance Amount" />
                        </div>
                        <!-- col -->

                    </div>
                    <div class="row mb-4">
                        <div class="col-lg-12">
                            <h4>Paylogs</h4>
                            <div class="table-responsive mb-3">
                                <table id="tblPayments" class="table table-striped table-bordered">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th class="pl-2 pr-2" scope="col">#</th>
                                            <th scope="col">OrderID</th>
                                            <th scope="col">Date</th>
                                            <th scope="col">BillNo</th>
                                            <th scope="col">ReceiptNo</th>
                                            <th scope="col">AmountPaid</th>
                                            <th scope="col">Mode of Payment</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnPay" runat="server" CssClass="btn btn-info btnSubmitPayment" Text="Submit" OnClick="btnPay_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
