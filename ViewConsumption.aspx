<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewConsumption.aspx.cs" Inherits="Yuan.ViewConsumption" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JScript/ViewConsumption.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="az-content-body">
            <div class="az-dashboard-one-title">
                <div>
                    <h2 class="az-dashboard-title">Consumption</h2>
                    <!-- <p class="az-dashboard-text">Welcome to the Yuan Thai Spa Admin Control Panel</p> -->
                </div>
                <div class="az-content-header-right">
                    <div class="media">
                        <div class="media-body">
                            <a href="Consumption.aspx" class="btn btn-purple"><i class="typcn typcn-document-add"></i>Add Consumption</a>
                        </div>
                        <!-- media-body -->
                    </div>
                    <!-- media -->
                </div>
            </div>
            <!-- az-dashboard-one-title -->


            <div class="row row-sm mg-b-20">
                <div class="col-lg-12">
                    <div class="card card-dashboard-pageviews card-table-one">

                        <!-- card-header -->
                        <div class="card-body mt-3">
                            <div class="table-responsive mb-3">
                                <table class="table table-striped table-bordered" id="tblConsumption">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th class="pl-2 pr-2" scope="col">#</th>
                                            <th scope="col">Member</th>
                                            <th scope="col">Order No</th>
                                            <th scope="col">Service Name</th>
                                            <th scope="col">Service Qty</th>
                                            <th scope="col">Outlet</th>
                                            <th scope="col">Date of Consumption</th>
                                            <th scope="col">Time of Consumption</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>
                            <!-- table-responsive -->
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

<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
