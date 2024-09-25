using System.ComponentModel.DataAnnotations;

namespace VendaLivros.Models {
    public class LivrosModel {

        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o título do livro!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Digite o nome do autor do livro!")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Digite a descrição do livro!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite o preço do livro!")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Digite o estado de conservação do livro!")]
        public string EstadoConservacao { get; set; }
        public DateTime dataUltimaAtualizacao { get; set; } = DateTime.Now;

    }

}








