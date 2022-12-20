<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDeal.aspx.cs" Inherits="Yuan.AddDeal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.cdnjs.com/ajax/libs/json2/20110223/json2.js"></script>
    <script type="text/javascript">
        document.cookie = "AC-C=ac-c;path=/;SameSite=Lax";
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //GetDropDownData();
            debugger;
            loadService();
            setTimeout(LoadStaff(), 100);
            BindServiceData();

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
            //alert('Infunction');
            var x = $(<%=tblService.ClientID%>).find('tbody')[0];
            var new_row = x.rows[1].cloneNode(true);
            // get the total number of rows
            var len = x.rows.length;

            var inp0 = new_row.cells[0].getElementsByTagName('select');// getElementsByTagName('select')[0];

            const Service = new_row.querySelector('#drpService');
            Service.id = `drpService${len}`;
            Service.removeClass = `drpService`;
            Service.addClass = `drpService${len}`;

            //inp0.id = `drpService${len}`;
            //inp0.value = '';
            //inp0.removeClass = 'drpService';
            //inp0.addClass = inp0.id;
            // grab the input from the first cell and update its ID and value
            var inp1 = new_row.cells[1].getElementsByTagName('input')[0];
            inp1.id += len;
            inp1.value = '';
            inp1.addClass = inp1.id;
            // grab the input from the second cell and update its ID and value
            //var inp2 = new_row.cells[2].getElementsByTagName('select');//.getElementsByTagName('input')[0];
            //inp2.id += len;
            //inp2.value = '';
            const Quantity = new_row.querySelector('#drpQty');
            Quantity.id = `drpQty${len}`;
            Quantity.removeClass = `drpQty`;
            Quantity.addClass = `drpQty${len}`;

            // grab the input from the first cell and update its ID and value
            //var inp3 = new_row.cells[3].getElementsByTagName('select');//.getElementsByTagName('input')[0];
            //inp3.id += len;
            //inp3.value = '';

            const ServiceBy = new_row.querySelector('#drpServiceBy');
            ServiceBy.id = `drpServiceBy${len}`;
            ServiceBy.value = '';

            var inp4 = new_row.cells[4].getElementsByTagName('input')[0];
            inp4.id += len;
            inp4.value = '';
            inp4.addClass = inp4.id;
            // append the new row to the table
            x.appendChild(new_row);
        }
       
        /* END EXTERNAL SOURCE */

        /* BEGIN EXTERNAL SOURCE */
        function loadService() {
            $.ajax({
                type: "POST",
                url: "AddDeal.aspx/FillDrpService",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    $.each(JSON.parse(data.d), function (data, value) {
                        /**************************************************************************************************************/
                        //console.log(value.ServiceID);
                        $(".drpService").append($("<option      />").val(value.ServiceID).text(value.ServiceName))
                    });
                },
                //onchange: function () { debugger; $("input[name=hdnServiceId]").val($(this).val()); },
                failure: function () {
                    alert("Failed!");
                }
            });
        }
        function LoadStaff() {
            $.ajax({
                type: "POST",
                url: "AddDeal.aspx/GetStaff",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    $.each(JSON.parse(data.d), function (data, value) {
                        /**************************************************************************************************************/
                        //console.log(value.ServiceID);
                        $(".drpStaff").append($("<option      />").val(value.StaffID).text(value.StaffName))
                    });
                },
                //onchange: function () { debugger; $("input[name=hdnServiceId]").val($(this).val()); },
                failure: function () {
                    alert("Failed!");
                }
            });
        }
        function BindServiceData() {
            const urlParams = new URLSearchParams(window.location.search);
            const DealId = urlParams.get('ID');
            var table = document.getElementById("<%=tblService.ClientID%>");
            if (table.rows === "undefined") {
                return;
            }

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "AddDeal.aspx/BindServiceData",
                data: "{did:'" + DealId + "'}",
                success: function (data) {

                    $.each(JSON.parse(data.d), function (index, data) {
                        /**************************************************************************************************************/
                        //console.log(value.ServiceID);
                        //alert(data.d.length);
                        var IsFree = $('#<%=chkIsFree.ClientID%>');
                        IsFree.prop('checked',data.IsFree);
                        var I = index + 1;
                        //debugger;
                        if (I > 1) {
                            insRow();
                        }

                        var x = $(<%=tblService.ClientID%>).find('tbody')[0];
                        let $row = $(x);
                        if (I <= 1) {
                            // set value of the select within this row instance
                            $row.find('select#drpService').val(data.ServiceID);
                            $row.find('.txtHrs').val(data.ServiceHRs);
                            $row.find('select#drpServiceBy').val(data.ServiceBy);
                            $row.find('select#drpQty').val(data.Qty);
                            $row.find('.txtAmount').val(data.Price);
                            $row.find('.hdnAmount').val(data.Price);
                        }
                        if (I > 1) {
                            // set value of the select within this row instance
                            $row.find('select#drpService' + I).val(data.ServiceID);
                            $row.find('#ContentPlaceHolder1_txtHrs' + I).val(data.ServiceHRs);
                            $row.find('select#drpServiceBy' + I).val(data.ServiceBy);
                            $row.find('select#drpQty' + I).val(data.Qty);
                            $row.find('#ContentPlaceHolder1_txtAmount' + I).val(data.Price);
                            $row.find('#ContentPlaceHolder1_hdnAmount' + I).val(data.Price);
                        }
                        //alert(data.ServiceID);
                        //var row = table.rows[I];
                        //var drpServ = row.cells[0].getElementsByTagName('select');
                        //drpServ.val(data.ServiceID); //"option [value="+ data.ServiceID +"]").attr["selected","selected"]; // +" option[value = " + data.ServiceID + "]").attr('selected', 'selected');


                        //var hrs = row.closest('td').find('.txtHrs');
                        //var Service = $("table td .drpService") //$('.drpService');
                        //var amt = row.closest('td').find('.txtAmount'); //$('.txtAmount');
                        //var Hamt = row.closest('td').find('.txtAmount');
                        //var Qty = $('.drpQty');

                        //hrs.val(data.ServiceHRs);
                        //amt.val(data.Price);
                        //Hamt.val(data.Price);
                        //$("Qty option[value = " + data.Qty + "]").attr('selected', 'selected');
                        //$("ServiceBy option[value=" + data.ServiceBy + "]").attr('selected', 'selected');
                        //$(".drpService option[value=" + value.ServiceId + "]").attr('selected', 'selected');
                    });
                },
                failure: function () { alert('Failue'); }
            });
        }   

        $(document).on("change", '.drpService', function (event) {

            //$("input[name=hdnServiceId]").val($(this).val());
            var Service = $(this);
            var SerId = Service.val();
            var hrs = Service.closest('tr').find('.txtHrs');
            var amt = Service.closest('tr').find('.txtAmount');
            var Hamt = Service.closest('tr').find('.hdnAmount');
            debugger;
            $.ajax({
                type: "POST",
                url: "AddDeal.aspx/FillServiceData",
                data: "{data: '" + SerId + "'}", //{ServiceId:SerId },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    $.each(JSON.parse(data.d), function (data, value) {
                        /**************************************************************************************************************/
                        //console.log(value.ServiceID);
                        //alert(value.ServiceHRs +','+ value.Price);
                        debugger;
                        hrs.val(value.ServiceHRs);
                        amt.val(value.Price);
                        Hamt.val(value.Price);
                        //$(Service).closest('td').find('.txtHrs').val(value.ServiceHRs);
                        //$(Service).closest('td').find('.txtAmount').val(value.Price);
                    });

                },

                //onchange: function () { debugger; $("input[name=hdnServiceId]").val($(this).val()); },
                failure: function () {
                    alert("Failed!");
                }
            });
        });

        function GetTableValues() {
            //Create an Array to hold the Table values.
            //debugger;
            var services = new Array;

            //Reference the Table.
            //var table = $("#tblService");
            //var table = $(<%=tblService.ClientID%>).find('tbody')[0];
            var table = document.getElementById("<%=tblService.ClientID%>");
            if (table.rows === "undefined") {
                return;
            }

            //Loop through Table Rows.           

            for (var i = 1; i < table.rows.length; i++) {
                //Reference the Table Row.                
                var row = table.rows[i];
                //Copy values from Table Cell to JSON object.
                debugger;
                var hrs = '';
                var Amt = '';
                //alert(hrs);
                if (i === 1) {
                    hrs = $("#<%=txtHrs.ClientID%>").val();
                    Amt = $("#<%=txtAmount.ClientID%>").val();
                }
                else {
                    hrs = $("#ContentPlaceHolder1_txtHrs"+ i).val();
                    Amt = $("#ContentPlaceHolder1_txtAmount"+ i).val();
                }
                var service = {
                    
                    ServiceId: document.getElementById('drpService')[i].value, //$("#drpService").find(":selected").val()
                    Hrs: hrs,//document.getElementById('txtHrs').value,
                    ServiceBy: document.getElementById('drpServiceBy')[i].value,
                    Qty: document.getElementById('drpQty')[i].value,
                    Price: Amt //document.getElementById('txtAmount').value,
                };
                services.push(service);
            }
            //console.log(services);
            //Convert the JSON object to string and assign to Hidden Field.
            document.getElementsByName("hdnServiceJson")[0].value = JSON.stringify(services);
            //alert(services);
            return true;
        }
        
    </script>
    <script type="text/javascript">
        <%--$("<%=drpService.ClientID%>").append($("<option><option/>").val(this.ServiceID).text(this.ServiceName));--%>
        $(document).on("change", '.drpOutlet2', function (event) {

            //$("input[name=hdnServiceId]").val($(this).val());
            var OutletId = $(this).val();
            //debugger;
            $.ajax({
                type: "POST",
                url: "AddDeal.aspx/GetServicesByOutlet",
                data: "{data: '" + OutletId + "'}", //{ServiceId:SerId },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    $.each(JSON.parse(data.d), function (data, value) {
                        /**************************************************************************************************************/
                        //console.log(value.ServiceID);
                        $(".drpService").append($("<option    />").val(value.ServiceId).text(value.ServiceName));

                    });
                    //$(".txtHrs").val(res[0].ServiceHRs);                     

                },
                //onchange: function () { debugger; $("input[name=hdnServiceId]").val($(this).val()); },
                failure: function () {
                    alert("Failed!");
                }
            });
        });

        $(document).on("change", '.drpQty', function () {
            debugger;
            var qty = $(this);
            var hdnamt = qty.closest('tr').find('.hdnAmount');
            var amt = qty.closest('tr').find('.txtAmount');
            var calc = qty.val() * hdnamt.val();
            //alert(amt.val());
            //amt.val('');
            amt.val(calc);
            //
        });

        $(document).on('change', '.DealsView', function () {
            //debugger;
            readURL(this);
            $(".DealsView").css("display", "block");
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.DealsView').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<div class="az-content az-content-dashboard">--%>
    <div class="container">
        <div class="az-content-body">
            <div class="az-dashboard-one-title">
                <div>
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
                                    <input id="txtDealname" runat="server" tabindex="1" type="text" class="form-control" placeholder="Deal Name" required>
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label>Description</label>
                                    <textarea id="txtDesc" runat="server" tabindex="2" class="form-control" rows="2" placeholder="Description"></textarea>
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label><span style="color: red">*</span> Validity</label>
                                    <input id="txtValidity" runat="server" tabindex="4" type="date" class="form-control" placeholder="Validity" required>
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label><span style="color: red">*</span> Discount %</label>
                                    <input id="txtDiscountper" runat="server" tabindex="6" type="number" step="0.01" class="form-control" placeholder="Discount" required>
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label>Discount</label>
                                    <input id="txtDiscountAmt" runat="server" tabindex="8" type="number" step="0.01" class="form-control" placeholder="Discount Flat">
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label>Discount Voucher</label>
                                    <input id="txtDiscVoucher" runat="server" tabindex="10" type="text" class="form-control" placeholder="Discount Voucher">
                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label><span style="color: red">*</span> Outlet</label>
                                    <asp:DropDownList ID="drpOutlet" runat="server" TabIndex="11" CssClass="form-control" required>
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
                                    <asp:DropDownList ID="drpMember" runat="server" TabIndex="12" CssClass="form-control" requied>
                                        <asp:ListItem>---Select---</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <!-- col -->

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label>Member Type</label>
                                    <asp:DropDownList ID="drpMemberType" runat="server" TabIndex="12" CssClass="form-control">
                                        <asp:ListItem Value="">---Select---</asp:ListItem>
                                        <asp:ListItem Value="All">All</asp:ListItem>
                                        <asp:ListItem Value="Gold">Gold</asp:ListItem>
                                        <asp:ListItem Value="Premium">Premium</asp:ListItem>
                                        <asp:ListItem Value="Ultimate">Ultimate</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- col -->
                                <div class="col-lg-4 pb-2 pt-1">
                                    <label><span style="color: red">*</span> Deal Type</label>
                                    <asp:DropDownList ID="drpDealType" runat="server" TabIndex="13" CssClass="form-control" required>
                                        <asp:ListItem Value="">---Select---</asp:ListItem>
                                        <asp:ListItem Value="Gift Voucher">Gift Voucher</asp:ListItem>
                                        <asp:ListItem Value="Discount Coupon">Discount Coupon</asp:ListItem>
                                        <asp:ListItem Value="Package">Package</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="col-lg-4 pb-2 pt-1">
                                    <label>Active</label>
                                    <asp:DropDownList ID="drpActive" runat="server" TabIndex="15" CssClass="form-control" required>
                                        <asp:ListItem Value="">---Select---</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
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
                                            <asp:FileUpload ID="FuimgFile1" runat="server" TabIndex="17" type="file" class="form-control" placeholder="Upload File" />
                                            <img src="" id="ImgDealView" runat="server" class="mb-3 p-0 DealsView" style="width: 100px; display: none;" />
                                        </div>
                                        <!-- col -->

                                        <div class="col-lg-4 mb-3">
                                            <label><span style="color: red">*</span> Image Name</label>
                                            <input id="imgName1" runat="server" tabindex="19" type="text" class="form-control" placeholder="File Name" required>
                                        </div>
                                        <!-- col -->

                                        <div class="col-lg-4 mb-3">
                                            <label><span style="color: red">*</span> Display Order</label>
                                            <input id="txtDisplayOrd1" runat="server" tabindex="20" type="number" class="form-control" placeholder="Display Order" required>
                                        </div>
                                        <!-- col -->
                                    </div>
                                    <%--<hr>--%>
                                    <%--<div class="row">
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
                                    </div>--%>
                                </div>
                            </div>
                            <%--<hr>--%>
                            <div class="row mb-3">
                                <div class="col-lg-12 mb-3">
                                    <h4>Services</h4>
                                </div>
                                <asp:UpdatePanel ID="updOutlet" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="col-lg-12 mb-3">
                                            <label>Outlet</label>
                                            <asp:DropDownList ID="drpOutlet2" TabIndex="22" runat="server" OnSelectedIndexChanged="drpOutlet2_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control drpOutlet2"></asp:DropDownList>
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
                                            <table id="tblService" runat="server" class="table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th colspan="5">Services</th>
                                                        <th style="text-align: center">
                                                            <a class="btn btn-purple" name="" value="Add" id="btnAdd">Add</a>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr class="Tr1">
                                                        <td>
                                                            <label><span style="color: red">*</span> Service Name</label>
                                                            <select id="drpService" class="form-control drpService">
                                                                <option value="">--Select--</option>
                                                            </select>                                                            
                                                            <%--<select id="drpService" runat="server" class="form-control drpService" required>
                                                                    <option value="">--Select--</option>
                                                                </select>--%>
                                                        </td>
                                                        <td>
                                                            <label>Hrs</label>
                                                            <input id="txtHrs" readonly="readonly" runat="server" type="text" class="form-control txtHrs" placeholder="Hrs">
                                                        </td>
                                                        <td>
                                                            <label>Serviced By</label>
                                                            <select id="drpServiceBy" class="form-control drpStaff">
                                                                <option value="">--Select--</option>
                                                            </select>
                                                            <%--<asp:DropDownList ID="drpServiceBy1" runat="server" class="form-control">
                                                                <asp:ListItem value="">--Select--</asp:ListItem>
                                                            </asp:DropDownList>--%>
                                                        </td>
                                                        <td>
                                                            <label><span style="color: red">*</span> Qty</label>
                                                            <select id="drpQty" class="form-control drpQty">
                                                                <option value="">--Select--</option>
                                                                <option value="1">1</option>
                                                                <option value="2">2</option>
                                                                <option value="3">3</option>
                                                                <option value="4">4</option>
                                                                <option value="5">5</option>
                                                                <option value="6">6</option>
                                                            </select>
                                                        </td>
                                                        <td>
                                                            <label>Amount</label>
                                                            <input id="txtAmount" type="number" readonly="readonly" runat="server" step="0.01" class="form-control txtAmount" placeholder="Amount" />
                                                            <input id="hdnAmount" name="hdnAmount" class="hdnAmount" type="hidden" />
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
                                    <textarea id="txtRemark" type="text" runat="server" aria-multiline="true" class="form-control" placeholder="Remarks"></textarea>
                                </div>
                                <!-- col -->
                            </div>

                            <div class="row mb-3">
                                <div class="col-lg-12 text-center">
                                    <asp:Button ID="btnSave" Text="Submit" runat="server" CssClass="typcn typcn-upload btn btn-purple" OnClick="btnSave_Click" OnClientClick="GetTableValues()"></asp:Button>
                                    <button id="btnSubmit" runat="server" class="btn btn-purple" style="display: none" onserverclick="btnSubmit_ServerClick"><i class="typcn typcn-upload"></i>Submit</button>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnDealId" runat="server" />
                            <asp:HiddenField ID="hdnImage1" runat="server" />
                            <input id="hdnJson" type="hidden" name="hdnServiceJson" />

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
    <%--</div>--%>
    <!-- az-content -->

</asp:Content>
