
function BindMenu(Uid) {
    //debugger;
    var Fullchk; var ViewChk; var AddChk; var EditChk; var DelChk; var ExportChk;
    var Modulename = ''; var ParentModule = '';
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'UserPermission.asmx/GetUserPermission',
        data: "{UserId :'" + Uid + "'}",
        success: function (data) {
            //var result = $.parseJSON(data.d);
            console.log(data);
            buildMenu($('#menu'), $.parseJSON(data.d));
            //$('.nav').menu();
            //var Li2 = $('.nav').remove;
            //var li = '';
            //var nav = '';
            //var $ul = $("<ul />").appendTo($("#Li2"));
            //$ul.addClass('nav');

            //$.each(data.d, function (index, item) {
            //    if (item.ModuleName == "Dashboard") {
            //        var li = $("<li />").appendTo($ul);
            //        li.append($("<a /><i class='typcn typcn-chart-pie-outline' />", { href: 'Dashboard.aspx' , text: 'Dashboard' }));
            //    }
            //    if (item.ModuleName == "Masters") {
            //        var li = $("<li id='liMaster' />").appendTo($ul);
            //        li.append($("<a /><i class='typcn typcn-chart-pie-outline' />", { href: '', text: 'Masters' }));
            //        li.append($("<nav id='navMaster' class='az-menu-sub' />"));
            //    }
            //    if (item.ParentModule == "Masters") {
            //        //var li = $("<li />").appendTo($ul);
            //        var Name = ''; var url = '';
            //        if (item.ModuleName == "Staff") {
            //            Name = 'Staff';
            //            url = 'Staff.aspx';
            //        }
            //        if (item.ModuleName == "Category") {
            //            Name = 'Category';
            //            url = 'Category.aspx';
            //        }
            //        if (item.ModuleName == "Services") {
            //            Name = 'Services';
            //            url = 'Services.aspx';
            //        }
            //        if (item.ModuleName == "Company") {
            //            Name = 'Company';
            //            url = 'CompanyDet.aspx';
            //        }
            //        if (item.ModuleName == "Appointment Slots") {
            //            Name = 'Slots';
            //            url = 'Slots.aspx';
            //        }
            //        var anc = $("<a /><i class='typcn typcn-chart-pie-outline' />", { href: url , text: Name }).appendTo($('#navMaster'));
            //    }
            //});


            //$('.nav').html(li);
            //alert($('.nav').text);
            //location.href = 'Dashboard.aspx';
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }

    });

    function buildMenu(parent, items) {
        $.each(items, function () {
            //console.log(parent);
            var li
            debugger;
            //alert($(parent).attr('id'));
            var Id = $(parent).attr('id');
            if (Id == "nav") {
                li = $("<a href='" + this.Url +"' class='nav-link'><i class='typcn typcn-chart-pie-outline'></i>" + this.ModuleName + "</a>");
            }
            else {
                if (this.Url.length > 0) {
                    li = $("<li class='nav-item'><a href='"+ this.Url +"' class='nav-link'><i class='typcn typcn-chart-pie-outline'></i>" + this.ModuleName + '</a></li>');
                }
                else {
                    li = $("<li class='nav-item'><a href='' class='nav-link with-sub'><i class='typcn typcn-cog-outline'></i>" + this.ModuleName + '</a></li>');
                }
                
            }

            //console.log('Module ' + this.ModuleName);
            if (this.IsActive) {
                debugger;
                var anc = "";
                var drpMenu = $('.dropdown-menu');                               

                if (this.ModuleName == "Users") {
                    var header = $(document.createElement("div")).addClass("az-dropdown-header d-sm-none");
                    $(header).append("<a href='' class='az-header-arrow'><i class='icon ion-md-arrow-back'></i></a>");
                    var profile = $(document.createElement("div")).addClass("az-header-profile");
                    var imgUser = $(document.createElement('div')).addClass("az-img-user");
                    imgUser.append("<img src='img/faces/face1.jpg' alt=''>");
                    profile.append($(imgUser));
                    drpMenu.appendTo(profile);
                    //anc = "<div class='az-dropdown-header d-sm-none'><a href='' class='az-header-arrow'><i class='icon ion-md-arrow-back'></i></a></div> ";
                    //anc +="<div class='az-header-profile'><div class='az-img-user'><img src='img/faces/face1.jpg' alt=''></div></div> ";
                    ////<!--az - img - user-- >"
                    ////anc += "<h6><asp:Literal ID='ltUserName' runat='server'></asp:Literal></h6 ><span><asp:Literal ID ='ltrRole' runat='server'></asp:Literal></span></div> ";
                    //anc += "<a href='' runat='server' id='lnklogout' onserverclick='lnklogout_ServerClick' class='dropdown-item'><i class='typcn typcn-power-outline'></i>Sign Out</a> ";
                    ////drpMenu.appendTo(anc);
                    //if (this.FullP == true || this.EditP == true) {
                    //    anc += "<a href='AddUser.aspx?Mode=V' class='dropdown-item'><i class='typcn typcn-user-outline'></i>My Profile'</a> ";
                    //    anc += "<a href='AddUser.aspx?Mode=E' class='dropdown-item'><i class='typcn typcn-edit'></i>Edit Profile'</a> ";
                    //    //drpMenu.appendTo(anc);
                    //}
                    //if (this.ModuleName == "Users" && this.ViewP == true) {
                    //    anc += "<a href='AddUser.aspx?Mode=V' class='nav-link with-sub'><i class='typcn typcn-cog-outline'></i>My Profile'</a>";
                    //    //drpMenu.appendTo(anc);
                    //}
                    //anc.appendTo(drpMenu);
                }  
                                
                //console.log(anc);
                
                //li.addClass("ui-state-disabled");
                li.appendTo(parent);
                if (this.List && this.List.length > 0) {
                    var nav = $("<nav id='nav' class='az-menu-sub'></nav>");
                    nav.appendTo(li);
                    buildMenu(nav, this.List);
                }
                //console.log('Complete ' + this.List);
            }

        });
    }
}