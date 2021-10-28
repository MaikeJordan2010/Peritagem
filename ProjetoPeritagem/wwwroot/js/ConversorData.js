function converterDataUs(data) {
    var dt = data.split(" ")[0];

    var ano = dt.split("/")[2];
    var mes = dt.split("/")[1];
    var dia = dt.split("/")[0];
    return ano + "-" + mes + "-" + dia;
}