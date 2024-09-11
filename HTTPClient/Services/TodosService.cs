using HTTPClient.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTPClient.Services
{
    public class TodosService
    {
        private HttpClient httpClient;
        private JsonSerializerOptions jsonSerializerOptions;

        public TodosService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<Todos>> getTodos()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/todos");
            ObservableCollection<Todos> items = new ObservableCollection<Todos>();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    items = JsonSerializer.Deserialize<ObservableCollection<Todos>>(content, jsonSerializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return items;
        }
    }
}
