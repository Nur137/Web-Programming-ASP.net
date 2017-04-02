var all_ok = true;

jQuery(document).ready(function(e) {
    	
	$('#reservation_date').blur(function(e) {
        checkReservationDate();
    });
		$('#reservation_name').blur(function(e) {
        checkReservationName();
    });
		$('#reservation_name').change(function(e) {
        checkReservationName();
    });
	$('#no_of_tables').blur(function(e) {
        checkTableSel();
    });
	$('#no_of_tables').change(function(e) {
        checkTableSel();
    });
	$('#reservation_date').change(function(e) {
        checkReservationDate();
    });
	
	$('#custReservationForm').submit(function() {
		all_ok = true;
		checkMendatory();
		if (all_ok) {
			return true;
		}
		return false;	
	});	
	
	var today = new Date();
	var dd = today.getDate();
	var mm = today.getMonth()+1; //January is 0!
	
	var yyyy = today.getFullYear();
	$( "#reservation_date" ).datepicker({ dateFormat: 'dd MM, yy', minDate: new Date(), maxDate: "+1M" });
	
});

function checkReservationDate() {
	if ($('#reservation_date').val() != '' && $('#reservation_date').val() != null) {
		$('.errReservationDate').html('');
		$('.errReservationDate').css({'display' : 'none'});
	} else {
		$('.errReservationDate').html('Enter date');
		$('.errReservationDate').css({'display' : 'block'});
		all_ok = false;
	}
}

function checkReservationName() {
	if ($('#reservation_name').val() != '' && $('#reservation_name').val() != null) {
		$('.errReservationName').html('');
		$('.errReservationName').css({'display' : 'none'});
	} else {
		$('.errReservationName').html('Enter name');
		$('.errReservationName').css({'display' : 'block'});
		all_ok = false;
	}
}

function checkTableSel() {
	if ($('#no_of_tables').val() != '' && $('#no_of_tables').val() != null) {
		$('.errReservationTables').html('');
		$('.errReservationTables').css({'display' : 'none'});
	} else {
		$('.errReservationTables').html('Select no of tables');
		$('.errReservationTables').css({'display' : 'block'});
		all_ok = false;
	}
}

function checkMendatory(){
	checkReservationName();
	checkTableSel();
}