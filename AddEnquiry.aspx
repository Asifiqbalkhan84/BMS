<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEnquiry.aspx.cs" Inherits="Yuan.AddEnquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="az-content-body">
          <div class="az-dashboard-one-title">
            <div>
              <h2 class="az-dashboard-title">Add Enquiry</h2>
              <!-- <p class="az-dashboard-text">Welcome to the Yuan Thai Spa Admin Control Panel</p> -->
            </div>
            <div class="az-content-header-right">
              <div class="media">
                <div class="media-body">
                  <a href="javascript:history.go(-1)" class="btn btn-purple"><i class="typcn typcn-arrow-back"></i> Back</a>
                </div><!-- media-body -->
              </div><!-- media -->
            </div>
          </div><!-- az-dashboard-one-title -->

          
          <div class="row row-sm mg-b-20">
            <div class="col-lg-12">
              <div class="card bg-add card-dashboard-pageviews card-table-one">
                <div class="card-body">
                  <div class="row mb-4">

                    <div class="col-lg-4 pb-2 pt-1">
                      <label><span style="color:red">*</span> Enquiry</label>
                      <input id="txtEnquiry" runat="server" tabindex="1" type="text" class="form-control" placeholder="Enquiry" required>
                    </div><!-- col -->

                    <div class="col-lg-4 pb-2 pt-1">
                      <label><span style="color:red">*</span> Source</label>
                      <asp:DropDownList ID="drpSource" runat="server" TabIndex="3" class="form-control" required>
                        <asp:ListItem Value="">--- Select ---</asp:ListItem>
                        <asp:ListItem Value="Website">Website</asp:ListItem>
                        <asp:ListItem Value="Mobile App">Mobile App</asp:ListItem>
                        <asp:ListItem Value="Facebook">Facebook</asp:ListItem>
                        <asp:ListItem Value="Google Ads">Google Ads</asp:ListItem>
                        <asp:ListItem Value="Others">Others</asp:ListItem>
                      </asp:DropDownList>
                    </div><!-- col -->

                    <div class="col-lg-4 pb-2 pt-1">
                      <label>Source Details</label>
                      <input id="txtSourceDet" runat="server" tabindex="4" type="text" class="form-control" placeholder="Source Details">
                    </div><!-- col -->

                    <div class="col-lg-4 pb-2 pt-1">
                      <label>Name of Guest</label>
                      <input id="txtGuest" runat="server" tabindex="5" type="text" class="form-control" placeholder="Name of Guest">
                    </div><!-- col -->

                    <div class="col-lg-4 pb-2 pt-1">
                      <label>Mobile No</label>
                      <input id="txtMobile" runat="server" tabindex="6" type="number" class="form-control" placeholder="Mobile No">
                    </div><!-- col -->

                    <div class="col-lg-4 pb-2 pt-1">
                      <label>Email ID</label>
                      <input id="txtEmail" runat="server" tabindex="8" type="email" class="form-control" placeholder="Email ID">
                    </div><!-- col -->

                    <div class="col-lg-4 pb-2 pt-1">
                      <label>Location</label>
                      <input id="txtLocation" runat="server" tabindex="10" type="text" class="form-control" placeholder="Location">
                    </div><!-- col -->

                    <div class="col-lg-4 pb-2 pt-1">
                      <label>Other Location Details</label>
                      <input id="txtLocationDet" runat="server" tabindex="12" type="text" class="form-control" placeholder="Other Location Details">
                    </div><!-- col -->

                    <div class="col-lg-4 pb-2 pt-1">
                      <label>Interested In</label>
                      <asp:DropDownList ID="drpServices" runat="server" TabIndex="14" class="form-control">                        
                      </asp:DropDownList>
                    </div><!-- col -->

                    <div class="col-lg-4 pb-2 pt-1">
                      <label>Comments</label>
                      <input id="txtcomment" runat="server" tabindex="16" type="text" class="form-control" placeholder="Comments">
                    </div><!-- col -->

                    <div class="col-lg-4 pb-2 pt-1">
                      <label>Outlet</label>
                      <asp:DropDownList ID="drpOutlet" runat="server" TabIndex="18" class="form-control">                        
                      </asp:DropDownList>                     
                    </div><!-- col -->

                    <div class="col-lg-4 pb-2 pt-1">
                      <label>Staff</label>
                      <asp:DropDownList ID="drpStaff" runat="server" TabIndex="20" class="form-control">                        
                      </asp:DropDownList>
                    </div><!-- col -->
                      <asp:HiddenField ID="hdnEnquiry" runat="server" Value="0"/>
                  </div>

                  <div class="row mb-3">
                    <div class="col-lg-12 text-center">                      
                        <button id="btnSubmit" runat="server" causesvalidation="true" onserverclick="btnSubmit_ServerClick" class="btn btn-purple"><i class="typcn typcn-upload"></i> Submit</button>
                    </div>
                  </div>

                </div><!-- card-body -->
              </div><!-- card -->

            </div><!-- col -->
            
          </div><!-- row -->
          
        </div><!-- az-content-body -->
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
