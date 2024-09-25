using System.ComponentModel.DataAnnotations;

namespace VendaLivros.Dto {
    public class UsuarioRegisterDto {
        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Sobrenome!")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Digite o Email!")]
        [EmailAddress(ErrorMessage = "Email inválido!")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a Senha!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A Senha deve ter pelo menos 6 caracteres.")] 
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme a Senha!")]
        [Compare("Senha", ErrorMessage = "As Senhas não estão iguais!")]
        public string ConfirmaSenha { get; set; }
    }
}
