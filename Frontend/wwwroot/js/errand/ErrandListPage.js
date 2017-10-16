function ErrandListPage(){
    BasePage.call(this);
    var self = this;

    self.errands = ko.observableArray();
    
    function setValues(data) {
        var items = _.map(data, function (item) {
            return new ErrandListModel(item);
        });
        self.errands(items);
    }

    $.getJSON(window.BACKENDURL + 'errand').then(setValues).always(self.dataLoaded);
}