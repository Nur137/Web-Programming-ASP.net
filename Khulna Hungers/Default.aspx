<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Homepage</title>
	  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link href="Style.css" rel="stylesheet" type="text/css">
  <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap.min.css">
  <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap-social">
  <link rel="stylesheet" href="Bootstrap(CSS)/bootstrap-theme.min">
  <link rel="stylesheet" type="text/css" href="engine1/style.css" />
  <link rel="shortcut icon" href="../favicon.ico"> 
  <link rel="stylesheet" type="text/css" href="css2/demo.css" />
  <link rel="stylesheet" type="text/css" href="css2/style.css" />
  <link rel="stylesheet" type="text/css" href="css2/animate-custom.css" />

    <style>
        body{
                    background-image:url('myback.jpg');


        }
        </style>

    <script type="text/javascript" src="engine1/jquery.js"></script>
  <script src="Bootstrap(JS)/jquery-2.1.4.min.js"></script>
  <script src="Bootstrap(JS)/bootstrap.min.js"></script>
  <script type="text/javascript" src="engine1/wowslider.js"></script>
  <script type="text/javascript" src="engine1/script.js"></script>

	</head>
<body >
<!--==============================header=================================-->
    
                          <form   runat="server" > 
      
    <header>
<div class="top"><font color="White" font-family="Cursive"size=15px ><br>Khulna Hungers
</font>
</div>


        <nav class="navbar navbar-inverse" >
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">Homepage</a>
    </div>
    <div>
      <ul class="nav navbar-nav" >
       
     <li><a href="AllFoods.aspx">Foods</a></li>
        <li><a href="AllShops.aspx">Shops</a></li>
        <li><a href="GMap.aspx">Locations</a></li>
       <li><a href="admlog.aspx">Admin Login</a></li>
          
        <li><a href="#"  data-toggle="modal" data-target="#myModal">Login</a></li>
          <li><a href="CS.aspx">Register</a></li>
          
  
  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Login</h4>
        </div>
        <div class="modal-body">
          <div class="container">
            <section>				
              
                   
                    <a class="hiddenanchor" id="tologin"></a>
                    <div id="wrapper">
                        <div id="login" class="animate form">
                                <h1>Log in</h1> 
                                <p class="uname"> 
                                    <label for="username"  data-icon="u" > Your Username 
                                  
                                    <asp:TextBox ID="TextBoxUN" runat="server" data-icon="u " name="username" required="required" type="text" placeholder="  Enter your username"> </asp:TextBox>
                                </label></p>
                                <p> 
                                    <label for="password" class="youpasswd" data-icon="p "> Your Password 
                                    &nbsp &nbsp<asp:TextBox ID="TextBoxPass" runat="server" required="required" TextMode="password" placeholder="   eg. X8df!90EO" /> 
                                </label></p>
                                <p class="keeplogin"> 
									<input type="checkbox" name="loginkeeping" id="loginkeeping" value="loginkeeping" /> 
									<label for="loginkeeping">Keep me logged in</label>
								</p>
                                <p class="login button">
                                <asp:Button ID="Button1" OnClick="L" runat="server" Text="Login" />
                                </p>
                                    
								
                                
                      
                        </div>

                      
            </section>
        </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
  

          <%--modal--%>
      </ul>
    </div>
  </div>
</nav>






        </header>



                               <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

                              
                              
                                <asp:UpdatePanel ID="UpdatePanel1"  runat="server" >
        <ContentTemplate>

                               <div class="fd">
                                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" >
            </asp:Timer>                 
                                   
                                   <asp:Image ID="Image1" runat="server"  height="300px" Width="400px"  />
                                   
                                <!--
                                         <br />
            Name: <asp:Label ID="lblImageName" class="" runat="server"></asp:Label>
            <br />
            Order: <asp:Label ID="lblImageOrder" runat="server"></asp:Label>
            <br />
                                   Shop Name: <asp:Label ID="Label1" runat="server" Text="Pizza Bazar" OnLoad="FetchShop"></asp:Label>
            <br />
                                    -->

                               </div>   
           <div class="fd">

               </div>
        
                                <div class="shp">
                                       
                                 
                                   <asp:Image ID="Image2" runat="server"  height="300px" Width="400px"  />
                                   
                                
                                   <br />
            

                               </div>   
            <div class="fdlabel">
                <font size="8px" color="white" >Foods </font>
            </div>
            <div class="splabel">
                <font size="8px" color="white" >Shops </font>


           </div>
                              </ContentTemplate>
                                    </asp:UpdatePanel>
                            	
         <footer class="footer">
             <div class="container">
                 <p class="text-muted text-center">&copy; 2016 Nur Imtiazul Haque All Rights Reserved.</p>
                 </div>
             </footer>                  
    </form> 
  

<footer >



</footer >

</body>
</html>
