document.getElementById("formularioAutenticacion").addEventListener("submit", async function (event) {

    event.preventDefault();

    
    var correo = document.getElementById("login-email").value;
    var contrasena = document.getElementById("login-password").value;

    
    encriptarClave(contrasena).then(contrasenaEncriptada => {
       
        var autenticacion = { correo, contrasena: contrasenaEncriptada };

        
        fetch(URL_API_AUTENTICACION, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(autenticacion)
        })
            .then(response => response.json())
            .then(resultado => {

                console.log("Respuesta de la API:", resultado);

                if (resultado.exito == true) {
                    mostrarMensaje(resultado.mensaje);

                    localStorage.clear();
                    localStorage.setItem("usuario", JSON.stringify(resultado.datos));
                    window.location.href = "../MenuPrincipal/Inicio.html";
                }
                else {
                    mostrarError(resultado.mensaje);
                }
            })
            .catch(error => {
                mostrarError(error);
            });


    });
});