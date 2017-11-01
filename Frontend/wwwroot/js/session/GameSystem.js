function GameSystem() {
    var self = this;

    self.events = ko.observableArray();
    self.currentErrand = ko.observable();
    self.players = ko.observableArray();

    //TODO: Make proper translation for numbers
    self.handleEvent = function (event) {
        switch (event.eventType) {
            case 1: //Session created
                break;
            case 2: //PlayerJoined
                self.players.push(event.playerName);
                break;
        }
        var model = new EventModel();
        model.setValues(event);
        self.events.push(model);
    }
}