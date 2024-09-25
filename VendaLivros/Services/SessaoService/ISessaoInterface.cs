using VendaLivros.Models;

namespace VendaLivros.Services.SessaoService
{
    public interface ISessaoInterface
    {
        UsuariosModel BuscarSessao();
        void CriaSessao(UsuariosModel usuariosModel);
        void RemoveSessao();


    }
}
