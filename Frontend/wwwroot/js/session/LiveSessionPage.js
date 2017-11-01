function LiveSessionPage(sessionId, playerName) {
    BasePage.call(this);
    var self = this;

    self.session = new SessionModel();
    self.game = new GameSystem();

    self.playerName = ko.observable(playerName);

    self.nextErrand = function () {
        var model = {
            SessionId: sessionId
        };

        $.post(window.BACKENDURL + 'gameSession/popErrand', model).then(updateErrand);       
    };

    function updateErrand(errand) {
        self.game.currentErrand(errand.description);
    }

    function handleEvents(events) {
        _.each(events, self.game.handleEvent);
    }

    function getSession() {
        return $.getJSON(window.BACKENDURL + 'gameSession/' + sessionId);
    }

    function getEvents() {
        return $.getJSON(window.BACKENDURL + 'event/' + sessionId);
    }

    getSession()
        .then(self.session.setValues)
        .then(getEvents)
        .then(handleEvents)
        .always(self.dataLoaded);
}