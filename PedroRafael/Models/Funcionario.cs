using System;

namespace PedroRafael.Models;

public class Funcionario
{
    public Funcionario(int id,string nome,string cpf){
        FuncionarioId = id;
        Nome = nome;
        Cpf = cpf;
    }
    public Funcionario(string nome,string cpf){
        Nome = nome;
        Cpf = cpf;
    }
    public int FuncionarioId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = "";
}
