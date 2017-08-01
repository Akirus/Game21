// Write your Javascript code.

require.config({
    paths: {
        "jquery": "/lib/jquery/dist/jquery.min",
        "knockout" : "/lib/knockout/dist/knockout"
    }
});

require(["app", "knockout"], function (AppViewModel, ko) {
    
   var app = new AppViewModel();
    
   ko.applyBindings(app, document.getElementById('app-container')); 
});