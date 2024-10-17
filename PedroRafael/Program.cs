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

// Configure the HTTP request pipeline.
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
        return Results.BadRequest("Invalid Id or pessoas Name");
    }
    if (Funcionarios.funcionarios.FirstOrDefault(u => u.Nome.ToLower() == funcionarioCDTO.Nome.ToLower()) != null)
    {
        return Results.BadRequest("Esta pessoa já existe");
    }
    Funcionario funcionario = new Funcionario(funcionarioCDTO.Nome,funcionarioCDTO.Cpf);
    funcionario.FuncionarioId = Funcionarios.funcionarios.OrderByDescending(u => u.FuncionarioId).FirstOrDefault().FuncionarioId + 1;
    Funcionarios.funcionarios.Add(funcionario);

    return Results.Ok("Funcionario Cadastrado");

});

app.MapGet("/api/funcionario/listar", () =>
{
    return Results.Ok(Funcionarios.funcionarios);
});
app.MapPost("api/folha/cadastrar", ()=>{

});
app.MapGet("api/folha/listar", (int id) =>{

});
app.MapGet("api/folha/buscar/{cpf}/{mes}/{ano}", (int id)=>{

});


app.Run();
