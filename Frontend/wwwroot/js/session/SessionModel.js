function SessionModel(){
    var self = this;
    self.id = ko.observable();
    self.gameName = ko.observable();

    self.setValues = function (data) {
        self.id(data.id);
        self.gameName(data.gameName);
    };
}