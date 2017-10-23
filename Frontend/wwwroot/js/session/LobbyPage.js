function LobbyPage(sessionId) {
    BasePage.call(this);
    var self = this;

    self.session = new SessionModel();

    function getSession() {
        return $.getJSON(window.BACKENDURL + 'gameSession/' + sessionId);
    }

    getSession().then(self.session.setValues).always(self.dataLoaded);
}