
define(["knockout", "api/playersRepository"], function (ko, playersRepository) {
    
    function PlayersGridViewModel(){
        var self = this;
        
        self.players = ko.observableArray([]);
        self.errorMessages = ko.observableArray([]);
        self.successMessages = ko.observableArray([]);
        
        playersRepository.requestList(0, 10).done(function (data) {
            if(data.success){
                self.successMessages.push(data.successMessages);
                
                self.players(data.result);
            } 
            else{
                self.errorMessages.push(data.errorMessages);
            }
        });
    }
    
    return new PlayersGridViewModel();
});