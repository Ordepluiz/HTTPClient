using HTTPClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTPClient.Services
{
    public class PostService
    {
        private HttpClient httpClient;
        private Post post;
        private ObservableCollection<Post> posts;
        private JsonSerializerOptions jsonSerializerOptions;

        public PostService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<Post>> getPost()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
            ObservableCollection<Post> items = new ObservableCollection<Post>();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string contant = await response.Content.ReadAsStringAsync();
                    items = JsonSerializer.Deserialize<ObservableCollection<Post>>(contant, jsonSerializerOptions);
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
