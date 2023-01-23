using MangaI.Data;
using MangaI.Repositorios;
using MangaI.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DisciplinaServico>();
builder.Services.AddScoped<DisciplinaRepositorio>();

builder.Services.AddScoped<EnderecoServico>();
builder.Services.AddScoped<EnderecoRepositorio>();

builder.Services.AddScoped<ConteudoServico>();
builder.Services.AddScoped<ConteudoRepositorio>();

builder.Services.AddScoped<PerfilServico>();
builder.Services.AddScoped<PerfilRepositorio>();

builder.Services.AddScoped<CursoServico>();
builder.Services.AddScoped<CursoRepositorio>();

builder.Services.AddScoped<MatrizServico>();
builder.Services.AddScoped<MatrizRepositorio>();

builder.Services.AddScoped<TelefoneServico>();
builder.Services.AddScoped<TelefoneRepositorio>();

builder.Services.AddScoped<AvaliacaoServico>();
builder.Services.AddScoped<AvaliacaoRepositorio>();

builder.Services.AddScoped<TurmaServico>();
builder.Services.AddScoped<TurmaRepositorio>();

builder.Services.AddScoped<UsuarioServico>();
builder.Services.AddScoped<UsuarioRepositorio>();

builder.Services.AddScoped<FrequenciaServico>();
builder.Services.AddScoped<FrequenciaRepositorio>();

builder.Services.AddScoped<MatriculaPorTurmaServico>();
builder.Services.AddScoped<MatriculaPorTurmaRepositorio>();

builder.Services.AddScoped<MatriculaServico>();
builder.Services.AddScoped<MatriculaRepositorio>();

builder.Services.AddScoped<NotaAlunoServico>();
builder.Services.AddScoped<NotaAlunoRepositorio>();

builder.Services.AddScoped<AutenticacaoServico>();



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

//Configurações para usar Autenticação com JWT
var JWTChave = Encoding.ASCII.GetBytes(builder.Configuration["JWTChave"]);
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.SaveToken = true;
      options.TokenValidationParameters = new TokenValidationParameters
      {
        IssuerSigningKey = new SymmetricSecurityKey(JWTChave),
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
      };
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
