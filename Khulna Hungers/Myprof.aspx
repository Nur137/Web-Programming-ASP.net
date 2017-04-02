<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Myprof.aspx.cs" Inherits="Myprof" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Prof.css" rel="stylesheet" type="text/css"/>
    <link href="Style.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap.min.css"/>
    <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap-social"/>
    <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap-theme.min"/>
  <style>
      body
    {
          background-color:black;
      
    }
      </style>
            <script type = "text/javascript">
                function SetContextKey() {
                    $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=dds.ClientID %>").value);
                }
</script>

</head>
      <body >
  
         <form runat="server">
               <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   

       <asp:Image ID="Image1" runat="server" class="ppic" />
  <div id="TOP" class="up">
            
           <font color="White" font-family="Cursive"size=15px > 
      <asp:Label ID="Label1" runat="server" Text="Welcome X" > </asp:Label> </br>
      <asp:Label ID="Label2" runat="server" Text="Here is your profile"></asp:Label>
        </font>
  </div>
             

             

             <div class="nv">
                  
                  <asp:FileUpload ID="FU" runat="server" />
                 <asp:Button ID="propicup"  runat="server" Text="Upload" OnClick="propicup_Click" />
                 <asp:Button ID="HyperLink1" runat="server" Text="Logout" OnClick="Logout"></asp:Button>
        
                 
           </div>
     
      <div class="ddlist">
                  <asp:DropDownList ID="dds" runat="server" CssClass="dlist" AppendDataBoundItems="true" AutoPostBack = "true" OnSelectedIndexChanged = "FetchShop">
            
    <asp:ListItem Text="Select Shop" Value="0" />
</asp:DropDownList> 
          </div>    
                
             <div class="searchbar">
                 
                <asp:TextBox ID="txtCity" Text="Search" class="sbox" runat="server" onkeyup = "SetContextKey()" OnTextChanged="txtCity_TextChanged"></asp:TextBox>
    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCity"
         MinimumPrefixLength="0" EnableCaching="false" UseContextKey = "true" CompletionSetCount="1" CompletionInterval="100"
         ServiceMethod="GetCity" >
 </asp:AutoCompleteExtender>    
                 <asp:Button ID="Button1" runat="server"  OnClick="Button1_Click" Text="Button" />
    
             </div>
                
             
                          
                     

                     
    
                  
    

             

     
             <p>
                 &nbsp;</p>
              

             <div id="x" class="conleft">
                 <asp:Image ID="fdimage" runat="server" Width="200px" Height="200px"/>

                
             </div>


  <div class="stfood">
                   <table border="0" cellpadding="4" cellspacing="4">  
            <tr>  
                <td>  
                    &nbsp;</td>  
                <td>  
                    <asp:Label   
                        ID="Label6"  
                        runat="server"  
                        Font-Size="X-Large"  
                        Font-Italic="true"  
                        Font-Names="Comic Sans MS"  
                        > </asp:Label>  
                    <br /><br />  
                    <asp:Label   
                        ID="Label7"  
                        runat="server"  
                        ForeColor="SandyBrown"  
                        Font-Size="Large"  
                        Text="Rate this image"  
                        > </asp:Label>  
                    <br />  
                    <asp:Rating   
                        ID="Rating1"  
                        runat="server"  
                        StarCssClass="StarCss"  
                        FilledStarCssClass="FilledStarCss"  
                        EmptyStarCssClass="EmptyStarCss"  
                        WaitingStarCssClass="WaitingStarCss"  
                        AutoPostBack="true"  
                        OnChanged="Rating1_Changed"  
                        Visible="false"
                        >
                        
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Rating>  
                     <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                     
                </td>  
            </tr>
                         
        </table>  

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RstConnectionString %>" SelectCommand="SELECT [Star] FROM [Rates]"></asp:SqlDataSource>

     
     
      </div>
             
             
                                <div class="conright">
                         <asp:Image ID="shpimage" runat="server" Width="200px" Height="200px"/>
                     
                      


             
                        
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RstConnectionString %>" SelectCommand="SELECT [Star] FROM [Rates]"></asp:SqlDataSource>

             </div>

             <div class="stshop">
                  <table border="0" cellpadding="4" cellspacing="4">  
            <tr>  
                <td>  
                    &nbsp;</td>  
                <td>  
                    <asp:Label   
                        ID="Label4"  
                        runat="server"  
                        Font-Size="X-Large"  
                        Font-Italic="true"  
                        Font-Names="Comic Sans MS"  
                        > </asp:Label>  
                    <br />&nbsp  
                    <asp:Label   
                        ID="Label5"  
                        runat="server"  
                        ForeColor="SandyBrown"  
                        Font-Size="Large"  
                        Text="Rate this image"  
                        > </asp:Label>
                  
                    <br />  
                    <asp:Rating   
                        ID="Rating2"  
                        runat="server"  
                        StarCssClass="StarCss"  
                        FilledStarCssClass="FilledStarCss"  
                        EmptyStarCssClass="EmptyStarCss"  
                        WaitingStarCssClass="WaitingStarCss"  
                        AutoPostBack="true"  
                        OnChanged="Rating2_Changed"  
                        Visible="false"
                        >  
                    &nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Rating>  
                     </td>  
            </tr>  
        </table>  
                  <asp:Label ID="Labelsh" runat="server" Text="You Rated: " Visible="false"></asp:Label>
                 </div>
             
          <!--     <div class="Commfd">
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" EnableModelValidation="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                       <Columns>
                           <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                           <asp:ImageField DataImageUrlField="directory" ItemStyle-Width="50px" ItemStyle-Height="40px">
<ItemStyle Height="40px" Width="50px"></ItemStyle>
                           </asp:ImageField>
                       </Columns>
                       <FooterStyle BackColor="White" ForeColor="#333333" />
                       <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                       <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                       <RowStyle BackColor="White" ForeColor="#333333" />
                       <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                   </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RstConnectionString %>" SelectCommand="SELECT [Username], [directory] FROM [profpicture]"></asp:SqlDataSource>
                 </div>

          
               <div class="Commsp">
                   <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" EnableModelValidation="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                       <Columns>
                           <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                           <asp:ImageField DataImageUrlField="directory" ItemStyle-Width="50px" ItemStyle-Height="40px">
<ItemStyle Height="40px" Width="50px"></ItemStyle>
                           </asp:ImageField>
                       </Columns>
                       <FooterStyle BackColor="White" ForeColor="#333333" />
                       <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                       <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                       <RowStyle BackColor="White" ForeColor="#333333" />
                       <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                   </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RstConnectionString %>" SelectCommand="SELECT [Username], [directory] FROM [profpicture]"></asp:SqlDataSource>
                 </div>
             -->
           <div class="q">
               <asp:TextBox ID="TextBoxfd" runat="server" class="sbox" Width="500px" Height="60px"></asp:TextBox>
               </br><asp:Button ID="Buttonfd" runat="server" Text="Comment Now" OnClick="Bfd"/>
               </div>
             <div class="boxsp">
                 <asp:TextBox ID="TextBoxshp" runat="server" class="sbox"  Width="500px" Height="60px"></asp:TextBox>
                 </br><asp:Button ID="Buttonshp" runat="server" Text="Comment Now" OnClick="Bshp" />
                
                 </div>

              <div class="cl">
                 <font color="White" Size="5px"><asp:Label ID="feedfd" runat="server" Text="Provide A Feedback"></asp:Label></font></div>

               <div class="cr">
                 <font color="White" Size="5px"><asp:Label ID="feedshp" runat="server" Text="Provide A Feedback"></asp:Label></font>

                  
               </div>
             
             <div class="line">
                 </div>


                       
             </form>
      
    


</body>
</html>

