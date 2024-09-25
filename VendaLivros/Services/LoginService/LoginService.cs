using Microsoft.EntityFrameworkCore;
using VendaLivros.Data;
using VendaLivros.Dto;
using VendaLivros.Models;
using VendaLivros.Services.SenhaService;
using VendaLivros.Services.SessaoService;

namespace VendaLivros.Services.LoginService
{
    public class LoginService : ILoginInterface {
        private readonly ApplicationDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        private readonly ISessaoInterface _sessaoInterface;

        public LoginService(ApplicationDbContext context,
                            ISenhaInterface senhaInterface,
                            ISessaoInterface sessaoInterface) {
            _context = context;
            _senhaInterface = senhaInterface;
            _sessaoInterface = sessaoInterface;
        }

        public async Task<ResponseModel<UsuariosModel>> Login(UsuarioLoginDto usuarioLoginDto) {
            var response = new ResponseModel<UsuariosModel>();

            try {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuarioLoginDto.Email);

                if (usuario == null) {
                    response.Mensagem = "Credenciais inválidas!";
                    response.Status = false;
                    return response;
                }

                if (!_senhaInterface.VerificaSenha(usuarioLoginDto.Senha, usuario.SenhaHash, usuario.SenhaSalt)) {
                    response.Mensagem = "Credenciais inválidas!";
                    response.Status = false;
                    return response;
                }

                // Criar uma sessão
                _sessaoInterface.CriaSessao(usuario);

                response.Mensagem = "Usuário logado com sucesso!";
                response.Status = true; // Adicionado para indicar sucesso
                return response;

            } catch (Exception ex) {
                response.Mensagem = "Erro ao logar: " + ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UsuariosModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto) {
            var response = new ResponseModel<UsuariosModel>();

            try {
                if (await VerificaSeEmailExiste(usuarioRegisterDto)) {
                    response.Mensagem = "Email já cadastrado!";
                    response.Status = false;
                    return response;
                }

                _senhaInterface.CriarSenhaHash(usuarioRegisterDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                var usuario = new UsuariosModel {
                    Nome = usuarioRegisterDto.Nome,
                    Sobrenome = usuarioRegisterDto.Sobrenome,
                    Email = usuarioRegisterDto.Email,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                };

                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();

                response.Mensagem = "Usuário cadastrado com sucesso!";
                response.Status = true;

                return response;

            } catch (Exception ex) {
                response.Mensagem = "Erro ao cadastrar usuário: " + ex.Message;
                response.Status = false;
                return response;
            }
        }

        private async Task<bool> VerificaSeEmailExiste(UsuarioRegisterDto usuarioRegisterDto) {
            return await _context.Usuarios.AnyAsync(x => x.Email == usuarioRegisterDto.Email);
        }
    }
}
