function PageAccess(pageid, menuid) {
    if (pageid != "") {
        $("." + pageid).css("display", "block");
    }
    if (menuid != "") {
        $("." + menuid).css("display", "block");
    }
}
function setAllAccess() {
    $(".ShowHide").css("display", "block");
}


function HidePageAccess() {
    $(".ShowHide").css("display", "none");
}

$(document).ready(function () {
    HidePageAccess();
    LoadMenu();
});

function LoadMenu() {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: 'Dashboard.aspx/LoadMenu',
        success: function (data) {
            var tableData = $.parseJSON(data.d);
            for (var i = 0; i < tableData.length; i++) {
                if (tableData[i].UserPermID != 0 && tableData[i].UserPermID != null) {
                    PageAccess(tableData[i].PageID, tableData[i].ParentName);
                }
            }
        },
        error: function (xhr, ajaxOptions, thrownError)  {
            alert(xhr.responseText);
        }
    });
}

function HideShowButton() {
    var url = document.location.pathname.match(/[^\/]+$/)[0];
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        url: "Dashboard.aspx/GetPageAccess",
        data: JSON.stringify({ url: url }),
        success: function (response) {
            var tableData = $.parseJSON(response.d);
            $.each(tableData, function (key, value) {
                $.each(value, function (keyname, valuename) {
                    if (keyname == "ModFull") {
                        if (valuename == false) {
                            $('.btnExport').css({ "display": "none" });
                            $('.btnView').css({ "display": "none" });
                            $('.btnDelete').css({ "display": "none" });
                            $('.btnEdit').css({ "display": "none" });
                            $('.btnAdd').css({ "display": "none" });
                        }
                    }
                    if (keyname == "ModAdd") {
                        if (valuename == false) {
                            $('.btnAdd').css({ "display": "none" });
                        }
                    }
                    if (keyname == "ModEdit") {
                        if (valuename == false) {
                            $('.btnEdit').css({ "display": "none" });
                        }
                    }
                    if (keyname == "ModView") {
                        if (valuename == false) {
                            $('.btnView').css({ "display": "none" });
                        }
                    }
                    if (keyname == "ModDelete") {
                        if (valuename == false) {
                            $('.btnDelete').css({ "display": "none" });
                        }
                    }
                    if (keyname == "ModExport") {
                        if (valuename == false) {
                            $('.btnExport').css({ "display": "none" });
                        }
                    }
                });
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
}

