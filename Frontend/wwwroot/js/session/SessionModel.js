function SessionModel(){
    var self = this;
    self.id = ko.observable();
    self.gameName = ko.observable();

    self.errands = ko.observableArray();
    self.players = ko.observableArray();

    self.setValues = function (data) {
        self.id(data.id);
        self.gameName(data.gameName);
        var items = _.map(data.errands, function (item) {
            return new GameErrandModel(item);
        });
        self.errands(items);
        self.players(data.players);
    };
}