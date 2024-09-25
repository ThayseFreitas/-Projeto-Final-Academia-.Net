using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using VendaLivros.Models;
using Newtonsoft.Json;

public class LivroApiService {
    private readonly HttpClient _httpClient;

    public LivroApiService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<List<LivrosModel>> GetLivrosExternosAsync(string url) {
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode) {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LivrosModel>>(jsonResponse);
        }

        return null;
    }
}
