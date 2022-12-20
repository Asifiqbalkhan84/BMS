<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="Yuan.AddRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="az-content az-content-dashboard">--%>
    <div class="container">
        <div class="az-content-body">
            <div class="az-dashboard-one-title">
                <div>
                    <h2 class="az-dashboard-title">Add User Role</h2>
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

                                <div class="col-lg-6 mb-3">
                                    <label><span style="color:red">*</span> Role</label>
                                    <input id="txtRole" runat="server" tabindex="1" type="text" class="form-control" placeholder="Role" required>
                                </div>
                                <!-- col -->

                                <div class="col-lg-6 mb-3">
                                    <label>Account Type</label>
                                    <asp:DropDownList ID="drpAccountType" runat="server" TabIndex="3" CssClass="form-control">
                                        <asp:ListItem>---Select---</asp:ListItem>
                                        <asp:ListItem>Administrator</asp:ListItem>
                                        <asp:ListItem>Staff</asp:ListItem>
                                        <asp:ListItem>Accounts</asp:ListItem>
                                        <asp:ListItem>Admin</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <!-- col -->

                                <div class="col-lg-6 mb-3">
                                    <label><span style="color:red">*</span> Active</label>
                                    <asp:DropDownList ID="drpActive" runat="server" TabIndex="15" CssClass="form-control" required>
                                        <asp:ListItem Value="">---Select---</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="updGrid" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="row mb-4">
                                        <div class="col-lg-12 mb-3">
                                            <div class="table-responsive mb-3">
                                                <div class="table table-striped table-bordered">
                                                    <asp:GridView ID="gvPerm" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowDataBound="gvPerm_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField ControlStyle-CssClass="pl-2 pr-2">
                                                                <ItemTemplate>
                                                                    <label></label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Module">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblModule" runat="server" Text='<%#Eval("ModuleName") %>'></asp:Label>
                                                                    <asp:HiddenField ID="hdnModuleId" runat="server" Value='<%#Eval("ModID") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Parent Module">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblParentModule" runat="server" Text='<%#Eval("ParentModule") %>'></asp:Label>
                                                                    <asp:HiddenField ID="hdnParentMId" runat="server" Value='<%#Eval("ParentId") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Full Permission">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkFull" CssClass="" runat="server" Checked='<%#Eval("FullPerm").ToString().Equals("True") %>' OnCheckedChanged="chkFull_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Add Permission">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkAdd" CssClass="" runat="server" Checked='<%#Eval("AddPerm").ToString().Equals("True") %>'></asp:CheckBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit Permission">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkEdit" CssClass="" runat="server" Checked='<%#Eval("EditPerm").ToString().Equals("True") %>'></asp:CheckBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete Permission">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkDelete" CssClass="" runat="server" Checked='<%#Eval("DeletePerm").ToString().Equals("True") %>'></asp:CheckBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View Permission">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkView" CssClass="" runat="server" Checked='<%#Eval("ViewPerm").ToString().Equals("True") %>'></asp:CheckBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Export Permission">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkExport" CssClass="" runat="server" Checked='<%#Eval("ExportPerm").ToString().Equals("True") %>'></asp:CheckBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                        </div>
                                        <!-- col -->

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="row mb-3">
                                <div class="col-lg-12 text-center">
                                    <button id="btnSubmit" runat="server" tabindex="2" onserverclick="btnSubmit_ServerClick" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit </button>
                                    <%--<a href="enquiries.html" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</a>--%>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnRoleId" runat="server" />
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
