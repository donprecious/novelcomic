!function(a,b,c){a.fn.scrollUp=function(b){a.data(c.body,"scrollUp")||(a.data(c.body,"scrollUp",!0),a.fn.scrollUp.init(b))},a.fn.scrollUp.init=function(d){var e=a.fn.scrollUp.settings=a.extend({},a.fn.scrollUp.defaults,d),f=(e.scrollTitle?e.scrollTitle:e.scrollText,a("<a/>",{id:e.scrollName,href:"#top"}).appendTo("body"));e.scrollImg||f.html(e.scrollText),f.css({display:"none",position:"fixed",zIndex:e.zIndex}),e.activeOverlay&&a("<div/>",{id:e.scrollName+"-active"}).css({position:"absolute",top:e.scrollDistance+"px",width:"100%",borderTop:"1px dotted"+e.activeOverlay,zIndex:e.zIndex}).appendTo("body"),scrollEvent=a(b).scroll(function(){switch(scrollDis="top"===e.scrollFrom?e.scrollDistance:a(c).height()-a(b).height()-e.scrollDistance,e.animation){case"fade":a(a(b).scrollTop()>scrollDis?f.fadeIn(e.animationInSpeed):f.fadeOut(e.animationOutSpeed));break;case"slide":a(a(b).scrollTop()>scrollDis?f.slideDown(e.animationInSpeed):f.slideUp(e.animationOutSpeed));break;default:a(a(b).scrollTop()>scrollDis?f.show(0):f.hide(0))}}),f.click(function(b){b.preventDefault(),a("html, body").animate({scrollTop:0},e.scrollSpeed,e.easingType)})},a.fn.scrollUp.defaults={scrollName:"scrollUp",scrollDistance:300,scrollFrom:"top",scrollSpeed:300,easingType:"linear",animation:"fade",animationInSpeed:200,animationOutSpeed:200,scrollText:"Scroll to top",scrollTitle:!1,scrollImg:!1,activeOverlay:!1,zIndex:2147483647},a.fn.scrollUp.destroy=function(d){a.removeData(c.body,"scrollUp"),a("#"+a.fn.scrollUp.settings.scrollName).remove(),a("#"+a.fn.scrollUp.settings.scrollName+"-active").remove(),a.fn.jquery.split(".")[1]>=7?a(b).off("scroll",d):a(b).unbind("scroll",d)},a.scrollUp=a.fn.scrollUp}(jQuery,window,document),function(a){"use strict";a(document).ready(function(){a.scrollUp({scrollName:"scrollUp",scrollDistance:300,scrollFrom:"top",scrollSpeed:1e3,easingType:"easeInOutCubic",animation:"fade",animationInSpeed:200,animationOutSpeed:200,scrollText:"<i class='fas fa-angle-up'></i>",scrollTitle:" ",scrollImg:0,activeOverlay:0,zIndex:1001})}),a(document).ready(function(){a("a.scrollTo").click(function(){return a("html, body").animate({scrollTop:a(a(this).attr("href")).offset().top+"px"},{duration:1e3,easing:"easeInOutCubic"}),!1})})}(jQuery);