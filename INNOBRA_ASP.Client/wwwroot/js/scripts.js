function generarPDF(contenido) {
    // Crear una instancia de jsPDF
    const doc = new jspdf.jsPDF();

    // Agregar el contenido al PDF
    doc.text(contenido, 10, 10);

    // Guardar el PDF con un nombre de archivo
    doc.save("informe.pdf");
}