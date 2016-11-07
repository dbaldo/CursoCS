using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio05
{
    class Program
    {
        static void Main(string[] args)
        {

            //Lendo o arquivo de horários
            Console.Write("Carregando a lista de ônibus...");

            var listaHorarios = new List<HorarioOnibus>();
            var numeros = new Dictionary<int, int>();

            using (var reader = File.OpenText("horarios_onibus.csv"))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var linha = reader.ReadLine();
                    if (linha != null)
                    {
                        var arrayLinha = linha.Split(',');

                        HorarioOnibus horario = new HorarioOnibus();
                        horario.Hora  = TimeSpan.Parse(arrayLinha[0]);
                        horario.NumeroLinha = int.Parse(arrayLinha[1]);

                        listaHorarios.Add(horario);
                    }
                }
            }

            Console.WriteLine("{0} linhas carregadas", listaHorarios.Count);

            //Pedindo para o usuário entrar com um intervalo
            Console.Write("Digite o horário inicial :");
            var horarioIni = TimeSpan.Parse(Console.ReadLine());

            Console.Write("Digite o horário final :");
            var horarioFim = TimeSpan.Parse(Console.ReadLine());

            //Lendo as linhas que irão passar nesse intervalo e agrupando em um dicionário
            foreach(var horario in listaHorarios)
            {
                if (horario.Hora >= horarioIni && horario.Hora < horarioFim)
                {
                    if (numeros.ContainsKey(horario.NumeroLinha))
                    {
                        numeros[horario.NumeroLinha]++;
                    }
                    else
                    {
                        numeros.Add(horario.NumeroLinha, 1);
                    }
                }
            }

            //Exibindo
            if (numeros.Count > 0)
            {
                foreach (var numero in numeros)
                {
                    Console.WriteLine("Linha {0} irá passar {1} vezes", numero.Key, numero.Value);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma linha irá passar nesse intervalo");
            }

        }
    }
}
