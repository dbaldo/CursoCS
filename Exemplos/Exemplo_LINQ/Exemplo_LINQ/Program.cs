using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            //var v1 = new { Nome = "João", Sobrenome = "Da Silva", Idade = 10 };
            //var v2 = new { Nome = "Adalberto", Sobrenome = "Da Silva", Idade = 50, RG = "12312123231" };

            //Console.WriteLine("{0} {1} Idade {2}", v1.Nome, v1.Sobrenome, v1.Idade);
            //Console.WriteLine("{0} {1} Idade {2}", v2.Nome, v2.Sobrenome, v2.Idade);

            //Console.WriteLine(v1.GetType() == v2.GetType());

            DataSet ds = new DataSet();
            FillDS(ds);

            var modelos = ds.Tables["TB_MODELO"];
            var marcas = ds.Tables["TB_MARCA"];

            //IEnumerable<dynamic> query = from m in modelos.AsEnumerable()
            //                             join marca in marcas.AsEnumerable() 
            //                                on m.Field<int>("ID_MARCA") equals marca.Field<int>("ID_MARCA") into ma
            //                             from row in ma.DefaultIfEmpty()
            //                             select new { Marca = row.Field<string>("NM_MARCA"), Modelo = m.Field<string>("NM_MODELO") };

            Console.WriteLine("LINQ Expression");
            IEnumerable<DataRow> query1 = from m in modelos.AsEnumerable()
                                         select m;

            foreach (var p in query1)
            {
                Console.WriteLine(" {0}", p.Field<string>("NM_MODELO"));
            }

            Console.WriteLine("LINQ Method");
            var query2 = modelos.AsEnumerable()
                .Select(x => new { Modelo = x.Field<string>("NM_MODELO") });

            foreach (var p in query2) 
            {
                Console.WriteLine(" {0}", p.Modelo);
            }
        }

        static void FillDS(DataSet ds)
        {
            //Conectar no banco
            using (var conn = new SqlConnection( @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\denis.baldo\Source\Repos\CursoCS\Exemplos\Database\lavaDB.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                conn.Open();

                var cmdSelect1 = new SqlCommand("SELECT * FROM TB_MODELO", conn);
                var sqlAdapter1 = new SqlDataAdapter(cmdSelect1);
                sqlAdapter1.Fill(ds, "TB_MODELO");

                var cmdSelect2 = new SqlCommand("SELECT * FROM TB_MARCA", conn);
                var sqlAdapter2 = new SqlDataAdapter(cmdSelect2);
                sqlAdapter2.Fill(ds, "TB_MARCA");
            }
        }

    }
}
