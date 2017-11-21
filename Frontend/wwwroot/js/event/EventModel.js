function EventModel() {
    var self = this;
    self.eventType = ko.observable();
    self.name = ko.observable();
    self.description = ko.observable();

    self.setValues = function (data) {
        self.eventType(data.eventType);
        self.name(data.name);
        self.description(data.description);
    }
}