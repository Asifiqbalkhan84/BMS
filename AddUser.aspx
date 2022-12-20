<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Yuan.AddUser" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagName="Ajax" TagPrefix="Ajax" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />   --%> 
        <div class="container">
            <div class="az-content-body">
                <div class="az-dashboard-one-title">
                    <div>
                        <h2 class="az-dashboard-title">Add System User</h2>
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
                                        <label><span style="color: red;">*</span> Name</label>
                                        <input id="txtName" runat="server" autocomplete="off" tabindex="1" type="text" class="form-control" placeholder="First Name" required />
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Role</label>
                                        <asp:DropDownList ID="drpRole" runat="server" TabIndex="2" OnSelectedIndexChanged="drpRole_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" required>
                                        </asp:DropDownList>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Staff Name</label>
                                        <asp:DropDownList ID="drpStaff" runat="server" TabIndex="3" CssClass="form-control" required>                                            
                                        </asp:DropDownList>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> User Name</label>
                                        <input id="txtUserName" runat="server" autocomplete="off" tabindex="4" type="text" class="form-control" placeholder="Login Name" required />
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Password</label>
                                        <input id="txtPassword" runat="server" aria-autocomplete="none" autocomplete="off" tabindex="6" type="password" class="form-control" placeholder="Password" required />
                                        <asp:CompareValidator ID="cmpPassword" runat="server" ControlToValidate="txtPassword" ControlToCompare="txtCnfPassword" ErrorMessage="Password and confirm password is different"></asp:CompareValidator>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Confirm Password</label>
                                        <input id="txtCnfPassword" runat="server" autocomplete="off" tabindex="8" type="password" class="form-control" placeholder="Confirm Password" required>
                                        <span id='message' style="color: red"></span>
                                    </div>
                                    <!-- col -->
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Type</label>
                                        <asp:DropDownList ID="drpUserType" runat="server" TabIndex="10" CssClass="form-control" required>
                                            <asp:ListItem Value="">---Select---</asp:ListItem>
                                            <asp:ListItem Value="Administrator">Administrator</asp:ListItem>
                                            <asp:ListItem Value="HR">HR</asp:ListItem>
                                            <asp:ListItem Value="Admin">Admin</asp:ListItem>
                                            <asp:ListItem Value="Employee">Employee</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <!-- col -->
                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red;">*</span> Active</label>
                                        <asp:DropDownList ID="drpActive" runat="server" TabIndex="12" CssClass="form-control" required>
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
                                                                        <asp:HiddenField ID="hdnSubModID" runat="server" Value='<%#Eval("ModID") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Parent Module">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblParentModule" runat="server" Text='<%#Eval("ParentModule") %>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnModID" runat="server" Value='<%#Eval("ParentId") %>' />                                                                        
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
                                        <button id="btnSubmit" runat="server" type="submit" onserverclick="btnSubmit_ServerClick" tabindex="15" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</button>
                                        <%--<a href="user-roles.html" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</a>--%>
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
    
    <!-- az-content -->
    <asp:HiddenField ID="hdnUserId" runat="server" Value="0" />
    <script>
        
        function setPass(userpass) {
            $("#<%=txtCnfPassword.ClientID%>").attr("value", userpass);
            $("#<%=txtPassword.ClientID%>").attr("value", userpass);
        }
    </script>
</asp:Content>
