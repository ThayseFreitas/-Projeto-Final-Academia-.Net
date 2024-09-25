namespace VendaLivros.Models {
    public class ApiResponseModel {
        public List<LivrosModel> Dados { get; set; }
        public string Mensagem { get; set; }
        public bool Status { get; set; }
    }
}