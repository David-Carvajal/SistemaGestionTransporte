document.addEventListener("DOMContentLoaded", () => {
    configurarMenu();  
    cargaTablaBuses();

});
function cargaTablaBuses() {
    fetch(URL_API_BUS, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then(response => response.json())  
    .then(resultado => {
        console.log("Datos de la API de buses:", resultado);
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
            <td>${bus.estadoBus}</td>
            
        `;

        tbody.appendChild(fila);
    });
}
