$('.carousel').carousel({
    interval: 1900
})


searchInput = $("#searchInput");
//microphone
window.SpeechRecognition = window.SpeechRecognition
    || window.webkitSpeechRecognition;

const reco = new SpeechRecognition();
reco.interimResults = true;
reco.lang = "he";
//let p = document.createElement("p");
//const words = document.querySelector(".words");
//words.appendChild(p);

reco.addEventListener("result",
    (e) => {
        const transcript = Array.from(e.results)
            .map((result) => result[0])
            .map((result) => result.transcript)
            .join("");
        searchInput.val(transcript);
        if (e.results[0].isFinal) {
            searchInput.val(transcript);
            $("#searchSubmit").click();
    //        p = document.createElement("p");
      //      words.appendChild(p);
        }
    });

$("#mic").click(function () {
    $("#mic").css("color", "red");
    reco.start();
})



//reco.start();
