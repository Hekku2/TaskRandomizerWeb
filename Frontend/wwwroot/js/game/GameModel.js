function GameModel(){
    var self = this;
    self.id = ko.observable();
    self.name = ko.observable();

    self.setValues = function (item){
        self.id(item.id);
        self.name(item.name);
    }
}