function LoadableElement(){
    var self = this;
    self.isLoading = ko.observable(false);
    self.isInitialized = ko.observable(false);

    self.showLoading = ko.computed(function () {
        self.isLoading() && !self.isInitialized();
    });

    self.startLoading = function () {
        self.isLoading(true);
        self.isInitialized(true)
    };

    self.loadFinished = function () {
        self.isLoading(false);
        self.isInitialized(true)
    }
}