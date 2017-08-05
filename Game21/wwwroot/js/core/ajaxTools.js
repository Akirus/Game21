
define(['jquery'], function ($) {
    
    function AjaxTools($) {
        var self = this;
        
        self.postCall = function (url, data) {
            return self.ajaxCall(url, 'POST', data);
        };
        
        self.getCall = function (url, data) {
            return self.ajaxCall(url,  'GET', data)
        };
        
        self.ajaxCall = function (url, method, data) {
            return $.ajax({
                method: method,
                url: url,
                data: data});
        };
    }
    
    return new AjaxTools($);
});