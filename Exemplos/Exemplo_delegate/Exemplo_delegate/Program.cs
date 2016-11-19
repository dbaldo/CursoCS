using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_delegate
{
    class Program
    {

        delegate T CalcularXY<T>(T x, T y);
        delegate T CalcularXYZ<T>(T x, T y, T z);

        static void Main(string[] args)
        {
            //var calculo = new Calculo();

            //var soma = new CalcularXY(calculo.Somar);
            //Console.WriteLine(" soma = {0} ", soma(10, 50));

            //var subtracao = new CalcularXY(calculo.Subtrair);
            //Console.WriteLine(" subbtracao = {0} ", subtracao(100, 50));

            //CalcularXY soma = (x, y) => x + y;
            //Console.WriteLine(" soma = {0} ", soma(10, 50));

            //CalcularXY subtracao = (x, y) => x - y;
            //Console.WriteLine(" subtracao = {0} ", subtracao(100, 50));

            //CalcularXY multiplicacao = (x, y) => x * y;
            //Console.WriteLine(" multiplicacao = {0} ", multiplicacao(100, 50));

            //CalcularXY divisao = (x, y) => x / y;
            //Console.WriteLine(" divisao  = {0} ", divisao(100, 50));

            Pessoa pessoa = new Pessoa() { Nome = "João", Sobrenome = "Silva" };

            Console.WriteLine(" exibir  = {0} ", pessoa.Exibir((p) => p.Nome + " " + p.Sobrenome));

            Console.WriteLine(" exibir  = {0} ", pessoa.Exibir((p) => p.Sobrenome + ", " + p.Nome));

            //CalcularXY<int> soma = (x, y) => x + y;
            //Console.WriteLine(" soma = {0} ", soma(10, 50));

            //CalcularXY<double> soma2 = (x, y) => x + y;
            //Console.WriteLine(" soma = {0} ", soma2(10.3340, 50.123));

            //CalcularXY<TimeSpan> soma3 = (x, y) => x + y;
            //Console.WriteLine(" soma = {0} ", soma3(TimeSpan.FromHours(1), TimeSpan.FromMinutes(30)));

            //CalcularXYZ<TimeSpan> soma4 = (x, y, z) => x + y + z;
            //Console.WriteLine(" soma = {0} ", soma4(TimeSpan.FromHours(1), TimeSpan.FromMinutes(30), TimeSpan.FromSeconds(50)));


            //Action<int> act1 = (x) => Console.WriteLine("ARRAY => {0}", x);
            //int[] array = {1,2,3,4,5,6};
            //foreach(var x in array)
            //{
            //    act1(x);
            //}

            //var l = new List<int> {1,2,3,4,5,6};
            //l.ForEach((x) => Console.WriteLine("LIST => {0}", x));


            var l = new List<int> { 1, 2, 3, 4, 5, 6, 90 };
            Comparison<int> comparacao = (x, y) => (x > y ? -1 : 1);

            l.Sort(comparacao);
            l.ForEach((x) => Console.WriteLine("LIST => {0}", x));

            Predicate<int> procurar90 = (x) => x == 90;
            Console.WriteLine(" FOUND {0} ", l.Find(procurar90));

            Console.WriteLine(" NOT FOUND {0} ", l.Find((x) => x == 233));

        }


    }
}
