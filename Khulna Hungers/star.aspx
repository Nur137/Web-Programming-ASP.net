
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="star.aspx.cs" Inherits="star" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>  
  
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  
  
<!DOCTYPE html>  
<script runat="server">  
    
</script>  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head id="Head1" runat="server">  
    <title>Ajax Rating - How to use OnChanged event in asp.net Rating</title>  
    <style type="text/css">  
        .StarCss {   
            background-image:  url(images.png);  
            height:24px;  
            width:24px;  
        }  
        body{
            background-color:white;
        }
        .FilledStarCss {  
            background-image: url(images.png);  
            height:24px;  
            width:24px;  
        }  
        .EmptyStarCss {  
            background-image: url(/Image/images.png);  
            height:24px;  
            width:24px;  
        }  
        .WaitingStarCss {  
            background-image: url(images.png);  
            height:24px;  
            width:24px;  
        }  
    </style>  
 </head>  
<body>  
    <form id="form1" runat="server" aria-orientation="vertical">  
    <div>  
        <h2 style="color:DarkBlue; font-style:italic;">  
            ASP.NET Ajax Rating - How to use OnChanged  
            <br /> event in asp.net Rating  
        </h2>  
        <hr width="500" align="left" color="LightBlue" />  
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">  
        </asp:ToolkitScriptManager>  
        
        <table border="0" cellpadding="4" cellspacing="4">  
            <tr>  
                <td>  
                    <asp:Image   
                        ID="Image1"  
                        runat="server"  
                        ImageUrl="black.jpg"  
                        Height="250"  
                        />  
                </td>  
                <td>  
                    <asp:Label   
                        ID="Label1"  
                        runat="server"  
                        Font-Size="X-Large"  
                        Font-Italic="true"  
                        Font-Names="Comic Sans MS"  
                        >  
                    </asp:Label>  
                    <br /><br />  
                    <asp:Label   
                        ID="Label2"  
                        runat="server"  
                        ForeColor="SandyBrown"  
                        Font-Size="Large"  
                        Text="Rate this image"  
                        >  
                    </asp:Label>  
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
                        >  
                    </asp:Rating>  
                     </td>  
            </tr>  
        </table>  
    </div>  

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RstConnectionString %>" SelectCommand="SELECT [Star] FROM [Rates]"></asp:SqlDataSource>

    </form>  
</body>  
</html>  