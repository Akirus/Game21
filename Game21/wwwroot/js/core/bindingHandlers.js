/**
 * Created by mac on 05/08/2017.
 */

/**
 * Created by Alex T. on 01/08/2017.
 */

define(["knockout", "jquery"], function (ko, $) {

    var handlers = {};

    handlers.appLink = {
        init: function(element, valueAccessor) {
            element.href = ko.unwrap(valueAccessor());

            $(element).on('click', function (event) {
                event.preventDefault();

                window.app.nagivate(ko.unwrap(valueAccessor()));

                return false;
            });
        },
        update: function(element, valueAccessor, allBindings) {
        }
    };
    
    return handlers;
});