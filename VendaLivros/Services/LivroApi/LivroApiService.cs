using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VendaLivros.Models; // Certifique-se de que este namespace está correto

public class LivroApiService {
    private readonly HttpClient _httpClient;

    public LivroApiService(HttpClient httpClient) {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:7001/api/"); // Ajuste a URL conforme necessário
    }

    public async Task<List<LivrosModel>> ObterTodosLivrosAsync() {
        return await _httpClient.GetFromJsonAsync<List<LivrosModel>>("livros");
    }

    public async Task<LivrosModel> ObterLivroPorIdAsync(int id) {
        return await _httpClient.GetFromJsonAsync<LivrosModel>($"livros/{id}");
    }

    
}
