namespace INNOBRA_ASP.Client.Servicios
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<object>> Delete(string url);
        Task<HttpRespuesta<T>> Get<T>(string url);
        Task<HttpRespuesta<object>> Post<T>(string url, T entidad);
        Task<HttpRespuesta<object>> Put<T>(string url, T entidad);
    }
}