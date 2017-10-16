function GameDetailsPage(id) {
    BasePage.call(this);
    var self = this;

    self.model = new GameModel();
    $.getJSON(window.BACKENDURL + 'game/' +  id).then(self.model.setValues).always(self.dataLoaded);
}