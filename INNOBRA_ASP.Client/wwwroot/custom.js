window.confirmSwal = async function () {
    const result = await Swal.fire({
        title: "¿Estás seguro?",
        text: "¡Esta acción no se puede deshacer!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Sí",
        cancelButtonText: "Cancelar"
    });
    return result.isConfirmed;
};

//Inicio de sesion
    function openModal() {
        document.getElementById("modal").style.display = "block";
    }

    function closeModal() {
        document.getElementById("modal").style.display = "none";
    }

    // Cerrar el modal si se hace clic fuera de él
    window.onclick = function (event) {
        const modal = document.getElementById("modal");
    if (event.target === modal) {
        closeModal();
        }
}
