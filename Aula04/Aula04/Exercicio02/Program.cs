using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio02
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<Pessoa>();

            list.Add(new Pessoa() { Id = 1, Nome = "José", Sobrenome = "Pereira", Idade = 30 });
            list.Add(new Pessoa() { Id = 2, Nome = "Alberto", Sobrenome = "Oliveira", Idade = 40 });
            list.Add(new Pessoa() { Id = 3, Nome = "Gilberto", Sobrenome = "Silva", Idade = 50 });
            list.Add(new Pessoa() { Id = 4, Nome = "Roberto", Sobrenome = "Ferreira", Idade = 60 });

            foreach(var item in list.Where(p => p.Nome.CompareTo(p.Sobrenome) == 1))
            {
                Console.WriteLine("- Pessoa Id {0} Nome {1}", item.Id, item.Nome, item.Sobrenome);
            }


        }
    }
}
