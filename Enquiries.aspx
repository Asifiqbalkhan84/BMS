<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enquiries.aspx.cs" Inherits="Yuan.Enquiries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JScript/Enquiry.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="container">
        <div class="az-content-body">
          <div class="az-dashboard-one-title">
            <div>
              <h2 class="az-dashboard-title">Enquiries</h2>
              <!-- <p class="az-dashboard-text">Welcome to the Yuan Thai Spa Admin Control Panel</p> -->
            </div>
            <div class="az-content-header-right">
              <div class="media">
                <div class="media-body">
                  <a href="AddEnquiry.aspx" class="btn btn-purple"><i class="typcn typcn-document-add"></i> Add Enquiry</a>
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
                        <a href="#" class="btn btn-purple">PDF</a>
                        <a href="#" class="btn btn-purple">CSV</a>
                        <a href="#" class="btn btn-purple">COPY</a>
                        <a href="#" class="btn btn-purple">EXCEL</a>
                        <a href="#" class="btn btn-purple">PRINT</a>
                      </div>
                  </div>
                </div>--%><!-- card-header -->
                <div class="card-body mt-3">
                  <div class="table-responsive mb-3">
                    <table id="tblEnquiry" class="table table-striped table-bordered">
                    <thead class="thead-dark">
                      <tr>
                        <th class="pl-2 pr-2" scope="col">#</th>
                        <th scope="col">Enquiry</th>
                        <th scope="col">Source</th>
                        <th scope="col">Name of Guest</th>
                        <th scope="col">Mobile No</th>
                        <th scope="col">Email ID</th>
                        <th scope="col">Location</th>
                        <th scope="col">Outlet</th>
                        <%--<th scope="col">Read</th>--%>
                        <th scope="col">Staff</th>
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
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
