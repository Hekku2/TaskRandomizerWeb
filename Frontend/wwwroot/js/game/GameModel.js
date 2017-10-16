function GameModel(){
    var self = this;
    self.id = ko.observable();
    self.name = ko.observable();

    self.errands = ko.observableArray();

    self.setValues = function(item){
        self.id(item.id);
        self.name(item.name);
    }

    self.setErrands = function(data) {
        var items = _.map(data, function (item) {
            return new GameErrandModel(item);
        });
        self.errands(items);
    }
}