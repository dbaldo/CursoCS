using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_LINQ2
{

    class Pessoa : IEquatable<Pessoa>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }

        public IEnumerable<string> Filhos { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Pessoa))
                return false;

            return Equals((Pessoa)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public bool Equals(Pessoa other)
        {
            return other.Nome == this.Nome;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<Pessoa>();
            var listEmpty = new List<Pessoa>();

            list.Add(new Pessoa() { Id = 1, Nome = "José", Sobrenome = "Pereira", Idade = 30, Filhos = new[] { "Ana", "Maria" } });
            list.Add(new Pessoa() { Id = 2, Nome = "Alberto", Sobrenome = "Oliveira", Idade = 40, Filhos = new[] { "Davi", "Antonio" } });
            list.Add(new Pessoa() { Id = 3, Nome = "Gilberto", Sobrenome = "Silva", Idade = 50, Filhos = new[] { "Cristina" } });
            list.Add(new Pessoa() { Id = 4, Nome = "Roberto", Sobrenome = "Ferreira", Idade = 60, Filhos = new[] { "Geraldo", "Paula" } });

            var list2 = new List<Pessoa>();
            list2.Add(new Pessoa() { Id = 5, Nome = "Maria", Sobrenome = "Pereira", Idade = 29, Filhos = new[] { "Ana" } });
            list2.Add(new Pessoa() { Id = 5, Nome = "Maria", Sobrenome = "ASADDASDSA", Idade = 29, Filhos = new[] { "Ana" } });
            list2.Add(new Pessoa() { Id = 5,  Nome = "Maria", Sobrenome = "REREEWRWE", Idade = 29, Filhos = new[] { "Ana" } });
            list2.Add(new Pessoa() { Id = 6, Nome = "Viviane", Sobrenome = "Silva", Idade = 27, Filhos = new[] { "Davi" } });
            list2.Add(new Pessoa() { Id = 7, Nome = "Leticia", Sobrenome = "Oliveira", Idade = 35, Filhos = new[] { "Cristina" } });


            //Console.WriteLine("Count {0}", list.Count());
            //Console.WriteLine("Max Idade {0}", list.Max(x => x.Idade));
            //Console.WriteLine("Avg Idade {0}", list.Average(x => x.Idade));

            //var pessoa = list.Aggregate((x, y) => new Pessoa() { Idade = x.Idade + y.Idade });
            //Console.WriteLine("Pessoa agregada {0}", pessoa.Idade);

            //Console.WriteLine("First {0}", list.FirstOrDefault().Nome);
            //Console.WriteLine("Last {0}", list.LastOrDefault().Nome);
            //Console.WriteLine("Terceiro {0}", list.ElementAtOrDefault(2).Nome);

            //Console.WriteLine("Single {0}", listEmpty.SingleOrDefault());
            //Console.WriteLine("Single {0}", list.Where(p => p.Filhos.Contains("Davi")).SingleOrDefault().Nome);

            //var listjoin = list.Join(
            //    list2,
            //    p1 => p1.Sobrenome,
            //    p2 => p2.Sobrenome,
            //    (p1, p2) => new { Marido = p1.Nome, Esposa = p2.Nome })
            //    .ToList();

            //listjoin.ForEach(x => Console.WriteLine("{0} {1}", x.Marido, x.Esposa));

            //Console.WriteLine("Except");
            //var list3 = new List<Pessoa>();
            //list3.Add(new Pessoa() { Id = 1, Nome = "José" });
            //list3.Add(new Pessoa() { Id = 2, Nome = "Alberto" });

            //var listexcept = list.Except(list3).ToList();
            //listexcept.ForEach(x => Console.WriteLine("- {0}", x.Nome));

            //Console.WriteLine("Union");
            //var listUnion = list.Union(list2);
            //listUnion.ToList().ForEach(x => Console.WriteLine("- {0}", x.Nome));


            //Console.WriteLine("Insert");
            //var list4 = new List<Pessoa>();
            //list4.Add(new Pessoa() { Id = 1, Nome = "José" });
            //list4.Add(new Pessoa() { Id = 2, Nome = "Alberto" });

            //var listintersect = list.Intersect(list4).ToList();
            //listintersect.ForEach(x => Console.WriteLine("- {0}", x.Nome));

            //Console.WriteLine("Distinct");
            //list2.Distinct().ToList().ForEach(x => Console.WriteLine("- {0}", x.Nome));

            //Console.WriteLine("Where Idade > 50");
            //list.Where(x => x.Idade >= 50 && x.Filhos.Count() == 1)
            //    .ToList()
            //    .ForEach(x => Console.WriteLine("- {0}", x.Nome));

            //Console.WriteLine("Where Filhos com pais idade > 50 e começando com p");
            //list.Where(x => x.Idade >= 50)
            //    .SelectMany(x => x.Filhos)
            //    .Where(x => x.StartsWith("P"))
            //    .ToList()
            //    .ForEach(x => Console.WriteLine("- {0}", x));

            //Console.WriteLine("OfType");
            //var listObj = new List<object>();
            //listObj.AddRange(list);
            //listObj.Add(10);
            //listObj.Add(30);
            //listObj.Add(40);

            //listObj.OfType<Pessoa>()
            //    .ToList()
            //    .ForEach(x => Console.WriteLine("- {0}", x.Nome));

            //listObj.OfType<int>()
            //    .ToList()
            //    .ForEach(x => Console.WriteLine("- {0}", x));

            Console.WriteLine("ToDictionary");
            var dictId = list.ToDictionary(x => x.Id);
            Console.WriteLine("Pessoa {0}", dictId[4].Nome);


            var dictNome = list.ToDictionary(x => x.Nome);
            Console.WriteLine("Pessoa {0} {1}", dictNome["Alberto"].Id, dictNome["Alberto"].Sobrenome);

            Console.WriteLine("Skip");
            list2.SkipWhile(x => x.Nome == "Maria")
                .ToList()
                .ForEach(x => Console.WriteLine("- {0}", x.Nome));

            Console.WriteLine("Take");
            list2.TakeWhile(x => x.Nome == "Maria")
                .ToList()
                .ForEach(x => Console.WriteLine("- {0}", x.Nome));

            Console.WriteLine("Any");
            Console.WriteLine(" Any = {0}", list2.Any(x => x.Filhos.Count() > 1));

            Console.WriteLine("Contains");
            Console.WriteLine(" Contains = {0}", list2.Contains(new Pessoa { Id = 6, Nome = "Viviane" }));

            Console.WriteLine("Reverse");
            var str = "abcdefghijklmnopq";
            var strInvertida = new String(str.Reverse().ToArray());
            Console.WriteLine(" - {0}", strInvertida);


            var listTodos = list.Union(list2);

            Console.WriteLine("Order by");
            listTodos.OrderBy(x => x.Sobrenome)
                .ThenBy(x => x.Nome)
                .ThenBy(x => x.Idade)
                .ToList()
                .ForEach(x => Console.WriteLine("- {0} {1}", x.Sobrenome, x.Nome));

                
            Console.WriteLine("Order by Desc");
            listTodos.OrderByDescending(x => x.Sobrenome)
                .ThenByDescending(x => x.Nome)
                .ThenByDescending(x => x.Idade)
                .ToList()
                .ForEach(x => Console.WriteLine("- {0} {1}", x.Sobrenome, x.Nome));
        } 

    }
}
