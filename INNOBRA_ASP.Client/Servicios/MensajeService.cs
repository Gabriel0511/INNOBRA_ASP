namespace INNOBRA_ASP.Client.Servicios
{
    public class MensajeService
    {
        // Propiedad para almacenar el mensaje
        private string _mensaje;

        // Propiedad pública para acceder y modificar el mensaje
        public string Mensaje
        {
            get => _mensaje;
            set
            {
                _mensaje = value;
                // Se puede agregar lógica adicional aquí, como un temporizador para borrar el mensaje después de un tiempo
            }
        }
    }
}
