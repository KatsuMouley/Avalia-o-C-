using System;

namespace PedroRafael.Models;

public class Folha
{

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
}
