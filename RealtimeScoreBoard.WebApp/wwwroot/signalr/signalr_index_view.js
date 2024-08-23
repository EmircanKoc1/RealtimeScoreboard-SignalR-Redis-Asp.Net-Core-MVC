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
    const receiveConnectedClientCount = "ReceiveConnectedClientCount";

    const firstLoadingScoreboardScore = "FirstLoadingScoreboardScore"

    const decreaseScoreboardScore = "DecreaseScoreboardScore"
    const updateScoreboardScore = "UpdateScoreboardScore";
    const increaseScoreboardScore = "IncreaseScoreboardScore";
    function startConnection () {

        connection
            .start()
            .then(() => {
                console.log("Bağlantı başarıyla kuruldu");
                connection
                        .invoke(firstLoadingScoreboardScore)
                        .catch(err => console.log(err));
               
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
        WriteTableData(result)
        
    });
    function WriteTableData(result) {

        if (Array.isArray(result)) {
            var tbody = document.getElementById("table-tbody");

            while (tbody.firstChild) {
                tbody.removeChild(tbody.firstChild);
            }

            result.forEach(keyValuePair => {
                //console.log(x.key, x.value);
                //datas.push(new DataItem(x.key,x.value));



                var row = document.createElement("tr");
                var cell1 = document.createElement("td")
                var cell2 = document.createElement("td");
                cell1.textContent = keyValuePair.key;
                cell2.textContent = keyValuePair.value;

                row.appendChild(cell1);
                row.appendChild(cell2);

                tbody.appendChild(row);



            });
        }
        else {
            console.log(result);
        }
    }


    connection.on(receiveConnectedClientCount, (count) => {
        console.log("connected count : ", count);
        $("#connected-count").html(count);

    });
    $("#increase-button").click(function () {

        const member = $("#member").val();
        const score = parseFloat($("#score").val());

        
        connection
            .invoke(increaseScoreboardScore, member, score)
            .catch(err => console.log(err));
    });
    $("#decrease-button").click(function () {

        const member = $("#member").val();
        const score = parseFloat($("#score").val());


        connection
            .invoke(decreaseScoreboardScore, member, score)
            .catch(err => console.log(err));
    });
    $("#update-button").click(function () {

        const member = $("#member").val();
        const score = parseFloat($("#score").val());


        connection
            .invoke(updateScoreboardScore, member, score)
            .catch(err => console.log(err));
    });

    


})