
function check() {
    if (document.cameraForm.cam[0].checked) {
        document.getElementById("downloadCam").innerHTML =
            `<input type="file" accept="image/jpeg">`
        document.getElementById("camera").innerHTML =
            `Сделать фото`
    }
    if (document.cameraForm.cam[1].checked) {
        document.getElementById("downloadCam").innerHTML =
            `Загрузить Фото`
        document.getElementById("camera").innerHTML =
            `<div id="myCam" >sfas</div>
                <button type="button" onclick="Cam()">Сделать</button>
               <button type="button" onclick="startCam()">Заново</button>`
        startCam();
    }
}



function startCam() {
    Webcam.set({
        wight: 450,
        height: 450,
        image_format: "jpeg",
        jpeg_quality: 90
    });
    Webcam.attach('#myCam');
}

function Cam() {
    take_snapshot();
}

function take_snapshot() {
    Webcam.snap(function (data_uri) {
        document.getElementById('myCam').innerHTML =
            `<img src="${data_uri}">`
    });
    Webcam.off();

}