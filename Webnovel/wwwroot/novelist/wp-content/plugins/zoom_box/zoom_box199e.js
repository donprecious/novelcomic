 jQuery.noConflict(); jQuery(document).ready(function(){

	var theBody = jQuery('body');
	
	//////////////////////////
	//ASSIGN ZOOM BOX FUNCTION
	//////////////////////////
	function assignZoomBox(){
		//GALLERY ID POP-UP
		jQuery(".gallery-icon a[href$='jpeg'],.gallery-icon a[href$='jpg'],.gallery-icon a[href$='png'],.gallery-icon a[href$='gif']").each(function(){
			var thisImg = jQuery(this),
				thisGallery = thisImg.parents('.gallery').attr('id');
			
			thisImg.attr({rel: "zoomBox["+ thisGallery +"]"});
		});
		//GALLERY POP-UP
		jQuery("a[href$='jpeg'],a[href$='jpg'],a[href$='png'],a[href$='gif']").siblings("a[href$='jpg'],a[href$='png'],a[href$='gif']").not('[rel^="zoomBox[gallery-"]').attr({rel: "zoomBox[gallery]"});
		//SINGLE POP-UP
		jQuery("a[href$='jpeg'],a[href$='jpg'],a[href$='png'],a[href$='gif']").not('[rel^="zoomBox[gallery"]').attr({rel: "zoomBox"});
	}

	/////////////
	//RUN SCRIPT
	/////////////
	assignZoomBox();
	
	///////////////////////	
	//RUN SCRIPT AFTER AJAX
	///////////////////////
	jQuery(document).ajaxComplete(function() {
		assignZoomBox();
	});	
	
	/////////////////////
	//SINGLE POP-UP CLICK
	/////////////////////
	jQuery(document).on('click',"a[rel='zoomBox']",function(){
		
		//CREATE BOX
		if(!jQuery('#zoomBox').length > 0){
			theBody.addClass('zoombox-open').prepend('<div id="zoomBox" class="singleBox zoomIn"><div id="imgBox"></div><div id="closeZoomBox">×</div><div id="titleBox"></div></div>');
		}
		
		//VAR SETUP
		var zoomBox = jQuery('#zoomBox'),
			imgBox = jQuery('#imgBox'),
			titleBox = jQuery('#titleBox'),
			thisLink = jQuery(this),
			imgURL = thisLink.attr('href'),
			imgTitle = thisLink.children().attr('alt');
		
		//TITLE CHECK
		if(typeof imgTitle == 'undefined') {
			var imgTitle = thisLink.attr('title');
		}
		
		//ADD LOADING
		zoomBox.addClass('loading').stop(true,true).fadeIn(500);
		
		//LOAD IMAGE
		jQuery('<img/>').attr('src', imgURL).load(function() {
   			jQuery(this).remove();
   			zoomBox.removeClass('loading');
   			imgBox.css({backgroundImage:"url("+imgURL+")"});
   			titleBox.html(imgTitle);
		});
		
		return false;
	});
		
	//////////////////////
	//GALLERY POP-UP CLICK
	//////////////////////
	jQuery(document).on('click',"a[rel='zoomBox[gallery]']",function(){
		
		//CREATE BOX
		if(!jQuery('#zoomBox').length > 0){
			theBody.addClass('zoombox-open').prepend('<div id="zoomBox" class="zoomIn"><div id="imgBox"></div><div id="closeZoomBox">×</div><div id="nextBox" class="boxNav">&rarr;</div><div id="prevBox" class="boxNav">&larr;</div><div id="titleBox"></div></div>');
		}
		
		//VAR SETUP
		var zoomBox = jQuery('#zoomBox'),
			imgBox = jQuery('#imgBox'),
			titleBox = jQuery('#titleBox'),
			allBoxes = jQuery('a[rel="zoomBox[gallery]"]'),
			selectedBox = jQuery('.selectedBox'),
			selectedIndex = allBoxes.index(jQuery(this)) + 1,
			lastIndex = allBoxes.index(allBoxes.filter(":last")) + 1,
			thisLink = jQuery(this),
			imgURL = thisLink.attr('href'),
			imgTitle = thisLink.children().attr('alt');
		
		//TITLE CHECK
		if(typeof imgTitle == 'undefined') {
			var imgTitle = thisLink.attr('title');
		}

		//ADD LOADING
		zoomBox.addClass('loading').stop(true,true).fadeIn(500);
		
		//ASSIGN SELECTED
		selectedBox.removeClass('selectedBox');
		thisLink.addClass('selectedBox');
		
		//LOAD IMAGE
		jQuery('<img/>').attr('src', imgURL).load(function() {
   			jQuery(this).remove();
   			zoomBox.removeClass('loading');
   			//HIDE/CHANGE/SHOW IMAGE
			imgBox.stop(true,true).fadeOut(150,function(){
   				imgBox.css({backgroundImage:"url("+imgURL+")"}).stop(true,true).fadeIn(150);
   			});
   			titleBox.html(imgTitle+"<span>"+selectedIndex+" / "+lastIndex+"</span>");
		});
		
		return false;
	});

	/////////////////////////
	//GALLERY ID POP-UP CLICK
	/////////////////////////
	jQuery(document).on('click',"a[rel^='zoomBox[gallery-']",function(){
	
		var theRel = jQuery(this).attr('rel');
					
		//CREATE BOX
		if(!jQuery('#zoomBox').length > 0){
			theBody.addClass('zoombox-open').prepend('<div id="zoomBox" class="zoomIn"><div id="imgBox"></div><div id="closeZoomBox">×</div><div id="nextBox" class="boxNav galleryId" data-galrel="'+ theRel +'">&rarr;</div><div id="prevBox" class="boxNav galleryId" data-galrel="'+ theRel +'">&larr;</div><div id="titleBox"></div></div>');
		}
		
		//VAR SETUP
		var zoomBox = jQuery('#zoomBox'),
			imgBox = jQuery('#imgBox'),
			titleBox = jQuery('#titleBox'),
			allBoxes = jQuery('a[rel="' + theRel + '"]'),
			selectedBox = jQuery('.selectedBox'),
			selectedIndex = allBoxes.index(jQuery(this)) + 1,
			lastIndex = allBoxes.index(allBoxes.filter(":last")) + 1,
			thisLink = jQuery(this),
			imgURL = thisLink.attr('href'),
			imgTitle = thisLink.children().attr('alt');
		
		//TITLE CHECK
		if(typeof imgTitle == 'undefined') {
			var imgTitle = thisLink.attr('title');
		}
		
		//ADD LOADING
		zoomBox.addClass('loading').stop(true,true).fadeIn(500);
		
		//ASSIGN SELECTED
		selectedBox.removeClass('selectedBox');
		thisLink.addClass('selectedBox');
		
		//LOAD IMAGE
		jQuery('<img/>').attr('src', imgURL).load(function() {
   			jQuery(this).remove();
   			zoomBox.removeClass('loading');
   			//HIDE/CHANGE/SHOW IMAGE
			imgBox.stop(true,true).fadeOut(150,function(){
   				imgBox.css({backgroundImage:"url("+imgURL+")"}).stop(true,true).fadeIn(150);
   			});
   			titleBox.html(imgTitle+"<span>"+selectedIndex+" / "+lastIndex+"</span>");
		});
		
		return false;
	});
	
	//////////
	//NEXT IMG
	//////////
	jQuery(document).on('click','#nextBox',function(){
	
		if(jQuery(this).hasClass('galleryId')){
			var galrel = jQuery(this).attr('data-galrel'),
				selectedBox = jQuery('.selectedBox'),
				allBoxes = jQuery('a[rel="'+galrel+'"]'),
				selectedIndex = allBoxes.index(selectedBox),
				nextImg = allBoxes.eq(selectedIndex + 1);		
		} else {		
			var selectedBox = jQuery('.selectedBox'),
				allBoxes = jQuery('a[rel="zoomBox[gallery]"]'),
				selectedIndex = allBoxes.index(selectedBox),
				nextImg = allBoxes.eq(selectedIndex + 1);
		}
			
		if(nextImg.length > 0){
			nextImg.click();
		} else {
			allBoxes.filter(":first").click();
		}
			
		return false;
	});
	
	//////////
	//PREV IMG
	//////////
	jQuery(document).on('click','#prevBox',function(){
	
		if(jQuery(this).hasClass('galleryId')){
			var galrel = jQuery(this).attr('data-galrel'),
				selectedBox = jQuery('.selectedBox'),
				allBoxes = jQuery('a[rel="'+galrel+'"]'),
				selectedIndex = allBoxes.index(selectedBox),
				prevImg = allBoxes.eq(selectedIndex - 1);
		} else {
			var selectedBox = jQuery('.selectedBox'),
				allBoxes = jQuery('a[rel="zoomBox[gallery]"]'),
				selectedIndex = allBoxes.index(selectedBox),
				prevImg = allBoxes.eq(selectedIndex - 1);
		}
		
		if(prevImg.length > 0){
			prevImg.click();
		} else {
			allBoxes.filter(":last").click();
		}
			
		return false;
	});
	
	//////////
	//ZOOM BOX
	//////////
	jQuery(document).on('click','#imgBox',function(){
		jQuery('#zoomBox').toggleClass('zoomOut');
	});	
	
	///////////
	//CLOSE BOX
	///////////
	jQuery(document).on('click','#closeZoomBox',function(){
		theBody.removeClass('zoombox-open');
		
		jQuery('#zoomBox').fadeOut(300,function(){
			jQuery(this).remove();
		});
		
		jQuery('.selectedBox').removeClass('selectedBox');
		
		return false;
	});
	
	////////////
	//KEYS PRESS
	////////////
	jQuery(document).keydown(function(e){
		//LEFT KEY
		if (e.keyCode == 37 && jQuery('#zoomBox').length > 0) {jQuery('#zoomBox #prevBox').click(); return false;}
		//UP KEY
		if (e.keyCode == 38 && jQuery('#zoomBox').length > 0) {jQuery('#zoomBox #nextBox').click(); return false;}
		//RIGHT KEY
		if (e.keyCode == 39 && jQuery('#zoomBox').length > 0) {jQuery('#zoomBox #nextBox').click(); return false;}
   		//DOWN KEY
		if (e.keyCode == 40 && jQuery('#zoomBox').length > 0) {jQuery('#zoomBox #prevBox').click(); return false;}
		//SPACEBAR
		if (e.keyCode == 32 && jQuery('#zoomBox').length > 0) {jQuery('#zoomBox #imgBox').click(); return false;}
		//ENTER
		if (e.keyCode == 13 && jQuery('#zoomBox').length > 0) {jQuery('#zoomBox #imgBox').click(); return false;}
		//ESCAPE
		if (e.keyCode == 27 && jQuery('#zoomBox').length > 0) {jQuery('#zoomBox #closeZoomBox').click(); return false;}
	});

});