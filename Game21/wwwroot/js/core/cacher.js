/**
 * Created by mac on 01/08/2017.
 */

define(function () {

    const _15_SECONDS = 15000;

    function Cacher() {
        var self = this;
        
        var dict = {};
        
        self.put = function (key, value, expirationTime) {
            expirationTime = typeof expirationTime === 'undefined' ? _15_SECONDS : expirationTime;
            
            dict[key] = {
                value: value,
                expireDate: new Date((new Date()).getTime() + expirationTime)
            }
        };
        
        self.get = function (key) {
            if (self.contains(key))
                return dict[key].value;
        };
        
        self.expire = function (key) {
            dict[key].expireDate = new Date(0);
        };
        
        self.contains = function (key) {
            return dict[key] 
            && dict[key].expireDate 
            && new Data() < dict[key].expireDate;
        };
    }
    
    return new Cacher();
});