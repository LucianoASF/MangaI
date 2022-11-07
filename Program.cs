using MangaI.Data;
using MangaI.Repositorios;
using MangaI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DisciplinaServico>();
builder.Services.AddScoped<DisciplinaRepositorio>();
builder.Services.AddScoped<EnderecoServico>();
builder.Services.AddScoped<EnderecoRepositorio>();
builder.Services.AddScoped<ConteudoServico>();
builder.Services.AddScoped<ConteudoRepositorio>();

//Adicionando a minha classe de contexto na API
//Tem que acrescentar using Microsoft.EntityFrameworkCore;
//using using IFBeaty.Data;
builder.Services.AddDbContext<ContextoBD>(
  options =>
  //Dizendo que vamos usar o MySQL
  options.UseMySql(
      //Pegando as configurações de acesso ao BD
      builder.Configuration.GetConnectionString("ConexaoBanco"),
      //Detectando o Servidor de BD
      ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoBanco"))
  )
);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
