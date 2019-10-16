	//VAR SETUP
	var htmlBody = jQuery("html,body"),
		sidebar = jQuery("#sidebar"),
		backTop = jQuery("#backTop"),
		toggleComments = jQuery('#toggleComments');
	
	//REMOVE TITLE ATTRIBUTE
	jQuery("#dropmenu a").removeAttr("title");
	
	//MENU
	jQuery("#dropmenu li").hover(function(){
		jQuery(this).find('ul:first').stop(true,true).slideDown(100);
		},function(){
		jQuery(this).find('ul:first').hide();
	});
	jQuery("#dropmenu ul").css("display", "none").parent().children("a").append("<span>&nbsp;&nbsp;+</span>");
	
	jQuery("#dropmenu ul li a").hover(function(){
		jQuery(this).stop(true,true).animate({paddingLeft:"20px"},300);
	},function(){
		jQuery(this).stop(true,true).animate({paddingLeft:"15px"},300);
	});
	
	jQuery('#mobile-menu').click(function(){
		jQuery('#navigation').stop(true,true).slideToggle(350);
		jQuery(this).find('i').toggleClass('fa-navicon fa-close');
	});
	
	//WIDGET PANEL STUFF
	jQuery("#header").append("<div id='sideToggle'>+</div>");
	var sideToggle = jQuery("#sideToggle");
	sideToggle.click(function(){
		if(jQuery(this).hasClass('open')){
			jQuery(this).html('+');
		} else {
			jQuery(this).html('&times;');
		}
		jQuery(this).toggleClass('open');
		sidebar.toggleClass('open').slideToggle(350);
	});	
	jQuery("#closeSidebar").click(function(){
		sideToggle.removeClass('open').html('+');
		sidebar.removeClass('open').slideUp(350);
		htmlBody.animate({scrollTop:0},350);
	});	
	
	//FIX ADDITIONAL ROWS OF WIDGETS	
	jQuery('.widget:nth-child(3n+1)').css({clear:"left"});
	
	//FIX ADDITIONAL ROWS OF POSTS	
	jQuery('.listing .post:nth-child(2n+1)').css({clear:"left"});
	
	//ERROR & SEARCH PAGE OPENS WIDGET PANEL	
	jQuery('body.error404 #sideToggle,body.search-no-results #sideToggle').click();
		
	//BACK TO TOP STUFF
	backTop.click(function(){
		htmlBody.animate({scrollTop:0},499);
	});
	jQuery(document).scroll(function(){
		if(jQuery(document).scrollTop()>0){
			backTop.stop(true,true).slideDown(200);
		} else {
			backTop.stop(true,true).slideUp(200);
		}
	});
	
	//COMMENT TOGGLE
	jQuery('#commentToggle').click(function(){
		toggleComments.slideToggle(500);
	});
    if (/#respond/.test(window.location)) {
    	toggleComments.show();
    }    
	
	//THE END
	function theend(){
		var listingPost = jQuery(".listing .post");
		if(listingPost.length == 1){
			listingPost.after("<div class='post' id='theEnd'>The End</div>");
		}
	}
	theend();
	
	//AJAX STUFF
	jQuery("div.pagenav a").live('click',function() {    
		var url = jQuery(this).attr('href'),
			main = jQuery("#main"),
			content = jQuery("#content"),
			height = main.outerHeight();
		
		content.css({height:height});
		
		htmlBody.animate({scrollTop:0},500);	
		
		if(jQuery(this).attr("class") == "nextpostslink"){
			var peelClass = "right";
		} else {
			var peelClass = "left";
		}
    	main.fadeOut(500,function(){
    		content.html("<div id='loading'>Loading</div>").load(url + " #main",'', function() {
    			theend();
        		main.hide().fadeIn(500);
        		jQuery(this).css({height:"auto"});
       		});
    	});
    	return false;
	});
	//jQuery(".postinate a").live('click',function() {    
	//	var thisLink = jQuery(this),
	//		url = thisLink.attr('href'),
	//		entryContainer = jQuery("#entryContainer"),
	//		entry = jQuery(".entry"),
	//		height = entryContainer.outerHeight(),
	//		entryTop = entryContainer.position().top;
		
	//	entryContainer.css({height:height});	
		
	//	htmlBody.animate({scrollTop:entryTop},500);
		
 //   	entry.fadeOut(500,function(){
 //   		entryContainer.html("<div id='loading'>Loading</div>").load(url + " .entry",'', function() {
 //       		entry.hide().fadeIn(500);
 //       		jQuery(this).css({height:"auto"});
 //      		});
       		
 //      		//ADD / REMOVE PAGINATING
 //      		if(thisLink.index() > 0){
	//			jQuery('body').addClass('paginating');
	//		} else {
	//			jQuery('body').removeClass('paginating');
	//		}
 //   	});
 //   	return false;
	//});
	
	////KEYS PRESS...
	//jQuery(document).keydown(function(e){
	//	//LEFT KEY...
	//	if (e.keyCode == 37) {
	//		jQuery('.postinate > span').prev('a').click();
	//		jQuery('a.previouspostslink').click();
	//	}
	//	//UP KEY...
	//	if (e.keyCode == 38) {}
	//	//RIGHT KEY...
	//	if (e.keyCode == 39) {
	//		jQuery('.postinate > span').next('a').click();
	//		jQuery('a.nextpostslink').click();
	//	}
 //  		//DOWN KEY...
	//	if (e.keyCode == 40) {}
	//	//SPACEBAR...
	//	if (e.keyCode == 32) {}
	//});
	
	//MESH BACKGROUND STUFF
	function docHeight(){
		var documentHeight = jQuery(document).height();
		jQuery("#mesh").css({height:documentHeight});		
	}
	jQuery(document).ready(function(){
	docHeight();
	});
	jQuery(window).resize(function(){
		docHeight();
	});
		
	//ZOOMING STUFF
	jQuery("body.single .postInfo, body.page .entrytitle").not("body.page-template-t-tags-php .entrytitle").after("<div id='zoom'><i class='fa fa-expand'></i><div id='zoomInfo'>Focus Mode</div></div>");
	var zoomInfo = jQuery('#zoomInfo');
	jQuery("#zoom").click(function(){
		jQuery(this).find('i').toggleClass('fa-expand fa-compress');
		jQuery("#mesh,#backstretch,a[rel~='prev'],a[rel~='next']").fadeToggle(1200);
		jQuery("#header,#footer, #sidebar.open").slideToggle(1200);
		htmlBody.animate({scrollTop:0},1200);
	}).hover(function(){
    	zoomInfo.fadeIn({ duration: 200, queue: false }).animate({bottom:"28px"},{duration:200,queue:false});
    },function(){
      	zoomInfo.stop(true,true).fadeOut(200,function(){jQuery(this).css({bottom:"0"})});
    });
	
	//INDEX PAGE STUFF
	jQuery("#tagList a").hover(function(){
		jQuery(this).stop(true,true).animate({paddingLeft:"5px"},300);
	},function(){
		jQuery(this).stop(true,true).animate({paddingLeft:"0px"},300);
	});