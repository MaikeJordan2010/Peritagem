function ValidarNumerosFloat() {

    if ((event.keyCode >= 48) && (event.keyCode <= 57) || (event.keyCode == 46) || (event.keyCode == 44))
    {
        event.returnValue = true;
    }else {
        event.returnValue = false;  
    }

}

function ValidarNumerosInteiro() {

    if ((event.keyCode >= 48) && (event.keyCode <= 57)) {
        event.returnValue = true;
    } else {
        event.returnValue = false;
    }

}


