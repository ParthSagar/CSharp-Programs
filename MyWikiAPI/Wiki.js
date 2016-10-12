$(function(){
	var searchUrl = 'https://en.wikipedia.org/w/api.php';
	var input;
	
	var callback=function(){
		input = $('.search-input').val();
   
   	
   
   /* $.getJSON('https://en.wikipedia.org/w/api.php?format=json&action=query&generator=search&gsrnamespace=0&gsrlimit=6&prop=pageimages|extracts&pilimit=max&exintro&explaintext&exchars=70&exlimit=max&gsrsearch='+ input +'&callback=?',function(data){*/
       $.getJSON('https://en.wikipedia.org/w/api.php?format=json&action=query&generator=search&gsrnamespace=0&gsrlimit=6&prop=pageimages|pageterms&pilimit=max&gsrsearch='+ input +'&callback=?',function(data){
      
      
      var key;
      
     
		
      for(key in data.query.pages){
        
        var titleArt = data.query.pages[key].title;
        var extractArt = data.query.pages[key].terms.description;
        var linkArt = 'https://en.wikipedia.org/?curid=' + data.query.pages[key].pageid;
        var imgArt;
        
        if(data.query.pages[key].hasOwnProperty('thumbnail')){
          imgArt = data.query.pages[key].thumbnail.source;
        } else {
         
        }
		  if(extractArt==null)
			  extractArt="";
			  var contentHTML = '<tbody style="cursor:pointer; margin-top:2px;" onclick=window.open("'+linkArt+'")><tr><td rowspan=2 class="imag"  ><img src="' + imgArt + '" alt="" /></a></td><th style="text-align:left;">'+ titleArt +'</th></tr><tr style="cursor:pointer;" onclick=window.open("'+linkArt+'")><td style="border-bottom: thin solid lightgrey;">' + extractArt + '</td></tr></tbody>';
      	$(".container1").css("display", "block");
        $('.sec-result .row').append(contentHTML);
      }
      
     });
	};
	 
  $('.search-input').keyup(function(data){
	 $('.sec-result .row').empty();
	  input = $('.search-input').val();
   	callback();
    
  })
  $('.submit').click(function myFunction() {
	 input = $('.search-input').val();
    window.open('https://en.wikipedia.org/wiki/'+input);
});
  
})