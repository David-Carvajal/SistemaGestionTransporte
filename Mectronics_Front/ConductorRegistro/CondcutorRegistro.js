document.addEventListener("DOMContentLoaded", function () {
    cargarEstadosConductor();
    cargarUsuarios(); // Solo si es necesario en la inserción del conductor

    document.getElementById("conductorForm").addEventListener("submit", function (event) {
        event.preventDefault();
        insertarConductor();
    });
});

function cargarEstadosConductor() {
    fetch("https://localhost:7225/api/estadoConductor")
        .then(response => response.json())
        .then(data => {
            console.log("Estados de conductor recibidos:", data);

            const selectEstado = document.getElementById("IdEstadoConductor");
            selectEstado.innerHTML = "<option disabled selected>Seleccione un estado</option>";

            data.datos.forEach(estado => {
                let option = document.createElement("option");
                option.value = estado.idEstadoConductor;
                option.textContent = estado.nombreEstado;
                selectEstado.appendChild(option);
            });
        })
        .catch(error => console.error("Error al cargar estados del conductor:", error));
}

function cargarUsuarios() {
    fetch("https://localhost:7225/api/usuarios")
        .then(response => response.json())
        .then(data => {
            console.log("Usuarios recibidos:", data);

            const selectUsuarios = document.getElementById("IdUsuario");
            selectUsuarios.innerHTML = "<option disabled selected>Seleccione un usuario</option>";

            data.datos.forEach(usuario => {
                let option = document.createElement("option");
                option.value = usuario.idUsuario;
                option.textContent = usuario.nombres;
                selectUsuarios.appendChild(option);
            });
        })
        .catch(error => console.error("Error al cargar usuarios:", error));
}

function insertarConductor() {
    const idUsuario = document.getElementById("IdUsuario").value;
    const idEstadoConductor = document.getElementById("IdEstadoConductor").value;
    const numeroLicencia = document.getElementById("NumeroLicencia").value.trim();

    if (!idUsuario || !idEstadoConductor || !numeroLicencia) {
        alert("Todos los campos son obligatorios");
        return;
    }

    const datos = {
        idUsuario: parseInt(idUsuario),
        idEstadoConductor: parseInt(idEstadoConductor),
        numeroLicencia: numeroLicencia
    };

    console.log("Datos a enviar:", datos);

    fetch("https://localhost:7225/api/conductor", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(datos)
    })
    .then(response => response.json())
    .then(data => {
        console.log("Respuesta del servidor:", data);
        alert("Conductor registrado con éxito");
    })
    .catch(error => console.error("Error al insertar el conductor:", error));
}
