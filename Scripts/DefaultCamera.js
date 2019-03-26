

var currentTab = 0;
var birthdate = "";

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

$(function () {
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
    // ... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
    } else {
        document.getElementById("prevBtn").style.display = "inline";
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").innerHTML = "Submit";
    } else {
        document.getElementById("nextBtn").innerHTML = "Next";
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
        document.getElementById("termsModal").style.display = "block";
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}

// When the user clicks the "Submit", open the modal
/* myBtn.onclick = function () {
    if (typeof (Page_ClientValidate) == 'function') {
        Page_ClientValidate("Submit");
    }
    var birthdate = new Date(document.getElementById("cmbMonth").value + " " + document.getElementById("cmbDay").value + " " + document.getElementById("cmbYear").value);
    var age = getAge(birthdate);
    if (age < 10) {
        var confirmStr = 'You have entered that you are ' + age + ' years old.\nPlease confirm your age.';
        if (confirm(confirmStr) == false) { return; }
    }

    if (Page_IsValid) {
        //do something
        if ('<%= Session["ShowTerms"] %>' == 'True') {
            modal.style.display = "block";
        }
        else { btnShipper.click(); }
    }
    else {
        alert('Please fill in ALL required fields');
    }

} */
$('#optLanguage').change(function (d) {
    var language = $(this).val();//d.value;

    $.ajax({
        type: "POST",
        url: '<%=ResolveUrl("DefaultCamera.aspx/ChangeLang") %>',
        cache: false,
        data: '{ lang: "' + language + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            $(".tab").load(location.href + " .tab>*", "");
        },
        error: function () {
            alert("failed");
        }

    });
    return false;
});

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
        if (y[i].value == "" && y[i].classList.contains("req")) {
            // add an "invalid" class to the field:
            y[i].className += " invalid";
            // and set the current valid status to false:
            valid = false;
        }
        if (y[i].Validators != null)
        {
            var vals = y[i].Validators;     
            for (j = 0; j < vals.length; j++)
            {
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
        if (z[i].Validators != null)
        {
            var vals = z[i].Validators;     
            for (j = 0; j < vals.length; j++)
            {
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

    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("step")[currentTab].className += " finish";
    }
    return valid; // return the valid status
}

function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    var i, x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    //... and adds the "active" class to the current step:
    x[n].className += " active";
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

$(function () {
    const urlParams = new URLSearchParams(window.location.search);
    const useCamera = urlParams.get('Camera');
    if (useCamera == "Yes") {
        navigator.permissions.query({ name: 'camera' })
            .then((permissionObj) => {
                console.log(permissionObj.state);
            })
            .catch((error) => {
                console.log('Got error :', error);
            })
        document.getElementById('cameraDiv').style.display = "inline-block";
        document.getElementById('fileUploadDiv').style.display = "none";
        const player = document.getElementById('player');
        const canvas = document.getElementById('canvas');
        const context = canvas.getContext('2d');
        const captureButton = document.getElementById('capture');
        const saveButton = document.getElementById('btnSave');
        const redoButton = document.getElementById('redo');

        const constraints = {
            video: { width: 240, height: 320 }
        };
        // Attach the video stream to the video element and autoplay.
        navigator.mediaDevices.getUserMedia(constraints)
            .then((stream) => {
                player.srcObject = stream;
            });
        captureButton.addEventListener('click', () => {
            // Draw the video frame to the canvas.
            context.drawImage(player, 0, 0, canvas.width, canvas.height);
            //img.src = canvas.toDataURL('image/webp');
            document.getElementById('canvasDiv').style.display = "block";
            document.getElementById('captureDiv').style.display = "none";
            // Stop all video streams.
            player.srcObject.getVideoTracks().forEach(track => track.enabled = false);
            return false;
        });

        redoButton.addEventListener('click', () => {
            document.getElementById('canvasDiv').style.display = "none";
            document.getElementById('captureDiv').style.display = "block";
            // Stop all video streams.
            player.srcObject.getVideoTracks().forEach(track => track.enabled = true);
            return false;
        });


    }
    else {
        document.getElementById('cameraDiv').style.display = "none";
        document.getElementById('fileUploadDiv').style.display = "block";

    }
    $("#btnSave").click(function () {

        var image = document.getElementById("canvas").toDataURL("image/png");
        //  image = image.replace('data:image/png;base64,', '');

        $.ajax({
            type: 'POST',
            url: "../",
            data: '{"imageData" : "' + image + '" }',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (msg) {
                alert('Image saved successfully !');
            },
            error: function (msg) {
                alert('failed');
            }
        });
    });
})


function displayWhenChecked(checkBox, element) {
    var checkBox = document.getElementById(checkBox);
    // Get the output text
    var text = document.getElementById(element);

    // If the checkbox is checked, display the output text
    if (checkBox.checked == true) {
        text.style.display = "block";
    } else {
        text.style.display = "none";
    }
}

$('#Insurance').change(function () {
    displayWhenChecked("Insurance", "InsuranceNameDiv");
})


// Get the modal
var modal = document.getElementById('termsModal');

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on <span> (x), close the modal

$(document).ready(function () {
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
    })
})


