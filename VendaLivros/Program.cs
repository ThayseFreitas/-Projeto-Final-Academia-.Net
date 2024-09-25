using Microsoft.EntityFrameworkCore;
using VendaLivros.Data;
using VendaLivros.Services.LoginService;
using VendaLivros.Services.SenhaService;
using VendaLivros.Services.SessaoService;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao container (como o DbContext e outros)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona o suporte para controladores com views
builder.Services.AddControllersWithViews();

// Adiciona suporte ao HttpClient
builder.Services.AddHttpClient();


//// Registrando o servi�o HttpClient para chamadas externas
builder.Services.AddHttpClient<LivroApiService>();



// Registrando servi�os customizados
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ILoginInterface, LoginService>();
builder.Services.AddScoped<ISenhaInterface, SenhaService>();
builder.Services.AddScoped<ISessaoInterface, SessaoService>();

// Configura��o de sess�o
builder.Services.AddSession(options => {
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configura��o de autentica��o
builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", options => {
        options.Cookie.Name = "UserLoginCookie";
        options.LoginPath = "/Login";
    });

var app = builder.Build();

// Configura��o do pipeline de requisi��o HTTP
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
} else {
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Usar autentica��o e sess�es
app.UseAuthentication();
app.UseSession();
app.UseAuthorization();

// Configura��o de rotas padr�o para MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configura as rotas da API
app.MapControllers();

app.Run();
