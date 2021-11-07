$(document).ready(function () {

    $('body').on('click', 'button#convert', function (e) {
        console.log('clicked');
        let amount = $('input#amount').val() || $('input#amount').attr('placeholder') || '';
        let exchangeRate = $('input#exchange-rate').val() || $('input#exchange-rate').attr('placeholder') || '';
        if (amount == '' || exchangeRate == '') {
            alert('Please enter an appropriate amount or exchange rate value.');
        } else {
            convert(amount, exchangeRate);
        }
    });

    function convert(amount, exchangeRate) {
        $.ajax({
            url: `https://localhost:44314/api/converter/convert/${amount}/${exchangeRate}`,
            method: 'get',
            success: function (result) {
                console.log(result);
                $('label.result').text("Result: " + result);
            },
            error: function (errors) {
                alert("There was an error. Please try again.");
                console.log(errors);
            }
        });
    }

});