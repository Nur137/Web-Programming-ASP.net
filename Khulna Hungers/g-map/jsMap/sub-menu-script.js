	var is_main_dish_submenu_open = false;
	var is_main_dish_submenu_hover = false;
	
	var is_food_menu_submenu_open = false;
	var is_food_menu_submenu_hover = false;

	
jQuery(document).ready(function(){

	$(".main_dish_link").mouseenter(function(){
		$(".main_dish_submenu").animate({
																		'filter':'alpha(opacity=75)',
																		'opacity': '0.75'																
																		}, 300, function(){																							
																							$(".main_dish_submenu").css("display","block");
																								if(is_food_menu_submenu_open){
																										$(".food_menu_submenu").animate({
																																										'filter':'alpha(opacity=0)',
																																										'opacity': '0'																
																																										}, 300, function(){																																														
																																														$(".food_menu_submenu").css("display","none");
																																														});
																									is_food_menu_submenu_open = false;
																									is_food_menu_submenu_hover = false;
																								}
																							});
		is_main_dish_submenu_open = true;
		is_main_dish_submenu_hover = false;
		
		
		
	});
	
	$(".main_dish_link").mouseleave(function(){																				 
		window.setTimeout("close_main_dish_submenu()", 500);
	});
	
	$(".main_dish_submenu").mouseenter(function(){																						
		if(!is_main_dish_submenu_open){
			$(".main_dish_submenu").animate({
																			'filter':'alpha(opacity=75)',
																			'opacity': '0.75'																		
																			}, 300, function(){																							
																							$(".main_dish_submenu").css("display","block");
																							});
		}
		is_main_dish_submenu_open = true;
		is_main_dish_submenu_hover = true;
		
	});
	
	
		$(".main_dish_submenu").mouseleave(function(){			
			$(".main_dish_submenu").animate({
																			'filter':'alpha(opacity=0)',
																			'opacity': '0'																	
																			}, 300, function(){
																							
																							$(".main_dish_submenu").css("display","none");
																							});
			is_main_dish_submenu_open = true;
			is_main_dish_submenu_hover = false;
		});
		
		
		/***************************************food menu*************************/
		$(".food_menu_link").mouseenter(function(){
		$(".food_menu_submenu").animate({
																		'filter':'alpha(opacity=75)',
																		'opacity': '0.75'																
																		}, 300, function(){																							
																							$(".food_menu_submenu").css("display","block");
																							});
		is_food_menu_submenu_open = true;
		is_food_menu_submenu_hover = false;
		
	});
	
	$(".food_menu_link").mouseleave(function(){																				 
		window.setTimeout("close_food_menu_submenu()", 500);
	});
	
	$(".food_menu_submenu").mouseenter(function(){																						
		if(!is_food_menu_submenu_open){
			$(".food_menu_submenu").animate({
																			'filter':'alpha(opacity=75)',
																			'opacity': '0.75'																
																			}, 300, function(){																							
																							$(".food_menu_submenu").css("display","block");
																							if(is_main_dish_submenu_open){
																								$(".main_dish_submenu").animate({
																																								'filter':'alpha(opacity=0)',
																																								'opacity': '0'																	
																																								}, 300, function(){
																																												
																																												$(".main_dish_submenu").css("display","none");
																																												});
																								is_main_dish_submenu_open = false;
																								is_main_dish_submenu_hover = false;
																							}
																							});
		}
		is_food_menu_submenu_open = true;
		is_food_menu_submenu_hover = true;
		
		
		
	});
	
	
		$(".food_menu_submenu").mouseleave(function(){			
			$(".food_menu_submenu").animate({
																			'filter':'alpha(opacity=0)',
																			'opacity': '0'															
																			}, 300, function(){
																							
																							$(".food_menu_submenu").css("display","none");
																							});
			is_food_menu_submenu_open = true;
			is_food_menu_submenu_hover = false;
		});
		/****************************************************************************/
		
});

function close_main_dish_submenu(){	
		if(is_main_dish_submenu_open && !is_main_dish_submenu_hover){
			$(".main_dish_submenu").animate({
																			'filter':'alpha(opacity=0)',
																			'opacity': '0'
																			}, 300, function(){																							
																							$(".main_dish_submenu").css("display","none");
																							});	
		}		
	}
	
function close_food_menu_submenu(){	
		if(is_food_menu_submenu_open && !is_food_menu_submenu_hover){
			$(".food_menu_submenu").animate({
																			'filter':'alpha(opacity=0)',
																			'opacity': '0'
																			}, 300, function(){																							
																							$(".food_menu_submenu").css("display","none");
																							});	
		}		
	}