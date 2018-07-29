function HomeViewModel(app, dataModel) {
    var self = this;

    self.myHometown = ko.observable("");
    self.bitcoinRealTimeData = ko.observable("");

    Sammy(function () {
        this.get('#home', function () {
            // Make a call to the protected Web API by passing in a Bearer Authorization Header
            $.ajax({
                method: 'get',
                url: app.dataModel.userInfoUrl,
                contentType: "application/json; charset=utf-8",
                headers: {
                    'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                },
                success: function (data) {
                    self.myHometown('Your Hometown is : ' + data.hometown);
                }
            });
        });
        this.get('/', function () { this.app.runRoute('get', '#home'); });
    });

    //setting a recurrent http call to get bitcoin realtime 
    $(document).ready(function () {
        setInterval(function () {
            $.ajax({
                type: "GET",
                url: app.dataModel.bitcoinRealDataUrl,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    self.bitcoinRealTimeData = $("#tableBitcoinRatio");
                    var tr = $("<tr></tr>");
                    tr.html(
                        + " " + ("<td>" + data.high + "</td>")
                        + " " + ("<td>" + data.last + "</td>")
                        + " " + ("<td>" + data.timestamp + "</td>")
                        + " " + ("<td>" + data.bid + "</td>")
                        + " " + ("<td>" + data.vwap + "</td>")
                        + " " + ("<td>" + data.volume + "</td>")
                        + " " + ("<td>" + data.low + "</td>")
                        + " " + ("<td>" + data.ask + "</td>")
                        + " " + ("<td>" + data.open + "</td>")
                    );
                    self.bitcoinRealTimeData.append(tr);
                }
            });
        }, 1000);

    });



    return self;
}

app.addViewModel({
    name: "Home",
    bindingMemberName: "home",
    factory: HomeViewModel
});
