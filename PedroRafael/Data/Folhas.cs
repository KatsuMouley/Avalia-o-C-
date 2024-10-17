using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedroRafael.Models; // Aqui no topo

namespace PedroRafael.Data;

public class Folhas
{
    public static List<Folha> folhas = new List<Folha>(){
        new Folha(50, 1000, 10, 2023, 1 ),
        new Folha(70, 1999, 10, 2023, 2 ),
        new Folha(60, 99, 10, 2023, 3 )
    };
}
