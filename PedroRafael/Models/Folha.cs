using System;

namespace PedroRafael.Models;

public class Folha
{
    
    public int folhaId { get; set; }
    public double valor { get; set; }
    public int quantidade { get; set; }
    public int mes { get; set; }
    public int ano { get; set; }
    public int funcionarioId { get; set; }
    public double salarioBruto{ get; set; }
    public double impostoIrrf { get; set; }
    public double impostoInss { get; set; }
    public double impostoFgts { get; set; }
    public double salarioLiquido{ get; set; }
    public Folha(int folhaId, double valor, int quantidade, int mes, int ano, int funcionarioId){
        this.folhaId = folhaId;
        this.valor = valor;
        this.quantidade = quantidade;
        this.mes = mes;
        this.ano = ano;
        this.funcionarioId=funcionarioId;
    }    public Folha(double valor, int quantidade, int mes, int ano, int funcionarioId){
        this.valor = valor;
        this.quantidade = quantidade;
        this.mes = mes;
        this.ano = ano;
        this.funcionarioId=funcionarioId;
    }
}
