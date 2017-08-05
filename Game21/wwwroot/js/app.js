define(["knockout", "jquery", "core/router"], function (ko, $, Router) {
    function ApplicationViewModel(appConfig) {
        var self = this;

        self.currentLocation = ko.computed(function () {
           return window.location.pathname;
        });
        
        self.title = ko.pureComputed(function () {
            return "Game21 - " + self.currentLocation();
        });
        
        self.router = new Router(appConfig.pagesPath);
        
        self.currentPage = ko.observable();
        
        self.resolvePage = function(location){
            self.router.resolvePage(location, function (page) {
                $("#currentPageTemplate").html(page.html);
                self.currentPage(page);
            });
        };

        self.nagivate = function(location) {
            history.pushState(undefined, undefined, location);
            
            self.resolvePage(location);
        };
        
        self.resolvePage(self.currentLocation());
    }  
    
    return ApplicationViewModel;
});