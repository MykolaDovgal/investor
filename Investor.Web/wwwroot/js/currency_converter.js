$(document).ready(function () {

    const hasStorage = ("sessionStorage" in window && window.sessionStorage);
    const storageKey = "_currensy";
    let data = false;

    if (hasStorage) {
        data = sessionStorage.getItem(storageKey);
        if (data) {
            data = JSON.parse(data);
            const now = new Date();
            const expiration = new Date(data.timestamp);
            expiration.setMinutes(expiration.getMinutes() + 30);

            if (now.getTime() > expiration.getTime()) {
                data = false;
                sessionStorage.removeItem(storageKey);
            }
        }
    }

    if (data) {
        setCurrency(data.content.USD, data.content.EUR);
    }
    else {

        $.ajax({
            url: "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json",
            success: function (content) {

                if (hasStorage) {
                    const eurRate = content.find(c => c["cc"] === "EUR");
                    const usdRate = content.find(c => c["cc"] === "USD");
                    console.log(eurRate);
                    const locContent = {
                        "USD": parseFloat(Math.round(usdRate["rate"] * 100) / 100).toFixed(2),
                        "EUR": parseFloat(Math.round(eurRate["rate"] * 100) / 100).toFixed(2)
                    };

                    sessionStorage.setItem(storageKey, JSON.stringify({
                        timestamp: new Date(),
                        content: locContent
                    }));

                    setCurrency(locContent.USD, locContent.EUR);

                }
                
            }
        });
    }


});


let setCurrency = function (usd, eur) {
    $("#USD").text(`USD ${usd}`);
    $("#EUR").text(`EUR ${eur}`);
}



