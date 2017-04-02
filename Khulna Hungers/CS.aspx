<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="CS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Khulna Hungers</title>
      <link href="Button.css" rel="stylesheet" type="text/css"/>
    
    
  <style>
        body{
                    background-image:url('backj/coff.jpg');


        }
     
        .auto-style1 {
            width: 100%
        }
        .auto-style2 {
            width: 100%
        }
        
.tb {
    background: #1A1A1A;
    border-radius: 2em;
    border: none;
    margin: 1em;
    padding: 0.4em;
    
    color: #A2A2A2;
    font-size: 1.1em;
    padding-left: 1.5em;
    
    outline: none;
    box-shadow: 0 3px 5px -5px hsl(0, 0%, 40%), inset 0px 4px 6px -5px hsl(0, 0%, 2%)
}


.center{
    position:absolute;
    height:231px;
    width:595px;
    left:20%;
    top:5%;
    margin-top:10px;
    margin-left:30px;

}
table{
    background-color:#808080;
}
h1 {
    color: #222;
   font: 70px Tahoma, Helvetica, Arial, Sans-Serif;
	text-align: center;
    text-shadow: 0px 2px 3px #555;
}

p {
    color: #222;
   font: 20px Tahoma, Helvetica, Arial, Sans-Serif;
	text-align: center;
    text-shadow: 0px 2px 3px #555;
}
        .auto-style3 {
            width: 375px;
        }
        .auto-style4 {
            width: 100%;
            height: 106px;
        }
        .auto-style5 {
            width: 375px;
            height: 106px;
        }
    </style>

</head>
   

<body >
    <form id="form1" runat="server">

    <div>

        <asp:ScriptManager ID="scriptmanager1" runat="server">

</asp:ScriptManager>

<div>


    <table class="center"  cellpadding="0" cellspacing="0">

    <tr>

        <th colspan="3">

           <h1 > Registration </h1>

        </th>

    </tr>

    <tr>

        <td class="auto-style2">

  <p>          Your          Username  </p>

        </td>

        <td class="auto-style3">

           
           <asp:TextBox ID="txtUsername" runat="server" class="tb" AutoPostBack="true" ontextchanged="txtUsername_TextChanged"/>
      
        </td>

        <td>

<div id="checkusername" runat="server"  Visible="false">

<asp:Label ID="lblStatus" runat="server"></asp:Label>

    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsername" ErrorMessage="Required" />

</div>

</td>


     


    </tr>

             <div id="mb" runat="server"  Visible="false">
    <tr>

        <td class="auto-style2">

            <p> Email </p>

        </td>

        <td class="auto-style3">

              
           <asp:TextBox ID="txtEmail" runat="server" class="tb" AutoPostBack="true" ontextchanged="txtEmail_TextChanged"/>
      

        </td>

      
            <td>
               
<div id="em" runat="server"  Visible="false">

    
<asp:Label ID="Label1" runat="server"></asp:Label>

    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Invalid email address." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />

</div>
                   
</td>
    </tr>
            </div>


    <tr>

        <td class="auto-style4">

            <p> Your Password </p>

        </td>

        <td class="auto-style5">

            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="tb"/>

        </td>

        <td class="auto-style4">

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ErrorMessage="Required" ForeColor="Red" />
        </td>

    </tr>

    <tr>

        <td class="auto-style2">

           <p> Confirm Password </p>

        </td>

        <td class="auto-style3">

            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="tb"/>

        </td>

        <td class="auto-style1">

            <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Passwords do not match." ForeColor="Red" />
        </td>

    </tr>
   
    <tr>
        <div id="button" runat="server"  Visible="false">
        <td class="auto-style2">

          
            &nbsp;</td>

        <td class="auto-style3" >
         
         
            <asp:LinkButton ID="Reg" Text="&lt;span&gt;✓&lt;/span&gt;Signup"   runat="server" class="button orange active" OnClick="RegisterUser"></asp:LinkButton>   
            
        </td>
            </div>
        <td class="auto-style1">

        </td>

    </tr>

</table>
    
</div>
    </div>
    </form>

   
   
</body>
</html>
