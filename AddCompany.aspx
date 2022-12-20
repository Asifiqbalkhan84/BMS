<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCompany.aspx.cs" Inherits="Yuan.AddCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
        <div class="container">
            <div class="az-content-body">
        <div class="az-dashboard-one-title">
            <div>
                <h2 class="az-dashboard-title">Add Company</h2>
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
                                <label>Company Name</label>
                                <input id="txtComapanyName" runat="server" tabindex="1" type="text" class="form-control" placeholder="Company Name">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Outlet Name</label>
                                <input id="txtOutletName" runat="server" tabindex="2" type="text" class="form-control" placeholder="Outlet Name">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Address Line 1</label>
                                <textarea id="txtAdd" runat="server" tabindex="3" rows="2" class="form-control" placeholder="Address Line 1"></textarea>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Address Line 2</label>
                                <textarea id="txtAdd2" runat="server" tabindex="4" rows="2" class="form-control" placeholder="Address Line 2"></textarea>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Location</label>
                                <input id="txtLocation" runat="server" tabindex="5" type="text" class="form-control" placeholder="Location Name">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label><span class="az-required" style="color:red">*</span> Area</label>
                                <input id="txtArea" runat="server" tabindex="6" type="text" class="form-control" placeholder="Area" required>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Landmark</label>
                                <input type="text" id="txtLandmark" runat="server" tabindex="7" class="form-control" placeholder="Landmark">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label><span class="az-required" style="color:red">*</span> City</label>
                                <asp:DropDownList ID="drpCity" TabIndex="8" runat="server" CssClass="form-control" required>
                                    <%--<asp:ListItem Value="">--- Select ---</asp:ListItem>
                                    <asp:ListItem Value="1">Mumbai</asp:ListItem>
                                    <asp:ListItem Value="2">Pune</asp:ListItem>
                                    <asp:ListItem Value="3">Delhi</asp:ListItem>
                                    <asp:ListItem Value="4">Guzrat</asp:ListItem>--%>
                                </asp:DropDownList>

                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label><span style="color:red">*</span> Postcode</label>
                                <input id="txtPincode" runat="server" tabindex="9" type="number" class="form-control" placeholder="Postcode" required>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label><span style="color:red">*</span> Contact Person</label>
                                <input id="txtContactPerson" runat="server" tabindex="10" type="text" class="form-control" placeholder="Contact Person" required>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label><span style="color:red">*</span> Contact No</label>
                                <input id="txtContactNo" runat="server" tabindex="11" type="text" class="form-control" placeholder="Contact No" required>
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Support Contact Person</label>
                                <input id="txtSupContactPerson" runat="server" tabindex="12" type="text" class="form-control" placeholder="Support Contact Person">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Support Contact No</label>
                                <input id="txtSupContactNo" runat="server" tabindex="13" type="text" class="form-control" placeholder="Support Contact No">
                            </div>
                            <!-- col -->
                            <div class="col-lg-4 pb-2 pt-1">
                                <label><span style="color:red">*</span> Total Slot</label>
                                <input id="txtSlot" runat="server" tabindex="14" type="number" class="form-control" placeholder="Total Slot">
                            </div>
                            <!-- col -->                            

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>GST No</label>
                                <input id="txtGSTNo" runat="server" tabindex="16"  type="text" class="form-control" placeholder="GST No">
                            </div>
                            <!-- col -->

                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Tax Rate</label>
                                <input id="txtTaxRate" runat="server" tabindex="18" type="text" class="form-control" placeholder="Tax Rate">
                            </div>
                            <!-- col -->
                            <!-- col -->
                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Tax Applicable</label>
                                <input id="txtTaxApplicable" runat="server" tabindex="14" type="checkbox" class="check" >
                            </div>
                            <!-- col -->
                            <div class="col-lg-4 pb-2 pt-1">
                                <label>Only Office</label>
                                <asp:DropDownList ID="drpOnlyOffice" CssClass="form-control" runat="server" tabindex="20" >
                                    <asp:ListItem Value="">--- Select ---</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                                
                            </div>
                            <!-- col -->

                        </div>

                        <div class="row mb-3">
                            <div class="col-lg-12 text-center">
                                <asp:LinkButton ID="btnSubmit" Text="Submit" runat="server" tabindex="22" CssClass="btn btn-purple" OnClick="btnSubmit_Click">
                                    Submit <i class="typcn typcn-upload"></i></asp:LinkButton>
                                <%--<a href="company.html" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</a>--%>
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
                <asp:HiddenField ID="hdnCompanyId" runat="server" />
    </div>
    <!-- az-content-body -->
            </div>        
</asp:Content>
