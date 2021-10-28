
function getLocation()
{
    if (navigator.geolocation)
    {
        navigator.geolocation.getCurrentPosition(showPosition);
    }
    else
    {
        //x.innerHTML = "O seu navegador não suporta Geolocalização.";
    }
}

function showPosition(position)
{
    var lat = document.getElementById("latitude");
    var lon = document.getElementById("longitude");

    lat.value = position.coords.latitude;
    lon.value = position.coords.longitude;
   
}
