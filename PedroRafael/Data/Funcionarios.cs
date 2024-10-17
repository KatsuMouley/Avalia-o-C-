using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedroRafael.Models; // Aqui no topo

namespace PedroRafael.Data;

public class Funcionarios
{
    public static List<Funcionario> funcionarios = new List<Funcionario>(){
        new Funcionario(1,"Victor","141.142.241-14"),
        new Funcionario(2,"jass","141.142.241-14"),
        new Funcionario(3,"Vicjoshtor","141.142.241-14")
    };
}
