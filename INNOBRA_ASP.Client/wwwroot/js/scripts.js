function generarPDF(contenido) {
    // Crear una instancia de jsPDF
    const doc = new jspdf.jsPDF();

    // Configurar título
    doc.setFont("helvetica", "bold"); // Fuente en negrita
    doc.setFontSize(16);
    doc.text("Informe del Item", doc.internal.pageSize.width / 2, 20, { align: "center" });

    // Configurar contenido
    doc.setFont("helvetica", "normal");
    doc.setFontSize(12);

    // Definir márgenes y ancho máximo para texto
    const margenIzquierdo = 15;
    const margenSuperior = 35;
    const anchoMaximo = 180;

    // Agregar contenido con ajuste automático de línea
    doc.text(contenido, margenIzquierdo, margenSuperior, { maxWidth: anchoMaximo });

    // Guardar el PDF con un nombre de archivo
    doc.save("informe.pdf");
}
