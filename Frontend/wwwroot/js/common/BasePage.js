function BasePage() {
    var self = this;
    self.pageLoaded = ko.observable(false);

    self.dataLoaded = function () {
        self.pageLoaded(true);
    }
}