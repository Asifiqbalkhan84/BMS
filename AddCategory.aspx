<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Yuan.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="az-content az-content-dashboard">--%>
        <div class="container">
            <div class="az-content-body">
                <div class="az-dashboard-one-title">
                    <div>
                        <h2 class="az-dashboard-title">Add Category</h2>
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
                                    <div class="col-lg-6">
                                        <label><span style="color:red">*</span> Category Name</label>
                                        <input id="txtCategory" runat="server" type="text" tabindex="1" class="form-control" placeholder="Category Name" required><%--value="Deep Tissue Swedish Massage" --%>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-6">
                                        <label>Parent Category</label>
                                        <asp:DropDownList ID="drpParent" runat="server" TabIndex="2" CssClass="form-control Multiselect">
                                            <%--<asp:ListItem Value="">--- Select ---</asp:ListItem>
                                            <asp:ListItem Value="1">Swedish Massage</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </div>
                                    <!-- col -->
                                    <div class="col-lg-6">
                                        <label>Active</label>
                                        <asp:DropDownList ID="drpActive" runat="server" TabIndex="2" CssClass="form-control">                                            
                                            <asp:ListItem Value="1">True</asp:ListItem>
                                            <asp:ListItem Value="0">False</asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                </div>

                                <div class="row mb-3">
                                    <div class="col-lg-12 text-center">                                        
                                        <%--<input type="button" id="btnsubmit1" runat="server" class="btn btn-purple typcn typcn-upload" Text="Submit"/>--%>
                                        <button id="btnsubmit" onserverclick="btnsubmit_ServerClick" runat="server" class="btn btn-purple">Submit <i class="typcn typcn-upload"></i></button>
                                    </div>
                                </div>
                                <asp:HiddenField ID="hdnCategoryId" runat="server" />
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
    <!-- az-content -->
</asp:Content>
