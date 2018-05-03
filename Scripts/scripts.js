$("#slideshow > img:gt(0)").hide();
setInterval(function() {
 $('#slideshow > img:first')
 .fadeOut(1000)
 .next()
 .fadeIn(1000)
 .end()
 .appendTo('#slideshow');
}, 3000);


/* $(document).ready(function() {
$("p").hide();
$("h2").click(function()
{
$(this).next("p").slideToggle(500);
});
}); 
  */

var showText = function (target, message, index, interval) {   
  if (index < message.length) {
    $(target).append(message[index++]);
    setTimeout(function () { showText(target, message, index, interval); }, interval);
  }
}

$(function () {

  showText(".center", "Adventurer, Welcome!", 0, 50);   

});




		
	

		
		
		
		
		
		
		

