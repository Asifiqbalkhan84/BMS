﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestDeals.aspx.cs" Inherits="Yuan.TestDeals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        /*const { debug } = require("util");*/

        $(document).ready(function () {

            //GetDropDownData();

            $("#btnAdd").on("click", function () {
                insRow();
            });

            $('table').on('click', '#dlt-btn', function (e) {

                var choice = confirm('Do you really want to delete this record?');
                if (choice === true) {
                    return $(this).closest('tr').remove();
                }
                return false;
            });


        });

        function insRow() {
            debugger;
            var x = $(<%=tblService.ClientID%>).find('tbody')[0];
            //var x = $('/**********************/').find("tbody");
            // deep clone the targeted row
            var new_row = x.rows[1].cloneNode(true);
            // get the total number of rows
            var len = x.rows.length;
            // set the innerHTML of the first row 
            //new_row.cells[0].innerHTML = len;

            var inp0 = new_row.cells[0].getElementsByTagName('select');// getElementsByTagName('select')[0];
            inp0.id += len;
            inp0.value = '';
            // grab the input from the first cell and update its ID and value
            var inp1 = new_row.cells[1].getElementsByTagName('input')[0];
            inp1.id += len;
            inp1.value = '';

            // grab the input from the second cell and update its ID and value
            var inp2 = new_row.cells[2].getElementsByTagName('select');//.getElementsByTagName('input')[0];
            inp2.id += len;
            inp2.value = '';

            // grab the input from the first cell and update its ID and value
            var inp3 = new_row.cells[3].getElementsByTagName('select');//.getElementsByTagName('input')[0];
            inp3.id += len;
            inp3.value = '';

            // append the new row to the table
            x.appendChild(new_row);
        }

        //$("#btnAdd").on("click", function () {
        //    insRow();
        //});


        function GetTableValues() {
            //Create an Array to hold the Table values.
            debugger;
            var services = [];

            //Reference the Table.
            //var table = $("#tblService");
            var table = $(<%=tblService.ClientID%>).find('tbody')[0];

            // get the total number of rows
           // var len = table.rows.length;
            //alert(len);
            //Loop through Table Rows.
            for (var i = 1; i < table.rows.length; i++) {
                //Reference the Table Row.                
                var row = table.rows[i];
                var test = document.getElementById('drpServices').value;
                alert(test);
                //Copy values from Table Cell to JSON object.
                //alert(row.cells[1].innerHTML);
                var service = {
                    ServiceId: document.getElementById('drpServices')[i].value,
                    ServiceBy: row.cells[1].innerHTML,
                    Qty: row.cells[2].innerHTML,
                    Price: row.cells[3].innerHTML
                };
                services.push(service);
            }
            console.log(services);
            //Convert the JSON object to string and assign to Hidden Field.
            document.getElementsByName("hdnService")[0].value = JSON.stringify(services);
            alert(services);
            return true;
        }

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "TestDeals.aspx/FillDrpService",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    $.each(JSON.parse(data.d), function (data, value) {
                        <%--$("<%=drpService.ClientID%>").append($("<option><option/>").val(this.ServiceID).text(this.ServiceName));--%>
                        //console.log(value.ServiceID);
                        $(".drpServices").append($("<option      />").val(value.ServiceID).text(value.ServiceName))
                    });
                },
                onchange: function () { },
                failure: function () {
                    alert("Failed!");
                }
            });
        });
        $(document).on("change", '.drpServices', function (event) {

            //$("input[name=hdnServiceId]").val($(this).val());
            var SerId = $(this).val();
            debugger;
            $.ajax({
                type: "POST",
                url: "TestDeals.aspx/FillServiceData",
                data: "{data: '" + SerId + "'}", //{ServiceId:SerId },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    $.each(JSON.parse(data.d), function (data, value) {
                        /**************************************************************************************************************/
                        //console.log(value.ServiceID);
                        $(".txtHrs").val(value.ServiceHRs);
                        $(".txtAmount").val(value.Price);
                    });


                    //$(".txtHrs").val(res[0].ServiceHRs);
                    //    

                },
                //onchange: function () { debugger; $("input[name=hdnServiceId]").val($(this).val()); },
                failure: function () {
                    alert("Failed!");
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>--%>
    <div class="az-content az-content-dashboard">
        <div class="container">
            <div class="az-content-body">
                <div class="az-dashboard-one-title">
                    <div>
                        <input id="hdnService" type="hidden" name="hdnService" />
                        <h2 class="az-dashboard-title">Add Deal</h2>
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
                                    <div class="col-lg-12 mb-3">
                                        <h4>Deals Details</h4>
                                    </div>
                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Deal Name</label>
                                        <input id="txtDealname" runat="server" tabindex="1" type="text" class="form-control" placeholder="Deal Name">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Description</label>
                                        <textarea id="txtDesc" runat="server" tabindex="2" class="form-control" rows="2" placeholder="Description"></textarea>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Validity</label>
                                        <input id="txtValidity" runat="server" tabindex="4" type="date" class="form-control" placeholder="Validity">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Discount %</label>
                                        <input id="txtDiscountper" runat="server" tabindex="6" type="text" class="form-control" placeholder="Discount">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Discount</label>
                                        <input id="txtDiscountAmt" runat="server" tabindex="8" type="text" class="form-control" placeholder="Discount Flat">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Discount Voucher</label>
                                        <input id="txtDiscVoucher" runat="server" tabindex="10" type="text" class="form-control" placeholder="Discount Voucher">
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Outlet</label>
                                        <asp:DropDownList ID="drpOutlet" runat="server" TabIndex="11" CssClass="form-control">
                                            <%--<asp:ListItem>---Select---</asp:ListItem>
                                            <asp:ListItem>All</asp:ListItem>
                                            <asp:ListItem>Bandra</asp:ListItem>
                                            <asp:ListItem>Juhu</asp:ListItem>
                                            <asp:ListItem>Andheri</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> For Members</label>
                                        <asp:DropDownList ID="drpMember" runat="server" TabIndex="12" CssClass="form-control">
                                            <asp:ListItem>---Select---</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <!-- col -->

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Member Type</label>
                                        <asp:DropDownList ID="drpMemberType" runat="server" TabIndex="12" CssClass="form-control">
                                            <asp:ListItem>---Select---</asp:ListItem>
                                            <asp:ListItem>All</asp:ListItem>
                                            <asp:ListItem>Gold</asp:ListItem>
                                            <asp:ListItem>Premium</asp:ListItem>
                                            <asp:ListItem>Ultimate</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <!-- col -->
                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label><span style="color: red">*</span> Deal Type</label>
                                        <asp:DropDownList ID="drpDealType" runat="server" TabIndex="13" CssClass="form-control">
                                            <asp:ListItem Value="">---Select---</asp:ListItem>
                                            <asp:ListItem Value="Gift Voucher">Gift Voucher</asp:ListItem>
                                            <asp:ListItem Value="Discount Coupon">Discount Coupon</asp:ListItem>
                                            <asp:ListItem Value="Package">Package</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-lg-4 pb-2 pt-1">
                                        <label>Is Free</label>
                                        <input id="chkIsFree" runat="server" tabindex="14" type="checkbox" class="form-check">
                                    </div>
                                </div>
                                <%--//class="row mb-4"--%>
                                <div class="row mb-4">
                                    <div class="col-lg-4 mb-3">
                                        <h4>Images</h4>
                                    </div>
                                    <div class="col-lg-8 mb-4">
                                        <label id="lblImgSize" visible="false" runat="server"></label>
                                    </div>
                                    <div class="col-lg-12 mb-3">
                                        <div class="row">
                                            <div class="col-lg-4 mb-3">
                                                <label><span style="color: red">*</span> Image file ( 1 ) </label>
                                                <asp:FileUpload ID="FuimgFile1" runat="server" TabIndex="15" type="file" class="form-control" placeholder="Upload File" />
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label><span style="color: red">*</span> Image Name</label>
                                                <input id="imgName1" runat="server" tabindex="16" type="text" class="form-control" placeholder="File Name">
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label><span style="color: red">*</span> Display Order</label>
                                                <input id="txtDisplayOrd1" runat="server" tabindex="17" type="number" class="form-control" placeholder="Display Order">
                                            </div>
                                            <!-- col -->
                                        </div>
                                        <hr>
                                        <div class="row">
                                            <div class="col-lg-4 mb-3">
                                                <label>Image file ( 2 )</label>
                                                <asp:FileUpload ID="FuimgFile2" runat="server" TabIndex="18" type="file" class="form-control" placeholder="Upload File" />
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label>Image Name</label>
                                                <input id="imgName2" runat="server" tabindex="19" type="text" class="form-control" placeholder="File Name">
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label>Display Order</label>
                                                <input id="txtDisplayOrd2" runat="server" tabindex="20" type="number" class="form-control" placeholder="Display Order">
                                            </div>
                                            <!-- col -->
                                        </div>
                                        <hr>
                                        <div class="row">
                                            <div class="col-lg-4 mb-3">
                                                <label>Image file ( 3 )</label>
                                                <asp:FileUpload ID="FuimgFile3" runat="server" TabIndex="22" type="file" class="form-control" placeholder="Upload File" />
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label>Image Name</label>
                                                <input id="imgName3" runat="server" tabindex="23" type="text" class="form-control" placeholder="File Name">
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label>Display Order</label>
                                                <input id="txtDisplayOrd3" runat="server" tabindex="25" type="number" class="form-control" placeholder="Display Order">
                                            </div>
                                            <!-- col -->
                                        </div>
                                        <hr>
                                        <div class="row">
                                            <div class="col-lg-4 mb-3">
                                                <label>Image file ( 4 )</label>
                                                <asp:FileUpload ID="FuImgFile4" runat="server" TabIndex="26" type="file" class="form-control" placeholder="Upload File" />
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label>Image Name</label>
                                                <input id="imgName4" runat="server" tabindex="27" type="text" class="form-control" placeholder="File Name">
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label>Display Order</label>
                                                <input id="txtDisplayOrd4" runat="server" tabindex="28" type="number" class="form-control" placeholder="Display Order">
                                            </div>
                                            <!-- col -->
                                        </div>
                                        <hr>
                                        <div class="row">
                                            <div class="col-lg-4 mb-3">
                                                <label>Image file ( 5 )</label>
                                                <asp:FileUpload ID="FuImgFile5" runat="server" type="file" class="form-control" placeholder="Upload File" />
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label>Image Name</label>
                                                <input id="imgName5" runat="server" tabindex="29" type="text" class="form-control" placeholder="File Name">
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label>Display Order</label>
                                                <input id="txtDisplayOrd5" runat="server" tabindex="30" type="number" class="form-control" placeholder="Display Order">
                                            </div>
                                            <!-- col -->
                                        </div>
                                        <hr>
                                        <div class="row">
                                            <div class="col-lg-4 mb-3">
                                                <label>Image file ( 6 )</label>
                                                <asp:FileUpload ID="FuImgFile6" runat="server" TabIndex="31" type="file" class="form-control" placeholder="Upload File" />
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label>Image Name</label>
                                                <input id="imgName6" runat="server" tabindex="32" type="text" class="form-control" placeholder="File Name">
                                            </div>
                                            <!-- col -->

                                            <div class="col-lg-4 mb-3">
                                                <label>Display Order</label>
                                                <input id="txtDisplayOrd6" runat="server" tabindex="34" type="number" class="form-control" placeholder="Display Order">
                                            </div>
                                            <!-- col -->
                                        </div>

                                    </div>
                                </div>

                                <hr>
                                <div class="row mb-3">
                                    <div class="col-lg-12 mb-3">
                                        <h4>Services</h4>
                                    </div>
                                    <asp:UpdatePanel ID="updOutlet" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="col-lg-12 mb-3">
                                                <label>Outlet</label>
                                                <asp:DropDownList ID="drpOutlet2" runat="server" OnSelectedIndexChanged="drpOutlet2_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                <%--<select class="form-control">
                                                    <option>--- Select ---</option>
                                                    <option>Bandra</option>
                                                    <option>Andheri</option>
                                                    <option>Malad</option>
                                                </select>--%>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <!-- col -->

                                    <div class="col-lg-12 pb-3 pt-2">
                                        <div class="table-wrap">
                                            <div class="table-responsive">
                                                <table id="tblService" runat="server" class="table table-striped table-bordered tblService">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="5">Services</th>
                                                            <th style="text-align: center">
                                                                <a class="btn btn-purple" name="" value="Add" id="btnAdd">Add</a>
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <label><span style="color: red">*</span> Service Name</label>
                                                                <%--<select ID="drpService" runat="server" class="form-control drpService" >
                                                                    <asp:ListItem Value="">--Select--</asp:ListItem>
                                                                </select>--%>
                                                                <asp:DropDownList ID="drpServices" runat="server" CssClass="form-control drpServices">
                                                                    <asp:ListItem Value="">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <label>Hrs</label>
                                                                <input id="txtHrs" type="text" class="form-control" placeholder="Hrs">
                                                            </td>
                                                            <td>
                                                                <label>Serviced By</label>
                                                                <select id="drpServiceBy" runat="server" class="form-control">
                                                                    <option value="">--Select--</option>
                                                                    <option value="1">Tarun</option>
                                                                    <option value="2">Amit</option>
                                                                </select>
                                                            </td>
                                                            <td>
                                                                <label>Qty</label>
                                                                <select id="drpQty" runat="server" class="form-control">
                                                                    <option value="">--Select--</option>
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                </select>
                                                            </td>
                                                            <td>
                                                                <label>Amount</label>
                                                                <input type="number" class="form-control" placeholder="Amount">
                                                            </td>
                                                            <td style="text-align: center">
                                                                <button class="btn btn-tbl-delete" id="dlt-btn" aria-readonly="true" title="Delete Record">
                                                                    <i class="typcn typcn-trash"></i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-4 mb-3">
                                        <label>Remarks</label>
                                        <textarea type="text" class="form-control" placeholder="Remarks"></textarea>
                                    </div>
                                    <!-- col -->
                                </div>


                                <div class="row mb-3">
                                    <div class="col-lg-12 text-center">
                                        <%--<asp:LinkButton ID="btnSubmit" runat="server" class="btn btn-purple" OnClick="btnSubmit_Click"><i class="typcn typcn-upload"></i>Submit</asp:LinkButton>--%>
                                        <button id="btnSubmit" runat="server" class="btn btn-purple" onclientclick="return GetTableValues()" onclick="submit"><i class="typcn typcn-upload"></i>Submit</button>
                                        <asp:Button ID="btnSubmit1" runat="server" CssClass="btn btn-purple" Text="Test" OnClick="btnSubmit1_Click1" OnClientClick="GetTableValues();" />
                                    </div>
                                </div>
                                <asp:HiddenField ID="hdnDealId" runat="server" />

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
    </div>

</asp:Content>
