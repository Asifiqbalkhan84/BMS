<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Guests.aspx.cs" Inherits="Yuan.Guests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JScript/Guests.js"></script>
    <script>
        debugger;
        var el = $('.dt-buttons');
        el.addClass('card-header float-right');
    //el.removeClass('theClassThatsThereNow');
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="az-content az-content-dashboard">
        <div class="container">
            <div class="az-content-body">
          <div class="az-dashboard-one-title">
            <div>
              <h2 class="az-dashboard-title">Guests</h2>
              <!-- <p class="az-dashboard-text">Welcome to the Yuan Thai Spa Admin Control Panel</p> -->
            </div>
            <div class="az-content-header-right">
              <div class="media">
                <div class="media-body">
                  <a href="AddGuest.aspx" class="btn btn-purple"><i class="typcn typcn-document-add"></i> Add Guest</a>
                </div><!-- media-body -->
              </div><!-- media -->
            </div>
          </div><!-- az-dashboard-one-title -->
          
          <div class="row row-sm mg-b-20">
            <div class="col-lg-12">
              <div class="card card-dashboard-pageviews card-table-one">
                <div class="card-header">
                  <div class="float-left">
                    <input type="text" class="form-control" placeholder="Search...">
                  </div>
                  <div class="float-right">
                      <div class="btn-icon-list">
                        <%--<a href="#" class="btn btn-purple">PDF</a>
                        <a href="#" class="btn btn-purple">CSV</a>
                        <a href="#" class="btn btn-purple">COPY</a>
                        <a href="#" class="btn btn-purple">EXCEL</a>
                        <a href="#" class="btn btn-purple">PRINT</a>--%>
                      </div>
                  </div>
                </div><!-- card-header -->
                <div class="card-body mt-3">
                  <div class="table-responsive mb-3">
                    <table id="tblGuest" class="table table-striped table-bordered">
                    <thead class="thead-dark">
                      <tr>
                        <th class="pl-2 pr-2" scope="col">#</th>
                        <th scope="col">Full Name</th>
                        <th scope="col">Mobile No</th>
                        <th scope="col">Landline No</th>
                        <th scope="col">Email ID</th>
                        <th scope="col">Alt Contact No</th>
                        <th scope="col">Active</th>
                        <th scope="col">Blacklisted</th>
                        <th scope="col">Source</th>
                        <!-- <th scope="col">Source Details</th> -->
                        <th scope="col">Member No</th>
                        <th scope="col">Action</th>
                      </tr>
                    </thead>
                    <tbody>
                      <%--<tr>
                        <th class="pl-2 pr-2" scope="row">1</th>
                        <td>Mr. Mahmood Khan</td>
                        <td>9664585865</td>
                        <td>2652 5652</td>
                        <td>mahmood@email.com</td>
                        <td>9685254822</td>
                        <td>Yes</td>
                        <td>No</td>
                        <td>Walk-In</td>
                        <td>YN0123123</td>  
                        <td>
                          <div class="btn-icon-list">
                            <a href="add-guest.html" class="btn btn-edit"><i class="typcn typcn-edit"></i></a>
                            <!-- <a href="#" class="btn btn-view"><i class="typcn typcn-eye"></i></a> -->
                            <a href="#" class="btn btn-delete"><i class="typcn typcn-trash"></i></a>
                          </div>
                        </td>
                      </tr>--%>
                    </tbody>
                  </table>
                  </div><!-- table-responsive -->
                </div><!-- card-body -->
              </div><!-- card -->

            </div><!-- col -->
            
          </div><!-- row -->
          
        </div><!-- az-content-body -->
            </div>
        </div>
</asp:Content>
