function setFile(input) {
    var reader = new FileReader();
    var file = input.files[0];
    var img = document.querySelector(".profile-pic");

    reader.readAsDataURL(file);
    reader.onload = function () {
        img.src = reader.result;
    }
}