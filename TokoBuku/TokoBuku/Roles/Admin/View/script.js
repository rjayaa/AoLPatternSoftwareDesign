
function validNumeric() {
    var charcode = (event.which) ? event.which : event.keyCode;
    if (charcode >= 48 && charcode <= 57) {
        return true;
    }
    else {
        return false;
    }
}

function validNumericAndLength() {
    var charcode = (event.which) ? event.which : event.keyCode;
    if (charcode >= 48 && charcode <= 57) {
        if (event.target.value.length >= 4) {
            return false;
        }
        return true;
    }
    else {
        return false;
    }
}

