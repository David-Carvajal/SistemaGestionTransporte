function encriptarClave(texto) {
    const encoder = new TextEncoder();
    const data = encoder.encode(texto);

    return crypto.subtle.digest("SHA-256", data).then(hashBuffer => {
        const hashArray = Array.from(new Uint8Array(hashBuffer));
        return hashArray.map(byte => byte.toString(16).padStart(2, "0")).join("");
    });
}