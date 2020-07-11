<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NFSMHome.aspx.cs" Inherits="NFSMHome" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/nfsm/Outmenu.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<header>
<meta charset="utf-8">
	<title>NFSM</title>
	<meta name="description"/>
	
	
    <!-- Mobile Specific Metas
  ================================================== -->
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    
    <!-- CSS
  ================================================== -->
  	<link rel="stylesheet" href="css/zerogrid.css"/>
	<link rel="stylesheet" href="css/style.css"/>
	<link rel="stylesheet" href="css/menu.css"/>
	<link rel="stylesheet" href="css/lightbox.css"/>
	
	<!-- Custom Fonts -->
	<link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
	
	<!-- Owl Carousel Assets -->
    <link href="owl-carousel/owl.carousel.css" rel="stylesheet"/>
    <!-- <link href="owl-carousel/owl.theme.css" rel="stylesheet"> -->
	
	<script src="js/jquery-2.1.1.js"></script>
	<script src="js/script.js"></script>

	
</header>

<body>
    <form id="form1" runat="server">
  
   <div class="wrap-body">

<!--////////////////////////////////////Header-->
<header>
	<div class="wrap-header">
		<!---Main Header--->
		<div class="main-header">
			<div class="zerogrid">
				<div class="row">
					<div class="col-1-4">
						<span>
							<img src="images/1/logo.png" />
						</span>
					</div>
					<div class="col-2-4">
						<div id="logo"><a href="#"><img src="images/logo.png" /></a></div>
					</div>
					<div class="col-1-4">
						<span>
							<img src="images/1/digital.png" />
						</span>
					</div>
				</div>
			</div>
		</div>
        
		<!---Top Menu--->
		<div id="cssmenu" >
		   <menu:menu ID="menu" runat="server"  />
		</div>
		<!---Owl Slide--->
		<div id="owl-slide" class="owl-carousel" >
			<div class="item">
				<img src="images/slides/1.png" />
				<div class="carousel-caption">
					<div class="carousel-caption-inner">
						<p class="carousel-caption-title"><a href="#">National Food Security Mission</a></p>
						<p class="carousel-caption-category"><a href="#" rel="category tag">Agriculture</a>, 
						<a href="#" rel="category tag">Seed</a>, <a href="#" rel="category tag">Vyavasayam</a>
						</p>
					</div>
				</div>
			</div>
			<div class="item">
				<img src="images/slides/2.png" />
				<div class="carousel-caption">
					<div class="carousel-caption-inner">
						<p class="carousel-caption-title"><a href="#">National Food Security Mission</a></p>
						<p class="carousel-caption-category"><a href="#" rel="category tag">Agriculture</a>, 
						<a href="#" rel="category tag">Seed</a>, <a href="#" rel="category tag">Vyavasayam</a>
						</p>
					</div>
				</div>
			</div>
			<div class="item">
				<img src="images/slides/3.png" />
				<div class="carousel-caption">
					<div class="carousel-caption-inner">
						<p class="carousel-caption-title"><a href="#">National Food Security Mission</a></p>
					<p class="carousel-caption-category"><a href="#" rel="category tag">Agriculture</a>, 
						<a href="#" rel="category tag">Seed</a>, <a href="#" rel="category tag">Vyavasayam</a>
						</p>
					</div>
				</div>
			</div>
			<div class="item">
				<img src="images/slides/4.png" />
				<div class="carousel-caption">
					<div class="carousel-caption-inner">
						<p class="carousel-caption-title"><a href="#">National Food Security Mission</a></p>
					<p class="carousel-caption-category"><a href="#" rel="category tag">Agriculture</a>, 
						<a href="#" rel="category tag">Seed</a>, <a href="#" rel="category tag">Vyavasayam</a>
						</p>
					</div>
				</div>
			</div>
			<div class="item">
				<img src="images/slides/5.png" />
				<div class="carousel-caption">
					<div class="carousel-caption-inner">
						<p class="carousel-caption-title"><a href="#">National Food Security Mission</a></p>
						<p class="carousel-caption-category"><a href="#" rel="category tag">Agriculture</a>, 
						<a href="#" rel="category tag">Seed</a>, <a href="#" rel="category tag">Vyavasayam</a>
						</p>
					</div>
				</div>
			</div>
			<div class="item">
				<img src="images/slides/6.png" />
				<div class="carousel-caption">
					<div class="carousel-caption-inner">
						<p class="carousel-caption-title"><a href="#">National Food Security Mission</a></p>
						<p class="carousel-caption-category"><a href="#" rel="category tag">Agriculture</a>, 
						<a href="#" rel="category tag">Seed</a>, <a href="#" rel="category tag">Vyavasayam</a>
						</p>
					</div>
				</div>
			</div>	
			<div class="item">
				<img src="images/slides/7.png" />
				<div class="carousel-caption">
					<div class="carousel-caption-inner">
						<p class="carousel-caption-title"><a href="#">National Food Security Mission</a></p>
						<p class="carousel-caption-category"><a href="#" rel="category tag">Agriculture</a>, 
						<a href="#" rel="category tag">Seed</a>, <a href="#" rel="category tag">Vyavasayam</a>
						</p>
					</div>
				</div>
			</div>
			<div class="item">
				<img src="images/slides/8.png" />
				<div class="carousel-caption">
					<div class="carousel-caption-inner">
						<p class="carousel-caption-title"><a href="#">National Food Security Mission</a></p>
					<p class="carousel-caption-category"><a href="#" rel="category tag">Agriculture</a>, 
						<a href="#" rel="category tag">Seed</a>, <a href="#" rel="category tag">Vyavasayam</a>
						</p>
					</div>
				</div>
			</div>	
			<div class="item">
				<img src="images/slides/9.png" />
				<div class="carousel-caption">
					<div class="carousel-caption-inner">
						<p class="carousel-caption-title"><a href="#">National Food Security Mission</a></p>
					<p class="carousel-caption-category"><a href="#" rel="category tag">Agriculture</a>, 
						<a href="#" rel="category tag">Seed</a>, <a href="#" rel="category tag">Vyavasayam</a>
						</p>
					</div>
				</div>
			</div>	
			<div class="item">
				<img src="images/slides/10.png" />
				<div class="carousel-caption">
					<div class="carousel-caption-inner">
						<p class="carousel-caption-title"><a href="#">National Food Security Mission</a></p>
						<p class="carousel-caption-category"><a href="#" rel="category tag">Agriculture</a>, 
						<a href="#" rel="category tag">Seed</a>, <a href="#" rel="category tag">Vyavasayam</a>
						</p>
					</div>
				</div>
			</div>
		</div>
	</div>
</header>


<!--////////////////////////////////////Container-->
<section id="container">
	<div class="wrap-container">
		<!-----------------content-box-1-------------------->
		<section class="content-box boxstyle-1 box-1">
		
		</section>
		
		<!-----------------content-box-2-------------------->
		<section class="content-box boxstyle-2 box-2">
			
		</section>
		
		<!-----------------content-box-3-------------------->
		<section class="content-box boxstyle-3 box-3 ">
			
		</section>
		
		<!-----------------content-box-4-------------------->
		<section class="content-box boxstyle-1 box-4">
			
		</section>
		
		<!-----------------content-box-5-------------------->
		<section class="content-box boxstyle-3 box-5">
			
		</section>
		
		<!-----------------content-box-6-------------------->
		<section class="content-box boxstyle-1 box-6">
		
		</section>
	</div>
</section>

<!--////////////////////////////////////Footer-->
<footer>
	
	<div class="copyright">
		<div class="zerogrid wrapper">
			Designed and Developed by <a href="https://www.zerotheme.com">National Informatics Center</a>
			<ul class="quick-link">
				<li><a href="#">Hyderabad,</a></li>
				<li><a href="#">Telangana</a></li>
			</ul>
		</div>
	</div>
</footer>

	<!-- Light Box -->
	<script src="js/lightbox-plus-jquery.min.js"></script>
	
	<!-- Google Map -->
	<script>
	    var marker;
	    var image = 'images/map-marker.png';
	    function initMap() {
	        var myLatLng = { lat: 39.79, lng: -86.14 };

	        // Specify features and elements to define styles.
	        var styleArray = [
          {
              featureType: "all",
              stylers: [
             { saturation: -80 }
            ]
          }, {
              featureType: "road.arterial",
              elementType: "geometry",
              stylers: [
              { hue: "#000000" },
              { saturation: 50 }
            ]
          }, {
              featureType: "poi.business",
              elementType: "labels",
              stylers: [
              { visibility: "off" }
            ]
          }
        ];

	        var map = new google.maps.Map(document.getElementById('map'), {
	            center: myLatLng,
	            scrollwheel: false,
	            // Apply the map style array to the map.
	            styles: styleArray,
	            zoom: 7
	        });

	        var directionsDisplay = new google.maps.DirectionsRenderer({
	            map: map
	        });

	        // Create a marker and set its position.
	        marker = new google.maps.Marker({
	            map: map,
	            icon: image,
	            draggable: true,
	            animation: google.maps.Animation.DROP,
	            position: myLatLng
	        });
	        marker.addListener('click', toggleBounce);
	    }

	    function toggleBounce() {
	        if (marker.getAnimation() !== null) {
	            marker.setAnimation(null);
	        } else {
	            marker.setAnimation(google.maps.Animation.BOUNCE);
	        }
	    }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB7V-mAjEzzmP6PCQda8To0ZW_o3UOCVCE&callback=initMap" async defer></script>
	
	<!-- carousel -->
	<script src="owl-carousel/owl.carousel.js"></script>
    <script>
    $(document).ready(function() {
      $("#owl-testimonials").owlCarousel({
        autoPlay: 3000,
        items : 1,
		itemsDesktop : [1199,1],
        itemsDesktopSmall : [979,2],
		navigation: false,
      });
	  $("#owl-slide").owlCarousel({
			autoPlay: 3000,
			items : 2,
			itemsDesktop : [1199,2],
			itemsDesktopSmall : [979,1],
			itemsTablet : [768, 1],
			itemsMobile : [479, 1],
			navigation: true,
			navigationText: ['<i class="fa fa-chevron-left fa-5x"></i>', '<i class="fa fa-chevron-right fa-5x"></i>'],
			pagination: false
		  });
    });
    </script>
	
</div>
  
    </form>
</body>
</html>
