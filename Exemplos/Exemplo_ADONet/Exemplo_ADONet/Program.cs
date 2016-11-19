using Dominio;
using Exemplo_ADONet.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_ADONet
{
    class Program
    {

        static void Main(string[] args)
        {
            //Inserindo marcas
            var repos = new RepositorioMarca();

            //repos.InserirMarca(new Marca() { Nome = "VOLKSWAGEM" });
            //repos.InserirMarca(new Marca() { Nome = "CHEVROLET" });
            //repos.InserirMarca(new Marca() { Nome = "FIAT" });
            //repos.InserirMarca(new Marca() { Nome = "HONDA" });


            //var ds = repos.ConsultarMarcaDataSet();

            //foreach(DataRow row in ds.Tables[0].Rows)
            //{
            //    Console.WriteLine("{0} - {1}", row["ID_MARCA"], row["NM_MARCA"]);
            //}

            //foreach (var marca in repos.ConsultarMarcas())
            //{
            //    Console.WriteLine("{0} - {1}", marca.Id, marca.Nome);
            //}

            MenuOperador();

        }

        private static void MenuOperador()
        {
            while (true)
            {
                ExibirOperadores();

                Console.WriteLine("Digite o id do operador para alterar ou N para criar um novo");
                Console.WriteLine("ESC para Sair");
                Console.WriteLine();

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if(key.Key == ConsoleKey.N)
                {
                    MenuInserirOperador();
                }
                else
                {
                    MenuAlterarOperador(key.KeyChar);
                }
            }

        }

        private static void ExibirOperadores()
        {
            Console.Clear();
            var repos = new RepositorioOperador();
            foreach (var op in repos.ConsultarOperadores())
            {
                Console.WriteLine("ID {0} - NOME {1} - LOGIN {2}", op.Id, op.Nome, op.Login);
            }
        }

        private static void MenuAlterarOperador(char charId)
        {
            var id = Convert.ToInt32(charId.ToString());

            var repos = new RepositorioOperador();

            Console.WriteLine("===ALTERANDO===");

            Console.WriteLine("ID = {0}", id);
            Console.Write("Digite o nome ");
            string nome = Console.ReadLine();
            Console.Write("Digite o login ");
            string login = Console.ReadLine();

            repos.AlterarOperador(new Operador() { Id = id, Nome = nome, Login = login });

        }

        private static void MenuInserirOperador()
        {
            var repos = new RepositorioOperador();

            Console.WriteLine("===INSERINDO===");

            Console.Write("Digite o nome ");
            string nome = Console.ReadLine();
            Console.Write("Digite o login ");
            string login = Console.ReadLine();

            repos.InserirOperador(new Operador() { Nome = nome, Login = login });
        }


    }
}
