
$(function () {
    var ctx = document.getElementById("Chart").getContext('2d');
    $.ajax({

        url: "Listar.aspx/getChartData",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var chartLabel = eval(response.d[0]); //Labels
            var chartData = eval(response.d[1]); //Data
            var barData = {
                labels: chartLabel,
                datasets: [
                    {
                        label: 'R$ ',
                        backgroundColor: "rgba(127,244,144,0.8)",
                        borderColor: "rgba(127,127,127,0.5)",
                        borderWidth: 1,
                        hoverBackgroundColor: "rgba(44,163,61,0.9)",
                        hoverBorderColor: "rgba(127,127,127,0.8)",
                        data: chartData
                    }
                ]
            };
            //var skillsChart = new Chart(ctx).Line(barData);

            var myNewChart = new Chart(ctx, {
                type: "bar",

                data: barData,


                options: {
                    responsive: true,

                    scales: {
                        xAxes: [{
                            display: true,
                            scaleLabel: {
                                display: true,
                                labelString: 'Meses de 2017'
                            }
                        }],
                        yAxes: [{
                            display: true,
                            scaleLabel: {
                                display: true,
                                labelString: 'Valor em R$'
                            }
                        }]
                    }
                }
            });
        }
    });
});

