function getAllSelected(id) {
    //alert(id);
    var e = document.getElementById(id);
    var val = "";
    var x = 0;

    for (x = 0; x < e.length; x++) {
        if (e[x].selected) {
            //alert(e[x].value);
            val = val + "," + e[x].value+",";
        }
    }
    return val;
}
function setAllSelected(id,value) {
    //alert(id);
    var e = document.getElementById(id);
    //var val = "";
    var x = 0;

    for (x = 0; x < e.length; x++) {
        e[x].selected = false;
        if (value.indexOf(","+e[x].value+",")>=0) {
            //alert(e[x].value);
            //val = val + "," + e[x].value;
            e[x].selected = true;
        }
    }
    
}