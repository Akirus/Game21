/**
 * Created by mac on 01/08/2017.
 */

define(['jquery'], function ($) {
    
    function Router(pagesDirectory) {
        var self = this;
        
        self.resolvePage = function (path, callback) {
            var filePath = pagesDirectory + path + path;
            require([filePath + ".js", "text!" + filePath + ".html"], function (viewModel, html) {
                var page = {
                    viewModel: viewModel,
                    html: html,
                    nodes : $(html)[0]
                }; 
                
                if (typeof callback === 'function')
                    callback(page);
            });
        };
        
    }
    
    return Router;
});