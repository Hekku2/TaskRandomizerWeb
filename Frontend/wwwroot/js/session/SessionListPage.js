function SessionListPage() {
    BasePage.call(this);
    var self = this;

    self.sessions = ko.observableArray();

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