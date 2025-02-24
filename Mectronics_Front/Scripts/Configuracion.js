const URL_API_AUTENTICACION = 'https://localhost:7152/api/Autenticacion'
const URL_API_BUS = "https://localhost:7116/api/Bus"
const URL_API_CONDUCTOR = "https://localhost:44306/api/Conductor"
function configurarMenu()
{
    var idRolUsuario = obtenerIdRol();

    if (idRolUsuario == 1){
        document.getElementById("opcionMenuGestionBuses").style.display = "block";
        document.getElementById("opcionMenuGestionCond").style.display = "block";
        document.getElementById("opcionMenuGestionProg").style.display = "block";
        document.getElementById("opcionMenuConsultarProg").style.display = "block";       
    }
    else if (idRolUsuario == 2){
        document.getElementById("opcionMenuConsultarProg").style.display = "block";  
    }   
}

function mostrarMensaje(mensaje){
    alertbox.render({
        alertIcon: 'success',
        title: 'Operación Satisfactoria',
        message: mensaje,
        btnTitle: 'Aceptar',
        btnColor: '#1ba32b',
        border:true
      });
}

function mostrarError(mensaje){
    alertbox.render({
        alertIcon: 'error',
        title: 'Se genero un error',
        message: mensaje,
        btnTitle: 'Aceptar',
        btnColor: '#ff8f4d',
        border:true
      });
}