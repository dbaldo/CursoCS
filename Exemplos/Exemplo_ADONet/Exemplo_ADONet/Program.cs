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

            foreach (var marca in repos.ConsultarMarcas())
            {
                Console.WriteLine("{0} - {1}", marca.Id, marca.Nome);
            }

        }
    }
}
