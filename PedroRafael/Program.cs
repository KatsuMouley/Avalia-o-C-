using System.Collections.Generic;
using PedroRafael.Models;
using PedroRafael.Models.DTO;
using PedroRafael.Data;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/funcionario/cadastrar", ([FromBody] FuncionarioCDTO funcionarioCDTO) =>
{
    if (String.IsNullOrEmpty(funcionarioCDTO.Nome))
    {
        return Results.BadRequest("Funcionário sem nome");
    }
    if (Funcionarios.funcionarios.FirstOrDefault(u => u.Nome.ToLower() == funcionarioCDTO.Nome.ToLower()) != null)
    {
        return Results.BadRequest("Este funcionário já existe");
    }
    Funcionario funcionario = new Funcionario(funcionarioCDTO.Nome, funcionarioCDTO.Cpf);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    funcionario.FuncionarioId = Funcionarios.funcionarios.OrderByDescending(u => u.FuncionarioId).FirstOrDefault().FuncionarioId + 1;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    Funcionarios.funcionarios.Add(funcionario);

    return Results.Ok("Funcionario Cadastrado");

});

app.MapGet("/api/funcionario/listar", () =>
{
    return Results.Ok(Funcionarios.funcionarios);
});

app.MapPost("api/folha/cadastrar",([FromBody] FolhaCDTO folhaCDTO) =>
{
    Folha folha = new Folha(folhaCDTO.valor, folhaCDTO.quantidade, folhaCDTO.mes, folhaCDTO.ano, folhaCDTO.funcionarioId);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    folha.folhaId = Folhas.folhas.OrderByDescending(u => u.folhaId).FirstOrDefault().folhaId + 1;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    Folhas.folhas.Add(folha);

    return Results.Ok("Folha cadastrada");
});

app.MapGet("api/folha/listar", (int id) =>
{
    return Results.Ok(Folhas.folhas);
});
app.MapGet("api/folha/buscar/{cpf}/{mes}/{ano}", (int id) =>
{

});


app.Run();
