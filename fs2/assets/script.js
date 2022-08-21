(function() {
  var urls = ['coyote', 'ginger', 'king', 'liu', 'marion'];
  function swap() {
    document.getElementById('waifu').setAttribute('src', 'assets/' + urls[Math.round(Math.random() * urls.length)] + '.png');
	  
  }

  // Mozilla, Opera and webkit nightlies currently support this event
  if ( document.addEventListener ) {
    window.addEventListener( 'load', swap, false );
  // If IE event model is used
  } else if ( document.attachEvent ) {
    window.attachEvent( 'onload', swap );
  }
})();	
	function ImgError(source){
	source.src = "assets/coyote.png";
	source.onerror = "";
	return true;
}
