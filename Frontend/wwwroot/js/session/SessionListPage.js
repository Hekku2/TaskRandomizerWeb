function SessionListPage() {
    BasePage.call(this);
    var self = this;

    self.playerName = ko.observable();
    self.sessions = ko.observableArray();

    self.joinSession = function (item)
    {
        function redirectSession(result)
        {
            console.log(result);
        }

        var joinParameters = {
            sessionId: item.id(),
            playerName: self.playerName()
        };
        $.post(window.BACKENDURL + 'gamesession/join', joinParameters).then(redirectSession);
    }

    function setValues(data) {
        var items = _.map(data, function (item) {
            var model = new SessionModel();
            model.setValues(item);
            return model;
        });
        self.sessions(items);
    }

    $.getJSON(window.BACKENDURL + 'gamesession').then(setValues).always(self.dataLoaded);
}