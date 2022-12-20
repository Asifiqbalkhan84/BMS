<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Yuan.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yuan Thai Spa - Mumbai</title>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Meta -->
    <meta name="description" content="Resposive Yuan Thai Spa Admin Control Panel" />
    <meta name="author" content="" />



    <!-- vendor css -->
    <link href="lib/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <link href="lib/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="lib/typicons.font/typicons.css" rel="stylesheet" />
    <link href="lib/flag-icon-css/css/flag-icon.min.css" rel="stylesheet" />

    <!-- Yuan CSS -->
    <link rel="stylesheet" href="css/style.css" />

    <style type="text/css">
        .az-body, .az-dashboard {
            background: url(img/white-great.jpg);
            background-size: cover;
        }
    </style>

    

    <script src="lib/jquery/jquery.min.js"></script>
    <script src="lib/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="lib/ionicons/ionicons.js"></script>    
    <script src="js/cookie.js" type="text/javascript"></script>

    <%--<script src="js/azia.js"></script>--%>
    <script>
        $(function () {
            'use strict'

        });
    </script>
</head>

<body class="az-body">
    <div class="az-signin-wrapper">
        <div class="az-card-signin">
            <h1 class="text-center">
                <img src="img/logo.png" width="220px"></h1>
            <div class="az-signin-header">
                <h2>Welcome back!</h2>
                <h4 class="text-white">Please sign in to continue</h4>
                <form id="form1" runat="server">
                    <div class="input-group mb-3" id="pnlError" runat="server" visible="false">
                        <h6>
                            <label id="ltrError" runat="server" class="text-danger"></label>
                        </h6>
                    </div>
                    <div class="form-group">
                        <label>Email</label>
                        <input id="txtUserName" type="text" runat="server" class="form-control" placeholder="Enter your user name" />
                    </div>
                    <!-- form-group -->
                    <div class="form-group">
                        <label>Password</label>
                        <input id="txtPassword" type="password" runat="server" class="form-control" placeholder="Enter your password" />
                    </div>
                    <!-- form-group -->

                    <div class="icheck-primary">
                        <input type="checkbox" id="remember" runat="server" checked="checked" />
                        <label for="remember">
                            Remember Me
                        </label>
                    </div>

                    <button id="btnSave" runat="server" onserverclick="btnSave_ServerClick" s class="btn btn-az-primary btn-block">Sign In</button>
                </form>
            </div>
        </div>
    </div>

</body>
</html>
