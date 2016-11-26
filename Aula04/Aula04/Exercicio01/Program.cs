using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            FillDS(ds);

            var operadores = ds.Tables["TB_OPERADOR"];

            var query = operadores.AsEnumerable()
                .Select(x => new { Operador = x.Field<string>("NM_OPERADOR") });

            foreach(var r in query)
            {
                Console.WriteLine("Nome: {0}", r.Operador);
            }

            var veiculos = ds.Tables["TB_VEICULO"];

            var query2 = veiculos.AsEnumerable()
                .Select(x => new { Modelo = x.Field<string>("NM_MODELO"), Placa = x.Field<string>("NM_PLACA") });

            foreach (var r in query2)
            {
                Console.WriteLine("Modelo: {0} - Placa {1}", r.Modelo, r.Placa);
            }
        }

        static void FillDS(DataSet ds)
        {
            //Conectar no banco
            using (var conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\denis.baldo\Source\Repos\CursoCS\Exemplos\Database\lavaDB.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                conn.Open();

                var cmdSelect1 = new SqlCommand("SELECT * FROM TB_OPERADOR", conn);
                var sqlAdapter1 = new SqlDataAdapter(cmdSelect1);
                sqlAdapter1.Fill(ds, "TB_OPERADOR");

                var sql = "SELECT V.*, M.*  FROM TB_VEICULO V ";
                sql += " INNER JOIN TB_MODELO M ON V.ID_MODELO = M.ID_MODELO ";

                var cmdSelect2 = new SqlCommand(sql, conn);
                var sqlAdapter2 = new SqlDataAdapter(cmdSelect2);
                sqlAdapter2.Fill(ds, "TB_VEICULO");
            }
        }
    }
}
