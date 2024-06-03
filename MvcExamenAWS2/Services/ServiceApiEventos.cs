using MvcExamenAWS2.Models;
using System.Net.Http.Headers;

namespace MvcExamenAWS2.Services
{
    public class ServiceApiEventos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceApiEventos(KeysModel keys)
        {
            this.UrlApi = keys.ApiEventosExamen;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = "api/eventos";
            List<Evento> eventos = await this.CallApiAsync<List<Evento>>(request);
            return eventos;
        }

        public async Task<List<CategoriaEvento>> GetCategoriasEventosAsync()
        {
            string request = "api/eventos/categoriaseventos";
            List<CategoriaEvento> categorias = await this.CallApiAsync<List<CategoriaEvento>>(request);
            return categorias;
        }

        public async Task<List<Evento>> GetEventosByCategoria(int idcategoria)
        {
            string request = "api/eventos/eventosbycategoria/" + idcategoria;
            List<Evento> eventosCategoria = await this.CallApiAsync<List<Evento>>(request);
            return eventosCategoria;
        }
    }
}
