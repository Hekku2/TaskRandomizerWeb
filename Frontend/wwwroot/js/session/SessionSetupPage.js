function SessionSetupPage() {
    BasePage.call(this);
    var self = this;

    self.games = ko.observableArray();
    self.selectedGame = ko.observable();
    self.selectedGame.subscribe(gameSelected);
    self.errandList = new ErrandListModel();

    self.startGame = function () {
        //Create session
        //Navigate to lobby
    };

    self.gameSetupReady = ko.computed(function (){
        return self.selectedGame() && self.errandList.errands().length > 0;
    });

    function gameSelected(game) {
        if (game) {
            self.errandList.startLoading();
            getErrands(game.id()).then(self.errandList.setErrands);
        } else {
            self.errandList.isInitialized(false);
        }
    }

    function setGames(data) {
        self.games(_.map(data, createGameModel));
    }

    function createGameModel(item) {
        var model = new GameModel();
        model.setValues(item);
        return model;
    }

    function getGames() {
        return $.getJSON(window.BACKENDURL + 'game');
    }

    function getErrands(gameId) {
        return $.getJSON(window.BACKENDURL + 'errand/game/' + gameId);
    }

    getGames().then(setGames).always(self.dataLoaded);
}