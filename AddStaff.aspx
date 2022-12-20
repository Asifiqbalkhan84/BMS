<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStaff.aspx.cs" Inherits="Yuan.AddStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
        <div class="container">
            <div class="az-content-body">
                <div class="az-dashboard-one-title">
                    <div>
                        <h2 class="az-dashboard-title">Add Staff</h2>
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
                                        <label><span style="color: red;">*</span> Staff Name</label>
                                        <input id="txtStaffName" runat="server" tabindex="1" type="text" class="form-control" placeholder="Staff Name" required>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Office/Outlet</label>
                                        <asp:DropDownList ID="drpOutlet" runat="server" TabIndex="3" CssClass="form-control" required>
                                            <%--<asp:ListItem>---Select---</asp:ListItem>
                                            <asp:ListItem>Bandra</asp:ListItem>
                                            <asp:ListItem>Juhu</asp:ListItem>
                                            <asp:ListItem>Andheri</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Contact Person</label>
                                        <input id="txtContactPerson" runat="server" tabindex="5" type="text" class="form-control" placeholder="Contact Person" required>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Designation</label>
                                        <input id="txtDesignation" runat="server" tabindex="6" type="text" class="form-control" placeholder="Designation" required>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Department</label>
                                        <asp:DropDownList ID="drpDepartment" runat="server" TabIndex="8" CssClass="form-control" required>
                                            <asp:ListItem Value="">---Select---</asp:ListItem>
                                            <asp:ListItem Value="Service">Spa Services</asp:ListItem>
                                            <asp:ListItem Value="Admin">Admin</asp:ListItem>
                                            <asp:ListItem Value="Accounts">Accounts</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Landline</label>
                                        <input id="txtLandline" runat="server" tabindex="10" type="number" class="form-control" placeholder="Landline">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Extension</label>
                                        <input id="txtExtension" runat="server" tabindex="12" type="number" class="form-control" placeholder="Extension">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Mobile No</label>
                                        <input id="txtMobileNo" runat="server" tabindex="14" type="number" class="form-control" placeholder="Mobile No" required>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Email ID</label>
                                        <input id="txtEmail" runat="server" tabindex="16" type="email" class="form-control" placeholder="Email ID" required>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Date of Joining</label>
                                        <input id="txtJoiningDate" runat="server" tabindex="18" type="date" class="form-control" placeholder="Date of Joining" required>
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
                                        <button id="btnSubmit" runat="server" onserverclick="btnSubmit_ServerClick" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</button>
                                        <%--<a href="staff.html" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</a>--%>
                                    </div>
                                </div>
                                <asp:HiddenField ID="hdnStaffId" runat="server" />
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
       <!-- az-content -->
</asp:Content>
