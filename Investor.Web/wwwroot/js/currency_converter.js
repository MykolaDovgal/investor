$(document).ready(function () {

    const hasStorage = ("sessionStorage" in window && window.sessionStorage);
    const storageKey = "currensy";
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

                    const locContent = {
                        "USD": parseFloat(Math.round(content[34]["rate"] * 100) / 100).toFixed(2),
                        "EUR": parseFloat(Math.round(content[42]["rate"] * 100) / 100).toFixed(2)
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



