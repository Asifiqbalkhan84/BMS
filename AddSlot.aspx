<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSlot.aspx.cs" Inherits="Yuan.AddSlot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="az-content-body">
            <div class="az-dashboard-one-title">
                <div>
                    <h2 class="az-dashboard-title">Add Appointment Slot</h2>
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
                                    <label><span style="color: red;">*</span> Company/Outlet</label>
                                    <asp:DropDownList ID="drpOutlet" CssClass="form-control" TabIndex="1" runat="server" required></asp:DropDownList>
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label><span style="color: red;">*</span> From Time</label>
                                    <input id="txtFromTime" runat="server" type="time" tabindex="3" class="form-control" placeholder="from time" required="required" />
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label><span style="color: red;">*</span> To Time</label>
                                    <input id="txtToTime" runat="server" type="time" class="form-control" placeholder="to time" tabindex="4" required="required">
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label><span style="color: red;">*</span> No of Slots</label>
                                    <asp:DropDownList ID="drpSlot" CssClass="form-control" TabIndex="6" runat="server" required>
                                        <asp:ListItem Value="">--- Select ---</asp:ListItem>
                                        <asp:ListItem Value="1">1</asp:ListItem>
                                        <asp:ListItem Value="2">2</asp:ListItem>
                                        <asp:ListItem Value="3">3</asp:ListItem>
                                        <asp:ListItem Value="4">4</asp:ListItem>
                                        <asp:ListItem Value="5">5</asp:ListItem>
                                        <asp:ListItem Value="6">6</asp:ListItem>
                                        <asp:ListItem Value="7">7</asp:ListItem>
                                        <asp:ListItem Value="8">8</asp:ListItem>
                                        <asp:ListItem Value="9">9</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label><span style="color: red;">*</span> Day of Week</label>
                                    <asp:DropDownList ID="drpDayOfWeek" CssClass="form-control" TabIndex="7" runat="server" required>
                                        <asp:ListItem Value="">--- Select ---</asp:ListItem>
                                        <asp:ListItem Value="All">All</asp:ListItem>
                                        <asp:ListItem Value="Monday">Monday</asp:ListItem>
                                        <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
                                        <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                                        <asp:ListItem Value="Thursday">Thursday</asp:ListItem>
                                        <asp:ListItem Value="Friday">Friday</asp:ListItem>
                                        <asp:ListItem Value="Saturday">Saturday</asp:ListItem>
                                        <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label>Date</label>
                                    <input id="txtDate" runat="server" type="date" class="form-control" placeholder="Date" tabindex="8">
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label><span style="color: red;">*</span> Service</label>
                                    <asp:DropDownList ID="drpService" CssClass="form-control" TabIndex="10" runat="server" required>
                                    </asp:DropDownList>
                                    <%--<option>Traditional Full Body Thai Massage</option>
                                <option>Full Body Aroma Therapy</option>
                                <option>Full Body Swedish Massage</option>
                                <option>Deep Tissue Massage</option>
                                <option>Full Body Balinese Massage</option>
                                <option>Body Scrubs</option>
                                <option>Body Wraps</option>
                                    </select>--%>
                                </div>
                                <!-- col -->
                                <div class="col-lg-4 pb-2 pt-1">
                                    <label>Active</label>
                                    <asp:DropDownList ID="drpActive" CssClass="form-control" TabIndex="11" runat="server">
                                        <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                            <div class="row mb-3">
                                <div class="col-lg-12 text-center">
                                    <button id="btnSubmit" runat="server" tabindex="12" onserverclick="btnSubmit_ServerClick" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</button>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnSlot" runat="server" />
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
