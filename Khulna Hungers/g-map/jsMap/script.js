var all_ok = true;

jQuery(document).ready(function(e) {
    $('.loginLink a, input[name=customerCancel]').click(function() {
		$('.customerLoginForm').toggle('fast');
	});
	
	$('.customerUsernameField').blur(function(e) {
        checkUsername();
    });
	$('.checkUsername').click(function(e) {
        checkUsername();
    });
	
	$('.customerEmailField').blur(function(e) {
        checkEmail();
    });
	
	$('#custRegistrationForm').submit(function() {
		all_ok = true;
		checkMendatory();
		checkUsername();
		checkEmail();
		if (all_ok) {
			saveCustomerInfo();
		}
		return false;	
	});
	$('#custLoginForm').submit(function() {
		all_ok = true;
		checkLoginMendatory();
		if (all_ok) {
			loginCustomer();
		}
		return false;	
	});	
	checkLoginStatus();	
});

function cust_logout() {
	var send_val = {'cust_logout' : 'y'};
	var redirect_link = '';
	jQuery.ajax({
					type: "POST",
					async: false,
					dataType: 'json',
					url: './register.php',
					data: send_val,
					success: function(data) {
						if (data != null && data != '') {
							redirect_link = data.redirect != null && data.redirect != '' ? data.redirect : '';
						}
					}
			});
	
	$('.heeaderRight p.custLoginInfo').remove();	
	$('#nav li.reserv').remove();
	$('.loginLink').css({'display' : 'block'});
	if (redirect_link != '') {
		location.href=redirect_link;
	}
	return false;
}

function checkLoginStatus() {
	var send_val = {'check_cust_login_status' : 'y'};
	var login_failed = true;
	var redirect_link ='';
	jQuery.ajax({
					type: "POST",
					async: false,
					dataType: 'json',
					url: './register.php',
					data: send_val,
					success: function(data) {											
						redirect_link = data.redirect != null && data.redirect != '' ? data.redirect : '';
						if (data != null && data != '') {
							if (data.status!= null && data.status!= '') {
								if (data.status == 'ok' && data.msg != 'Login error'){
									login_failed = false;									
									if ($('.heeaderRight p.custLoginInfo').html() == null && $('#nav li.reserv').html() == null) {
										$('.loginLink').css({'display' : 'none'});
										$('.heeaderRight').append('<p class="custLoginInfo"></p>');
										$('.heeaderRight p.custLoginInfo').append(data.msg);
										$('#nav').append('<li class="reserv"></li>');
										$('#nav li.reserv').append(data.menu_item);										
										if (typeof current_file_base != 'undefined' && current_file_base != null && current_file_base == 'reservation.php') {
											if (!($('#nav li.reserv').hasClass('active'))) {
												$('#nav li.reserv').addClass('active')	
											}
										}
									}
								}
							}						
						}
					}
			});
	if (login_failed) {
		$('.heeaderRight p.custLoginInfo').remove();
		$('#nav li.reserv').remove();
		$('.loginLink').css({'display' : 'block'});		
		if (redirect_link != '') {
			location.href=redirect_link;
		}
	}
	window.setTimeout('checkLoginStatus()', 5000);
}
function saveCustomerInfo() {
	var tmp = '"save_cust_info" : "y"';
	jQuery.each($('#custRegistrationForm').serializeArray(),function(i,v) {
		tmp += ', "' + v.name + '" : "' + v.value + '"';
	});
	var send_val = eval('({'+tmp+'})');
	var checking_response_text = '';
	checking_response_text = jQuery.ajax({
										type: "POST",
										async: false,
										url: './register.php',
										data: send_val,
										success: function(data) {																
										}
								}).responseText;
	if (checking_response_text != '') {
		$('.custregFormMsg').html(checking_response_text);	
		$('.custregFormMsg').css({'display' : 'block'});
		jQuery('#custRegistrationForm')[0].reset();
	} else {
		$('.custregFormMsg').html('');	
		$('.custregFormMsg').css({'display' : 'none'});
	}
}

function loginCustomer() {
	var tmp = '"login_cust" : "y"';
	jQuery.each($('#custLoginForm').serializeArray(),function(i,v) {
		tmp += ', "' + v.name + '" : "' + v.value + '"';
	});
	var send_val = eval('({'+tmp+'})');
	var checking_response_text = '';
	var err_message = 'Login error';
	jQuery.ajax({
					type: "POST",
					async: false,
					dataType: 'json',
					url: './register.php',
					data: send_val,
					success: function(data) {
						if (data != null && data != '') {
							if (data.status!= null && data.status!= '') {
								if (data.status == 'err') {
									err_message = data.msg != null && data.msg != '' ? data.msg : err_message;
								} else if (data.status == 'ok'){
									if (!$('#remember').is(":checked")) $('#custLoginForm')[0].reset();
									$('.loginLink').css({'display' : 'none'});
									$('.customerLoginForm').hide('fast');
									$('.heeaderRight').append('<p class="custLoginInfo"></p>');
									$('.heeaderRight p.custLoginInfo').append(data.msg);
									$('#nav').append('<li class="reserv"></li>');
									$('#nav li.reserv').append(data.menu_item);
									$('.errCustomerLogin').css({'display' : 'none'});
									err_message = '';
								}
							}							
						}
					}
			});
			
	if (err_message != '') {
		$('.errCustomerLogin').html(err_message);
		$('.errCustomerLogin').css({'display' : 'block'});		
	} else {
		$('.errCustomerLogin').html('');
		$('.errCustomerLogin').css({'display' : 'none'});
	}
}

function checkMendatory(){
	if ($('#customer_name').val() != '' && $('#customer_name').val() != null) {
		$('.errCustomerName').html('');
		$('.errCustomerName').css({'display' : 'none'});
	} else {
		$('.errCustomerName').html('Enter name');
		$('.errCustomerName').css({'display' : 'block'});
		all_ok = false;
	}
	
	if ($('#customer_phone').val() != '' && $('#customer_phone').val() != null) {
		$('.errCustomerPhone').html('');
		$('.errCustomerPhone').css({'display' : 'none'});
	} else {
		$('.errCustomerPhone').html('Enter phone');
		$('.errCustomerPhone').css({'display' : 'block'});
		all_ok = false;
	}
	
	if ($('#customer_password').val() != '' && $('#customer_password').val() != null) {
		$('.errCustomerPass').html('');
		$('.errCustomerPass').css({'display' : 'none'});
	} else {
		$('.errCustomerPass').html('Enter password');
		$('.errCustomerPass').css({'display' : 'block'});
		all_ok = false;
	}
}

function checkLoginMendatory(){	
	if ($('#username').val() != '' && $('#username').val() != null) {
		$('.errUserName').html('');
		$('.errUserName').css({'display' : 'none'});
	} else {
		$('.errUserName').html('Enter username');
		$('.errUserName').css({'display' : 'block'});
		all_ok = false;
	}
	
	if ($('#password').val() != '' && $('#password').val() != null) {
		$('.errUserPass').html('');
		$('.errUserPass').css({'display' : 'none'});
	} else {
		$('.errUserPass').html('Enter password');
		$('.errUserPass').css({'display' : 'block'});
		all_ok = false;
	}
}

function checkUsername() {
	var username = $('.customerUsernameField').val();
	var err_message = 'Enter username';
	var possible_username = '';
	if (username != '') {
		var send_val = {'check_customer_username':username}		
		jQuery.ajax({
					type: "POST",
					async: false,
					dataType: 'json',
					url: './register.php',
					data: send_val,
					success: function(data) {											
						//console.log(data);
						if (data != null && data != '') {
							$.each(data, function(i, v){
								if (v == 'ok') {
									err_message = '';
									 return 0;
								}
								err_message = 'This username already exists';
								possible_username += (possible_username != '' ? '<br />' : '') + v;
							});
						} else {
							err_message = '';
						}
					}
			});
	}
	if (err_message != '') {
		$('.errCustomerUsername').html(err_message);
		$('.errCustomerUsername').css({'display' : 'block'});
		if (possible_username != '') {
			$('.possibleUsernames').html('<span style="color: #424242;">You can try any of these:</span> <br />' + possible_username);
			$('.possibleUsernames').css({'display' : 'block'});
		}
		all_ok = false;
	} else {
		$('.errCustomerUsername').html('');
		$('.errCustomerUsername').css({'display' : 'none'});
		
		$('.possibleUsernames').html('');
		$('.possibleUsernames').css({'display' : 'none'});
	}
}
function checkEmail() {
	var email = $('.customerEmailField').val();
	var result = false;    
	var filter=/^.+@.+\..{2,3}$/	
	if (filter.test(email))
		result=true
	var checking_response_text = '';
	var err_message = 'Invalid email address';
	if (result) {
		var send_val = {'check_customer_email':email}
		checking_response_text = jQuery.ajax({
									type: "POST",
									async: false,
									url: './register.php',
									data: send_val,
									success: function(data) {																
									}
							}).responseText;
		if (checking_response_text != '' && checking_response_text == 'exist') {
			err_message = 'This eamil address is already exist.';
		} else {
			err_message = '';
		}
	} 
	
	if (err_message != '') {
		$('.errCustomerEmail').html(err_message);
		$('.errCustomerEmail').css({'display' : 'block'});
		all_ok = false;
	} else {
		$('.errCustomerEmail').html('');
		$('.errCustomerEmail').css({'display' : 'none'});
	}
}