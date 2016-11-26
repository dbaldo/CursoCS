using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio03
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<Pessoa>();

            list.Add(new Pessoa() { Id = 2, Nome = "Alberto", Sobrenome = "Oliveira", Idade = 18, Filhos = new[] { "Juliana", "Pedro" } });
            list.Add(new Pessoa() { Id = 1, Nome = "José", Sobrenome = "Pereira", Idade = 21, Filhos = new[] { "Ana", "Gustavo", "Henrique" } });
            list.Add(new Pessoa() { Id = 3, Nome = "Gilberto", Sobrenome = "Silva", Idade = 35, Filhos = new[] { "Lucas" } });
            list.Add(new Pessoa() { Id = 5, Nome = "Lilian", Sobrenome = "Silva", Idade = 21, Filhos = new[] { "Bia" } });
            list.Add(new Pessoa() { Id = 6, Nome = "Mariana", Sobrenome = "Silva", Idade = 35, Filhos = new[] { "Marcos", "Luan" } });
            list.Add(new Pessoa() { Id = 4, Nome = "Roberto", Sobrenome = "Ferreira", Idade = 60, Filhos = new string[] {} });

            Console.WriteLine("Pessoas entre 18 e 24 anos");
            list
                .Where(x => x.Idade >= 18 && x.Idade <= 24)
                .ToList()
                .ForEach(x => Console.WriteLine(" {0} {1} - Idade {2}", x.Nome, x.Sobrenome, x.Idade));

            Console.WriteLine("Ordenação de idade e filhos");
            list
                .OrderByDescending(x => x.Idade)
                .ThenByDescending(x => x.Filhos.Count())
                .ToList()
                .ForEach(x => Console.WriteLine(" {0} {1} - Idade {2} - Qtd Filho {3}", x.Nome, x.Sobrenome, x.Idade, x.Filhos.Count()));


        }
    }
}
