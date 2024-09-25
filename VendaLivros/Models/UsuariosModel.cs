using System.ComponentModel.DataAnnotations;


namespace VendaLivros.Models {
    public class UsuariosModel {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        public string Login { get; set; }

        [Required(ErrorMessage = "O Sobrenome é obrigatório.")]
        public string Sobrenome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;

        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizãcao { get; set; }
    }
}