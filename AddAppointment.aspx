<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAppointment.aspx.cs" Inherits="Yuan.AddAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
        <div class="container">
            <div class="az-content-body">
        <div class="az-dashboard-one-title">
            <div>
                <h2 class="az-dashboard-title">Add Appointment</h2>
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

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Guest Name</label>
                                <input id="txtGuestName" runat="server" tabindex="1" type="text" class="form-control" placeholder="Guest Name">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Member No</label>
                                <input id="txtMemberNo" runat="server" tabindex="2" type="text" class="form-control" placeholder="Member No">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Office/Outlet</label>
                                <asp:DropDownList ID="drpOffice" runat="server" TabIndex="3" CssClass="form-control">
                                    <asp:ListItem>---Select---</asp:ListItem>
                                    <asp:ListItem>Bandra</asp:ListItem>
                                    <asp:ListItem>Juhu</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Date</label>
                                <input id="txtAppointDate" runat="server" tabindex="6" type="date" class="form-control" placeholder="Date of Appoint">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Time</label>
                                <input id="txtTime" runat="server" tabindex="8" type="time" class="form-control" placeholder="Time of Appoint">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Source</label>
                                <asp:DropDownList ID="drpSource" runat="server" TabIndex="10" CssClass="form-control">
                                    <asp:ListItem>---Select---</asp:ListItem>
                                    <asp:ListItem>Online</asp:ListItem>
                                    <asp:ListItem>Telephone</asp:ListItem>
                                    <asp:ListItem>Walk-In</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Serviced By</label>
                                <input id="txtServiceBy" runat="server" tabindex="12" type="text" class="form-control" placeholder="Serviced By">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Remarks</label>
                                <input id="txtRemark" runat="server" rows="2" tabindex="14" type="text" class="form-control" placeholder="Remarks">
                            </div>
                            <!-- col -->

                        </div>

                        <div class="row mb-3">
                            <div class="col-lg-12 text-center">
                                <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</asp:LinkButton>
                                <asp:LinkButton ID="btnOrder" runat="server" CssClass="btn btn-purple"><i class="typcn typcn-shopping-cart"></i>Book a Order</asp:LinkButton>
                                <%--<a href="appointments.html" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</a>
                                <a href="add-order.html" class="btn btn-purple"><i class="typcn typcn-shopping-cart"></i>Book a Order</a>--%>
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
</asp:Content>
