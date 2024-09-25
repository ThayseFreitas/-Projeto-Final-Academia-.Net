using Newtonsoft.Json;
using VendaLivros.Models;

namespace VendaLivros.Services.SessaoService
{
    public class SessaoService : ISessaoInterface
    {

        private readonly IHttpContextAccessor _contextAccessor;
        public SessaoService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public UsuariosModel BuscarSessao()
        {
            var sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuario");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UsuariosModel>(sessaoUsuario);
        }

        public void CriaSessao(UsuariosModel usuariosModel)
        {
            var usuarioJson = JsonConvert.SerializeObject(usuariosModel);
            _contextAccessor.HttpContext.Session.SetString("sessaoUsuario", usuarioJson);
        }

        public void RemoveSessao()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuario");
        }
    }
}
