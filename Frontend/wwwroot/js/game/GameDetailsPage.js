function GameDetailsPage(id) {
    BasePage.call(this);
    var self = this;

    self.model = new GameModel();

    function getErrands() {
        return $.getJSON(window.BACKENDURL + 'errand/game/' + id);
    }

    $.getJSON(window.BACKENDURL + 'game/' + id)
        .then(self.model.setValues)
        .then(getErrands)
        .then(self.model.setErrands)
        .always(self.dataLoaded);
}