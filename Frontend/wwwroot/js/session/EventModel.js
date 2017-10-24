function EventModel() {
    var self = this;
    self.eventType = ko.observable();

    self.setValues = function (data) {
        self.eventType(data);
    }
}