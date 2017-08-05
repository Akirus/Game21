/**
 * Created by Alex T. on 01/08/2017.
 */

define(["knockout", "jquery", "core/cacher", "core/ajaxTools"], function (ko, $, cacher, ajax) {
    
    function PlayersRepository(connectionUrl) {
        var self = this;
        
        self.requestList = function (pageNumber, pageSize) {

            var cacheKey = "playerList-" + pageNumber + "-" + pageSize;

            if (cacher.contains(cacheKey)) {
                return $.Deferred().resolve(cacher.get(cacheKey));
            }

            pageNumber = typeof pageNumber === 'undefined' ? 0 : pageNumber;
            pageSize = typeof pageSize === 'undefined' ? 10 : pageSize;

            return ajax.getCall(connectionUrl + "list", {
                pageNumber: pageNumber,
                pageSize: pageSize
            }).done(function (data) {
                console.dir(data);
                cacher.put(cacheKey, data, 10000);
            });
        };
    }
    
    return new PlayersRepository("/player/");
});