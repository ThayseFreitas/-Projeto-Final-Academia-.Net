using Microsoft.AspNetCore.Mvc;
using VendaLivros.Data;
using VendaLivros.Models;
using VendaLivros.Services.SessaoService;



namespace VendaLivros.Controllers {
    public class LivrosController : Controller {
        private readonly LivroApiService _livroApiService;
        private readonly ApplicationDbContext _db;
        private readonly ISessaoInterface _sessaoInterface;

        // Construtor unificado
        public LivrosController(LivroApiService livroApiService, ApplicationDbContext db, ISessaoInterface sessaoInterface) {
            _livroApiService = livroApiService;
            _db = db;
            _sessaoInterface = sessaoInterface;
        }

        // Método para exibir livros externos
        public async Task<IActionResult> ExibirLivrosExternos() {
            string apiUrl = "https://localhost:7001/api/Livro";
            var livros = await _livroApiService.GetLivrosExternosAsync(apiUrl);
            return View(livros);
        }

        // Página inicial
        public IActionResult Index() {
            var usuario = _sessaoInterface.BuscarSessao();
            if (usuario == null) {
                return RedirectToAction("Login", "Login");
            }

            IEnumerable<LivrosModel> livro = _db.Livros;
            return View(livro);
        }

        // Método GET para cadastrar livro
        [HttpGet]
        public IActionResult Cadastrar() {
            if (!UsuarioAutenticado()) {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        // Método POST para cadastrar livro
        [HttpPost]
        public IActionResult Cadastrar(LivrosModel livro) {
            if (ModelState.IsValid) {
                _db.Livros.Add(livro);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // Método GET para editar livro
        [HttpGet]
        public IActionResult Editar(int? id) {
            if (!UsuarioAutenticado()) {
                return RedirectToAction("Login", "Login");
            }
            if (id == null || id == 0) {
                return NotFound();
            }

            LivrosModel livro = _db.Livros.FirstOrDefault(x => x.Id == id);
            if (livro == null) {
                return NotFound();
            }

            return View(livro);
        }

        // Método POST para editar livro
        [HttpPost]
        public IActionResult Editar(LivrosModel livro) {
            if (ModelState.IsValid) {
                _db.Livros.Update(livro);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";
                return RedirectToAction("Index");
            }
            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar a edição!";
            return View(livro);
        }

        // Método GET para excluir livro
        [HttpGet]
        public IActionResult Excluir(int id) {
            if (!UsuarioAutenticado()) {
                return RedirectToAction("Login", "Login");
            }

            LivrosModel livro = _db.Livros.FirstOrDefault(x => x.Id == id);
            if (livro == null) {
                return NotFound();
            }

            return View(livro);
        }

        // Método POST para excluir livro
        [HttpPost]
        public IActionResult Excluir(LivrosModel livro) {
            if (livro == null) {
                return NotFound();
            }

            _db.Livros.Remove(livro);
            _db.SaveChanges();
            TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";
            return RedirectToAction("Index");
        }

        // Método privado para verificar se o usuário está autenticado
        private bool UsuarioAutenticado() {
            var usuario = _sessaoInterface.BuscarSessao();
            return usuario != null;
        }
    }
}
