<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="Yuan.AddOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="container">
    <div class="az-content-body">
        <div class="az-dashboard-one-title">
            <div>
                <h2 class="az-dashboard-title">Add Orders</h2>
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
                <div class="card bg-add card-dashboard-pageviews card-table-one">
                    <div class="card-body">

                        <div class="row mb-4">
                            <div class="col-lg-12 mb-3">
                                <h4>Order Details</h4>
                            </div>
                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Guest Name</label>
                                <input id="txtGuestName" runat="server" tabindex="1" type="text" class="form-control" placeholder="Guest Name">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Order Value</label>
                                <input id="txtOrderValue" runat="server" tabindex="2" type="text" class="form-control" placeholder="Order Value">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Discount</label>
                                <input id="txtDiscount" runat="server" tabindex="4" type="text" class="form-control" placeholder="Discount">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Discount Details</label>
                                <input id="txtDiscountDet" runat="server" tabindex="6" type="text" class="form-control" placeholder="Discount Details">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Net Value</label>
                                <input id="txtNetValue" runat="server" tabindex="8" type="text" class="form-control" placeholder="Net Value">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Tax Value</label>
                                <input id="txtTaxValue" runat="server" tabindex="10" type="text" class="form-control" placeholder="Tax Value">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Final Value</label>
                                <input id="txtFinal" runat="server" tabindex="12" type="text" class="form-control" placeholder="Final Value">
                            </div>
                            <!-- col -->
                        </div>

                        <div class="row mb-3">
                            <div class="col-lg-12 mb-3">
                                <h4>Delivery Address</h4>
                            </div>
                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Delivery Add Line 1</label>
                                <input id="txtDelAdd1" runat="server" tabindex="14" type="text" class="form-control" placeholder="Delivery Add Line 1">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Delivery Add Line 2</label>
                                <input id="txtDelAdd2" runat="server" tabindex="16" type="text" class="form-control" placeholder="Delivery Add Line 2">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Delivery Area</label>
                                <input id="txtDelArea" runat="server" tabindex="18" type="text" class="form-control" placeholder="Delivery Area">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Delivery Landmark</label>
                                <input id="txtDelLandmark" runat="server" tabindex="20" type="text" class="form-control" placeholder="Delivery Landmark">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Delivery City</label>
                                <asp:DropDownList ID="drpCity" CssClass="form-control" TabIndex="22" runat="server">
                                    <asp:ListItem>--- Select ---</asp:ListItem>
                                    <asp:ListItem>Mumbai</asp:ListItem>
                                    <asp:ListItem>Pune</asp:ListItem>
                                    <asp:ListItem>Goa</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Delivery Postcode</label>
                                <input id="txtDelPostCode" runat="server" tabindex="24" type="number" class="form-control" placeholder="Delivery Postcode">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Delivery Contact No</label>
                                <input id="txtDelContactNo" runat="server" tabindex="26" type="number" class="form-control" placeholder="Delivery Contact No">
                            </div>
                            <!-- col -->
                        </div>

                        <div class="row mb-3">
                            <div class="col-lg-12 mb-3">
                                <h4>Cancellation</h4>
                            </div>
                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Cancelled</label>
                                <asp:DropDownList ID="drpCancel" CssClass="form-control" TabIndex="28" runat="server">
                                    <asp:ListItem>--- Select ---</asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Date of Cancel</label>
                                <input id="txtCancelDate" runat="server" tabindex="30" type="date" class="form-control" placeholder="Date of Cancel">
                            </div>
                            <!-- col -->
                        </div>

                        <div class="row mb-3">
                            <div class="col-lg-12 mb-3">
                                <h4>Payment</h4>
                            </div>
                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Paid</label>
                                <asp:DropDownList ID="drpPaid" CssClass="form-control" TabIndex="32" runat="server">
                                    <asp:ListItem>--- Select ---</asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Payment Mode</label>
                                <asp:DropDownList ID="drpPaymentMode" CssClass="form-control" TabIndex="33" runat="server">
                                    <asp:ListItem>--- Select ---</asp:ListItem>
                                    <asp:ListItem>Cash</asp:ListItem>
                                    <asp:ListItem>Credit Card</asp:ListItem>
                                    <asp:ListItem>Bank Transfer</asp:ListItem>
                                </asp:DropDownList>
                                <%--<select class="form-control">
                                                                       
                                    <option>Membership</option>
                                    <option>Complimentary</option>
                                </select>--%>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Date of Payment</label>
                                <input id="txtPaymentDate" runat="server" tabindex="34" type="date" class="form-control" placeholder="Date of Payment">
                            </div>
                            <!-- col -->
                        </div>

                        <div class="row mb-3">
                            <div class="col-lg-12 mb-3">
                                <h4>Deals</h4>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 mb-3">
                                <input id="txtDealCode" runat="server" tabindex="36" type="text" class="form-control" placeholder="Deal Code">
                                <a href="#" class="btn btn-purple btn-deals mt-3">Apply Deal</a>
                            </div>
                            <!-- col -->
                        </div>

                        <hr>
                        <div class="row mb-3">
                            <div class="col-lg-12 mb-3">
                                <h4>Services</h4>
                            </div>
                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Outlet</label>
                                <asp:DropDownList ID="drpOutlet" CssClass="form-control" TabIndex="38" runat="server">
                                    <asp:ListItem>--- Select ---</asp:ListItem>
                                    <asp:ListItem>Bandra</asp:ListItem>
                                    <asp:ListItem>Andheri</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <!-- col -->

                            <div class="col-lg-12 pb-2 pt-1">
                                <div class="table-wrap">
                                    <div class="table-responsive">
                                        <table class="table table-striped table-bordered" id="support_table5">
                                            <tbody>
                                                <tr>
                                                    <td colspan="5">Services</td>
                                                    <td style="text-align: center">
                                                        <a class="btn btn-purple" name="" value="Add" id="btnAdd">Add</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>Service Name</label>
                                                        <asp:DropDownList ID="drpService" runat="server" CssClass="form-control" TabIndex="40" runat="server">
                                                            <asp:ListItem>--- Select ---</asp:ListItem>
                                                            <asp:ListItem>Service1</asp:ListItem>
                                                            <asp:ListItem>Service2</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <label>Hrs</label>
                                                        <input type="text" class="form-control" placeholder="Hrs">
                                                    </td>
                                                    <td>
                                                        <label>Serviced By</label>
                                                        <asp:DropDownList ID="drpServiceBy" runat="server" CssClass="form-control" TabIndex="42">
                                                            <asp:ListItem>--- Select ---</asp:ListItem>
                                                            <asp:ListItem>Jinal</asp:ListItem>
                                                            <asp:ListItem>Abhishek</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <label>Qty</label>
                                                        <asp:DropDownList ID="drpQty" runat="server" CssClass="form-control" TabIndex="43" >
                                                            <asp:ListItem>--- Select ---</asp:ListItem>
                                                            <asp:ListItem>1</asp:ListItem>
                                                            <asp:ListItem>2</asp:ListItem>
                                                            <asp:ListItem>3</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <label>Amount</label>
                                                        <input id="txtAmount" runat="server" tabindex="44" type="number" class="form-control" placeholder="Amount">
                                                    </td>
                                                    <td style="text-align: center">
                                                        <button class="btn btn-tbl-delete" tabindex="46" id="dlt-btn" title="Delete Record">
                                                            <i class="typcn typcn-trash"></i>
                                                        </button>
                                                    </td>
                                                </tr>
                                                <tr>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-4 mb-3">
                                <label>Remarks</label>
                                <textarea id="txtRemarks" runat="server" tabindex="50" type="text" class="form-control" placeholder="Remarks"></textarea>
                            </div>
                            <!-- col -->
                        </div>


                        <div class="row mb-3">
                            <div class="col-lg-12 text-center">
                                <button id="btnSubmit" runat="server" onserverclick="btnSubmit_ServerClick" class="btn btn-purple">
                                    <i class="typcn typcn-upload"></i>Submit
                                </button>
                                <%--<a href="orders.aspx" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</a>--%>
                            </div>
                        </div>

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
        
    <script type="text/javascript">
        $("#btnAdd").on("click", function () {
            var $tableBody = $('#support_table5').find("tbody"),
                $trLast = $tableBody.find("tr:nth-last-child(2)"),
                $trNew = $trLast.clone();

            $trLast.after($trNew);
        });
        $('table').on('click', '#dlt-btn', function (e) {
            var choice = confirm('Do you really want to delete this record?');
            if (choice === true) {
                return $(this).closest('tr').remove();
            }
            return false;
        });
    </script>
</asp:Content>
