<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddModule.aspx.cs" Inherits="Yuan.AddModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
        <div class="container">
            <div class="az-content-body">
        <div class="az-dashboard-one-title">
            <div>
                <h2 class="az-dashboard-title">Add Module</h2>
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
                                <label>Module Name</label>
                                <input id="txtModule" runat="server" tabindex="1" type="text" class="form-control" placeholder="Module Name">
                            </div>
                            <!-- col -->

                            <div class="col-lg-6 mb-3">
                                <label>Parent Module Name</label>
                                <asp:DropDownList ID="drpSource" CssClass="form-control" TabIndex="2" runat="server">
                                    <asp:ListItem>--- Select ---</asp:ListItem>
                                    <asp:ListItem>Masters</asp:ListItem>
                                    <asp:ListItem>Orders / Appointments</asp:ListItem>
                                    <asp:ListItem>Guests</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <!-- col -->

                        </div>

                        <div class="row mb-3">
                            <div class="col-lg-12 text-center">
                                <a href="modules.aspx" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</a>
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
