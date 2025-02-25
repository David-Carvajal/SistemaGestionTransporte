document.addEventListener("DOMContentLoaded", function () {
    configurarMenu();
    cargarProgramacion('');

    document.getElementById("formulario").addEventListener("submit", function (event) {
        event.preventDefault();
        cargarProgramacion(document.getElementById('filtro').value);
    });
});


function cargarProgramacion(filtro) {

    const tablaProgramaciones = document.getElementById('tablaProgramaciones');
            tablaProgramaciones.innerHTML = "";

    fetch(URL_API_BUS_HORARIOS + "?filtroLike=" + filtro)
        .then(response => response.json())
        .then(resultado => {

            let registrosArray = Array.isArray(resultado) ? resultado : resultado.datos;

            if (!registrosArray || !Array.isArray(registrosArray)) {
                return;
            }

            registrosArray.forEach(programacion => {
                let fila = document.createElement("tr");

                const tiempoEntrada = new Date(programacion.horaEntrada).toLocaleTimeString('es-ES', { hour: '2-digit', minute: '2-digit' });
                const tiempoSalida = new Date(programacion.horaSalida).toLocaleTimeString('es-ES', { hour: '2-digit', minute: '2-digit' });
              
                fila.innerHTML = `
                <td>${programacion.bus.placa}</td>
                <td>${programacion.nombreConductor}</td>
                <td>${new Date(programacion.fecha).toLocaleDateString('es-ES')}</td>
                <td>${tiempoEntrada}</td>            
                <td>${tiempoSalida}</td>                            
            `;

                tablaProgramaciones.appendChild(fila);
            });
        })
        .catch(error => {
            mostrarError(error);
        });
}