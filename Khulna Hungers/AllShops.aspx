<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllShops.aspx.cs" Inherits="AllShops" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap.min.css"/>
    <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap-social"/>
   
    <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap-theme.min"/>
   <link href="allshop.css" rel="stylesheet" type="text/css"/>
      <style>
        body{
                    background-image:url('backj/sh.jpg');


        }
          </style>
</head>

    

      <body >
  <form runat="server">
      
   
      <div class="up">
          <font Size="30px" Color="Red">
          Shops Review  
          </font>
          </div>

      
                  <asp:DropDownList ID="dds" runat="server" OnSelectedIndexChanged = "FetchShop" AppendDataBoundItems="true" AutoPostBack = "true" class="dlist">
            
    <asp:ListItem Text="Select Shop" Value="0" />

</asp:DropDownList> 
                         
                 
                
                
    


      <div class="image">
          <asp:Image ID="shpimage" runat="server"    Height="300px" Width="300px"/>
          </div>
     <font color="Yellow">
       <div class="image1">
                    <asp:Image ID="Image1" runat="server" Height="150px" Width="120px" ImageUrl="~/5st.jpg"/>
          </div>
       <div class="l1">
       <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
         </div>
           <div class="l2">
       <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
         </div>
           <div class="l3">
       <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
         </div>
           <div class="l4">
       <asp:Label ID="Label4" runat="server" Text="0"></asp:Label>
         </div>
           <div class="l5">
       <asp:Label ID="Label5" runat="server" Text="0"></asp:Label>
         </div>
         </font>
      <div class="but">
      <asp:Button ID="Button1" runat="server" Text="Feedbacks" OnClick="Button1_Click" />
      </div>
        
      
        <div class="comment">

            <div style="background-color:#082600; margin-left:100px; margin-right:100px;">
                <div style="margin-left:200px; margin-top:30px;">    
                <asp:PlaceHolder ID="placeholder1" runat="server">            
                    </asp:PlaceHolder>
                </div>
                
                </div>
    </div>
         
  </form>
  
</body>
</html>
