
array_imagen = new Array(3)
array_imagen[0] = new Image(600,200) 
array_imagen[0].src = "imagenes/1.jpg" 
array_imagen[1] = new Image(600,200)
array_imagen[1].src = "imagenes/2.jpg" 
array_imagen[2] = new Image(600,200) 
array_imagen[2].src = "imagenes/3.jpg" 
//creo el array de URLs 
array_url = new Array(3) 
array_url[0] = "#" 
array_url[1] = "#" 
array_url[2] = "#" 
//variable para llevar la cuenta de la imagen siguiente 
contador = 0
//función para rotar el banner 
function alternar_banner(){ 
   	window.document["banner"].src = array_imagen[contador].src 
   	window.document.links[0].href = array_url[contador] 
   	contador ++ 
   	contador = contador % array_imagen.length 
   	setTimeout("alternar_banner()",3000) 
} 
$(function(){
    $('.button-checkbox').each(function(){
		var $widget = $(this),
			$button = $widget.find('button'),
			$checkbox = $widget.find('input:checkbox'),
			color = $button.data('color'),
			settings = {
					on: {
						icon: 'glyphicon glyphicon-check'
					},
					off: {
						icon: 'glyphicon glyphicon-unchecked'
					}
			};

		$button.on('click', function () {
			$checkbox.prop('checked', !$checkbox.is(':checked'));
			$checkbox.triggerHandler('change');
			updateDisplay();
		});

		$checkbox.on('change', function () {
			updateDisplay();
		});

		function updateDisplay() {
			var isChecked = $checkbox.is(':checked');
			// Set the button's state
			$button.data('state', (isChecked) ? "on" : "off");

			// Set the button's icon
			$button.find('.state-icon')
				.removeClass()
				.addClass('state-icon ' + settings[$button.data('state')].icon);

			// Update the button's color
			if (isChecked) {
				$button
					.removeClass('btn-default')
					.addClass('btn-' + color + ' active');
			}
			else
			{
				$button
					.removeClass('btn-' + color + ' active')
					.addClass('btn-default');
			}
		}
		function init() {
			updateDisplay();
			// Inject the icon if applicable
			if ($button.find('.state-icon').length == 0) {
				$button.prepend('<i class="state-icon ' + settings[$button.data('state')].icon + '"></i> ');
			}
		}
		init();
	});
});
