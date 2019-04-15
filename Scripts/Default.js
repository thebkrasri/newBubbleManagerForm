

var currentTab;
var birthdate = "";
var UseCamera;

function SetUseCamera(bool) {
    UseCamera = bool;
}

function GetUseCamera() {
    return UseCamera;
}


$(function () {
    var c = $.urlParam('Camera');
    if (c != null && c.toLowerCase() == "yes") {
        UseCamera = true;
        document.getElementById('CameraUsed').value = "true";
    }
    else {
        UseCamera = false;
        document.getElementById('CameraUsed').value = "false";
    }
});

function getAge(dateString) {
    var today = new Date();
    var birthDate = new Date(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}


$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    if (results == null) {
        return null;
    }
    else {
        return decodeURI(results[1]) || 0;
    }
}

$(function () {
    currentTab = 0;
    // Current tab is set to be the first tab (0)
    showTab(currentTab); // Display the current tab
});
$(function () {
    var x = document.getElementsByClassName("tab");
    var n = 0;
    while (n < x.length) {
        document.getElementById('stepsDiv').innerHTML += "<span class='step'></span>";
        n++;
    }
});
function showTab(n) {
    // This function will display the specified tab of the form ...
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";
    $('#currentTab').value = n;
    // ... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
        document.getElementById("btnCustomerNumber").style.display = '';
    } else {
        document.getElementById("prevBtn").style.display = "inline";
        document.getElementById("btnCustomerNumber").style.display = 'none';
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").innerHTML = "Submit";
    } else {
        document.getElementById("nextBtn").innerHTML = "Next";
    }
    if (x[n].id == "PhotoPanel") {
        //($.urlParam('Camera') == "Yes") {
        if (UseCamera && (navigator.getUserMedia != null)) {
            SetUseCamera(true);
            loadCamera();
        }
        else if (UseCamera && (navigator.getUserMedia == null)) {
            SetUseCamera(false);
            alert("Camera not available in this browser!");
            loadFileUpload();
        }
        else {
            SetUseCamera(false);
            loadFileUpload();
        }
    }
    // ... and run a function that displays the correct step indicator:
    fixStepIndicator(n)
}

function nextPrev(n) {
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Exit the function if any field in the current tab is invalid:
    if (n == 1 && !validateForm()) return false;
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // if you have reached the end of the form... :
    if (currentTab == x.length) {
        document.getElementById("nextBtn").Text = "Submit";
    }
    if (currentTab >= x.length) {
        //...the form gets submitted:
        document.getElementById("termsModal").style.display = "table";
        x[currentTab - 1].style.display = "none";
        document.getElementById("stepsDiv").style.display = "none";
        document.getElementById("stepbuttons").style.display = "none";
        document.getElementById("optLanguage").style.display = "none";
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}

function validateForm() {
    // This function deals with validation of the form fields
    var x, y, i, valid = true;
    x = document.getElementsByClassName("tab");
    y = x[currentTab].getElementsByTagName("input");
    z = x[currentTab].getElementsByTagName("select");
    // A loop that checks every input field in the current tab:
    if (Page_ClientValidate("validator") == false) {
        valid = false;
    }
    for (i = 0; i < y.length; i++) {
        // If a field is empty...
        if (y[i].type == "radio") {
            if (!$("input:radio[name='" + y[i].name + "']:checked").val()) {
                y[i].classList.add("invalid");
                valid = false;
                document.getElementById(y[i].name).style.border = "5px solid red";
            }
        }

        if (y[i].value == "" && y[i].classList.contains("req")) {
            // add an "invalid" class to the field:
            y[i].className += " invalid";
            // and set the current valid status to false:
            if (y[i].id == "imageData") {
                document.getElementById("cameraAlert").style.display = "block";
                alert("CAPTURE a selfie!")
            }
            if (y[i].id == "FileUpload1") {
                if (document.getElementById("FileUpload1").files.length == 0) {
                    alert("Upload a photo before submiting!");
                    document.getElementById('fileContainer').className += " invalid";
                }
            }
            valid = false;
        }
        if (y[i].Validators != null) {
            var vals = y[i].Validators;
            for (j = 0; j < vals.length; j++) {
                if (vals[j].validationGroup == "validator" && !vals[j].isvalid) {

                    y[i].className += " invalid";
                    // and set the current valid status to false:
                    valid = false;
                }
            }
        }
    }
    for (i = 0; i < z.length; i++) {
        // If a field is empty...
        if (z[i].value == "0" && z[i].classList.contains("req")) {
            // add an "invalid" class to the field:
            z[i].className += " invalid";
            // and set the current valid status to false:
            valid = false;
        }
        if (z[i].Validators != null) {
            var vals = z[i].Validators;
            for (j = 0; j < vals.length; j++) {
                if (vals[j].validationGroup == "validator" && !vals[j].isvalid) {

                    y[i].className += " invalid";
                    // and set the current valid status to false:
                    valid = false;
                }
            }
        }
    }

    if (x[currentTab].id == "PersonalInfoPanel") {
        var birthdate = new Date(document.getElementById("cmbMonth").value + " " + document.getElementById("cmbDay").value + " " + document.getElementById("cmbYear").value);
        var age = getAge(birthdate);
        if (age < 10) {
            var confirmStr = 'You have entered that you are ' + age + ' years old.\nPlease confirm your age.';
            if (confirm(confirmStr) == false) { return; }
        }
    }

    if (x[currentTab].id == "PhotoPanel" && document.getElementById("captureDiv").style.display != "none") {
        alert('Capture a photo!');
        return false;
    }

    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("step")[currentTab].className += " finish";
    }
    return valid; // return the valid status
}

function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    var i, x = document.getElementsByClassName("step");
    if (x.length > 0) {
        for (i = 0; i < x.length; i++) {
            x[i].className = x[i].className.replace(" active", "");
        }
        //... and adds the "active" class to the current step:
        x[n].className += " active";
    }
}

function loadFileUpload() {
    document.getElementById('cameraDiv').style.display = "none";
    document.getElementById('captureDiv').style.display = "none";
    document.getElementById('fileUploadDiv').style.display = "block";
    document.getElementById('imageData').classList.remove('req');
    if (document.getElementById("FileUploadValidator").validationGroup == "Submit") {
        document.getElementById('FileUpload1').className += " req";
    }
}

$(function () {
    $("#FileUpload1").change(function () {
        $("#dvPreview").html("");
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (regex.test($(this).val().toLowerCase())) {
            if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                $("#dvPreview").show();
                $("#dvPreview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
            }
            else {
                if (typeof (FileReader) != "undefined") {
                    $("#dvPreview").show();
                    $("#dvPreview").append("<img />");
                    var reader = new FileReader();
                    h = $("#dvPreview").height;
                    w = $("#dvPreview").width;
                    reader.onload = function (e) {
                        $("#dvPreview img")
                            .attr("src", e.target.result);
                        if ($("#dvPreview img").width > $("#dvPreview img").height) {
                            $("#dvPreview img").width(150);
                            $("#dvPreview img").height = (h / w * 150);
                        } else {
                            $("#dvPreview img").height(150);
                            $("#dvPreview img").width = (w / h * 150);
                        }
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                    alert("This browser does not support FileReader.");
                }
            }
        } else {
            alert("Please upload a valid image file.");
        }
    });
});

function loadCamera() {
    document.getElementById('loadingImg').style.display = "block";
    document.getElementById('cameraDiv').style.display = "inline-block";
    document.getElementById('fileUploadDiv').style.display = "none";
    document.getElementById('imageData').className += " req";
    document.getElementById('FileUpload1').classList.remove('req');
    const player = document.getElementById('player');
    const canvas = document.getElementById('canvas');
    const context = canvas.getContext('2d');
    context.clearRect(0, 0, canvas.width, canvas.height);
    const captureButton = document.getElementById('capture');
    captureButton.style.display = "none";
    const redoButton = document.getElementById('redo');

    if (player.srcObject == null) {
        const constraints = {
            audio: false,
            video: {
                width: 240,
                height: 320
            }
        };
        // Attach the video stream to the video element and autoplay.
        navigator.mediaDevices.getUserMedia(constraints)
            .then(function (stream) {
                player.srcObject = stream;
            })
            .catch(function (err) {
                alert("Webcam could not load\n" + err.name);
                SetUseCamera(false);
                loadFileUpload();
            });
    }
    else {
        loadCaptureDiv();
    }

    player.addEventListener('canplaythrough', function () {
        if (player.srcObject.active) {
            loadCaptureDiv();
        }
        else {
            alert('Unable to use webcam! Check if in use by another app.');
            SetUseCamera(false);
            loadFileUpload();
        }
    })

    captureButton.addEventListener('click', function () {
        document.getElementById('CameraUsed').value = "true";
        // Draw the video frame to the canvas.
        fitImage(context, player);
        document.getElementById('canvasDiv').style.display = "block";
        document.getElementById('captureDiv').style.display = "none";
        // Stop all video streams.
        // player.srcObject.getVideoTracks().forEach(function (track) { track.enabled = false });
        var image = document.getElementById("canvas").toDataURL("image/png").replace('data:image/png;base64,', '');
        document.getElementById('canvas').style.border = "solid 5px green";
        document.getElementById('cameraAlert').style.display = "none";
        $("#imageData").val(image);
        return false;
    });

    function fitImage(context, imageObj) {
        var imageAspectRatio = imageObj.videoWidth / imageObj.videoHeight;
        var canvasAspectRatio = canvas.width / canvas.height;
        var renderableHeight, renderableWidth, xStart, yStart;

        // If image's aspect ratio is less than canvas's we fit on height
        // and place the image centrally along width
        if (imageAspectRatio > canvasAspectRatio) {
            renderableHeight = canvas.height;
            renderableWidth = imageObj.videoWidth * (renderableHeight / imageObj.videoHeight);
            xStart = (canvas.width - renderableWidth) / 2;
            yStart = 0;
        }

        // If image's aspect ratio is greater than canvas's we fit on width
        // and place the image centrally along height
        else if (imageAspectRatio < canvasAspectRatio) {
            renderableWidth = canvas.width
            renderableHeight = imageObj.videoHeight * (renderableWidth / imageObj.videoWidth);
            xStart = 0;
            yStart = (canvas.height - renderableHeight) / 2;
        }

        // Happy path - keep aspect ratio
        else {
            renderableHeight = canvas.height;
            renderableWidth = canvas.width;
            xStart = 0;
            yStart = 0;
        }
        context.drawImage(imageObj, xStart, yStart, renderableWidth, renderableHeight);
    }

    redoButton.addEventListener('click', function () {
        document.getElementById('canvasDiv').style.display = "none";
        var vheight = document.getElementById('player').videoHeight;
        var boxWidth = vheight * .75;
        document.getElementById('pictureBox').style.width = boxWidth + "px";
        document.getElementById('pictureBox').style.border = "3px solid red";
        document.getElementById('captureDiv').style.display = "block";
        captureButton.style.display = "block";
        // Restart video streams.
        //player.srcObject.getVideoTracks().forEach(function (track) { track.enabled = true });
        return false;
    });
    function loadCaptureDiv() {
        document.getElementById('loadingImg').style.display = "none";
        var vheight = document.getElementById('player').videoHeight;
        var boxWidth = vheight * .75;
        document.getElementById('pictureBox').style.width = boxWidth + "px";
        if (imgPreview.src != "") {
            // SetUseCamera(false);
            imgData = imgPreview.src;
            var image = new Image();
            image.onload = function () {
                context.drawImage(image, 0, 0);
            };
            image.src = imgData;
            var hiddenImg = document.getElementById("canvas").toDataURL("image/png").replace('data:image/png;base64,', '');
            $("#imageData").val(hiddenImg);
            document.getElementById('canvasDiv').style.display = "block";
            document.getElementById('captureDiv').style.display = "none";
        }
        else {
            document.getElementById('captureDiv').style.display = "block";
            document.getElementById('pictureBox').style.border = "3px solid red";
            captureButton.style.display = "block";
        }
    }
}

// Get the modal
//var modal = document.getElementById('termsModal');

// Get the button that opens the modal
//var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
//var span = document.getElementsByClassName("close")[0];

$(document).ready(function () {

    $('#btnCustomerNumber').click(function () {
        $('#prevCustomerModal').css('display', 'table');
    })
    // When the user clicks on <span> (x), close the modal
    $('#btnClose').click(function () {
        $(this).closest('.modal').css('display', 'none');
    })

    $('select').change(function () {
        if (this.classList.contains("invalid") && this.value != "0") {
            this.classList.remove("invalid");
        }
    })

    $('input').change(function () {
        if (this.classList.contains("invalid") && this.value != "") {
            this.classList.remove("invalid");
        }
        if (this.id == "FileUpload1" && this.files.length > 0) {
            document.getElementById("fileContainer").classList.remove("invalid");
        }
        if (this.type == "radio" && $("input:radio[name='" + this.name + "']:checked").val());
        this.classList.remove("invalid");
        document.getElementById(this.name).style.border = "none";
    })

    $('#Insurance_0').on('change', function () {
        if ($(this).is(':checked')) {
            $('#InsuranceNameDiv').css("display", "block");
        }
    });
    $('#Insurance_1').on('change', function () {
        if ($(this).is(':checked')) {
            $('#InsuranceNameDiv').css("display", "none");
        }
    });
})
