<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deals.aspx.cs" Inherits="Yuan.Deals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="JScript/Deals.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    
    <%--<div class="az-content az-content-dashboard">--%>
      <div class="container">
        <div class="az-content-body">
          <div class="az-dashboard-one-title">
            <div>
              <h2 class="az-dashboard-title">Deals</h2>
              <!-- <p class="az-dashboard-text">Welcome to the Yuan Thai Spa Admin Control Panel</p> -->
            </div>
            <div class="az-content-header-right">
              <div class="media">
                <div class="media-body">
                  <a href="AddDeal.aspx" class="btn btn-purple"><i class="typcn typcn-document-add"></i> Add Deal</a>
                </div><!-- media-body -->
              </div><!-- media -->
            </div>
          </div><!-- az-dashboard-one-title -->

          
          <div class="row row-sm mg-b-20">
            <div class="col-lg-12">
              <div class="card card-dashboard-pageviews card-table-one">
                <%--<div class="card-header">
                  <div class="float-left">
                    <input type="text" class="form-control" placeholder="Search...">
                  </div>
                  <div class="float-right">
                      <div class="btn-icon-list">
                        <%--<a href="#" class="btn btn-purple">PDF</a>
                        <a href="#" class="btn btn-purple">CSV</a>
                        <a href="#" class="btn btn-purple">COPY</a>
                        <a href="#" class="btn btn-purple">EXCEL</a>
                        <a href="#" class="btn btn-purple">PRINT</a>
                      </div>
                  </div>
                </div><!-- card-header -->--%>
                <div class="card-body mt-3">
                  <div class="table-responsive mb-3">
                    <table id="tblDeal" class="table table-striped table-bordered">
                    <thead class="thead-dark">
                      <tr>
                        <th class="pl-2 pr-2" scope="col">#</th>
                        <th scope="col">Deal Name</th>
                        <th scope="col">Outlet</th>
                        <th scope="col">Validity</th>
                        <th scope="col">Discount %</th>
                        <th scope="col">Discount</th>
                        <th scope="col">Discount Voucher</th>
                        <th scope="col">For Members</th>
                        <th scope="col">Member Type</th>
                        <th scope="col">Action</th>
                      </tr>
                    </thead>
                    <tbody>                    
                      
                    </tbody>
                  </table>
                  </div><!-- table-responsive -->
                </div><!-- card-body -->
              </div><!-- card -->

            </div><!-- col -->
            
          </div><!-- row -->
          
        </div><!-- az-content-body -->
      </div>
    <%--</div><!-- az-content -->--%>
    <!-- Modal-->
    <div class="modal fade" id="deal-details" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLongTitle">Deal Details</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="table-responsive mb-3">
              <table id="tblDealModel" class="table table-striped table-bordered">
                <tbody>
                  <tr>
                    <td class="pl-2 pr-2" scope="col">#</td>
                    <th class="pl-2 pr-2" scope="row"></th>
                  </tr>
                  <tr>
                    <td scope="col">Deal</td>
                    <td><span id="Deal" class="DealName"></span></td>
                  </tr>
                  <tr>
                    <td scope="col">Service</td>
                    <td><span id="Service" class="ServiceName"></span></td>
                  </tr>
                  <tr>
                    <td scope="col">Free</td>
                    <td><span id="IsFree" class="IsFree"></span></td>
                  </tr>
                  <tr>
                    <td scope="col">Price</td>
                    <td><span id="price" class="price"></span></td>
                  </tr>
                  <tr>
                    <td scope="col">By User</td>
                    <td><span id="ByUser" class="ByUser"></span></td>
                  </tr>                  
                </tbody>
              </table>
            </div><!-- table-responsive -->
          </div>
        </div>
      </div>
    </div><!-- Modal Ends-->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
