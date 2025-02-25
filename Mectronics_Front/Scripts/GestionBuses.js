document.addEventListener("DOMContentLoaded", () => {
    configurarMenu();
    cargaTablaBuses();
    cargarEstadoBuses();

    document.getElementById("formularioGuardarBuses").addEventListener("submit", function (event) {
        event.preventDefault();
        guardarBus();
    });
});

function cargarEstadoBuses() {
    fetch(URL_API_ESTADO_BUS)
        .then(response => response.json())
        .then(respuesta => {
            let registrosArray = Array.isArray(respuesta) ? respuesta : respuesta.datos;

            if (!registrosArray || !Array.isArray(registrosArray)) {
                return;
            }

            const select = document.getElementById("idEstado");
            select.innerHTML = "";

            let defaultOption = document.createElement("option");
            defaultOption.value = "";
            defaultOption.textContent = "Seleccione un estado";
            defaultOption.disabled = true;
            select.appendChild(defaultOption);

            registrosArray.forEach(registro => {
                let option = document.createElement("option");
                option.value = registro.idEstadoBus;
                option.textContent = registro.nombreEstadoBus;
                select.appendChild(option);
            });
        })
        .catch(error => {
            alertaError(error);
        });
}

function cargaTablaBuses() {
    fetch(URL_API_BUS, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
        .then(response => response.json())
        .then(resultado => {
            if (resultado.exito) {
                llenarTablaBuses(resultado.datos);
            } else {
                mostrarError(resultado.mensaje);
            }
        })
        .catch(error => {
            console.error("Error al obtener los datos:", error);
            mostrarError("Error al cargar los buses.");
        });
}

function llenarTablaBuses(buses) {

    let tbody = document.querySelector("tbody");
    tbody.innerHTML = "";

    buses.forEach(bus => {

        let fila = document.createElement("tr");

        fila.innerHTML = `
            <td>${bus.idBus}</td>
            <td>${bus.modelo}</td>
            <td>${bus.capacidad}</td>
            <td>${bus.placa}</td>
            <td>${bus.estadoBus.nombreEstadoBus}</td> 
            <td>
                <button class="btn btn-primary btn-sm" onclick="cargarBus(${bus.idBus})" data-bs-toggle="modal" data-bs-target="#modalGuardarBus">
                    Editar
                </button>                
            </td>           
        `;

        tbody.appendChild(fila);
    });
}

function cargarBus(idBus) {
    fetch(URL_API_BUS + "/" + idBus, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
        .then(response => response.json())
        .then(resultado => {

            if (resultado.exito) {
                document.getElementById("idBus").value = resultado.datos.idBus;
                document.getElementById("modelo").value = resultado.datos.modelo;
                document.getElementById("capacidad").value = resultado.datos.capacidad;
                document.getElementById("placa").value = resultado.datos.placa;
                document.getElementById("idEstado").value =  resultado.datos.estadoBus.idEstadoBus;
            } else {
                mostrarError(resultado.mensaje);
            }
        })
        .catch(error => {            
            mostrarError(error);
        });
}

function guardarBus() {

    let idBus = document.getElementById("idBus").value;
    var metodo = 'POST';

    const modelo = document.getElementById("modelo").value;
    const capacidad = document.getElementById("capacidad").value;
    const placa = document.getElementById("placa").value;
    const idEstado = document.getElementById("idEstado").value;

    const registroBus = {
        modelo: modelo,
        capacidad: parseInt(capacidad),
        placa: placa,
        estadoBus: {
            idEstadoBus: idEstado
        }
    };

    if (!idBus) {
        metodo = 'POST';
    }
    else {
        metodo = 'PATCH';
        registroBus.idBus = idBus;
    }

    fetch(URL_API_BUS, {
        method: metodo,
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(registroBus)
    })
        .then(response => response.json())
        .then(resultado => {
            cerrarModal('modalGuardarBus');
            if (resultado.exito) {
                mostrarMensaje(resultado.mensaje);
                document.getElementById("formularioGuardarBuses").reset();
                document.getElementById("idBus").value = "";
                cargaTablaBuses();
            }
            else {                
                mostrarError(resultado.mensaje);
            }
        })
        .catch(error => {
            cerrarModal('modalGuardarBus');
            mostrarError(error);
        });
}