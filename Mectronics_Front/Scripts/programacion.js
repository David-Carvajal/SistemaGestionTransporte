document.addEventListener("DOMContentLoaded", function () {
    configurarMenu();
    cargarBuses();
    cargarConductores();
    document.getElementById("formularioGuardarProgramacionBus").addEventListener("submit", function (event) {
        event.preventDefault();
        guardarProgramacionBus();
    });
});

function cargarBuses(){
    fetch(URL_API_BUS + '?IdEstado=2')
        .then(response => response.json())
        .then(respuesta => {
            let registrosArray = Array.isArray(respuesta) ? respuesta : respuesta.datos;

            if (!registrosArray || !Array.isArray(registrosArray)) {
                return;
            }

            const select = document.getElementById("IdBus");
            select.innerHTML = "";

            let defaultOption = document.createElement("option");
            defaultOption.value = "";
            defaultOption.textContent = "Seleccione un bus";
            defaultOption.disabled = true;
            select.appendChild(defaultOption);

            registrosArray.forEach(registro => {
                let option = document.createElement("option");
                option.value = registro.idBus;
                option.textContent = registro.placa;
                select.appendChild(option);
            });
        })
        .catch(error => {
            alertaError(error);
        });
}
function cargarConductores() {
    fetch(URL_API_CONDUCTOR )
        .then(response => response.json())
        .then(respuesta => {

            let registrosArray = Array.isArray(respuesta) ? respuesta : respuesta.datos;

            if (!registrosArray || !Array.isArray(registrosArray)) {
                return;
            }

            const select = document.getElementById("idConductor");
            select.innerHTML = "";

            let defaultOption = document.createElement("option");
            defaultOption.value = "";
            defaultOption.textContent = "Seleccione un bus";
            defaultOption.disabled = true;
            select.appendChild(defaultOption);

            registrosArray.forEach(registro => {
                let option = document.createElement("option");
                option.value = registro.idConductor;
                option.textContent = registro.usuario.nombre;
                select.appendChild(option);
            });
        })
        .catch(error => {
            mostrarError(error);
        });
}

function guardarProgramacionBus() { 
   
    debugger;

    var fecha = document.getElementById("fecha").value;
    var horaEntrada = document.getElementById("horaEntrada").value;
    var horaSalida = document.getElementById("horaSalida").value;
    const idBus = document.getElementById("IdBus").value;
    const idConductor = document.getElementById("idConductor").value;

    const registroBusHorario = {
        fecha: fecha,
        horaEntradaTexto: horaEntrada,
        horaSalidaTexto: horaSalida,
        bus: {
            idBus: idBus
        },
        idConductor: idConductor
    };

    fetch(URL_API_BUS_HORARIOS, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(registroBusHorario)
    })
        .then(response => response.json())
        .then(resultado => {
            if (resultado.exito) {
                mostrarMensaje(resultado.mensaje);
                document.getElementById("formularioGuardarProgramacionBus").reset();                               
            }
            else {                
                mostrarError(resultado.mensaje);
            }
        })
        .catch(error => {            
            mostrarError(error);
        });
}