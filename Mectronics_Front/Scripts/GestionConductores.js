document.addEventListener("DOMContentLoaded", function () {
    configurarMenu();
    cargaTablaConductores();
    cargarEstadoConductores();

    document.getElementById("formularioGuardarConductor").addEventListener("submit", function (event) {
        event.preventDefault();
        guardarConductor();
    });
});

function cargarEstadoConductores() {
    fetch(URL_API_ESTADO_CONDUCTORES)
        .then(response => response.json())
        .then(respuesta => {
            let registrosArray = Array.isArray(respuesta) ? respuesta : respuesta.datos;

            if (!registrosArray || !Array.isArray(registrosArray)) {
                return;
            }

            const select = document.getElementById("estadoConductor");
            select.innerHTML = "";

            let defaultOption = document.createElement("option");
            defaultOption.value = "";
            defaultOption.textContent = "Seleccione un estado";
            defaultOption.disabled = true;
            select.appendChild(defaultOption);

            registrosArray.forEach(registro => {
                let option = document.createElement("option");
                option.value = registro.idEstadoConductor;
                option.textContent = registro.nombreEstadoConductor;
                select.appendChild(option);
            });
        })
        .catch(error => {
            mostrarError(error);
        });
}

function cargaTablaConductores() {
    fetch(URL_API_CONDUCTOR)
        .then(response => response.json())
        .then(resultado => {

            let conductorArray = Array.isArray(resultado) ? resultado : resultado.datos;
            modalGuardarConductor
            if (!conductorArray || !Array.isArray(conductorArray)) {
                console.error("No se recibió un array de Conductores.");
                return;
            }

            const tablaConductores = document.getElementById('tablaConductores');
            tablaConductores.innerHTML = "";

            conductorArray.forEach(conductor => {
                let fila = document.createElement("tr");

                fila.innerHTML = `
                <td>${conductor.idConductor}</td>
                <td>${conductor.usuario.nombre}</td>
                <td>${conductor.usuario.correo}</td>
                <td>${conductor.numeroLicencia}</td>            
                <td>${conductor.estadoConductor.nombreEstadoConductor}</td>            
                <td>
                    <button class="btn btn-warning btn-sm" onclick="cargarConductor(${conductor.idConductor})" data-bs-toggle="modal" data-bs-target="#modalGuardarConductor">
                        Editar
                    </button>
                </td>
            `;

                tablaConductores.appendChild(fila);
            });
        })
        .catch(error => {
            mostrarError(error);
        });
}

function cargarConductor(idConductor) {
    fetch(URL_API_CONDUCTOR + "/" + idConductor, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
        .then(response => response.json())
        .then(resultado => {

            if (resultado.exito) {
                document.getElementById("idConductor").value = resultado.datos.idConductor;
                document.getElementById("idUsuario").value= resultado.datos.usuario.idUsuario;
                document.getElementById("numeroLicencia").value= resultado.datos.numeroLicencia;
                document.getElementById("nombreCompleto").value= resultado.datos.usuario.nombre;
                document.getElementById("correo").value= resultado.datos.usuario.correo;
                document.getElementById("contrasena").value = "noaplicacambio";
                document.getElementById("estadoConductor").value= resultado.datos.estadoConductor.idEstadoConductor;
            } else {
                mostrarError(resultado.mensaje);
            }
        })
        .catch(error => {
            mostrarError(error);
        });
}


function guardarConductor() {

    let idConductor = document.getElementById("idConductor").value;
    let idUsuario = document.getElementById("idUsuario").value;
    var metodo = 'POST';

    const contrasena = document.getElementById("contrasena").value;

    encriptarClave(contrasena).then(contrasenaEncriptada => {
        const numeroLicencia = document.getElementById("numeroLicencia").value;
        const nombreCompleto = document.getElementById("nombreCompleto").value;
        const correo = document.getElementById("correo").value;

        const estadoConductor = document.getElementById("estadoConductor").value;

        const registroConductor = {
            numeroLicencia: numeroLicencia,
            estadoConductor: {
                idEstadoConductor: parseInt(estadoConductor)
            },
            usuario: {
                nombre: nombreCompleto,
                correo: correo,
                contrasena: contrasenaEncriptada,
                rol: {
                    idRol: 2 // Condutor
                }
            }
        };

        if (!idConductor) {
            metodo = 'POST';
        }
        else {
            metodo = 'PATCH';
            registroConductor.idConductor = idConductor;
            registroConductor.usuario.idUsuario = idUsuario;
        }

        fetch(URL_API_CONDUCTOR, {
            method: metodo,
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(registroConductor)
        })
            .then(response => response.json())
            .then(resultado => {
                cerrarModal('modalGuardarConductor');
                if (resultado.exito) {
                    mostrarMensaje(resultado.mensaje);
                    document.getElementById("formularioGuardarConductor").reset();
                    document.getElementById("idConductor").value = "";
                    cargaTablaConductores();
                }
                else {
                    mostrarError(resultado.mensaje);
                }
            })
            .catch(error => {
                cerrarModal('modalGuardarConductor');
                mostrarError(error);
            });
    });
}