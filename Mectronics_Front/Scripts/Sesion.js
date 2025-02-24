function obtenerIdUsuario(){
    var usuarioActual = localStorage.getItem("usuario");
    
    if (usuarioActual != null && usuarioActual != undefined){

        var usuario = JSON.parse(usuarioActual);
        return usuario.idUsuario;
    }    
}

function obtenerNombreUsuario(){
    var usuarioActual = localStorage.getItem("usuario");
    
    if (usuarioActual != null && usuarioActual != undefined){

        var usuario = JSON.parse(usuarioActual);
        return usuario.nombre;
    }    
}

function obtenerIdRol(){
    var usuarioActual = localStorage.getItem("usuario");
    
    if (usuarioActual != null && usuarioActual != undefined){

        var usuario = JSON.parse(usuarioActual);
        return usuario.rol.idRol;
    }    
}

function cerrarSesion(){
    localStorage.clear();
    window.location.href = "../Login/Login.html";
}