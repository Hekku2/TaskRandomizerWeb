function GameListPage(){
    BasePage.call(this);
    var self = this;

    self.games = ko.observableArray();
    
    function setValues(data) {
        var items = _.map(data, function (item) {
            var model = new GameModel();
            model.setValues(item)
            return model;
        });
        self.games(items);
    }

    $.getJSON(window.BACKENDURL + 'game').then(setValues).always(self.dataLoaded);
}