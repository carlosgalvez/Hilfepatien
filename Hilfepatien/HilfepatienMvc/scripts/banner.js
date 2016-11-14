
<script> 
//creo array de imágenes 
array_imagen = new Array(3)
array_imagen[0] = new Image(120,41) 
array_imagen[0].src = "../imagenes/1.jpg" 
array_imagen[1] = new Image(120,41) 
array_imagen[1].src = "../imagenes/2.jpg" 
array_imagen[2] = new Image(120,41) 
array_imagen[2].src = "../imagenes/3.jpg" 


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
   	setTimeout("alternar_banner()",1000) 
} </script> 