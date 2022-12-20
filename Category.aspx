<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Yuan.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JScript/Category.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <div class="az-content az-content-dashboard">--%>
    <div class="container">
        <div class="az-content-body">
            <div class="az-dashboard-one-title">
                <div>
                    <h2 class="az-dashboard-title">Category</h2>
                    <!-- <p class="az-dashboard-text">Welcome to the Yuan Thai Spa Admin Control Panel</p> -->
                </div>
                <div class="az-content-header-right">
                    <div class="media">
                        <div class="media-body">
                            <a href="AddCategory.aspx" class="btn btn-purple"><i class="typcn typcn-document-add"></i>Add Category</a>
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
                                <table id="tblCategory" class="table table-striped table-bordered">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th class="pl-2 pr-2" scope="col">#</th>
                                            <th scope="col">Category</th>
                                            <th scope="col">Parent Category</th>
                                            <th scope="col">By User</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%--<tr>
                        <th class="pl-2 pr-2" scope="row">1</th>
                        <td>Deep Tissue Swedish Massage</td>
                        <td>Swedish Massage</td>
                        <td>John Carter</td>
                        <td width="125px">
                          <div class="btn-icon-list">
                            <a href="add-category.html" class="btn btn-edit"><i class="typcn typcn-edit"></i></a>
                            <a href="#" class="btn btn-delete"><i class="typcn typcn-trash"></i></a>
                          </div>
                        </td>
                      </tr>--%>
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
    </div>
    <%--</div>--%>
</asp:Content>
