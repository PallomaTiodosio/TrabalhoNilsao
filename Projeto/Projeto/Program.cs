using Projeto.Repositorio;
using Projeto.Repositorio.Contrato;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Adicionando a interface como serviço
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
//Adicionando a interface como serviço - tabela endereço
builder.Services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
