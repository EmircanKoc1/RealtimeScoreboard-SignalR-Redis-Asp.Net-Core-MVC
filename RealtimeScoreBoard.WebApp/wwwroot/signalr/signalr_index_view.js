$(document).ready(function () {

    console.log("documan yuklendi");

    const hubUrl = "/scoreboardhub";

    var connection = new signalR
        .HubConnectionBuilder()
        .withUrl(hubUrl)
        .withAutomaticReconnect()
        .configureLogging(signalR.LogLevel.Information)
        .build();


    const receiveScoreboardScores = "ReceiveScoreboardScores"; 

    const decreaseScoreboardScore = "DecreaseScoreboardScore"
    const updateScoreboardScore = "UpdateScoreboardScore";
    const increaseScoreboardScore = "IncreaseScoreboardScore";


    function startConnection () {

        connection
            .start()
            .then(() => {
                console.log("Bağlantı başarıyla kuruldu");
            })
            .catch(err => {
                console.log("Bağlantı başlatılamadı", err);
            })      


    }

    try {

        startConnection();

    }
    catch (e) {
        setTimeout(() => startConnection(), 5000);
    }


    connection.on(receiveScoreboardScores, (result) => {
        console.log(result);

    });


    $("#increase-button").click(function () {

        const member = $("#member").val();
        const score = $("#score").val();

        
        connection
            .invoke(increaseScoreboardScore, member, score)
            .catch(err => console.log(err));
    });



})