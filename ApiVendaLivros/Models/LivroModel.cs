using System.ComponentModel.DataAnnotations;

namespace ApiLivros.Model {
    public class LivroModel {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(100)]
        public string Autor { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(100)]
        public string EstadoConservacao { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}