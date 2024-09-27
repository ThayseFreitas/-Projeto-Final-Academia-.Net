 ✍🏻 **Projeto-Final-Academia.Net**
 
 ReutiLivros - Plataforma de Compra e Venda de Livros Usados
 




📓 •**Objetivo**	

• Promover a reutilização de livros, incentivando o consumo sustentável.

•	Facilitar a compra e venda de livros usados de maneira acessível e organizada.

•	Conectar vendedores e compradores em uma interface simples e intuitiva.

**Funcionalidades Principais**

•	Listagem de livros disponiveis:  Mostra uma lista de todos os livros usados cadastrados no sistema, incluindo informações como título, autor, preço e disponibilidade.

•	Cadastro de Livros: Permite que um usuário (ou vendedor) adicione um novo livro à plataforma, preenchendo informações como título, autor,descrição, preço, estado de conservação e se o livro está disponível para venda.

•	Marcação de disponobilidade de livros: Permite que o vendedor ou administrador marque se o livro está disponível ou não para compra



**Tecnologias Utilizadas**

•	 ASP.NET Core MVC: Estrutura principal para o desenvolvimento da aplicação web.

•	 Entity Framework Core: Utilizado para manipulação de dados e integração com banco de dados.

•	 SQL Server: Banco de dados relacional para armazenamento de livros, usuários e transações.

•	 Bootstrap: Framework para estilização e criação de interfaces responsivas.


:woman_technologist: Como Rodar o Projeto**

• Clone o repositório.

• Configure o banco de dados no arquivo appsettings.json.

• Execute as migrações com o Entity Framework para criar as tabelas no banco de dados.

• Execute o projeto através do Visual Studio ou linha de comando.



Configurar o Banco de Dados
Criar o Banco de Dados

Execute o script ScriptTableDataBase.sqll no SQL Server Management Studio (SSMS) para criar o banco e tabelas.

**Popular o Banco de Dados**

Execute o script ScriptTableLivros.sql  e ScriptTableUsuarios.sql no SSMS para adicionar dados iniciais.


 **Rodar a API**

• Abra o projeto da API em uma IDE.

• Alterar a String de Conexão

• No arquivo appsettings.json, ajuste a string de conexão na seção ConnectionStrings:
"ConnectionStrings": {
    "conexao":  "server=localhost\\SQLEXPRESS01; Database=VendaLivrosBase; Integrated Security=True; TrustServerCertificate=True;"
}

**Instalar Dependências**

• No Console do Gerenciador de Pacotes, execute:
dotnet restore

**Iniciar a API**

• Pressione F5 ou clique em "Run" para iniciar a API.


**Melhorias Futuras**

• Integração da API: Consumir dados de livros disponíveis para venda diretamente no ReutiLivros.
• Login Separado: Criar páginas de login distintas para vendedores e compradores, com funções exclusivas para cada perfil.
• Tela de Livros Disponíveis: Exibir livros à venda com imagens, títulos, autores e preços em uma interface atraente.
• Carrinho de Compras: Implementar um carrinho para facilitar a adição e finalização de compras de múltiplos livros.

