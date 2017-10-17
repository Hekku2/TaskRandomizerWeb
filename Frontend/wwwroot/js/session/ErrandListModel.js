function ErrandListModel() {
    LoadableElement.call(this);
    var self = this;

    self.errands = ko.observableArray();

    self.setErrands = function (data) {
        var items = _.map(data, function (item) {
            return new GameErrandModel(item);
        });
        self.errands(items);
    }
}