define(["knockout", "jquery"], function (ko, $) {
    function ApplicationViewModel() {
        var self = this;

        self.currentLocation = ko.computed(function () {
           return window.location.pathname;
        });
    }  
    
    return ApplicationViewModel;
});