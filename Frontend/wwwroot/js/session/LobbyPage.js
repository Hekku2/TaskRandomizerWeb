function LobbyPage(sessionId) {
    BasePage.call(this);
    var self = this;

    self.session = new SessionModel();
    self.events = ko.observableArray();

    function getSession() {
        return $.getJSON(window.BACKENDURL + 'gameSession/' + sessionId);
    }

    function getEvents() {
        return $.getJSON(window.BACKENDURL + 'event/' + sessionId);
    }

    function handleEvents(data){
        var items = _.map(data, function (item) {
            var model = new EventModel();
            model.setValues(item);
            return model;
        });
        self.events(items);
    }

    getSession()
        .then(self.session.setValues)
        .then(getEvents)
        .then(handleEvents)
        .always(self.dataLoaded);
}