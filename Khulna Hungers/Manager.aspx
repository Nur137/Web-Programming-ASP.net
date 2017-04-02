<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager.aspx.cs" Inherits="Manager" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Admin Panel</title>
	<meta charset="utf-8">
<link href="Style.css" rel="stylesheet" type="text/css">
 
    <style>
        body{
            background-color:black;
        }
        </style>
    <script type = "text/javascript">
        function SetContextKey() {
            $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=dds.ClientID %>").value);
        }
        
</script>

	</head>
<body class="index">
<!--==============================header=================================-->
<div class="top"><font color="White" font-family="Cursive"size=15px ><br>Admin Page
</font>
</div>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
            <div>
       <font Size="5px" color="yellow"> Shop Upload</font><br>
           <hr />
           <font Size="3px" color="red"> Shop Name</font>
       
        <asp:TextBox ID="sh" runat="server"></asp:TextBox>
        <font Size="3px" color="red"> Browse</font>
       <asp:FileUpload ID="FS" runat="server" />
        
        </br>
        <asp:Button id="shopup" Text="Upload Shop" OnClick="ShopUp" runat="server" />
                <hr />

        </br>
        </br>
                  <font Size="5px" color="yellow"> Food Upload</font><br>
           <hr />
        
        
              <font Size="3px" color="red"> Food Name</font>
        <asp:TextBox ID="txtCity" Text="Search" runat="server" onkeyup = "SetContextKey()"></asp:TextBox>
    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCity" UseContextKey = "true"
         MinimumPrefixLength="0" EnableCaching="false" CompletionSetCount="10" CompletionInterval="100"
         ServiceMethod="GetCity" >
    </asp:AutoCompleteExtender>
     
                
              <font Size="3px" color="red"> Shop Name</font>
       
                <asp:DropDownList ID="dds" runat="server" AppendDataBoundItems="true" AutoPostBack = "true" OnSelectedIndexChanged = "FetchShop">
            
    <asp:ListItem Text="Select Shop" Value="0" />
</asp:DropDownList>
                <font Size="3px" color="red"> Browse</font>
         
        <asp:FileUpload ID="FU" runat="server" /></br>
        <asp:Button ID="Button1" runat="server" OnClick="Upfood" Text="Upload Food" />
    
        
    </div>
        </br>
        </br>
                  <font Size="5px" color="yellow"> Location Upload</font><br>
           <hr />
       
                    <font Size="3px" color="red"> Shop Name</font>
   
        <asp:TextBox ID="Shop" runat="server"></asp:TextBox>
                <font Size="3px" color="red"> Longitude</font>
    
        <asp:TextBox ID="Long" runat="server"></asp:TextBox>
                <font Size="3px" color="red"> Latitude</font>
    
            Latitude
        <asp:TextBox ID="Lat" runat="server"></asp:TextBox>
        <asp:Button ID="SubShop" runat="server" Text="Button" OnClick="SubShop_Click" />
        <p>
             </br>
        </br>
                  <font Size="5px" color="yellow"> Test Image</font><br>
           <hr />
       
<asp:Image ID="Image1" runat="server" width="200px" height="200px"/>
        </p>
    </form>
</body>
</html>

