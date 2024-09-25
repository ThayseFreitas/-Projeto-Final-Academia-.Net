using Microsoft.AspNetCore.Mvc;
using VendaLivros.Models;

[Route("api/[controller]")]
[ApiController]
public class LivrosVendaController : ControllerBase {
    private readonly LivroApiService _livroApiService;

    public LivrosVendaController(LivroApiService livroApiService) {
        _livroApiService = livroApiService;
    }

    [HttpGet]
    public async Task<ActionResult<List<LivrosModel>>> GetTodosLivros() {
        var livros = await _livroApiService.ObterTodosLivrosAsync();
        return Ok(livros);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LivrosModel>> GetLivro(int id) {
        var livro = await _livroApiService.ObterLivroPorIdAsync(id);
        if (livro == null) {
            return NotFound();
        }
        return Ok(livro);
    }

    
}
