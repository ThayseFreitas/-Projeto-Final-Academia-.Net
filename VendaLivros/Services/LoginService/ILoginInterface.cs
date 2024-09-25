using VendaLivros.Dto;
using VendaLivros.Models;

namespace VendaLivros.Services.LoginService {
    
    public interface ILoginInterface {
        Task<ResponseModel<UsuariosModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto);
        Task<ResponseModel<UsuariosModel>> Login(UsuarioLoginDto usuarioLoginDto); 
    }
}
