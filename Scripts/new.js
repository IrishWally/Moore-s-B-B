



/* faq page Java Script*/
$(document).ready(function() {
$("p").hide();
$("h2").click(function()
{
$(this).next("p").slideToggle(500);
});
}); 


