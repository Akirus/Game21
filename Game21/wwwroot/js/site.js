// Write your Javascript code.

require.config({
    paths: {
        "jquery": "/lib/jquery/dist/jquery.min",
        "knockout" : "/lib/knockout/dist/knockout",
        "text" : "/lib/text/text",
        "api/playersRepository" : "/js/api/playersRepository",
        "core/cacher" : "/js/core/cacher",
        "core/ajaxTools" : "/js/core/ajaxTools",
        "core/router" : "/js/core/router",
        "core/bindingHandlers" : "/js/core/bindingHandlers"
    }
});

require(["app", "knockout", "text", "jquery", "core/bindingHandlers"], function (AppViewModel, ko, text, $, bindingHandlers) {
    
   var app = window.app = new AppViewModel({
       pagesPath : "/pages"
   });

    for(var prop in bindingHandlers) {
        if(bindingHandlers.hasOwnProperty(prop)) {
            ko.bindingHandlers[prop] = bindingHandlers[prop];
        }
    }
    
   ko.applyBindings(app, document.getElementById('app-container'));
});