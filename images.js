(function () { 
    var imageString = "";
    var imagesFromElements = document.body.querySelectorAll('img.StickerImage__image[src]');
    var test = /\/128\.png/;
     var images = Array.from(imagesFromElements)
                        .map(image => {
                            imageString += image.getAttribute('src').replace(test, '/512.png') + ',';
                            return image.getAttribute('src').replace(test, '/512.png');
                        }); 
    console.log(imageString);
    return 0;
}());