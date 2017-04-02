<%@ Page Language="C#" AutoEventWireup="true" CodeFile="show.aspx.cs" Inherits="show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RstConnectionString %>" SelectCommand="SELECT * FROM [login2]"></asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableModelValidation="True">
            <Columns>
                
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="Confirm" HeaderText="Confirm" SortExpression="Confirm" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
