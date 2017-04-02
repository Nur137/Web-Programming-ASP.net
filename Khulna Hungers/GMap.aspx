<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GMap.aspx.cs" Inherits="GMap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="cssMap/bootstrap.min.css">
	<link rel="stylesheet" href="cssMap/bootstrap-theme.min.css">
	<link rel="stylesheet" href="cssMap/font-awesome.min.css">
	<link rel="stylesheet" type="text/css" href="cssMap/smoothness/jquery-ui-1.8.16.custom.css" />

	<link href="cssMap/style.css" media="all" rel="stylesheet" type="text/css"/>

	<script src="http://maps.google.com/maps/api/js?sensor=true"></script>
	<script src="jsMap/gmaps.js"></script>
	<script src="jsMap/jquery-2.1.4.min.js" type="text/javascript"></script>
	<script src="jsMap/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
	<script type="text/javascript" src="jsMap/jquery-ui-1.8.16.custom.min.js"></script>
	<script type="text/javascript" src="jsMap/sub-menu-script.js"></script>
	<script src="jsMap/bootstrap.min.js" type="text/javascript"></script>
	<script type="text/javascript" src="jsMap/script.js"></script>
</head>
<body>
    <form runat="server">
    <div class="continer">
    	<p>Our restaurant at Google Map</p>
		     <asp:TextBox ID="T1" runat="server" Text="24.5"></asp:TextBox>
            <asp:TextBox ID="T2" runat="server" Text="90.8"></asp:TextBox>

            <button id="Button1" type="button" onclick="myFunction()">Submit</button>
           
          
            <asp:DropDownList ID="dds" runat="server" AppendDataBoundItems="true" AutoPostBack = "true" OnSelectedIndexChanged = "FetchShop">
                    <asp:ListItem Text="Select Shop" Value="0" />
</asp:DropDownList> 

           
          
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

           
          
            <div>
            <div id="google-map"> 
            
			</div>
    </div>
      </div>  
            </form>
    
</body>
</html>


	<script>
	    //for google map
	  
	    
	    function myFunction() {
	        var x;
	        var y;
	        x = document.getElementById('<%=this.T1.ClientID%>').value;
	        y = document.getElementById('<%=this.T2.ClientID%>').value;


	        $(document).ready(function () {
	            map = new GMaps({
	                el: '#google-map',
	                lat: x,
	                lng: y,
	                scrollwheel: true
	            });
	            map.addMarker({
	                lat: x,
	                lng: y,
	                title: 'Lima',
	                details: {
	                    database_id: 42,
	                    author: 'HPNeo'
	                },
	                click: function (e) {
	                    if (console.log)
	                        console.log(e);
	                    alert('You clicked in this marker');
	                },
	                mouseover: function (e) {
	                    if (console.log)
	                        console.log(e);
	                }
	            });
	            map.addMarker({
	                lat: x,
	                lng: y,
	                title: 'Marker with InfoWindow',
	                infoWindow: {
	                    content: '<p>HTML Content</p>'
	                }
	            });
	        });
	    }
		</script>