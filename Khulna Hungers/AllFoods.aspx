<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllFoods.aspx.cs" Inherits="AllFoods" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap.min.css"/>
    <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap-social"/>
    <link href="allfood.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap-theme.min"/>
      <style>
        body{
                    background-image:url('backj/sh.jpg');


        }
          </style>
</head>

     <script type = "text/javascript">
         function SetContextKey() {
             $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=dds.ClientID %>").value);
                }
</script>
      <body >
  <form runat="server">
   
      <div class="up">
          <font Size="30px" Color="white">
          Foods Review  
          </font>
          </div>

      
                  <asp:DropDownList ID="dds" runat="server" AppendDataBoundItems="true" AutoPostBack = "true" class="dlist">
            
    <asp:ListItem Text="Select Shop" Value="0" />

</asp:DropDownList> 
                         <div class="searchbar">
                             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:TextBox ID="txtCity" Text="Search" class="sbox" runat="server" onkeyup = "SetContextKey()" ></asp:TextBox>
    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCity"
         MinimumPrefixLength="0" EnableCaching="false" UseContextKey = "true" CompletionSetCount="1" CompletionInterval="100"
         ServiceMethod="GetCity" >
 </asp:AutoCompleteExtender>    
                 <asp:Button ID="Button1" runat="server"  OnClick="Button1_Click" Text="Feedbacks" />

    
             </div>
      <div class="rat">
          <font Size="30px" Color="white">
          Ratings  
          </font>
          
          </div>
      
      <div class="image">
          <asp:Image ID="fdimage" runat="server"    Height="300px" Width="300px"/>
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
