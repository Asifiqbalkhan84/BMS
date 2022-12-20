<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddServices.aspx.cs" Inherits="Yuan.AddServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function fnValidateFile() {
            debugger;
            var Sid = $("#hdnServiceId");
            var ServImg = $(".ServiceImg");
            if (Sid.val == "") {
                if (ServImg.length > 0) {
                    return true;
                }
            }
            else {
                return true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="az-content-body">
            <div class="az-dashboard-one-title">
                <div>
                    <h2 class="az-dashboard-title">Add Services</h2>
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

            <div class="card bg-add card-dashboard-pageviews card-table-one">
                <div class="card-body">
                    <div class="row evenodd">
                        <div class="col-lg-4 mb-3">
                            <label><span style="color: red">*</span> Service Name</label>
                            <input id="txtService" runat="server" tabindex="1" type="text" class="form-control" placeholder="Service Name">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="txtService" ValidationGroup="v1" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                        </div>
                        <!-- col -->
                        <div class="col-lg-4 mb-3">
                            <label><span style="color: red">*</span> Outlets</label>
                            <asp:DropDownList ID="drpOutlet" CssClass="form-control" TabIndex="3" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="" ForeColor="Red" ControlToValidate="drpOutlet" ValidationGroup="v1" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                        </div>
                        <!-- col -->
                        <div class="col-lg-4 mb-3">
                            <label>Service Description</label>
                            <textarea id="txtServDesc" runat="server" tabindex="4" rows="2" class="form-control" placeholder="Service Description"></textarea>
                        </div>
                        <!-- col -->
                    </div>
                    <div class="row evenodd">
                        <div class="col-md-4 mb-3">
                            <label><span style="color: red">*</span> Category</label>
                            <asp:DropDownList ID="drpCategory" CssClass="form-control" TabIndex="5" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" InitialValue="" ControlToValidate="drpCategory" ValidationGroup="v1" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label><span style="color: red">*</span> Service Hours</label>
                            <asp:DropDownList ID="drpServiceHrs" CssClass="form-control" TabIndex="6" runat="server">
                                <asp:ListItem Value="">--- Select ---</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" InitialValue="" ControlToValidate="drpServiceHrs" ValidationGroup="v1" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                        </div>
                        <!-- col -->

                        <div class="col-md-4 mb-3">
                            <label><span style="color: red;">*</span> Price</label>
                            <input type="text" step="0.01" id="txtPrice" onchange="validateFloatKeyPress(this);" class="form-control" tabindex="8" runat="server" placeholder="Price">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ControlToValidate="txtPrice" ValidationGroup="v1" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <div class="row evenodd">
                        <!-- col -->

                        <div class="col-lg-4 mb-3">
                            <label><span style="color: red;">*</span> Special Offer Price</label>
                            <input type="text" step="0.01" id="txtSpecialPrice" onchange="validateFloatKeyPress(this);" class="form-control" tabindex="10" runat="server" placeholder="Special Offer Price">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSpecialPrice" ValidationGroup="v1" ForeColor="Red" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                        </div>
                        <!-- col -->
                        <div class="col-lg-4 mb-3">
                            <label>Special Offer Validity</label>
                            <input id="txtSpecialOffValidity" tabindex="12" runat="server" type="date" class="form-control date" placeholder="Special Offer Validity">
                        </div>
                        <!-- col -->

                        <div class="col-lg-4 mb-3">
                            <label><span style="color: red;">*</span> Online Price</label>
                            <input id="txtOnlinePrice" tabindex="14" runat="server" type="text" onchange="validateFloatKeyPress(this);" step="0.01" class="form-control" placeholder="Online Price" required>
                            <asp:RequiredFieldValidator ID="reqOnlinePrice" runat="server" ControlToValidate="txtOnlinePrice" ValidationGroup="v1" ForeColor="Red" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                        </div>
                        <!-- col -->
                    </div>
                    <div class="row evenodd">
                        <%--mb-2--%>
                        <div class="col-lg-4 pb-2 pt-1">
                            <label>Active</label>
                            <asp:DropDownList ID="drpActive" CssClass="form-control" TabIndex="15" runat="server">
                                <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row evenodd ">
                        <%--mb-2--%>
                        <div class="col-lg-12 mb-3">
                            <h4>Images</h4>
                        </div>
                    </div>
                    <div class="row evenodd">
                        <%--mb-2--%>
                        <div class="col-lg-12 viceversa mb-3">
                            <div class="row">
                                <div class="col-lg-4 mb-3">
                                    <label><span style="color: red">*</span> Image file </label>
                                    <asp:FileUpload ID="FuImage1" TabIndex="18" runat="server" type="file" class="form-control ServiceImg" placeholder="Upload File"></asp:FileUpload>
                                    <asp:CustomValidator ID="CfileUpload" runat="server" ValidationGroup="v1" ControlToValidate="FuImage1" Display="Dynamic" ClientValidationFunction="fnValidateFile();" OnServerValidate="reqfileupload1_ServerValidate" ForeColor="Red" ErrorMessage="File is required"></asp:CustomValidator>
                                    <Img src="" id="ServiceView" runat="server" class="mb-3 p-0 ServiceView" Style="width: 100px; display: none;" />

                                </div>
                                <!-- col -->
                                <div class="col-lg-4 mb-3">
                                    <label>Image Name</label>
                                    <input id="txtImageName" tabindex="20" runat="server" type="text" class="form-control" placeholder="File Name">
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 mb-3">
                                    <label>Display Order</label>
                                    <input id="txtDisplayOrder" tabindex="21" runat="server" type="number" class="form-control" placeholder="Display Order">
                                </div>
                                <!-- col -->
                            </div>
                            <div>
                                <asp:Literal ID="ServiceImgPath" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-lg-12 text-center">
                            <button id="btnSubmit" runat="server" tabindex="40" causesvalidation="true" validationgroup="v1" class="btn btn-purple" onserverclick="btnSubmit_ServerClick"><i class="typcn typcn-upload"></i>Submit</button>
                            <%--<a href="services.html" class="btn btn-purple"><i class="typcn typcn-upload"></i>Submit</a>--%>
                        </div>
                    </div>

                </div>
                <!-- card-body -->
            </div>
            <!-- card -->
            <asp:HiddenField ID="hdnServiceId" runat="server" />
            <asp:HiddenField ID="hdnImage1" runat="server" />
            <asp:HiddenField ID="hdnImage2" runat="server" />
            <asp:HiddenField ID="hdnImage3" runat="server" />
            <asp:HiddenField ID="hdnImage4" runat="server" />
            <asp:HiddenField ID="hdnImage5" runat="server" />
            <asp:HiddenField ID="hdnImage6" runat="server" />
        </div>
        <!-- az-content-body -->
    </div>
    <script>
        $(document).on('change', '.ServiceImg', function () {
            //debugger;
            readURL(this);
            $(".ServiceView").css("display", "block");
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.ServiceView').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <script type="text/javascript">
        function validateFloatKeyPress(el) {
            //debugger;
            var v = parseFloat(el.value);
            el.value = (isNaN(v)) ? '' : v.toFixed(2);
        }
    </script>
</asp:Content>
