using Microsoft.EntityFrameworkCore;
using VendaLivros.Data;
using VendaLivros.Services.LoginService;
using VendaLivros.Services.SenhaService;
using VendaLivros.Services.SessaoService;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container (como o DbContext e outros)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona o suporte para controladores com views
builder.Services.AddControllersWithViews();

// Adiciona suporte ao HttpClient
builder.Services.AddHttpClient();


//// Registrando o serviço HttpClient para chamadas externas
builder.Services.AddHttpClient<LivroApiService>();



// Registrando serviços customizados
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ILoginInterface, LoginService>();
builder.Services.AddScoped<ISenhaInterface, SenhaService>();
builder.Services.AddScoped<ISessaoInterface, SessaoService>();

// Configuração de sessão
builder.Services.AddSession(options => {
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configuração de autenticação
builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", options => {
        options.Cookie.Name = "UserLoginCookie";
        options.LoginPath = "/Login";
    });

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
} else {
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Usar autenticação e sessões
app.UseAuthentication();
app.UseSession();
app.UseAuthorization();

// Configuração de rotas padrão para MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configura as rotas da API
app.MapControllers();

app.Run();
