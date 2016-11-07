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
        //Usando um arquivo CSV com os horários e os números dos ônibus.
        //Escreva um programa que retorna os números de ônibus dentro de
        //um determinado intervalo (horário inicial e horário final)
        static void Main(string[] args)
        {

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

            Console.Write("Digite o horário inicial :");
            var horarioIni = TimeSpan.Parse(Console.ReadLine());

            Console.Write("Digite o horário final :");
            var horarioFim = TimeSpan.Parse(Console.ReadLine());

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

            foreach(var numero in numeros)
            {
                Console.WriteLine("Linha {0} - {1} vezes", numero.Key, numero.Value);
            }

        }
    }
}
