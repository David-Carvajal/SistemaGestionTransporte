document.addEventListener("DOMContentLoaded", function () {
    configurarMenu();
    cargaTablaConductores();
    document.getElementById("tablaConductores").addEventListener("submit", function (event) {
        event.preventDefault();
    });

    function cargaTablaConductores() {
        fetch("https://localhost:44306/api/Conductor")
            .then(response => {
                if (!response.ok) {
                    throw new Error('Error HTTP: ${response.status}');
                }
                return response.json();
            })
            .then(data => {
                console.log("Condutores Recibidos:", data);

                let conductorArray = Array.isArray(data) ? data : data.conductores;

                if (!conductorArray || !Array.isArray(conductorArray)) {
                    console.error("No se recibió un array de Conductores.");
                    return;
                }

                const tablaConductores = document.getElementById(tablaConductores);
                tablaConductores.innerHTML = "";

                conductores.forEach(conductor => {
                    let fila = document.createElement("tr");

                    fila.innerHTML = `
            <td>${conductor.idConductor}</td>
            <td>${conductor.numeroLicencia}</td>
            <td>${conductor.estadoConductor.idEstado}</td>
            <td>${conductor.estadoConductor.nombre}</td>
            <td>${conductor.usuario.idUsuario}</td>
                    <td>
                        <button class="btn btn-warning btn-sm" onclick="cargarMateriaParaEditar(${materia.idMateria})" data-bs-toggle="modal" data-bs-target="#modalRegistroMateria">
                            Editar
                        </button>
                    </td>
                `;

                    tablaMaterias.appendChild(fila);
                });
            })
            .catch(error => {
                console.error("Error al cargar las materias:", error);
                alertaError("No se pudieron cargar las materias.");
            });
    }

    function llenarTablaConductores(conductores) {
        let tbody = document.querySelector("tbody");
        tbody.innerHTML = "";

        const tablaConductores = document.getElementById(tablaConductores);
        tablaConductores.innerHTML = "";

        conductores.forEach(conductor => {
            let fila = document.createElement("tr");

            fila.innerHTML = `
            <td>${conductor.idConductor}</td>
            <td>${conductor.numeroLicencia}</td>
            <td>${conductor.estadoConductor.idEstado}</td>
            <td>${conductor.estadoConductor.nombre}</td>
            <td>${conductor.usuario.idUsuario}</td>
        `;
            tbody.appendChild(fila);
        });
    }
})