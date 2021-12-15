$('.owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    nav:true,
    dots:false,
    navigation: false,
    navText: [" ", " "],
    responsive:{
        0:{
            items:1
        },
        375:{
            items:2
        },
        425:{
            items:3
        },
        768:{
            items:5
        },
        1024:{
            items:8
        },
        1440:{
            items:8
        },
    }
})

