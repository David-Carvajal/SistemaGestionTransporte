document.getElementById("formularioAutenticacion").addEventListener("submit", async function (event) {

    event.preventDefault();

    var correo = document.getElementById("login-email").value;
    var contrasena = document.getElementById("login-password").value;

    encriptarClave(contrasena).then(contrasenaEncriptada => {
       
        console.log(contrasenaEncriptada);

    });
});