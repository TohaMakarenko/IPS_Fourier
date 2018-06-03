
const serverUrl = '/FFT/RunFFT'

const calculateClick = () => {
    if (!validation()) return;

    // ajaxInterpolationPromised()
    //     .then(
    //       ajaxFuncPromised
    //     )
    //     .then(
    //       ajaxDelta
    //     );

    ajaxFurier()
};

const ajaxFurier = () => {
    // return new Promise((resolve, reject) => {
    // $.ajax({
    //   type: 'POST',
    //   url: serverUrl + '/interpolate',
    //
    //   data: {
    //       startPoint: $('#startPoint').val(),
    //       endPoint: $('#endPoint').val(),
    //       funcStr: $('#funcStr').val(),
    //       nodes: $('#nodes').val()
    //     },
    //
    //   success: (res) => {
    //       drawChart('interpolated', 'int-parent', res[0], res[1], 'interpolated ' + $('#funcStr').val());
    //       $('#interpolated').show();
    //       resolve(res);
    //     }
    // });


    const startPoint = Number.parseFloat($('#startPoint').val()) 
    const endPoint = Number.parseFloat($('#endPoint').val())
    const funcStr = $('#funcStr').val()
    const nodes = Number.parseFloat($('#nodes').val())


    const size = (endPoint - startPoint) / nodes

    const f = math.parse(funcStr)

    let inputArrX = []

    for (var i = 0; i < nodes; i++) {
        inputArrX.push(startPoint + i * size)
    }

    let inputArrY = inputArrX.map((item) => math.eval(funcStr, { x: item }))

    const success = (res) => {
        drawChart('interpolated', 'int-parent', inputArrX, res.result.map((item) => item.real), 'Furier')
        drawChart('func', 'func-parent', inputArrX, inputArrY, $('#funcStr').val());
        $('#func').show();
        $('#interpolated').show()
        // resolve(res)
    }

    $.ajax({
        type: 'POST',
        url: serverUrl,
        contentType: "application/json",
        data: JSON.stringify(inputArrY),

        success: success
    })
    // })
}

// const ajaxFuncPromised = (interpolationRes) => {
//   return new Promise((resolve, reject) => {
//     $.ajax({
//       type: 'POST',
//       url: serverUrl + '/calculate',
//
//       data: {
//         startPoint: $('#startPoint').val(),
//         endPoint: $('#endPoint').val(),
//         funcStr: $('#funcStr').val(),
//         nodes: $('#nodes').val()
//       },
//
//       success: (res) => {
//
//         const transferObj = {
//           interpolationRes: interpolationRes,
//           calculationRes: res
//         };
//
//         drawChart('func', 'func-parent', interpolationRes[0], res, $('#funcStr').val());
//         $('#func').show();
//         resolve(transferObj);
//       }
//     });
//   });
// };


const drawChart = (id, parentId, xArr, yArr, label) => {
    refreshCanvas(id, parentId);

    let deltaChart = new Chart(document.getElementById(id), {
        type: 'line',
        data: {
            labels: xArr,
            datasets: [{
                fill: false,
                lineTension: 0.1,
                backgroundColor: "rgba(75,192,192,0.4)",
                borderColor: "rgba(75,192,192,1)",
                borderCapStyle: 'butt',
                borderDash: [],
                borderDashOffset: 0.0,
                borderJoinStyle: 'miter',
                pointBorderColor: "rgba(75,192,192,1)",
                pointBackgroundColor: "#fff",
                pointBorderWidth: 1,
                pointHoverRadius: 5,
                pointHoverBackgroundColor: "rgba(75,192,192,1)",
                pointHoverBorderColor: "rgba(220,220,220,1)",
                pointHoverBorderWidth: 2,
                pointRadius: 1,
                pointHitRadius: 10,
                label: label,
                data: yArr
            }]
        }
    });
};

const refreshCanvas = (id, parentId) => {
    $('#' + parentId).html('');
    $('#' + parentId).append('<canvas id="' + id + '"><canvas>');
};

const validation = () => {
    if ($('#startPoint').val() >= $('#endPoint').val() ||
        $('#nodes').val() <= 0 || !$('#funcStr').val()) {
        $('#startPoint').css({ 'color': 'red' });
        $('#endPoint').css({ 'color': 'red' });
        $('#funcStr').css({ 'color': 'red' });
        $('#nodes').css({ 'color': 'red' });

        return false;
    }

    $('#startPoint').css({ 'color': 'black' });
    $('#endPoint').css({ 'color': 'black' });
    $('#nodes').css({ 'color': 'black' });
    $('#funcStr').css({ 'color': 'black' });

    return true;
};
