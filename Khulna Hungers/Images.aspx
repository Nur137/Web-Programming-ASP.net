<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Images.aspx.cs" Inherits="Images" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AJAX AutoComplete</title>
</head>
<body>
    <form id="form1" runat="server">  
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>   
    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCity"
         MinimumPrefixLength="0" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
         ServiceMethod="GetCity" >
    </asp:AutoCompleteExtender>
    </div>
        <asp:Image ID="Image1" runat="server" />
        <div>
         <asp:Button ID="Upload" runat="server" OnClick="FetchImage" Text="Upload" />
            </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RstConnectionString %>" SelectCommand="SELECT [UserId], [Comment] FROM [Comm] WHERE ([ImageId] = @ImageId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtCity" Name="ImageId" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:ListBox ID="ListBox2" runat="server" DataSourceID="SqlDataSource2" DataTextField="Propic" DataValueField="Username">
            <asp:ListItem></asp:ListItem>
        </asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RstConnectionString %>" SelectCommand="SELECT * FROM [profpicture]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource3" EnableModelValidation="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:ImageField DataImageUrlField="Propic" HeaderText="Image">
                </asp:ImageField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RstConnectionString %>" SelectCommand="SELECT * FROM [profpicture]"></asp:SqlDataSource>
    </form>
</body>
</html>
