<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admlog.aspx.cs" Inherits="admlog" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Homepage</title>
	<meta charset="utf-8">
	<meta name = "format-detection" content = "telephone=no" />
	<link rel="icon" href="images/favicon.ico" type="image/x-icon">
	<link rel="stylesheet" href="css/grid.css">
	<link rel="stylesheet" href="css/style.css">
	<link rel="stylesheet" href="css/camera.css">
	<link rel="stylesheet" href="css/owl.carousel.css">

	<script src="js/jquery.js"></script>
	<script src="js/jquery-migrate-1.2.1.js"></script>
	<script src='js/camera.js'></script>
	<script src="js/owl.carousel.js"></script>
	<script src="js/jquery.stellar.js"></script>
	<script src="js/script.js"></script>
	<!--[if (gt IE 9)|!(IE)]><!-->
	<script src="js/jquery.mobile.customized.min.js"></script>
	<script src="js/wow.js"></script>
	<script>
	    $(document).ready(function () {
	        if ($('html').hasClass('desktop')) {
	            new WOW().init();
	        }
	    });
	</script>
	<!--<![endif]-->
	<!--[if lt IE 8]>
	<div style=' clear: both; text-align:center; position: relative;'>
	 <a href="http://windows.microsoft.com/en-US/internet-explorer/products/ie/home?ocid=ie6_countdown_bannercode">
		 <img src="images/ie8-panel/warning_bar_0000_us.jpg" border="0" height="42" width="820" alt="You are using an outdated browser. For a faster, safer browsing experience, upgrade for free today." />
	 </a>
	</div>
	<![endif]-->
	<!--[if lt IE 9]>
		<script src="js/html5shiv.js"></script>
		<link rel="stylesheet" type="text/css" media="screen" href="css/ie.css">
	<![endif]-->
	</head>
<body class="index">
<!--==============================header=================================-->
<header id="header">
	<div id="stuck_container">
		<div class="container">
			<div class="row">
				<div class="grid_12">
					<h1><a href="index.html">Admin</a><span>Login</span></h1>
					
				</div>
			</div>
		</div>
	</div>
</header>



    <div>
    <form id="form1" runat="server">
    <div style="font-weight: 700; font-size: xx-large; text-align: center">
    
        Login Page</div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">User Name</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxUN" runat="server" ></asp:TextBox>
&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxUN" ErrorMessage="Please Enter Username"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Password</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxPass" runat="server"  TextMode="Password"></asp:TextBox>
&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="ButtonLog" runat="server" OnClick="ButtonLog_Click" Text="Login" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>.
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style4">
                    <asp:CheckBox ID="RM" runat="server" Text="Remember Me" />
                </td>
                
                <td class="auto-style4"></td>
            </tr>
        </table>
    </form>
        </div>
</body>
</html>
