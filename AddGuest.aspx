<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGuest.aspx.cs" Inherits="Yuan.AddGuest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="az-content az-content-dashboard">--%>
        <div class="container">
            <div class="az-content-body">
                <div class="az-dashboard-one-title">
                    <div>
                        <h2 class="az-dashboard-title">Add Guest</h2>
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
                                        <label><span style="color: red">*</span> Title</label>
                                        <asp:DropDownList ID="drpTitle" TabIndex="1" CssClass="form-control" runat="server" required>
                                            <asp:ListItem Value="">--- Select ---</asp:ListItem>
                                            <asp:ListItem Value="Mr.">Mr.</asp:ListItem>
                                            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
                                            <asp:ListItem Value="Other">Other</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <!-- col -->
                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> First Name</label>
                                        <input id="txtFirstName" runat="server" tabindex="3" type="text" class="form-control" placeholder="First Name" required>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Last Name</label>
                                        <input id="txtLastName" runat="server" type="text" tabindex="5" class="form-control" placeholder="Last Name" required>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Mobile No</label>
                                        <input id="txtMobile" runat="server" type="number" tabindex="6" class="form-control" placeholder="Mobile No" required>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Landline No</label>
                                        <input id="txtLandline" runat="server" type="text" tabindex="8" class="form-control" placeholder="Landline No">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Email ID</label>
                                        <input id="txtEmailId" runat="server" tabindex="10" type="text" class="form-control" placeholder="Email ID" required>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Alternate Contact No</label>
                                        <input id="txtAltContactNo" runat="server" tabindex="12" type="text" class="form-control" placeholder="Alternate Contact No">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Address Line 1</label>
                                        <input type="text" id="txtAddress" runat="server" tabindex="14" class="form-control" placeholder="Address Line 1" required>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Address Line 2</label>
                                        <input id="txtAddress2" runat="server" type="text" tabindex="15" class="form-control" placeholder="Address Line 2">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Area</label>
                                        <input id="txtArea" runat="server" type="text" tabindex="16" class="form-control" placeholder="Area" required>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Landmark</label>
                                        <input id="txtLandmark" runat="server" type="text" tabindex="18" class="form-control" placeholder="Landmark">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> City</label>
                                        <asp:DropDownList ID="drpCity" CssClass="form-control" TabIndex="20" runat="server">
                                            <asp:ListItem>--- Select ---</asp:ListItem>
                                            <asp:ListItem>Mumbai</asp:ListItem>
                                            <asp:ListItem>Pune</asp:ListItem>
                                            <asp:ListItem>Goa</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Postcode</label>
                                        <input id="txtPostCode" runat="server" type="number" max="6" tabindex="22" class="form-control" placeholder="Postcode">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Active</label>
                                        <asp:DropDownList ID="drpActive" CssClass="form-control" TabIndex="23" runat="server">
                                            <asp:ListItem Value="">--- Select ---</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Blacklisted</label>
                                        <asp:DropDownList ID="drpBlacklisted" CssClass="form-control" TabIndex="24" runat="server" required>
                                            <asp:ListItem Value="">--- Select ---</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Source</label>
                                        <asp:DropDownList ID="drpSource" CssClass="form-control" TabIndex="26" runat="server" required>
                                            <asp:ListItem Value="">--- Select ---</asp:ListItem>
                                            <asp:ListItem Value="Website">Website</asp:ListItem>
                                            <asp:ListItem Value="SearchEngine">Search Engine</asp:ListItem>
                                            <asp:ListItem Value="Walk-In">Walk-In</asp:ListItem>
                                            <asp:ListItem Value="Referral">Referral</asp:ListItem>
                                            <asp:ListItem Value="Campaign">Campaign</asp:ListItem>
                                            <asp:ListItem Value="Other">Other</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Source Details</label>
                                        <input id="txtSourceDet" runat="server" type="text" tabindex="28" class="form-control" placeholder="Source Details">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Member No</label>
                                        <input id="txtMemberNo" runat="server" type="number" tabindex="30" class="form-control" placeholder="Member No">
                                    </div>
                                    <!-- col -->
                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Profile Photo</label>
                                        <asp:FileUpload ID="fuProfile" runat="server" type="file" TabIndex="31" class="form-control" />
                                    </div>
                                    <div id="dvProfile" runat="server" visible="false" class="col-lg-4 pb-2 pt-1">
                                        <asp:HyperLink runat="server" ID="lnkprofile" Text="Download" ToolTip="click to download file">
                                                            <%--<asp:Image ID="imgDisability" runat="server" class="mb-3 p-0" Width="100px"></asp:Image>--%>
                                        </asp:HyperLink>
                                        <asp:LinkButton runat="server" ID="lnkRemove" CssClass="fa fa-link" Text="Remove" OnClick="lnkRemove_Click" OnClientClick="return confirm('Are you sure you want to remove profile picture');"></asp:LinkButton>
                                    </div>
                                    <div class="col-lg-6 pb-2 pt-1">
                                        <label id="lblImgSize" runat="server" style="color: red; display: none;"></label>
                                    </div>
                                </div>

                                <div class="row mb-3">
                                    <div class="col-lg-12 text-center">
                                        <button id="btnSubmit" runat="server" onserverclick="btnSubmit_ServerClick" class="btn btn-purple" tabindex="32"><i class="typcn typcn-upload"></i>Submit</button>
                                        <a href="AddOrder.aspx" class="btn btn-purple" tabindex="34"><i class="typcn typcn-shopping-cart"></i>Order</a>
                                        <a href="AddAppointment.aspx" class="btn btn-purple" tabindex="33"><i class="typcn typcn-pen"></i>Appointment</a>                                        
                                        <a href="AddEnquiry.aspx" class="btn btn-purple" tabindex="35"><i class="typcn typcn-clipboard"></i>Enquiry</a>
                                    </div>
                                </div>
                                <asp:HiddenField ID="hdnGuestId" runat="server" />
                                <asp:HiddenField ID="hdnProfile" runat="server" />
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
    <%--</div>--%>
</asp:Content>
